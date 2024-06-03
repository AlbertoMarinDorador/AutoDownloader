using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace autodownloader
{
    class ClickWebButton
    {
        //------------------------------------SELENIUM--------------------------------------------
        //------------------------------------DOESNT WORK--------------------------------------------
        [STAThread]
        static void Main()
        {
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddUserProfilePreference("download.default_directory", @"C:\DIRECTORIO PRUEBAS\");
            chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            var driver = new ChromeDriver(@"C:\ChromeDriver\", chromeOptions);
            driver.Navigate().GoToUrl("http://www.twitter.es");
            System.Threading.Thread.Sleep(10000);
            //var element1 = driver.FindElement(By.ClassName("submit btn primary-btn flex-table-btn js-submit")); // works for your case.
            //var element2 = driver.FindElement(By.Id("closeButton"));Inloggen
            driver.FindElement(By.LinkText("Inloggen")).Click();
            //driver.FindElement(By.ClassName("submit")).Click();


        }

    }
}
