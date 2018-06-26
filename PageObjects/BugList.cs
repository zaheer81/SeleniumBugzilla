using Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
  public class BugList : PageBase
  {
    #region ELEMENTS & CONSTRUCTOR
    #endregion

    [FindsBy(How = How.XPath, Using = "//td[@class = 'bz_short_desc_column']/a")]
    private IList<IWebElement> bugSummaries { get; set; }

    public BugList(IWebDriver _driver ):base(_driver)
    {
      callingPageTitle = "Bug List";
    }

    #region ACTIONS

    public bool IsBugReported(string _summary)
    {
      //string xPath = "//td[@class = 'bz_short_desc_column']/a[contains(text(),'" +_summary +"')]";

      //var bugSummaries = Driver.Instance.FindElements(By.XPath(xPath));

      bool bugFound = false;

      if (bugSummaries.Count > 0)
      {
        foreach (var summary in bugSummaries)
        {
        //  string bugSummary = summary.Text;
          if (summary.Text.Equals(_summary, System.StringComparison.OrdinalIgnoreCase))
          {
            bugFound = true;
            break;
          }
        }
      }
      return bugFound;
    }
    #endregion


    #region NAVIGATIONS
    #endregion
    
  }
}