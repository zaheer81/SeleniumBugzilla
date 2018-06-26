
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using PageObjects;
using System;
using System.Collections.Generic;
using Common;

namespace Tests.NUnitTests 
{
   [TestFixture]
    class LoginPageTests_UsingNUnit : ProjectInitialisation4NUnit
    {
        #region TestData
        private static  IEnumerable<TestCaseData> InvalidLoginCredentials()
        {
            yield return new TestCaseData(UserName, "IncorrectPassword");
            yield return new TestCaseData("nonExistingUser", Password);
        }

      /* static object[] InvalidLoginCredentials =
      {
            new object[] {UserName, "incorrectPassword"},
            new object[] {"invalidUser", Password },
            new object[] {"invalidUser", "incorrectPassword" }
        };*/

        private static IEnumerable<TestCaseData> ValidLoginCredentials()
        {
            yield return new TestCaseData(UserName, Password);
            yield return new TestCaseData("ahmadzaheer@gmail.com", Password);
            yield return new TestCaseData("test@test.com", Password); // this cause failure be
            //yield return new TestCaseData(UserName, "incorrectPassword");
        }

        #endregion


        [TestCaseSource("ValidLoginCredentials")]
        [Category("Positive")]
        public void NUNIT_Can_User_Login_Using_Correct_Login_Credentials(string userName, string pwd)
        {
            Pages.MainPage.GoTo();
            Pages.MainPage.Login(userName, pwd);

            //Assert.IsTrue(Pages.HomePage.IsAt(), "User is failed to login with following valid credentials" + 
              //  "\n User Name:\t"+ userName +"\n Password:\t" +  pwd);
            //Assert.IsTrue(Pages.MainPage.GoTo().Login(UserName, Password).IsAt(), "Failed to Login");            

             Assert.Multiple(() =>
             {
                 // Reference link https://github.com/nunit/docs/wiki/Multiple-Asserts
                 // All failed assertion will be reported at the end of block. 
                 if (Users.IsUserInAdminGroup(userName))
                 {
                     Assert.IsTrue(Pages.HomePage.IsAt(), "FOR ADMIN - First Assertion FAILED");
                     Assert.IsTrue(Pages.HomePage.IsAt(), "FOR ADMIN - Second Assertion FAILED");
                 }
                 else
                 {
                     Assert.AreEqual("Bugzilla Main Page", Pages.MainPage.Title, "FOR NON ADMIN - First Assertion FAILED");
                     Assert.AreEqual("Bugzilla Main Page", Pages.MainPage.Title, "FOR NON ADMIN - Second Assertion FAILED");
                 }
             });
        }


        [TestCaseSource("InvalidLoginCredentials")]
        [Category("Negative")]
        public void NUNIT_Cannot_Login_Using_Incorect_Credentials( string userName, string pwd)
        {
            Assert.IsFalse(Pages.MainPage.GoTo().Login(userName, pwd).IsAt(), 
                "User was able to login with following invalid credentials. \n User Name:\t"+ userName +"\n Password:\t" +  pwd);
        }

        [TearDown]
        public void TearDown()
        {
            //var currentContext = TestContext.CurrentContext;
            //var message = TestContext.CurrentContext.Result.Message;
            //var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            if (CurrentContext.Result.Outcome != ResultState.Success)
            {
                var testName = CurrentContext.Test.Name;

                Console.WriteLine(testName + " :           FAILED");
                
            }
            else
                Pages.Header.Logout();
        }


    }
}
