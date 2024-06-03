using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autodownloader
{
    public partial class LauncherLinksOpctions : Form
    {
        Settings loadedSettings;
        Interface view;
        System.Threading.Thread downloadThread;

        public LauncherLinksOpctions(Settings theSettings, Interface theview)
        {
            InitializeComponent();

            view = theview;
            loadedSettings = theSettings;
            textBox_topLevelFolder.Text = loadedSettings.topLevelFolderDefaultPath;
            textBox_linksFile.Text = loadedSettings.linksFileDefaultPath;
            for (int i = 0; i < loadedSettings.personalisedRoutes.Count; i++)
            {
                comboBoxSetRouteForEachLink.Items.Add(i + ". " + loadedSettings.personalisedRoutes[i].name);
            }
            comboBoxSetRouteForEachLink.SelectedIndex = 0;
        }
            /*      
         * Este boton abre un 'openFileDialog' que permite al usuario navegar
         * por las carpetas e indicar donde se encuentra el archivo con los links.
         * La ruta seleccionada se mostrara en el 'textbox' a su derecha.
         */
        private void button_linksFile_Click(object sender, EventArgs e)
        {
            // The user selected a file and pressed the OK button.
            if (openFileDialog_linksFile.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog_linksFile.FileName;
                textBox_linksFile.Text = path;
                BeginInvoke(new Action(() => view.MostrarFeedback("Seleccionado nuevo archivo." + Environment.NewLine)));

            }
            else
            {
                BeginInvoke(new Action(() => view.MostrarFeedback("No se ha seleccionado ningun archivo." + Environment.NewLine)));
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            // Compruebo la ruta a la carpeta de descargas y la ruta al archivo con los links
            if (ViewTopLevelFolderPathExists() && ViewlinksFilePathExists())
            {
                BeginInvoke(new Action(() => view.MostrarFeedback("Las 2 rutas son validas.")));
                // Compruebo la ruta para resetear el router
                if (loadedSettings.personalisedRoutes.Count == 0)
                {
                    BeginInvoke(new Action(() => view.MostrarFeedback("Faltan las rutas para el reinicio del router." + Environment.NewLine)));
                }
                // Compruebo que existan unas coordenadas para pulsar el boton de descarga
                else if (loadedSettings.personalisedRoutes[1].route[0].mousePosition.X == 0 && loadedSettings.personalisedRoutes[1].route[0].mousePosition.Y == 0)
                {
                    BeginInvoke(new Action(() => view.MostrarFeedback("Falta la posicion del boton de descarga." + Environment.NewLine)));
                }
                // Si todo es correcto, lanza el programa en una nueva hebra, y bloquea el boton de start
                else
                {
                    if (CheckAddedNewSettings())
                    {
                        DealWithDB.SaveDBSettings(loadedSettings);
                    }
                    //Start();
                }
                //Start();    // esta linea esta aqui para que funcione el program mientras estoy de pruebas
            }
        }
        /*
         * 
         */
        private bool CheckAddedNewSettings()
        {
            bool hasChanges = false;
            // Compruebo si se ha modificado el archivo con los links
            if (textBox_linksFile.Text != loadedSettings.linksFileDefaultPath && ViewlinksFilePathExists())
            {
                hasChanges = true;
                loadedSettings.linksFileDefaultPath = textBox_linksFile.Text;
            }
            // Compruebo si se ha modificado la ruta a la carpeta de descargas
            if (textBox_topLevelFolder.Text != loadedSettings.topLevelFolderDefaultPath && ViewTopLevelFolderPathExists())
            {
                hasChanges = true;
                loadedSettings.topLevelFolderDefaultPath = textBox_topLevelFolder.Text;
            }
            // Compruebo si se ha cambiado de recorrido para realizar las desacargas
            if (comboBoxSetRouteForEachLink.Text != "RRR")
            {
                hasChanges = true;
                string action = comboBoxSetRouteForEachLink.Text;
                string actionId = action[0] + "";
                loadedSettings.iterateActionId = Convert.ToInt32(actionId);
            }
            if (UpDownWaitTime.Value != 1)
            {
                hasChanges = true;
                loadedSettings.iterationNumber = Convert.ToUInt32(UpDownWaitTime.Value);
            }

            return hasChanges;
        }

        private void button_topLevelFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog_topLevelFolder.ShowDialog();
            // The user selected a folder and pressed the OK button.
            if (result == DialogResult.OK)
            {
                string path = folderBrowserDialog_topLevelFolder.SelectedPath;
                textBox_topLevelFolder.Text = path;
                BeginInvoke(new Action(() => view.MostrarFeedback("Seleccionado nuevo directorio para las descargas." + Environment.NewLine)));
            }
            else
            {
                BeginInvoke(new Action(() => view.MostrarFeedback("No se ha seleccionado ningun directorio." + Environment.NewLine)));
            }
        }



        /*
         * Realiza las comprobaciones necesarias para saber si el 'TopLevelFolderPath' que 
         * se encuentra en la vista es valido.
         * Return: true (si es valido), false (si no lo es).
         */
        public bool ViewTopLevelFolderPathExists()
        {
            // Compruebo si la ruta para la carpeta de descargas esta vacia
            if (textBox_topLevelFolder.Text == "")
            {
                textBox_topLevelFolder.Text = loadedSettings.topLevelFolderDefaultPath;
                BeginInvoke(new Action(() => view.MostrarFeedback("El Directorio de Descargas no puede estar vacio." + Environment.NewLine)));
                return false;
            }
            // Si se ha introducido una ruta personalizada se comprueba si no existe
            else if (!DealWithFilesAndDirs.CheckTopLevelFolderExists(textBox_topLevelFolder.Text))
            {
                BeginInvoke(new Action(() => view.MostrarFeedback("El Directorio de Descargas seleccionado no existe." + Environment.NewLine)));
                return false;
            }
            // La ruta personaliza existe
            else
            {
                return true;
            }
        }

        /*
         * Realiza las comprobaciones necesarias para saber si el 'linksFilePath' que 
         * se encuentra en la vista es valido.
         * Return: true (si es valido), false (si no lo es)
         */
        public bool ViewlinksFilePathExists()
        {
            // Compruebo si la ruta para el archivo con los links esta vacia
            if (textBox_linksFile.Text == "")
            {
                textBox_linksFile.Text = loadedSettings.linksFileDefaultPath;
                BeginInvoke(new Action(() => view.MostrarFeedback("El Directorio del Archivo con los links no puede estar vacio." + Environment.NewLine)));
                return false;
            }
            // Si se ha introducido una ruta personalizada se comprueba si no existe
            else if (!DealWithFilesAndDirs.CheckFileExists(textBox_linksFile.Text))
            {
                BeginInvoke(new Action(() => view.MostrarFeedback("El Archivo seleccionado no existe." + Environment.NewLine)));
                return false;
            }
            // La ruta personaliza existe
            else
            {
                return true;
            }
        }

        /*
         * Sabiendo que todo esta correcto, este modulo lanza una nueva hebra que va a ejecutar
         * la descarga con los argumentos que le pasamos.
         * Para evitar problemas, modifica en el boton start 'Enabled = false'.
         */
        private void Start()
        {
            // Compruebo que la hebra no exista
            if (downloadThread == null)
            {
                /*
                //
                loadedSettings.waitTime = Convert.ToUInt32(UpDownWaitTime.Value);
                // Creo y lanzo la hebra encargada de las descargas
                downloadThread = new System.Threading.Thread(() => startDownload());
                downloadThread.Start();
                */

                //view.checkDownloadThreadStop
                BeginInvoke(new Action(() => view.MostrarFeedback(" Se procede a la descarga." + Environment.NewLine)));
            }
            else
            {
                BeginInvoke(new Action(() => view.MostrarFeedback(" Ya se estan realizando las descargas en este momento." + Environment.NewLine)));
            }
        }

        
    }
}
