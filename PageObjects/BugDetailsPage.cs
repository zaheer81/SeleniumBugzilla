using Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace PageObjects
{
  public class BugDetailsPage : PageBase
  {
    #region ELEMENTS & CONSTRUCTORS

    [FindsBy(How = How.Id, Using = "component")]
    private IWebElement txtComponent { get; set; }

    [FindsBy(How = How.Id, Using = "version")]
    private IWebElement txtVersion { get; set; }

    [FindsBy(How = How.Id, Using = "bug_severity")]
    private IWebElement ddlSeverity { get; set; }

    [FindsBy(How = How.Id, Using = "rep_platform")]
    private IWebElement ddlHardware { get; set; }

    [FindsBy(How = How.Id, Using = "op_sys")]
    private IWebElement ddlOS { get; set; }

    [FindsBy(How = How.Id, Using = "short_desc")]
    private IWebElement txtSummary { get; set; }

    [FindsBy(How = How.Id, Using = "comment")]
    private IWebElement txtDescription { get; set; }

    [FindsBy(How = How.Id, Using = "commit")]
    private IWebElement btnSubmitBug { get; set; }


    public BugDetailsPage(IWebDriver _driver) : base(_driver)
    {
      callingPageTitle = "Enter Bug";
    }
    #endregion


    #region NAVIGATIONS

    #endregion

    #region ACTIONS

    public bool IsProductExist(string _productName)
    {
      var productList = Driver.Instance.FindElements(By.LinkText(_productName));

      return productList.Count ==1;
    }
    public BugDetailsPage SelectAProduct(string _productName)
    {
      var productList = Driver.Instance.FindElements(By.LinkText(_productName));
      if (productList.Count == 1)
      {
        productList[0].Click();
        return new BugDetailsPage(Driver.Instance);
      }
      else
        return null;
    }
    public void SubmitBug(string _summary) //, string _comp = null, string _version = null
    {
      txtSummary.SendKeys(_summary);
      btnSubmitBug.Click();
    }
    #endregion
  }
}