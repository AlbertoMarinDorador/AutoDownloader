using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace autodownloader
{
    class OpenWebAndChangeDir
    {
        [STAThread]
        static void Main()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", @"C:\DIRECTORIO PRUEBAS\");
            chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            var driver = new ChromeDriver(@"C:\ChromeDriver\", chromeOptions);
            driver.Navigate().GoToUrl("http://www.google.es");

        }
    }
}
