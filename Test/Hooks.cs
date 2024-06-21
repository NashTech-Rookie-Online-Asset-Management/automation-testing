using AssetManagement.Core;
using AssetManagement.Core.Helper;
using Microsoft.Extensions.Configuration;


namespace AssetManagement.Test
{

    [SetUpFixture]
    public class Hooks
    {
        public static IConfiguration Config;

        const string AppSettingPath = "Configurations\\appsettings.json";

        [OneTimeSetUp]
        public void MySetup()
        {
            TestContext.Progress.WriteLine("====> Global one time setup");

            // Read Configuration file
            Config = ConfigurationHelper.ReadConfiguration(AppSettingPath);
            string browser = ConfigurationHelper.GetConfigurationByKey(Config, "browser");
            string enviroment = ConfigurationHelper.GetConfigurationByKey(Config, "enviroment");

            // Create report path dynamically
            string date = DateTime.Now.ToString("ddMMMMMyyyy_HHmm");
            string projectDirectory = Directory.GetCurrentDirectory();
            string testResultsDirectory = Path.Combine(projectDirectory, "TestResults");
            Directory.CreateDirectory(testResultsDirectory);

            //string testClassName = TestContext.CurrentContext.Test.ClassName;
            //string classNameWithoutNamespace = testClassName.Substring(testClassName.LastIndexOf('.') + 1);

            string functionTestDirectory = Path.Combine(testResultsDirectory, $"ResultTest{date}");
            Directory.CreateDirectory(functionTestDirectory);

            string reportPath = Path.Combine(functionTestDirectory, "result.html");

            ExtentReportHelper.InitializeReport(reportPath, "Hostname", enviroment, browser);
        }
        
    }

}






