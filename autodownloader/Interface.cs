using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace autodownloader
{
    public partial class Interface : Form
    {
        // Variable con los ajustes cargados de la DB
        Settings loadedSettings;
        // Hebra que va a controlar la ejecucion de las descargas
        System.Threading.Thread threadDownloadRoute;
        // Hebra que va a controlar la ejecucion de los recorridos
        System.Threading.Thread threadPersonalisedRoute;
        // Hebra que va a comprobar cuanto queda hasta la hora que hemos seleccionado
        System.Threading.Thread threadScheludedTime;
        // Estas variables sirven para detener a las hebras encargadas de las acciones
        public volatile static bool haveToStop = false;
        public volatile static bool haveToForcedStop = false;
        private ThreadManager threadManagerInstance = new ThreadManager();

        /*
        // el constructor por defecto, acabara desapareciendo
        public Interface()
        {
            InitializeComponent();
        }
        */

        /*
         * Constructor con sobrecarga que recibe los ajustes de la DB, los guarda en una variable,
         * y los carga en la vista.
         */
        public Interface(Settings dbSettings)
        {
            InitializeComponent();
            loadedSettings = dbSettings;
            SetComboBox();
            threadManagerInstance.SetViewInstance(this);
        }

        /*
         * Lo primero que carga la interfaz.
         */
        private void Interface_Load(object sender, EventArgs e)
        {
            MostrarFeedback(" ¡¡¡ WELCOME !!! " + Environment.NewLine);
        }

        /*
         * Reacciona al evento que surge cuando se cierra la vista.
         * Me aseguro que antes de salir, de haber hebras, las cierre 
         * mediante 'ForcedStop()'.
         */
        private void Interface_FormClosing(object sender, FormClosingEventArgs e)
        {
            ForcedStop();
            MostrarFeedback(" Cerrando el programa.");
        }


        /*
-----------------------------COMIENZAN LOS BOTONES----------------------------------- 
         */

        /*
         * Antes de lanzar la hebra, comprueba si todas las variables son correctas,
         * de serlo, realiza la llamada. 
         */
        private void button_startDownloadRoute_Click(object sender, EventArgs e)
        {
            ViewChangeToRouteInProgress();
            OpenDownloadOptions();
        }

        /*
         * Este boton llama a la funcion 'Stop()'. 
         * La cual se encarga de cerrar la hebra de descargas de manera segura.
         * Ofrece 2 modos de cierre: 'SafeStop' y 'ForcedStop';
         */
        private void button_stop_Click(object sender, EventArgs e)
        {
            Stop();
            threadManagerInstance.SetStopThread(true);
        }

        /*      !!! que compruebe que el nombre no exista !!!
         *  Comprueba antes de lanzar la creacion de una nueva ruta que se 
         *  haya introducido un nombre
         */
        private void button_addPersonalisedRoute_Click_1(object sender, EventArgs e)
        {
            if (textBoxNewPersonalisedRouteName.Text == "Sin nombre")
            {
                MostrarFeedback(" Elije un nombre para poder continuar.");
            }
            else
            {
                SetNewPersonalisedRoute();
            }
        }

        /*
         * Llama al modulo 'PrintRoutes()', y este imprime todas las rutas que esten cargadas 
         * en los ajustes
         */
        private void button_showAllRoutes_Click_1(object sender, EventArgs e)
        {
            PrintRoutes();
        }

        /*
         * Se encarga de realizar los cambios necesarios antes lanzar la hebra
         * encargada de las rutas personalizadas
         */
        private void button_startPersonalised_Click(object sender, EventArgs e)
        {
            // Compruebo que la hebra no exista
            if (AreAnyThreadRunning())
            {
                MostrarFeedback(" Ya se estan realizando otras acciones en este momento." + Environment.NewLine);
            }
            else
            {
                ViewChangeToRouteInProgress();
                // Obtengo la id de la ruta a ejecutar
                string action = comboBoxPersonalisedRoutes.Text;
                string actionId = action[0] + "";
                // Creo y lanzo la hebra encargada de las rutas personalizadas
                threadPersonalisedRoute = new System.Threading.Thread(() => StartPersonalisedRouteThread(actionId));
                threadPersonalisedRoute.Start();
                MostrarFeedback(" Se procede a ejecutar la ruta personalizada." + Environment.NewLine);
            }
        }


        /*
-----------------------------TERMINAN LOS BOTONES----------------------------------- 

-----------------------------COMIENZAN LOS MODULOS DE GESTION DE LA VISTA ----------------------------------- 
        */

        /*
         * Se encarga de hacer las modificaciones necesarias en la vista para mostrar al
         * usuario que se estan realizando recorridos.
         */
        public void ViewChangeToRouteInProgress()
        {
            button_startDownloadRoute.Enabled = false;
            button_startPersonalised.Enabled = false;
            haveToStop = false;
            haveToForcedStop = false;
        }

        /*
         * Se encarga de hacer las modificaciones necesarias en la vista para mostrar al
         * usuario que se pueden realizar acciones.
         */
        public void ViewChangeToNothingRunning()
        {
            if (this.button_startPersonalised.InvokeRequired)
            {
                BeginInvoke(new Action(() => button_startDownloadRoute.Enabled = true));
                BeginInvoke(new Action(() => button_startPersonalised.Enabled = true));
                BeginInvoke(new Action(() => haveToStop = false));
                BeginInvoke(new Action(() => haveToForcedStop = false));
            }
            else
            {
                haveToStop = false;
                haveToForcedStop = false;
                button_startDownloadRoute.Enabled = true;
                button_startPersonalised.Enabled = true;
            }

        }

        /*
         * Este modulo se encarga de recibir todos los mensages dirigidos al textbox
         * desde todas las hebras, gestionando su adecuado funcionamiento.
         */
        public void MostrarFeedback(string text)
        {
            // InvokeRequired required compares the thread ID of the  
            // calling thread to the thread ID of the creating thread.  
            // If these threads are different, it returns true.  
            if (this.textBox_displayData.InvokeRequired)
            {
                BeginInvoke(new Action(() => textBox_displayData.AppendText(DateTime.Now.ToShortTimeString() + "  --  " + text + Environment.NewLine)));
            }
            else
            {
                //ObjectDisposedException
                this.textBox_displayData.AppendText(DateTime.Now.ToShortTimeString() + "  -  " + text + Environment.NewLine);
            }
        }

        /*
         * Inicializa el 'comboBoxPersonalisedRoutes' con los nombres de los recorridos
         * que se encuentran cargados actualmente (no en la DB)
         */
        private void SetComboBox()
        {
            for (int i = 0; i < loadedSettings.personalisedRoutes.Count; i++)
            {
                comboBoxPersonalisedRoutes.Items.Add(i + ". " + loadedSettings.personalisedRoutes[i].name);
            }
        }

        /*
         * Modulo que devuelve el estado de 'haveToStop'.
         * Las hebras llamaran a esta funcion para saber si deben detenerse o no.
         */
        public bool HaveToStopState()
        {
            if (!haveToStop)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /*
         * Modulo que devuelve el estado de 'haveToForcedStop'.
         * Las hebras llamaran a esta funcion para saber si deben detenerse o no.
         */
        public bool HaveToForcedStopState()
        {
            if (!haveToForcedStop)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /*
         * Modulo que muestra una cuenta atras por pantalla, es utilizado en la captura 
         * y muestra, de las coordenadas del raton.
         * Tras el 3, la pantalla se minimiza, y tras mostrar las coordenadas vuelve a 
         * aparecer.
         */
        public void CountDown()
        {
            MostrarFeedback("Capturando posicion del raton en:");
            MostrarFeedback(" \t 3... ");
            System.Threading.Thread.Sleep(1000);
            this.WindowState = FormWindowState.Minimized;
            MostrarFeedback(" \t 2... ");
            System.Threading.Thread.Sleep(1000);
            MostrarFeedback(" \t 1... ");
            System.Threading.Thread.Sleep(1000);
            this.WindowState = FormWindowState.Normal;
        }

        /*
         * Devuelve un 'bool' en funcion del estado de las hebras.
         * Si hay alguna ejecutandose (true), si no hay (false)
         */
        public bool AreAnyThreadRunning()
        {
            bool areRunning;
            if (threadDownloadRoute == null && threadPersonalisedRoute == null & threadScheludedTime == null)
            {
                areRunning = false;
            }
            else
            {
                areRunning = true;
            }
            return areRunning;
        }

        /*
-----------------------------TERMINAN LOS MODULOS DE GESTION DE LA VISTA -----------------------------------  
         
-----------------------------COMIENZAN LOS MODULOS DE LAS FUNCIONALIDADES----------------------------------- 
         */

        /*  
         *  Mediante un 'MessageBox' ofrece 2 modos de cierre: 
         *      - SafeStop: Esperar hasta que termine la accion actual antes de salir.
         *      - ForcedStop: Cierra la hebra lo antes posible.
         * Los cierres se basan en el uso de 'bools' para comunicarle a la otra hebra 
         * que debe cerrarse.
         * Modifico el boton de start a 'Enabled = true' tras la detencion.
         */
        private void Stop()
        {
            // Compruebo que las hebras no existan
            if (AreAnyThreadRunning())
            {
                // pregunto si se desea realizar un cierre seguro o uno rapido 
                DialogResult MessageBoxValueSelected = MessageBox.Show("¿Desea esperar hasta que termine la descarga actual para cerrar la ejecucion?", "¿Antes de continuar?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (MessageBoxValueSelected == System.Windows.Forms.DialogResult.Yes)
                {
                    // Cierre seguro                    
                    SafeStop();
                }
                else if (MessageBoxValueSelected == System.Windows.Forms.DialogResult.No)
                {
                    // Cierre forzado
                    ForcedStop();
                }
                else
                {
                    MostrarFeedback(" Stop cancelado." + Environment.NewLine);
                }
            }
            else
            {
                MostrarFeedback(" No hay acciones ejecutandose." + Environment.NewLine);
            }
        }

        /*  
         * Cierra las hebras que esten ejecutando acciones lo antes posible.
         * Este modulo modifica 'haveToForcedStop' a true; Cuando la hebra encargada de
         * las acciones lo vea, se detendra.
         * Este stop puede interrumpir acciones.
         */
        public void ForcedStop()
        {
            haveToForcedStop = true;
            System.Threading.Thread.Sleep(500);
            MostrarFeedback(" Se ha forzado el cierre del proceso." + Environment.NewLine
                     + "      Esta accion puede tardar unos segundos." + Environment.NewLine);
        }

        /*  
         * Cierra la hebra de las descargas tras terminar la descarga actual.
         * Este modulo modifica 'haveToStop' a true; Cuando la hebra encargada de
         * las descargas lo vea, sabra que debe detenerse tras la descarga que 
         * este realizando. 
         * Lanza una hebra que espera hasta que la descarga termine.
         */
        public void SafeStop()
        {
            haveToStop = true;
            MostrarFeedback(" El proceso se cerrara en cuanto termine la descarga actual.");
            MostrarFeedback(" No podra realizar una nueva descarga hasta que termine." + Environment.NewLine);
            Thread checker = new System.Threading.Thread(() => checkThreadStop());
            checker.Start();
        }

        /*  
         * Modulo que imprime todos los recorridos almacenados en 'loadedSettings'
         */
        private void PrintRoutes()
        {
            // Compruebo si la lista esta vacia, de estarlo imprime un error.
            if (loadedSettings.personalisedRoutes.Count == 0)
            {
                MostrarFeedback(" No se ha establecido ninguna ruta." + Environment.NewLine);
            }
            // Como no esta vacio lo imprimo
            else
            {
                MostrarFeedback(" Inicio de las Rutas:");
                for (int i = 0; i < loadedSettings.personalisedRoutes.Count; i++)
                {
                    MostrarFeedback(Environment.NewLine + "\t Ruta Personalizada nº: " + i + ".\t Nombre: \t" + loadedSettings.personalisedRoutes[i].name);
                    for (int y = 0; y < loadedSettings.personalisedRoutes[i].route.Count; y++)
                    {
                        // Cuando las coordenadas son 0, es porque no han sido modificadas y se ha 
                        // introducido texto.
                        if (loadedSettings.personalisedRoutes[i].route[y].actionType == 1)
                        {
                            MostrarFeedback("\t Paso " + y + ".\t Coordenadas:\t X=" + loadedSettings.personalisedRoutes[i].route[y].mousePosition.X + "\t Y=" + loadedSettings.personalisedRoutes[i].route[y].mousePosition.Y);
                        }
                        // Si no es texto, entonces son coordenadas.
                        else if (loadedSettings.personalisedRoutes[i].route[y].actionType == 2)
                        {
                            MostrarFeedback("\t Paso " + y + ".\t Introducir texto: \t" + loadedSettings.personalisedRoutes[i].route[y].texto);
                        }
                        else if (loadedSettings.personalisedRoutes[i].route[y].actionType == 3)
                        {
                            MostrarFeedback("\t Paso " + y + ".\t Espera: \t" + loadedSettings.personalisedRoutes[i].route[y].waitTime + " segundos.");
                        }
                        else if (loadedSettings.personalisedRoutes[i].route[y].actionType == 4)
                        {
                            MostrarFeedback("\t Paso " + y + ".\t Ruta Personalizada, id: \t" + loadedSettings.personalisedRoutes[i].route[y].personalisedRouteId
                                + ", nombre: " + loadedSettings.personalisedRoutes[loadedSettings.personalisedRoutes[i].route[y].personalisedRouteId].name);
                        }
                    }
                }
                MostrarFeedback(Environment.NewLine + " Fin de la Ruta." + Environment.NewLine);
            }
        }

        /*
         * Gestiona el proceso de creado de un nuevo recorrido
         */
        private void SetNewPersonalisedRoute()
        {
            PersonalisedRoute auxPersonalicedRoute = new PersonalisedRoute();
            List<PersonalisedAction> auxPersonalisedActionList = new List<PersonalisedAction>();
            auxPersonalisedActionList = DealWithPersonalisedRoutes.CreateNewPersonalisedRoute(loadedSettings, this);
            if (auxPersonalisedActionList == null)
            {
                MostrarFeedback(" Se ha cancelado la creacion de una ruta personalizada ");
            }
            else
            {
                // Guardo el 'List'            
                auxPersonalicedRoute.route = auxPersonalisedActionList;
                auxPersonalicedRoute.name = textBoxNewPersonalisedRouteName.Text;
                // Compruebo que no este vacio
                if (auxPersonalisedActionList.Count > 0)
                {
                    loadedSettings.personalisedRoutes.Add(auxPersonalicedRoute);
                    comboBoxPersonalisedRoutes.Items.Clear();
                    SetComboBox();
                    // Lo imprimo por pantalla para confirmacion visual
                    PrintRoutes();
                }
                else
                {
                    MostrarFeedback(" No se ha añadido ninguna accion");
                }
            }
        }

        /*
-----------------------------TERMINAN LOS MODULOS DE LAS FUNCIONALIDADES -----------------------------------  

-----------------------------COMIENZAN LOS MODULOS DE LOS THREADS----------------------------------- 
        */

        /*
         * Hebra que espera hasta que termine el thread de las descargas.
         * Cuando termina la descarga modifica el boton de start a 'Enabled = true'.
         */
        public void checkThreadStop()
        {
            do
            {
            } while (AreAnyThreadRunning());
            ViewChangeToNothingRunning();
            MostrarFeedback(" Puedes volver a realizar acciones.");
        }

        /*
         * Sabiendo que todo esta correcto, este modulo lanza una nueva hebra que va a ejecutar
         * la descarga con los argumentos que le pasamos.
         * Para evitar problemas, modifica en el boton start 'Enabled = false'.
         */
        private void OpenDownloadOptions()
        {
            if (AreAnyThreadRunning())
            {
                MostrarFeedback(" Ya se estan realizando las descargas en este momento." + Environment.NewLine);
            }
            else
            {
                MostrarFeedback(" Se abren las opciones para los links." + Environment.NewLine);
                Application.EnableVisualStyles();
                // Muestro un 'MessageBox' con las opciones de la descarga
                LauncherLinksOpctions messageBoxGetClick = new LauncherLinksOpctions(loadedSettings, this);
                DialogResult messageBoxResult = messageBoxGetClick.ShowDialog();
                if (messageBoxResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    MostrarFeedback(" Se ha cancelado la descarga." + Environment.NewLine);
                    ViewChangeToNothingRunning();
                }
                else
                {
                    MostrarFeedback(" Se procede a la descarga." + Environment.NewLine);
                    // Recargo las opciones por si se han modificado
                    loadedSettings = DealWithDB.LoadDBSettings();
                    // Creo y lanzo la hebra encargada de las descargas
                    threadDownloadRoute = new System.Threading.Thread(() => startDownload());
                    threadDownloadRoute.Start();
                }
            }            
        }
        
        /*    
         * Este modulo es un delegado para la hebra encargada de ejecutar la descarga de archivos.
         * Cuando esta hebra termine, la iguala a 'null' y modifica 'button_startDownloadRoute.Enabled = true'
         */
       public void startDownload()
       {
           // le envio como argumentos todos los ajustes realizados en la vista, y la propia vista,
           // para que pueda acceder a 'MostrarFeedback()'
           DealWithDownloads.StartDownloadLinks(loadedSettings, this);
           // cuando se cierra la aplicacion de golpe y termina la otra hebra, intenta ejecutar 
           // este codigo y salta la excepcion
           try
           {
                ViewChangeToNothingRunning();
                MostrarFeedback("Hebra Descargas: Todas las descargas han finalizado." + Environment.NewLine);
           }
           catch (Exception InvalidOperationException)
           {
                MostrarFeedback("Hebra Descargas: Se ha producido el error: InvalidOperationException.." + Environment.NewLine);
           }
            // Cuando haya terminado todo, cierro la hebra
            threadDownloadRoute = null;
        }
        
        /*
         * Hebra que lanza la ejecucion del recorrido indicado, y al terminar modifica la vista
         */
        private void StartPersonalisedRouteThread(string actionId)
        {
            DealWithPersonalisedRoutes.StartPersonalised(loadedSettings.personalisedRoutes, actionId, this);

            // cuando se cierra la aplicacion de golpe y termina la otra hebra, intenta ejecutar 
            // este codigo y salta la excepcion
            try
            {
                ViewChangeToNothingRunning();
                MostrarFeedback("Todas las acciones han finalizado." + Environment.NewLine);
            }
            catch (Exception InvalidOperationException)
            {
                MostrarFeedback("Se ha lanzado el error: InvalidOperationException" + Environment.NewLine);
            }
            // Cuando haya terminado todo cierro la hebra
            threadPersonalisedRoute = null;
        }

        /*  IN PROGRESS
         * 
         */
        public void PopulateTreeView(XmlDocument xml)
        {
            xmlTreeView.Nodes.Clear();
            AddTreeNodes(xml, xmlTreeView);
            xmlTreeView.ExpandAll();
        }

        /*
         * IN PROGRESS
         */
        private void AddTreeNodes(XmlDocument xml, TreeView treeView)
        {
            XmlNodeList xmlChilds = xml.DocumentElement.ChildNodes;
            // Recorre los primeros nodos, que corresponden a los settings 
            for (int i = 0; i < xmlChilds.Count -1; i++)
            {
                XmlNode settingNode = xmlChilds[i];
                TreeNode settingTreeNode = new TreeNode(settingNode.LocalName);
                // Guardo el nombre del nodo
                settingTreeNode.Tag = settingNode.LocalName;
                // Guardo el valor del nodo
                settingTreeNode.Name = settingNode.ChildNodes[0].InnerText;
                treeView.Nodes.Add(settingTreeNode);
            }
            // El ultimo hijo son las rutas personalizadas, guardamos su posicion y empezamos con sus hijos
            int personalisedRoutesListNodePosition = xmlChilds.Count - 1;
            XmlNodeList personalisedRoutesNodes = xmlChilds[personalisedRoutesListNodePosition].ChildNodes;
            // Incrementa por cada iteracion, indica la posicion del nodo al que añadir los nodos hijos
            int positionOfCurrentNode = xmlChilds.Count - 1;
            foreach (XmlNode route in personalisedRoutesNodes)
            {
                // Comprueba que el nodo sea correcto (pj:no un atributo)
                if (route.NodeType == XmlNodeType.Element)
                {
                    XmlElement routeNode = (XmlElement)route;
                    TreeNode routeTreeNode = new TreeNode(routeNode["name"].InnerText);
                    routeTreeNode.Tag = routeNode.ChildNodes[0].LocalName;
                    routeTreeNode.Name = routeNode.ChildNodes[0].InnerText;
                    // añado el primer hijo de 'personalisedRoutes' ('name')
                    treeView.Nodes.Add(routeTreeNode);
                    // el siguiente nodo es 'personalisedActionsList', asi que iteramos sus hijos
                    XmlNodeList personalisedActionsListNode = routeNode["personalisedActionsList"].ChildNodes;
                    foreach (XmlNode personalisedAction in personalisedActionsListNode)
                    {
                        XmlElement personalisedActionNode = (XmlElement)personalisedAction;

                        //XmlElement actionChild = (XmlElement)personalisedActionNode;
                        //TreeNode child = new TreeNode(actionChild["ActionType"].InnerText);

                        // el nombre que aparecera en el 'TreeNode' sera el del ultimo hijo de la accion: su tipo
                        TreeNode personalisedActionTreeNode = new TreeNode(personalisedActionNode.LastChild.LocalName);

                        //XmlNode tempXMLNode = personalisedActionNode.Attributes.GetNamedItem("actionId");
                        ///////personalisedActionTreeNode.Tag = personalisedActionNode.LocalName;
                        personalisedActionTreeNode.Tag = personalisedActionNode.LocalName;
                        // añado su atributo en lugar del valor
                        personalisedActionTreeNode.Name = personalisedActionNode.Attributes.GetNamedItem("actionId").Value;

                        //child.Name = tempXMLNode2.OuterXml;
                        //treeView.Nodes.Add(child);

                        // Lo añado indicando la posicion del nodo, para que se guarde como un nodo hijo de esa posicion
                        treeView.Nodes[positionOfCurrentNode].Nodes.Add(personalisedActionTreeNode);                        
                    }
                    positionOfCurrentNode++;
                    Console.WriteLine("Posicion nodo: " + positionOfCurrentNode);
                }
            }
        }

        /*  IN PROGRESS
         * 
         */
        private void xmlTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string sampleTag, sampleName;
            sampleTag = (string)e.Node.Tag;
            sampleName = (string)e.Node.Name;
            if (sampleTag != null)
            {
                MostrarFeedback("Tag: \t" + sampleTag);

                if (sampleName != "noName")
                {
                    MostrarFeedback("Value: \t" + sampleName + Environment.NewLine);
                }
                else
                {
                    MostrarFeedback(Environment.NewLine);
                }
            }

            if (sampleTag == "topLevelFolderDefaultPath" || sampleTag == "linksFileDefaultPath"
                || sampleTag == "iterationNumber" || sampleTag == "iterateActionId")
            {
                button_updateDB.Enabled = false;
                button_deleteDB.Enabled = false;
            }
            else if (sampleTag == "name" || sampleTag == "personalisedAction")
            {
                button_updateDB.Enabled = true;
                button_deleteDB.Enabled = true;
            }
        }

        /*
         * 
         */
        private void button_loadDB_Click_2(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(DealWithDB.GetDBPath());
            PopulateTreeView(doc);
        }

        /*
         * 
         */
        private void button_updateDB_Click_2(object sender, EventArgs e)
        {

            if (textBoxDBModifyValue.Text == "New value" || textBoxDBModifyValue.Text == "")
            {
                MostrarFeedback(" Elije un valor para poder continuar.");                
            }
            else
            {
                string NodeName = xmlTreeView.SelectedNode.Tag.ToString();
                string nodeValue = xmlTreeView.SelectedNode.Name;
                string newValue = textBoxDBModifyValue.Text;

                Console.WriteLine("Valores: " + NodeName + " - " + nodeValue);

                if (NodeName == "personalisedAction")
                {
                    UpdateAction(nodeValue, newValue);
                    MostrarFeedback(" Modificado con exito.");
                }
                else if (NodeName == "name")
                {
                    UpdateRoute(nodeValue, newValue);
                    MostrarFeedback(" Modificado con exito.");
                }
                else
                {
                    Console.WriteLine("Aqui no se puede modificar esta opcion ");
                }
            }
        }

        /*  IN DEVELOPMENT
         *  ya he conseguido que funcione, ahora necesito una nueva interfaz
         *  para introducir los valores
         */
        public static void UpdateAction(string nodeIdentifier, string newValue)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(DealWithDB.GetDBPath());

            // Encuentra el nodo con la id
            XmlNodeList nodesWithActionId = xml.SelectNodes("Settings/personalisedRoutesList/personalisedRoutes/" +
                "personalisedActionsList/personalisedAction [@actionId='" + nodeIdentifier + "']");
            foreach (XmlNode searchedNode in nodesWithActionId)
            {
                // Es un point
                if (searchedNode.FirstChild.InnerText == "1")
                {
                    foreach (XmlNode xnc in searchedNode.ChildNodes[1])
                    {
                        Console.WriteLine("A modificar: " + xnc.InnerText);
                        // para obtener el nuevo point debe invocar el modulo de la creacion de rutas
                    }
                }
                // Es un text
                if (searchedNode.FirstChild.InnerText == "2")
                {
                    Console.WriteLine("A modificar: " + searchedNode.LastChild.InnerText);
                    searchedNode.LastChild.InnerText = newValue;
                }
                // Es un wait
                if (searchedNode.FirstChild.InnerText == "3")
                {
                    Console.WriteLine("A modificar: " + searchedNode.LastChild.InnerText);
                    searchedNode.LastChild.InnerText = newValue;
                }
            }
            xml.Save("0.xml");
        }

        /*  IN DEVELOPMENT
         *  ya he conseguido que funcione, ahora necesito una nueva interfaz
         *  para introducir los valores
         */
        public static void UpdateRoute(string nodeIdentifier, string newValue)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(DealWithDB.GetDBPath());

            XmlNodeList allElementsWithThisTag = xml.GetElementsByTagName("name");
            foreach (XmlNode checkingNode in allElementsWithThisTag)
            {
                // Encuentra los nodos de las rutas personalizadas
                if (checkingNode.InnerText == nodeIdentifier)
                {
                    Console.WriteLine("Encontrada ruta personalizada.");
                    checkingNode.InnerText = newValue;
                }
                else
                {
                    Console.WriteLine("No coincide: " + checkingNode.InnerText);
                }
            }
            xml.Save("0.xml");
        }

        /*
         * 
         */
        private void button_deleteDB_Click_1(object sender, EventArgs e)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(DealWithDB.GetDBPath());

            string NodeName = xmlTreeView.SelectedNode.Tag.ToString();
            string nodeValue = xmlTreeView.SelectedNode.Name;

            Console.WriteLine("Valores: " + NodeName + " - " + nodeValue);

            if (NodeName == "personalisedAction")
            {
                // Encuentra el nodo con la id
                XmlNodeList nodesWithActionId = xml.SelectNodes("Settings/personalisedRoutesList/personalisedRoutes/" +
                    "personalisedActionsList/personalisedAction [@actionId='" + nodeValue + "']");
                foreach (XmlNode searchedNode in nodesWithActionId)
                {
                    if (searchedNode != null)
                    {
                        searchedNode.ParentNode.RemoveChild(searchedNode);
                    }
                }
                    MostrarFeedback(" Eliminado con exito.");
            }
            else if (NodeName == "name")
            {
                XmlNodeList allElementsWithThisTag = xml.GetElementsByTagName("name");
                XmlNode auxNode = null;
                foreach (XmlNode checkingNode in allElementsWithThisTag)
                {
                    // Encuentra los nodos de las rutas personalizadas
                    if (checkingNode.InnerText == nodeValue)
                    {
                        if (checkingNode != null)
                        {
                            auxNode = checkingNode.ParentNode;
                        }
                    }
                }
                auxNode.ParentNode.RemoveChild(auxNode);
                MostrarFeedback(" Eliminado con exito.");
            }
            else
            {
                Console.WriteLine("No se puede elimininar esta opcion ");
            }

            xml.Save("db.xml");
            PopulateTreeView(xml);
        }

        

        /*
-----------------------------TERMINAN LOS MODULOS DE LOS THREADS -----------------------------------  
*/




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNewPersonalisedRouteName_TextChanged(object sender, EventArgs e)
        {

        }

        /*
         * 
         */
        private void button_saveDB_Click(object sender, EventArgs e)
        {
            DealWithDB.SaveDBSettings(loadedSettings);
        }

        /*
         * 
         */
        private void button_setScheludedTimeToRoute_Click(object sender, EventArgs e)
        {
            threadManagerInstance.CreateSleepToTargetThread();

            /*
            //MostrarFeedback(" Iniciando espera de 'threadScheludedTime'.");
            SleepToTarget Temp = new SleepToTarget(DateTime.Now.AddSeconds(10), Done);
            //Temp.Start();
            //Console.ReadLine();

            MostrarFeedback(" Iniciando espera de 'threadScheludedTime'.");
            threadScheludedTime = new System.Threading.Thread(() => Telele(Temp));
            threadScheludedTime.Start();
            MostrarFeedback(" Establecido tiempo de espera.");
            */
        }

        private void Telele(SleepToTarget Temp)
        {
            /*
            MostrarFeedback(" entrando de Telele.");
            Console.WriteLine("Telele: " + threadScheludedTime);
            Temp.Start(this);
            
            
            MostrarFeedback(" saliendo de Telele.");
            MostrarFeedback(" Fin de espera de 'threadScheludedTime'.");
            threadScheludedTime = null;
            */
        }

        static void Done()
        {
            Console.WriteLine("Done");
        }
    }
}
