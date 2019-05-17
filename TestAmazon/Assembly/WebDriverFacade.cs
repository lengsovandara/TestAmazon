using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAmazon.Assembly
{
    public static class WebDriverFacade
    {
        private static IWebDriver webDriver;
        private static string baseURL = "https://www.amazon.co.uk/";
        public static void Init()
        {
            webDriver = new ChromeDriver();         
            webDriver.Manage().Window.Maximize();
            Goto(baseURL);
        }
        public static string Tittle { get { return webDriver.Title; } }
        public static IWebDriver getDriver { get { return webDriver; } }
        public static void Goto(string url)
        {
            webDriver.Url = url;
        }
        public static void Close()
        {
            webDriver.Quit();
        }

        //extensions method;
        
        public static bool ControlExists(this IWebDriver driver, By by)
        {
            return driver.FindElements(by).Count == 0 ? false : true;
        }
        public static bool ControlDisplayed(this IWebElement element, uint timeoutInSeconds = 60)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(Exception));
            return wait.Until(drv =>
            {
                if(element.Displayed)
                {                   
                    return true;
                }
                return false;
            });
        }
        public static IWebElement WaitUntilElementExists(this By Locator, uint timeoutInSeconds = 60)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutInSeconds));               
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(Locator));
            }
            catch
            {
                return null;
            }
        }
        public static bool ElementIsClickable(this IWebElement element, uint timeoutSeconds =60)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutSeconds));
                return wait.Until(driv =>
                {
                    if (SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element) != null)
                    {
                        return true;
                    }
                    return false;
                });

            }
            catch { return false; }
        }
        public static void ClickWrapper(this IWebElement element, string elementName)
        {
            if (element.ElementIsClickable())
            {
                element.Click();
            }
            else
            {
                throw new Exception(string.Format("[{0}] - Element [{1}] is not displayed", DateTime.Now.ToString("HH:mm:ss.fff"), elementName));
            }
        }  
    }
}
