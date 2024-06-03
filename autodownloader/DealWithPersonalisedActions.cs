using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autodownloader
{
    /*
     * Clase que contiene todos los modulos relacionados con la gestion 
     * de las 'PersonalisedActions'
     */
    class DealWithPersonalisedActions
    {
        /*
         * Modulo que ejecuta la accion que lanza otro recorrido
         */
        public static void DoActionType4(List<PersonalisedRoute> allRoutes, int selectedRouteId, Interface view)
        {
            DealWithPersonalisedRoutes.StartPersonalised(allRoutes, selectedRouteId.ToString(), view);
        }

        /*
         * Modulo que recibe un id y ejecuta la accion correspondiente
         */
        public static void DoAction(PersonalisedAction action, Interface view)
        {
            // Emula el click izquierdo del raton
            if (action.actionType == 1)
            {
                DealWithMouse.MakeLeftClick(action.mousePosition);
            }
            // introduce texto
            else if (action.actionType == 2)
            {
                SendKeys.SendWait(action.texto);
                //Keyboard.SendKeys("Pene");
            }
            // Realiza una espera
            else if (action.actionType == 3)
            {
                DealWithThreads.goToSafeSleep(Convert.ToInt32(action.waitTime), view, null);
            }            
        }

        /*
         * Devuelve una 'PersonalisedAction' con la posicion actual del raton.
         * Realiza una cuenta atras antes de capturar el raton.
         */
        public static PersonalisedAction AddMousePosition()
        {
            PersonalisedAction auxiliarAction = new PersonalisedAction();
            auxiliarAction.actionType = 1;
            Point actualMousePos = DealWithMouse.GetCursorPosition();
            auxiliarAction.mousePosition.X = actualMousePos.X;
            auxiliarAction.mousePosition.Y = actualMousePos.Y;
            return auxiliarAction;
        }

        /*
         * Devuelve una 'PersonalisedAction' con el texto recibido.
         */
        public static PersonalisedAction AddText(string auxValue)
        {
            PersonalisedAction auxiliarAction = new PersonalisedAction();
            auxiliarAction.actionType = 2;
            auxiliarAction.texto = auxValue;
            return auxiliarAction;
        }

        /*
         * Devuelve una 'PersonalisedAction' con una espera inicializada con el valor recibido.
         */
        public static PersonalisedAction AddWait(string auxValue)
        {
            PersonalisedAction auxiliarAction = new PersonalisedAction();
            auxiliarAction.actionType = 3;
            auxiliarAction.waitTime = Convert.ToUInt32(auxValue);
            return auxiliarAction;
        }

        /*  !!! EN DESARROLLO, NO SE USA!!!
         * Devuelve una 'PersonalisedAction' con la id de otra ruta.
         */
        public static PersonalisedAction AddRoute(string auxValue)
        {
            PersonalisedAction auxiliarAction = new PersonalisedAction();
            auxiliarAction.actionType = 4;
            auxiliarAction.personalisedRouteId = Convert.ToInt32(auxValue);
            return auxiliarAction;
        }

        /*
         * Este modulo ayuda a inicializar una 'Action' a 0, se usa para evitar errores
         * a la hora de crear rutas.
         */
        public static PersonalisedAction ClearAction()
        {
            PersonalisedAction auxAction = new PersonalisedAction();
            auxAction.actionType = 0;
            auxAction.mousePosition.X = 0;
            auxAction.mousePosition.Y = 0;
            auxAction.texto = "";
            auxAction.waitTime = 0;
            return auxAction;
        }
    }
}
