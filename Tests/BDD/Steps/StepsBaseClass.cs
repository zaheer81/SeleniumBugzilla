using Common;
using Common.Configuration;
using TechTalk.SpecFlow;

namespace Tests.BDD.Steps
{
    [Binding]
    public class StepsBaseClass
    {
        /*private ScenarioContext _currentContext;
        public ScenarioContext CurrentContext
        {
            get { return ScenarioContext.Current; }
            set { _currentContext = value; }
        }*/
        

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

        [BeforeFeature]
        public static void ProjectInit()
        {
            Driver.Initilize();
        }


        [AfterFeature]
        public static void ProjectCleanup()
        {
            Driver.CloseWindow();
        }
    }
}

