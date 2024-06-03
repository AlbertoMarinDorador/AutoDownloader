using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace autodownloader
{
    /*
     * Realiza las acciones relacionadas con archivos XML
     */
    class DealWithXML
    {
        /*
         * Realiza una busqueda de todos los nodos que sean "name" (solo las rutas tienen nombre),
         * y devuelve el que sea igual al buscado: "nodeName".
         */
        private XmlNode FindRouteNode(string nodeName)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(DealWithDB.GetDBPath());
            // "null" por si no lo encuentra
            XmlNode auxNode = null;
            XmlNodeList allElementsWithThisTag = xml.GetElementsByTagName("name");
            foreach (XmlNode checkingNode in allElementsWithThisTag)
            {
                // Encuentra los nodos de las rutas personalizadas
                if (checkingNode.InnerText == nodeName)
                {
                    Console.WriteLine("Encontrada ruta personalizada: " + checkingNode.InnerText);
                    auxNode = checkingNode;
                }
                else
                {
                    Console.WriteLine("La ruta no coincide: " + checkingNode.InnerText);
                }
            }
            return auxNode;
        }

        /*
         * Realiza una busqueda de todos los nodos que tengan el atributo "actionId" ,
         * y devuelve el que sea igual al buscado: "id".
         */
        private XmlNode FindActionNode(int nodeId)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(DealWithDB.GetDBPath());
            // "null" por si no lo encuentra
            XmlNode auxNode = null;
            // Encuentra el nodo con la id
            XmlNodeList actionNodesList = xml.SelectNodes("Settings/personalisedRoutesList/personalisedRoutes/" +
                "personalisedActionsList/personalisedAction [@actionId='" + nodeId + "']");
            foreach (XmlNode searchedNode in actionNodesList)
            {
                Console.WriteLine("Found: " + searchedNode.InnerText);
                auxNode = searchedNode;
            }
            return auxNode;

            /* NO FUNCIONA
            XmlDocument doc = new XmlDocument();
            doc.Load(DealWithDB.GetDBPath());

            var x = doc.GetElementsByTagName(nodeName)[id];
            //output = output + x.ChildNodes[0].Value;
            return x.ChildNodes[0].Value;
            */
        }

        /*
         * Guarda los ajustes que recibe en un archivo XML
         */
        public static void SaveDB(Settings theSettings)
        {
            XmlTextWriter xmlw = new XmlTextWriter(DealWithDB.GetDBPath(), System.Text.Encoding.UTF8);
            xmlw.WriteStartDocument();
            xmlw.WriteStartElement("Settings");
            xmlw.WriteStartElement("topLevelFolderDefaultPath");
            xmlw.WriteString(theSettings.topLevelFolderDefaultPath);
            xmlw.WriteEndElement();
            xmlw.WriteStartElement("linksFileDefaultPath");
            xmlw.WriteString(theSettings.linksFileDefaultPath);
            xmlw.WriteEndElement();
            xmlw.WriteStartElement("iterationNumber");
            xmlw.WriteString(theSettings.iterationNumber.ToString());
            xmlw.WriteEndElement();
            xmlw.WriteStartElement("iterateActionId");
            xmlw.WriteString(theSettings.iterateActionId.ToString());
            xmlw.WriteEndElement();
            // Empieza el List
            xmlw.WriteStartElement("personalisedRoutesList");
            for (int i = 0; i < theSettings.personalisedRoutes.Count; i++)
            {
                xmlw.WriteStartElement("personalisedRoutes");
                xmlw.WriteStartElement("name");
                xmlw.WriteString(theSettings.personalisedRoutes[i].name);
                xmlw.WriteEndElement();
                xmlw.WriteStartElement("personalisedActionsList");
                for (int x = 0; x < theSettings.personalisedRoutes[i].route.Count; x++)
                {
                    xmlw.WriteStartElement("personalisedAction");
                    //xmlw.WriteString(theSettings.personalisedRoutes[i].route[x].actionType.ToString());
                    // Guardo coordenadas
                    if (theSettings.personalisedRoutes[i].route[x].actionType == 1)
                    {
                        xmlw.WriteStartElement("ActionType");
                        xmlw.WriteString(theSettings.personalisedRoutes[i].route[x].actionType.ToString());
                        xmlw.WriteEndElement();
                        xmlw.WriteStartElement("Point");
                        xmlw.WriteStartElement("X");
                        xmlw.WriteString(theSettings.personalisedRoutes[i].route[x].mousePosition.X.ToString());
                        xmlw.WriteEndElement();
                        xmlw.WriteStartElement("Y");
                        xmlw.WriteString(theSettings.personalisedRoutes[i].route[x].mousePosition.Y.ToString());
                        xmlw.WriteEndElement();
                        xmlw.WriteEndElement();
                    }
                    else if (theSettings.personalisedRoutes[i].route[x].actionType == 2)
                    {
                        xmlw.WriteStartElement("ActionType");
                        xmlw.WriteString(theSettings.personalisedRoutes[i].route[x].actionType.ToString());
                        xmlw.WriteEndElement();
                        xmlw.WriteStartElement("texto");
                        xmlw.WriteString(theSettings.personalisedRoutes[i].route[x].texto);
                        xmlw.WriteEndElement();
                    }
                    else if (theSettings.personalisedRoutes[i].route[x].actionType == 3)
                    {
                        xmlw.WriteStartElement("ActionType");
                        xmlw.WriteString(theSettings.personalisedRoutes[i].route[x].actionType.ToString());
                        xmlw.WriteEndElement();
                        xmlw.WriteStartElement("waitTime");
                        xmlw.WriteString(theSettings.personalisedRoutes[i].route[x].waitTime.ToString());
                        xmlw.WriteEndElement();
                    }
                    else if (theSettings.personalisedRoutes[i].route[x].actionType == 4)
                    {
                        xmlw.WriteStartElement("ActionType");
                        xmlw.WriteString(theSettings.personalisedRoutes[i].route[x].actionType.ToString());
                        xmlw.WriteEndElement();
                        xmlw.WriteStartElement("personalisedRouteId");
                        xmlw.WriteString(theSettings.personalisedRoutes[i].route[x].personalisedRouteId.ToString());
                        xmlw.WriteEndElement();
                    }
                    xmlw.WriteEndElement();
                }
                xmlw.WriteEndElement();
                xmlw.WriteEndElement();
            }
            xmlw.WriteEndElement();
            // Cierra 'Settings'
            xmlw.WriteEndElement();
            xmlw.WriteEndDocument();
            xmlw.Close();
        }

        /*
         * Lee un archivo XML y devuelve un 'Settings'
         */
        public static Settings LoadDB()
        {
            Settings newSettings = new Settings();
            PersonalisedRoute auxRoute = new PersonalisedRoute();
            PersonalisedAction auxAction = new PersonalisedAction();
            XmlTextReader reader = new XmlTextReader(DealWithDB.GetDBPath());
            string className;
            string classValue;
            // Empiezo a leer el XML
            reader.Read();
            while (reader.Read())
            {
                // Busco el inicio de los elementos en la DB
                if (reader.IsStartElement())
                {
                    className = reader.Name;
                    if (className == "Settings")
                    {
                        Console.WriteLine(". Name: " + className);
                    }
                    else
                    {
                        if (className == "topLevelFolderDefaultPath")
                        {
                            classValue = reader.ReadString();
                            //Console.WriteLine(". topLevelFolderDefaultPath: " + SetTopLevelFolderDefaultPath(reader));
                            newSettings.topLevelFolderDefaultPath = classValue;
                            Console.WriteLine("topLevelFolderDefaultPath: " + classValue);
                        }
                        if (className == "linksFileDefaultPath")
                        {
                            classValue = reader.ReadString();
                            //Console.WriteLine(". linksFileDefaultPath: " + SetTopLevelFolderDefaultPath(reader));
                            newSettings.linksFileDefaultPath = classValue;
                            Console.WriteLine("linksFileDefaultPath: " + classValue);
                        }
                        if (className == "iterationNumber")
                        {
                            classValue = reader.ReadString();
                            //Console.WriteLine(". topLevelFolderDefaultPath: " + SetTopLevelFolderDefaultPath(reader));
                            newSettings.iterationNumber = Convert.ToUInt32(classValue, 16);
                            Console.WriteLine("iterationNumber: " + classValue);
                        }
                        if (className == "iterateActionId")
                        {
                            classValue = reader.ReadString();
                            //Console.WriteLine(". topLevelFolderDefaultPath: " + SetTopLevelFolderDefaultPath(reader));
                            newSettings.iterateActionId = Convert.ToInt32(classValue);
                            Console.WriteLine("iterateActionId: " + classValue);
                        }
                        if (className == "personalisedRoutesList")
                        {
                            classValue = SetPersonalisedRoutesList(reader);
                            auxRoute.name = classValue;
                            newSettings.personalisedRoutes.Add(auxRoute);
                            Console.WriteLine(".1 personalisedRoute: " + classValue);

                        }
                        if (className == "personalisedAction")
                        {
                            classValue = SetPersonalisedAction(reader);
                            auxAction = DealWithPersonalisedActions.ClearAction();
                            auxAction.actionType = Convert.ToInt32(classValue);
                            newSettings.personalisedRoutes.Last().route.Add(auxAction);
                            Console.WriteLine(". personalisedAction Type: " + classValue);
                        }
                        if (className == "waitTime")
                        {
                            classValue = reader.ReadString();
                            newSettings.personalisedRoutes.Last().route.Last().waitTime = Convert.ToUInt32(classValue);
                        }
                        if (className == "Point")
                        {
                            classValue = SetPoint(reader);
                            newSettings.personalisedRoutes.Last().route.Last().mousePosition.X = Convert.ToInt32(classValue);
                        }
                        if (className == "Y")
                        {
                            newSettings.personalisedRoutes.Last().route.Last().mousePosition.Y = Convert.ToInt32(reader.ReadString());
                        }
                        if (className == "texto")
                        {
                            newSettings.personalisedRoutes.Last().route.Last().texto = reader.ReadString();
                        }
                        if (className == "personalisedRoutes")
                        {
                            classValue = SetPersonalisedRoutes(reader);
                            auxRoute = DealWithPersonalisedRoutes.ClearRoute();
                            auxRoute.name = classValue;
                            newSettings.personalisedRoutes.Add(auxRoute);
                            Console.WriteLine(".2 personalisedRoute: " + classValue);
                        }
                    }
                }
            }
            reader.Close();
            return newSettings;
        }

        /*
         * Durante la lectura de la DB, devuelve el nombre de la ruta a añadir
         */
        public static string SetPersonalisedRoutesList(XmlTextReader reader)
        {
            string classValue = reader.Name;
            classValue = reader.ReadString();
            classValue = reader.Name;
            classValue = reader.ReadString();
            classValue = reader.Name;
            classValue = reader.ReadString();
            Console.WriteLine(". Read: " + classValue);
            Console.WriteLine(". Name: " + reader.Name);
            return classValue;
        }

        /*
         * Durante la lectura de la DB, devuelve el nombre de la ruta a añadir
         */
        public static string SetPersonalisedRoutes(XmlTextReader reader)
        {
            string classValue = reader.ReadString();
            classValue = reader.Name;
            classValue = reader.ReadString();
            Console.WriteLine(". Read: " + classValue);
            Console.WriteLine(". Name: " + reader.Name);
            return classValue;
        }

        /*
         * Durante la lectura de la DB, devuelve el tipo de accion
         */
        public static string SetPersonalisedAction(XmlTextReader reader)
        {
            string classValue = reader.ReadString();
            classValue = reader.Name;
            //Console.WriteLine(". Name: " + reader.Name);
            classValue = reader.ReadString();
            //Console.WriteLine(". Read: " + classValue);
            return classValue;
        }

        /*
         * Durante la lectura de la DB, devuelve las coordenadas para emular al raton
         */
        public static string SetPoint(XmlTextReader reader)
        {
            string classValue = reader.ReadString();
            classValue = reader.Name;
            classValue = reader.ReadString();
            return classValue;
        }

        /*
       public static string SetPersonalisedRoutes(XmlTextReader reader)
       {
           string classValue = reader.ReadString();

           Console.WriteLine(". Read: " + classValue);
           Console.WriteLine(". Name: " + reader.Name);
           return classValue;
       }
       */

        
    }
}
