using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autodownloader
{
    /*
     * Esta clase contiene todas las funcionalidades relacionadas con las opciones por defecto.
     */
    class DefaultSettings
    {
        /*
         * Si no hay datos guardados en la DB, devuelvo unos ajustes Default.
         * Return: Un objeto 'Settings' con todos los ajustes.
         */
        public static Settings Load()
        {
            Settings defaultSettings = new Settings();
            // Ruta default para el archivo con los links de descarga
            defaultSettings.linksFileDefaultPath = @"C:\DEFAULT DOWNLOADS FOLDER\Links.txt";
            // Ruta default para la carpeta donde se guardaran todas las descargas
            defaultSettings.topLevelFolderDefaultPath = @"C:\DEFAULT DOWNLOADS FOLDER";
            // Cantidad de descargas a esperar antes de realizar el recorrido entre descargas
            defaultSettings.iterationNumber = 1;
            // Identificador del recorrido a realizar entre descargas
            defaultSettings.iterateActionId = 0;
            // El recorrido a realizar entre descargas
            defaultSettings.personalisedRoutes = DefaultRRR();
            // Recorrido encargado de realizar la descarga
            defaultSettings.personalisedRoutes.Add(DefaultDownloadPosition());
            return defaultSettings;
        }

        /*
         * Este modulo devuelve el recorrido por defecto a ejecutar entre descargas.
         */
        public static List<PersonalisedRoute> DefaultRRR()
        {
            List<PersonalisedRoute> auxList = new List<PersonalisedRoute>();
            PersonalisedRoute auxPersonalisedRoute = new PersonalisedRoute();
            auxPersonalisedRoute.name = "RRR";
            PersonalisedAction auxAction = new PersonalisedAction();
            // Paso 0
            auxAction.actionType = 3;
            auxAction.waitTime = 7;
            auxPersonalisedRoute.route.Add(auxAction);
            auxAction = DealWithPersonalisedActions.ClearAction();
            // Paso 0.5  Refresh
            auxAction.actionType = 1;
            auxAction.mousePosition.X = 70;
            auxAction.mousePosition.Y = 45;
            auxPersonalisedRoute.route.Add(auxAction);
            auxAction = DealWithPersonalisedActions.ClearAction();
            // Paso 0.5.5
            auxAction.actionType = 3;
            auxAction.waitTime = 7;
            auxPersonalisedRoute.route.Add(auxAction);
            auxAction = DealWithPersonalisedActions.ClearAction();
            // Paso 1
            auxAction.actionType = 1;
            auxAction.mousePosition.X = 1343;
            auxAction.mousePosition.Y = 88;
            auxPersonalisedRoute.route.Add(auxAction);
            auxAction = DealWithPersonalisedActions.ClearAction();
            // Paso 2
            auxAction.actionType = 3;
            auxAction.waitTime = 1;
            auxPersonalisedRoute.route.Add(auxAction);
            auxAction = DealWithPersonalisedActions.ClearAction();
            // Paso 3
            auxAction.actionType = 1;
            auxAction.mousePosition.X = 707;
            auxAction.mousePosition.Y = 208;
            auxPersonalisedRoute.route.Add(auxAction);
            auxAction = DealWithPersonalisedActions.ClearAction();
            // Paso 4
            auxAction.actionType = 2;
            auxAction.texto = "1234";
            auxPersonalisedRoute.route.Add(auxAction);
            auxAction = DealWithPersonalisedActions.ClearAction();
            // Paso 5
            auxAction.actionType = 3;
            auxAction.waitTime = 1;
            auxPersonalisedRoute.route.Add(auxAction);
            auxAction = DealWithPersonalisedActions.ClearAction();
            // Paso 6
            auxAction.actionType = 1;
            auxAction.mousePosition.X = 699;
            auxAction.mousePosition.Y = 241;
            auxPersonalisedRoute.route.Add(auxAction);
            auxAction = DealWithPersonalisedActions.ClearAction();
            // Paso 7
            auxAction.actionType = 2;
            auxAction.texto = "Pardo";
            auxPersonalisedRoute.route.Add(auxAction);
            auxAction = DealWithPersonalisedActions.ClearAction();
            // Paso 8
            auxAction.actionType = 3;
            auxAction.waitTime = 1;
            auxPersonalisedRoute.route.Add(auxAction);
            auxAction = DealWithPersonalisedActions.ClearAction();
            // Paso 9
            auxAction.actionType = 1;
            auxAction.mousePosition.X = 727;
            auxAction.mousePosition.Y = 305;
            auxPersonalisedRoute.route.Add(auxAction);
            auxAction = DealWithPersonalisedActions.ClearAction();
            // Paso 10
            auxAction.actionType = 3;
            auxAction.waitTime = 5;
            auxPersonalisedRoute.route.Add(auxAction);
            auxAction = DealWithPersonalisedActions.ClearAction();
            // Paso 11
            auxAction.actionType = 1;
            auxAction.mousePosition.X = 46;
            auxAction.mousePosition.Y = 290;
            auxPersonalisedRoute.route.Add(auxAction);
            auxAction = DealWithPersonalisedActions.ClearAction();
            // Paso 12
            auxAction.actionType = 3;
            auxAction.waitTime = 1;
            auxPersonalisedRoute.route.Add(auxAction);
            auxAction = DealWithPersonalisedActions.ClearAction();
            // Paso 13
            auxAction.actionType = 1;
            auxAction.mousePosition.X = 61;
            auxAction.mousePosition.Y = 416;
            auxPersonalisedRoute.route.Add(auxAction);
            auxAction = DealWithPersonalisedActions.ClearAction();
            // Paso 14
            auxAction.actionType = 3;
            auxAction.waitTime = 1;
            auxPersonalisedRoute.route.Add(auxAction);
            auxAction = DealWithPersonalisedActions.ClearAction();
            // Paso 15 Pulsa boton reboot
            auxAction.actionType = 1;
            auxAction.mousePosition.X = 758;
            auxAction.mousePosition.Y = 213;
            auxPersonalisedRoute.route.Add(auxAction);
            auxAction = DealWithPersonalisedActions.ClearAction();
            // Paso 16
            auxAction.actionType = 3;
            auxAction.waitTime = 150;
            auxPersonalisedRoute.route.Add(auxAction);
            auxAction = DealWithPersonalisedActions.ClearAction();
            // Guardo el recorrido
            auxList.Add(auxPersonalisedRoute);
            return auxList;
        }

        /*
         * Este modulo devuelve el recorrido por defecto encargado de realizar la descarga.
         */
        public static PersonalisedRoute DefaultDownloadPosition()
        {
            PersonalisedRoute auxPersonalisedRoute = new PersonalisedRoute();
            auxPersonalisedRoute.name = "Download Position";
            PersonalisedAction auxAction = new PersonalisedAction();
            // Paso 0
            auxAction.actionType = 1;
            auxAction.mousePosition.X = 768;
            auxAction.mousePosition.Y = 463;
            auxPersonalisedRoute.route.Add(auxAction);
            auxAction = DealWithPersonalisedActions.ClearAction();
            return auxPersonalisedRoute;
        }
    }
}
