using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using Common;
using Common.Configuration;
using System;

namespace PageObjects
{
  public class MainPage : PageBase
  {
   
    #region WEB ELEMENTS

    [FindsBy(How = How.LinkText, Using = "Log In")]
    private  IWebElement lnkLogin { get; set; }

    [FindsBy(How = How.Name, Using = "Bugzilla_login")]
    private  IWebElement txtLogin { get; set; }

    [FindsBy(How = How.Name, Using = "Bugzilla_password")]
    private  IWebElement txtPassword { get; set; }

    [FindsBy(How = How.Id, Using = "log_in_top")]
    private  IWebElement btnLogin { get; set; }

    [FindsBy(How = How.Id, Using = "enter_bug")]
    private IWebElement lnkFileABug { get; set; }

     public MainPage(IWebDriver _driver): base(_driver)
    {
        callingPageTitle = "Bugzilla Main Page";
            //PageFactory.InitElements(_driver, this);
    }
    #endregion

    #region PROPERTIES


    #endregion

    #region ACTIONS 

    public HomePage Login(string userName, string password)
    {
      lnkLogin.Click();
      txtLogin.SendKeys(userName);
      txtPassword.SendKeys(password);
      btnLogin.Click();
      return new HomePage(Driver.Instance);
    }
    #endregion

    #region NAVIGATIONS
    public MainPage GoTo()
    {
      Driver.Instance.Navigate().GoToUrl(AppConfigReader.GetURL());
      return new MainPage(Driver.Instance);

    }

    public LoginPage ClickFileABugLink()
    {
      lnkFileABug.Click();
      return new LoginPage(Driver.Instance);
    }

    #endregion
  }

}
