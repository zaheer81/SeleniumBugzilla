using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using Common.Configuration;

namespace Tests
{
  [TestClass]
  public class MotherTest
  {
    private TestContext _testContext;
    public TestContext TestContext
    {
      get { return _testContext; }
      set { _testContext = value; }
    }

    protected static string UserName
    {
      get
      {
        return AppConfigReader.GetUserName();
      }
    }

    protected static string Password
    {
      get
      {
        return AppConfigReader.GetPassword();
      }
    }

    protected string Product
    {
      get
      {
        return AppConfigReader.GetProductName();
      }
    }

    [AssemblyInitialize]
    public static void ProjectInit(TestContext tc)
    {
      Driver.Initilize();
    }

    [AssemblyCleanup]
    public static void ProjectCleanup()
    {
      Driver.CloseWindow();
    }
  }
}
