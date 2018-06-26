using Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace PageObjects
{
  public class PageBase
  {
    protected static string callingPageTitle { get; set; }
   
    public PageBase(IWebDriver _driver)
    {
      PageFactory.InitElements(_driver, this);
    }
    public string Title
    {
      get
      {
        return Driver.Instance.Title;
      }
    }

    public bool IsAt()
    {
      return Title.Contains(callingPageTitle);
    }
  }
}
