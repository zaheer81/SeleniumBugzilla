using System;
using OpenQA.Selenium.Support.PageObjects;
using Common;
using OpenQA.Selenium;

namespace PageObjects
{
  public class HomePage : PageBase
  {
    //private static string PageTitle = "Welcome to Bugzilla";

    public HomePage(IWebDriver _driver) : base(_driver)
    {
      callingPageTitle = "Welcome to Bugzilla";
    }

    #region PROPERTIES 

    #endregion
    
  }
}