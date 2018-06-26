using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.Common
{
  public class Header : PageBase
  {
    #region ELEMENTS & CONSTRUCTORS
    [FindsBy(How = How.XPath, Using = "//div[@id='header']//a[contains(text(), 'Log')]")]
    public IWebElement lnkLogout { get; set; }

    [FindsBy(How = How.LinkText, Using = "//li[@id='new_account_container_top']/a")]
    private IWebElement lnkNewAccount { get; set; }
    public Header(IWebDriver _driver) : base(_driver)
    {

    }
    #endregion

    public void Logout()
    {
      if (lnkLogout != null)
        lnkLogout.Click();
    }

  }
}
