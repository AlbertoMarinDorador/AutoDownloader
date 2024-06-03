using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;

namespace autodownloader
{
    /* 
     * Clase en la que se encuentran los modulos encargados de la funcionalidad que permite
     * realizar las descargas
     */
    class DealWithDownloads
    {
        /*
         * Realiza la descarga de los links en el archivo indicado
         */
        public static void StartDownloadLinks(Settings loadedSettings, Interface view)
        {
            // Dir where all dirs with theirs downloads are going to be
            string topFolderPath = loadedSettings.topLevelFolderDefaultPath + "\\";
            // The path for the Dir of each download   
            string pathDownloadFolder = "Default";
            // Iterations of the parts for downloads with more than 1 link
            int counterForDownloadedParts = 0;
            // Contador que controla la ejecucion de otra ruta cada 'x' descargas
            int counterPartsRemainingForOtherRoute = Convert.ToInt32(loadedSettings.iterationNumber);
            // Each 'line' in the .txt file which we filled.
            string[] fileLines = DealWithFilesAndDirs.ReadFile(loadedSettings.linksFileDefaultPath);

            view.MostrarFeedback("\t\tPROGRAM START" + Environment.NewLine);
            // Sorting 'lines'
            for (int i = 0; i < fileLines.Count(); i++)
            {
                // Compruebo si se ha solicitado el cierre de la hebra desde la vista.
                if (DealWithThreads.CloseThisThread(view, null)) return;
                // Si empieza con 'Mega' es un link de descarga
                if (fileLines[i].StartsWith("https://mega.nz"))
                {
                    // Interesa llamar al RRR primero para asegurar el maximo tiempo de descarga
                    view.MostrarFeedback(" ANTES DE Reset: \t" + counterPartsRemainingForOtherRoute + ", " + counterForDownloadedParts + Environment.NewLine);
                    // Compruebo si hay que llamar a RRR
                    if (loadedSettings.iterationNumber > 0 && counterForDownloadedParts == counterPartsRemainingForOtherRoute)
                    {
                        view.MostrarFeedback(" EN Reset \t" + Environment.NewLine);
                        // Inicio la ruta para resetear el router
                        StartResetRouter(loadedSettings.personalisedRoutes[0], view);
                        // Wait for the router reset (2 min)
                        view.MostrarFeedback(" TRAS Reset \t" + Environment.NewLine);
                        //System.Threading.Thread.Sleep(3000);
                        counterPartsRemainingForOtherRoute = counterPartsRemainingForOtherRoute + Convert.ToInt32(loadedSettings.iterationNumber);
                    }
                    view.MostrarFeedback(" New Link: \t" + fileLines[i] + Environment.NewLine);
                    // Open a web whose download Dir is 'pathDownloadFolder' and open the link 'lines[i]'
                    var driver = DealWithChrome.OpenWeb(pathDownloadFolder, fileLines[i]);
                    // Si algo falla, se pasa a la siguiente descarga
                    if (driver == null)
                    {
                        view.MostrarFeedback(" Se ha cerrado la pagina web. Cancelando descarga del link actual. \t" + Environment.NewLine);
                    }
                    else
                    {
                        counterForDownloadedParts++;
                        ExecuteDownload(loadedSettings, driver, view, pathDownloadFolder, counterForDownloadedParts);
                        view.MostrarFeedback(" End download \t Download Parts Counter: " + counterForDownloadedParts + Environment.NewLine);
                    }
                }
                else
                {
                    // if it is not a link, null or a whitespace, then it is a Dir
                    if (!string.IsNullOrWhiteSpace(fileLines[i]))
                    {
                        // Creates a folder in 'topFolderName' with the name 'lines[i]'
                        pathDownloadFolder = DealWithFilesAndDirs.CreateNewDir(loadedSettings.topLevelFolderDefaultPath, fileLines[i]);
                        // An empty new folder doesnt have any part inside
                        counterForDownloadedParts = 0;
                        counterPartsRemainingForOtherRoute = Convert.ToInt32(loadedSettings.iterationNumber);
                        view.MostrarFeedback(" New Folder: \t" + pathDownloadFolder + Environment.NewLine);
                    }
                }
            }
            view.MostrarFeedback("\t\t PROGRAM END" + Environment.NewLine);
        }

        /*
         * Ejecuta la descarga
         */
        public static void ExecuteDownload(Settings loadedSettings, ChromeDriver driver, Interface view, string pathDownloadFolder, int counterForDownloadedParts)
        {
            DealWithThreads.goToSafeSleep(7, view, driver);     // Wait for the web loading
            //Realizo el click de la descarga
            // asegurarse de que la ventana esta en primer plano
            DealWithMouse.MakeLeftClick(loadedSettings.personalisedRoutes[1].route[0].mousePosition);
            if (DealWithThreads.CloseThisThread(view, driver)) return;
            // The program waits until a new file is founded in the folder
            view.MostrarFeedback("Esperando a que termine la descarga: " + pathDownloadFolder + ", y: " + counterForDownloadedParts);
            DealWithFilesAndDirs.WaitDownloadEnd(pathDownloadFolder, counterForDownloadedParts, view);
            view.MostrarFeedback(" La descarga a terminado, wait");
            DealWithThreads.goToSafeSleep(180, view, driver);     // Wait for the download load
            view.MostrarFeedback(" Todo terminado");
            if (driver != null)
            {
                // WebDriverException
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Quit();  // Close the web page and the cmd windows    
            }  
        }

        /*    !!! PERFECTAMENTE SE PUEDE REEMPLAZAR POR 'StartPersonalised()'!!!
         *      !!! este modulo debe asegurarse de que la ventana
         *          esta en primer plano antes de realizar el click !!!
         * Modulo que se encarga de reiniciar el router
         */
        public static void StartResetRouter(PersonalisedRoute RRR, Interface view)
        {
            try
            {
                var driver = DealWithChrome.OpenWeb("", "http://192.168.1.1/");
                //driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30));

                for (int i = 0; i < RRR.route.Count; i++)
                {
                    // raton
                    if (RRR.route[i].actionType == 1)
                    {
                        view.MostrarFeedback("\t Paso " + i + ".\t mouse");
                        DealWithMouse.MakeLeftClick(RRR.route[i].mousePosition);
                    }
                    // texto.
                    else if (RRR.route[i].actionType == 2)
                    {
                        view.MostrarFeedback("\t Paso " + i + ".\t Introducir texto: \t");
                        SendKeys.SendWait(RRR.route[i].texto);
                    }
                    else if (RRR.route[i].actionType == 3)
                    {
                        view.MostrarFeedback("\t Paso " + i + ".\t Espera: \t");
                        //System.Threading.Thread.Sleep(Convert.ToInt32(RRR[i].waitTime) * 1000);
                        DealWithThreads.goToSafeSleep(Convert.ToInt32(RRR.route[i].waitTime), view, driver);
                    }
                }

                driver.Manage().Cookies.DeleteAllCookies();
                driver.Quit();
            }
            catch (Exception ex)
            {
                // NullReferenceException
                view.MostrarFeedback("\t Ha petao, controlalo \t");
                //throw ex;
            }

        }


    }
}
