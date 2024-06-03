using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using System.Runtime.InteropServices;
using System.Drawing;
using OpenQA.Selenium;
using System.Windows.Forms;

namespace autodownloader
{
    /*
     * Clase que contiene los modulos relacionados con el driver de Chrome 'Selenium'
     */
    class DealWithChrome
    {

        /*  FUTURE CODE
         *  driver.FindElement(By.XPath("//td[5]/a").Click());
         *  XPath for Mega download buttom:     
         *          //*[@id="startholder"]/div[3]/div/div[4]/div/div/div[2]/div[2]/span
         */


        /*
         * Modulo que abre una ventana de chrome con el 'link' indicado, y configurado con
         * la carpeta de descargas en 'path'.
         * Return: La referencia al 'ChromeDriver', permitiendo su cierre cuando termine.
         *         O 'null' si se cierra la web o el cmd durante el proceso.
         * A mejorar:
         *      - Encontrar la manera de descargar varios links en el mismo chrome, siempre 
         *          que compartan la carpeta de descarga.
         */
        public static ChromeDriver OpenWeb(string path, string link)
        {
            // Defino los ajustes de la pagina web que se va a abrir
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", path);
            chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
              
            try
            {
                // Abro la pagina web deseada.
                var driver = new ChromeDriver(@"C:\ChromeDriver\", chromeOptions);
                driver.Navigate().GoToUrl(link);
                driver.Manage().Window.Maximize();
                return driver;
            }
            catch (Exception ex)
            {
                if (ex is WebDriverException || ex is InvalidOperationException)
                {
                    //driver.Quit();
                    return null;
                }
                throw;
            }
        }

        /*  DEPRECATED
         * Abre una ventana con un link predefinido para realizar configuraciones.
         */
        public static void OpenConfigurationLink()
        {
            string defaultLinkForConfiguration = "https://mega.nz/#!qM1zGSgQ!AlotfLFyGG5zt1D9YPYIpR_vCF2rYUt63K9_fcLxSdQ";
            OpenWeb("", defaultLinkForConfiguration);
        }
    }
}
