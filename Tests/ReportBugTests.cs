using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObjects;
using Common;

namespace Tests
{
  [TestClass]
  public class ReportBugTests : MotherTest
  {
    private static string bugSummary; 


    [TestMethod]
    public void Can_File_A_Bug()
    {
      bugSummary = "Report a bug";

      Pages.MainPage.GoTo().
        ClickFileABugLink().
        Login(UserName, Password).
        SelectAProduct(Product).
        SubmitBug(bugSummary);

      Assert.IsTrue(Pages.Footer.NavigateToMyBugsList().IsBugReported(bugSummary), "Failed to find the submitted bug");
    }

    [TestCleanup]
    public void Delete_Bug()
    {
        Pages.Header.Logout();
           if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
           {
               Bug.Delete(bugSummary);
           }
    }

  }
}

