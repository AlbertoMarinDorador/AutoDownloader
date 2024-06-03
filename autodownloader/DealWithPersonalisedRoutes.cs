using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autodownloader
{
    /*
     * Esta clase contiene los modulos que se encargan de la gestion y ejecucion
     * de las 'PersonalisedRoute'
     */
    class DealWithPersonalisedRoutes
    {
        /*   !!! este modulo debe asegurarse de que la ventana
         *      esta en primer plano antes de realizar el click !!!
         * Modulo que realiza una 'PersonalisedRoute'
         */
        public static void StartPersonalised(List<PersonalisedRoute> allRoutes, String selectedRouteId, Interface view)
        {
            int routeId = Int32.Parse(selectedRouteId);
            view.MostrarFeedback("Inicia el recorrido:" + routeId + ".\t Count: " + allRoutes[routeId].route.Count);
            // Recorro el recorrido indicado
            for (int i = 0; i < allRoutes[routeId].route.Count; i++)
            {
                // Compruebo si se ha solicitado el stop desde la vista
                if (DealWithThreads.CloseThisThread(view, null)) return;
                // Compruebo si la siguiente accion 
                if (allRoutes[routeId].route[i].actionType == 4)
                {
                    // Lanza otro recorrido
                    DealWithPersonalisedActions.DoActionType4(allRoutes, allRoutes[routeId].route[i].personalisedRouteId, view);
                }
                else
                {
                    // Lanza una accion
                    DealWithPersonalisedActions.DoAction(allRoutes[routeId].route[i], view);
                }
            }
            view.MostrarFeedback("SALE");
        }

        /*
         * Este modulo ayuda a inicializar una 'Route' a 0, se usa para evitar errores
         * a la hora de crear rutas. 
         */
        public static PersonalisedRoute ClearRoute()
        {
            PersonalisedRoute auxRoute = new PersonalisedRoute();
            auxRoute.name = "";
            auxRoute.route = new List<PersonalisedAction>();
            return auxRoute;
        }

        /*  !!! Cambiar 'CountDown' para que no necesite llamar a la vista!!!
         *  Esta funcion va poppeando una vista que funciona a modo de 'DialogResult' y dependiendo 
         *  de la opcion que elijas, el programa registrara la pos del raton, texto, etc.
         *  Este modulo devuelve un 'PersonalisedActionList'
         */
        public static List<PersonalisedAction> CreateNewPersonalisedRoute(Settings loadedSettings, Interface view)
        {
            List<PersonalisedAction> auxPersonalisedActionList = new List<PersonalisedAction>();
            MessageBoxForAddNewRoutes messageBoxSelectedAction = new MessageBoxForAddNewRoutes(loadedSettings);
            DialogResult messageBoxResult;
            bool addPersonalisedRouteIsCanceled = false;
            // Bucle que va captando la opcion pulsada en el 'messageBoxSelectedAction', y actua en consecuencia.
            // No terminara hasta que se capte la opcion 'Cancel'
            do
            {
                messageBoxResult = messageBoxSelectedAction.ShowDialog();
                // La primera opcion captura el raton y añade el 'Point' al 'List'
                if (messageBoxResult == System.Windows.Forms.DialogResult.Yes)
                {
                    view.CountDown();
                    auxPersonalisedActionList.Add(DealWithPersonalisedActions.AddMousePosition());
                }
                // La segunda opcion captura texto y lo añade al 'List'
                else if (messageBoxResult == System.Windows.Forms.DialogResult.No)
                {
                    auxPersonalisedActionList.Add(DealWithPersonalisedActions.AddText(messageBoxSelectedAction.newActionValue));
                }
                // La tercera opcion añade una espera, indicada en segundos
                else if (messageBoxResult == System.Windows.Forms.DialogResult.Ignore)
                {
                    auxPersonalisedActionList.Add(DealWithPersonalisedActions.AddWait(messageBoxSelectedAction.newActionValue));
                }
                // Añado el id de otra ruta, DISABLED
                else if (messageBoxResult == System.Windows.Forms.DialogResult.Retry)
                {
                    /*
                    MostrarFeedback(" Has pulsado 'RETRY': " + messageBoxSelectedAction.newActionValue);
                    auxPersonalisedActionList.Add(DealWithPersonalisedActions.AddRoute(messageBoxSelectedAction.newActionValue));
                     */
                }
                // Cuando se cierre la ventana, significa que se cancela el proceso
                else if (messageBoxResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    addPersonalisedRouteIsCanceled = true;
                }
                // La ultima opcion finaliza el bucle 
            } while (messageBoxResult != System.Windows.Forms.DialogResult.Cancel && messageBoxResult != System.Windows.Forms.DialogResult.OK);

            // Si no se ha cancelado la creacion, guardo la nueva ruta
            if (addPersonalisedRouteIsCanceled == false)
            {
                return auxPersonalisedActionList;
            }
            else
            {
                return null;
            }
        }
    }
}
