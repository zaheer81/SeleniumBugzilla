using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Common;
using PageObjects;
using PageObjects.Common;


namespace Tests.BDD.Steps
{
    [Binding]
    public sealed class LoginStepDefinition
    {
        string LoginName = StepsBaseClass.UserName;
        string Password = StepsBaseClass.Password;

        [Given(@"a web browser is at Bugzilla main page")]
        public void GivenAWebBrowserIsAtBugzillaMainPage()
        {
            //Driver.Initilize();
            Pages.MainPage.GoTo();
        }

        [When(@"user enters correct user name and password and clicks login button")]
        public void WhenUserEntersCorrectUserNameAndPasswordAndClicksLoginButton()
        {
            //LoginName = "zaheer@bugzilla.com";
            //LoginName = "test@test.com";
            //Password = "123456";
            Pages.MainPage.Login(LoginName, Password);
            //Pages.MainPage.Login("Test@test.com", "123456"); //Assert for checking Home Page will fail for Test user.
        }

        [Then(@"user is successfully logged in")]
        public void ThenUserIsSuccessfullyLoggedIn()
        {
            if (Users.IsUserInAdminGroup(LoginName))
                Assert.IsTrue(Pages.HomePage.IsAt(), "FOR ADMIN - Home page does not displayed");
            else
                Assert.IsTrue(Pages.MainPage.IsAt(), "FOR NON-ADMIN - Main Page does not displayed");

            //Driver.CloseWindow();
        }
        [When(@"user enters incorrect (.*) and (.*) and clicks login button")]
        public void WhenUserEntersIncorrectAndAndClicksLoginButton(string usrName, string pwd)
        {
            Pages.MainPage.Login(usrName, pwd);
        }

        [Then(@"user is not logged in")]
        public void ThenUserIsNotLoggedIn()
        {
            Assert.Multiple(() =>
            {
                Assert.IsFalse(Pages.HomePage.IsAt(), "FOR ADMIN - User is Logged in with incorrect credentials");
                Assert.IsFalse(Pages.MainPage.IsAt(), "FOR NON-ADMIN - User is Logged in with incorrect credentials");
            });
            
        }


    }
}
