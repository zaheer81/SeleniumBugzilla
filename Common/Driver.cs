using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using Common.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.PhantomJS;
using Common.CustomExceptions;
using TestAutomationEssentials.Selenium;

namespace Common
{
  public class Driver
    {
        public static IWebDriver Instance { get; set; }
        public static void Initilize()
        {

            switch (AppConfigReader.GetBrowser())
            {
                case BrowserType.Chrome:
                    Instance = new ChromeDriver();
                    break;
                case BrowserType.Firefox:
                    Instance = new FirefoxDriver();
                    break;
                case BrowserType.IE:
                    Instance = new InternetExplorerDriver();
                    break;
                case BrowserType.PhantomJS:
                    Instance = new PhantomJSDriver();
                    break;
                default:
                    throw new NoSuitableDriverFound("Driver not found:  " + AppConfigReader.GetBrowser().ToString());
            }
            //Instance.Manage().Window.Maximize();
        }
        public static void CloseWindow()
        {
            Instance.Close();
        }
        public static void CloseAllWindows()
        {
            Instance.Quit();
        }
  }
}