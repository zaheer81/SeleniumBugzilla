using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObjects;
using System.Collections.Generic;

namespace Tests
{
  [TestClass]
  public class LoginTests_UsingMSTEST : MotherTest
  {
        //private static IEnumerable<object[]> InvalidLoginCredentials
        //{
        //    get
        //    {
        //        return new[]
        //        {
        //        new object[] { string.Empty, string.Empty },
        //        new object[] { string.Empty, Password },
        //        new object[] { UserName, string.Empty },
        //        new object[] { UserName, "IncorrectPassword" },
        //        new object[] { "nonExistingUser", Password }
        //        }
        //    };
        //}
        private static IEnumerable<object[]> InvalidLoginCredentials()
        {
                return new[]
                {
                    new object[] { UserName, "IncorrectPassword" },
                    new object[] { "nonExistingUser", Password },
                    new object[] { "nonExistingUser", "incorrectPWD" }
                };
        }

        [TestMethod]
    public void Can_User_Login_Using_Correct_Login_Credentials()
    {    
      Pages.MainPage.GoTo();
      Pages.MainPage.Login(UserName, Password);
      Assert.IsTrue(Pages.HomePage.IsAt(), "Failed to login");     
      //Assert.IsTrue(Pages.MainPage.GoTo().Login(UserName, Password).IsAt(), "Failed to Login");
      
      //Clean up specific for this test.
      Pages.Header.Logout();
    }

    [TestMethod]
    [DynamicData("InvalidLoginCredentials", DynamicDataSourceType.Method)]
    public void Cannot_Login_Using_Incorect_Credentials(string user, string pwd)
    {
      //string incorrectUserName = "abc";
      //string incorrectPassword = "123";
      
      Assert.IsFalse(Pages.MainPage.GoTo().Login(user, user).IsAt(), "Logged in with incorrect password");
      //Assert.IsFalse(Pages.MainPage.GoTo().Login(incorrectUserName, Password).IsAt(), "Logged in with incorrect user name");
      //Assert.IsFalse(Pages.MainPage.GoTo().Login(incorrectUserName, incorrectPassword).IsAt(), "Logged in with incorrect user name and password");
    }
    [TestCleanup]
    public void Cleanup()
    {
      //if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
      //Pages.Header.Logout();
    }
  }
}
