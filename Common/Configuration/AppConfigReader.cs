using System;
using System.Configuration;


namespace Common.Configuration
{
  public class AppConfigReader
  {
    public static BrowserType GetBrowser()
    {
      string browser = ConfigurationManager.AppSettings.Get("Browser");
      return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
    }

    public static string GetURL()
    {
      return ConfigurationManager.AppSettings.Get("BaseURL");
    }

    public static string GetUserName()
    {
      return ConfigurationManager.AppSettings.Get("User");
    }
    public static string GetPassword()
    {
      return ConfigurationManager.AppSettings.Get("Password");
    }

    public static string GetProductName()
    {
      return ConfigurationManager.AppSettings.Get("Product");
    }
  }
}
