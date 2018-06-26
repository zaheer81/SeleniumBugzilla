using NUnit.Framework;
using Common;
using Common.Configuration;

namespace Tests.NUnitTests
{
    [SetUpFixture]
    public class ProjectInitialisation4NUnit
    {
        private TestContext _currentContext;
        public TestContext CurrentContext
        {
            get { return TestContext.CurrentContext; }
            set { _currentContext = value; }
        }

        public static string UserName
        {
            get
            {
                return AppConfigReader.GetUserName();
            }
        }

        public static string Password
        {
            get
            {
                return AppConfigReader.GetPassword();
            }
        }

        public string Product
        {
            get
            {
                return AppConfigReader.GetProductName();
            }
        }

        [OneTimeSetUp]
            public static void ProjectInit()
            {
                Driver.Initilize();
            }

            [OneTimeTearDown]
            public static void ProjectCleanup()
            {
                //Driver.CloseWindow();
            }
        }
    }
