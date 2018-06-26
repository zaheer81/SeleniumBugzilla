using OpenQA.Selenium.Support.PageObjects;
using Common;
using PageObjects.Common;

namespace PageObjects
{
  public class Pages
  {
    #region PROPERTIES
    public static Header Header
    {
      get
      {
        return new Header(Driver.Instance);
      }
    }
    public static Footer Footer
    {
      get
      {
        return new Footer(Driver.Instance);
      }
    }
    public static MainPage MainPage => new MainPage(Driver.Instance);
        /*{
          get
          {
            return new MainPage(Driver.Instance);
          }
        }*/
    public static HomePage HomePage => new HomePage(Driver.Instance);
        /*}
        {
          get
          { return new HomePage(Driver.Instance);}
        }*/

        //public static BugDetailsPage Login { get; set; }
        #endregion
    }
}
