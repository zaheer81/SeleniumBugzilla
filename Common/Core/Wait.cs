using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Common.Core
{
   public class Wait
    {
        private readonly TimeSpan DEFAULT_TIMEOUT = new TimeSpan(0, 0, 15);
        //private readonly int DEFAULT_SLEEP = 5000;
        //private static final String INIT_MESSAGE = "INIT ELEMENT";
        //private static final String INIT_ERROR_MESSAGE = "PROBLEM WITH ELEMENT INIT";
        //private static final String ELEMENT_PRESENT_MESSAGE = "ELEMENT PRESENT";
        //private static final String ELEMENT_PRESENT_ERROR_FORMAT = "PROBLEM WITH FINDING ELEMENT %s"

        private WebDriverWait wait;
        private IWebDriver driver;
        public Wait(IWebDriver webDriver)
        {
            this.driver = webDriver;
            this.wait = new WebDriverWait(webDriver, DEFAULT_TIMEOUT);
            //this.sleepingWait = new WebDriverWait(webDriver, DEFAULT_TIMEOUT, DEFAULT_SLEEP);
        }
        public IWebElement ForElementVisible(By locator)
        {
            try
            {
                return wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (WebDriverTimeoutException e)
            {
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IWebElement ForElementClickable(IWebElement element)
        {
            try
            {
                return wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }            
            catch (NoSuchElementException e)
            {
                throw e;
            }
        }
        public IWebElement ForElementClickable(By locator)
        {
            try
            {
                return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (NoSuchElementException e)
            {
                throw e;
            }
        }

        public bool ForElementInvisible(By locator)
        {
            try
            {
                return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
            }
            catch (WebDriverTimeoutException e)
            {
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool ForElementStaleness(IWebElement element )
        {
            try
            {
                return wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (WebDriverTimeoutException e)
            {
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
    }
}
