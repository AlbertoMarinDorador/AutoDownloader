using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autodownloader
{
    /*
     * Clase que contiene los modulos orientados a gestionar el funcionamiento de las hebras
     */
    class DealWithThreads
    {
        /*
         * divide las esperas en esperas de 1 seg para poder realizar comprobaciones
         * durante el sleep
         */
        public static void goToSafeSleep(int time, Interface view, ChromeDriver driver)
        {
            for (int i = 0; i <= time; i++)
            {
                System.Threading.Thread.Sleep(1000);
                if (CloseThisThread(view, driver)) return;
            }
        }

        /*
         * Modulo encargado de comprobar si se ha solicitado el cierre desde la vista.
         * Hay 2 tipos de cierre que pueden ser invocados:
         *  - view.HaveToStopState()
         *      Espera hasta que termine la descarga actual y termina la ejecucion.
         *  - view.HaveToForcedStopState()
         *      Termina la ejecucion lo antes posible. 
         *      Debe cerrar 'driver' de no ser 'driver == null'. 
         * En caso de invocarse los 2 a la vez, ForcedStop esta primero.
         */
        public static bool CloseThisThread(Interface view, ChromeDriver driver)
        {
            if (view.HaveToForcedStopState())
            {
                if (driver != null)
                {
                    try
                    {
                        driver.Manage().Cookies.DeleteAllCookies();
                        driver.Quit();
                    }
                    catch (Exception WebDriverException)
                    {

                    }
                }                    
                return true;
            }
            // el momento en el que 'driver == null' es cuando finaliza una descarga
            if (view.HaveToStopState() && driver == null) return true;
            return false;
        }
    }
}
