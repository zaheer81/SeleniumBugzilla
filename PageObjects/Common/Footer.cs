using Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace PageObjects.Common
{

  #region ELEMENTS & CONSTRUCTOR
  public class Footer : PageBase
  {
    [FindsBy(How = How.XPath, Using = "//div[@id='footer']//a[contains(text(), 'Log')]")]
    private IWebElement lnkLogout { get; set; }

    [FindsBy(How = How.XPath, Using = "//li[@id='new_account_container_bottom']/a")]
    private IWebElement lnkNewAccount { get; set; }

    [FindsBy(How = How.LinkText, Using = "My Bugs")]
    private IWebElement lnkMyBugs { get; set; }

    public Footer(IWebDriver _driver) : base(_driver)
    {

    }

    #endregion

    #region ACTIONS

    public void Logout()
    {
      if (lnkLogout != null)
        lnkLogout.Click();
    }

    #endregion

    #region NAVIGATIONS

    public BugList NavigateToMyBugsList()
    {
      lnkMyBugs.Click();
      return new BugList(Driver.Instance);
    }
    #endregion  
  }
}
