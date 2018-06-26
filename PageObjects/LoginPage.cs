using Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace PageObjects
{
  public class LoginPage : PageBase
  {
    #region WEB ELEMENTS 

    [FindsBy(How = How.Id, Using = "Bugzilla_login")]
    private IWebElement txtLogin { get; set; }

    [FindsBy(How = How.Id, Using = "Bugzilla_password")]
    private IWebElement txtPassword { get; set; }

    [FindsBy(How = How.Id, Using = "log_in")]
    private IWebElement btnLogin { get; set; }


    public LoginPage(IWebDriver _driver) : base(_driver)
    {
      callingPageTitle = "";
    }

    #endregion

    #region ACTIONS
    public BugDetailsPage Login(string userName, string password)
    {
      txtLogin.SendKeys(userName);
      txtPassword.SendKeys(password);
      btnLogin.Click();
      return new BugDetailsPage(Driver.Instance);
    }

    #endregion
  }
}