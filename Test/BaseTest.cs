using AssetManagement.Constant;
using AssetManagement.Core;
using AssetManagement.Core.Helper;
using AssetManagement.Extensions;
using AssetManagement.Models;

namespace AssetManagement.Test
{
    namespace AssetManagement.Core.Test
    {
        [TestFixture]
        public class BaseTest
        {
            protected Dictionary<string, Account> AccountData;

            [SetUp]
            public void SetUp()
            {
                AccountData = JsonHelper.ReadAndParse<Dictionary<string, Account>>(FileConstant.AccountFilePath.GetAbsolutePath());
                string browser = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "browser");

                ExtentReportHelper.CreateTest(TestContext.CurrentContext.Test.ClassName);
                ExtentReportHelper.CreateNode(TestContext.CurrentContext.Test.Name);
                ExtentReportHelper.LogTestStep("Initialize webdriver");

                //string browser = "chrome";

                DriverManager.InitDriver(browser);
                DriverManager.driver.Manage().Window.Maximize();
                DriverManager.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                DriverManager.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(100);
            }

            [TearDown]
            public void TearDown()
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

                ExtentReportHelper.CreateTestResult(status, stacktrace, TestContext.CurrentContext.Test.ClassName, TestContext.CurrentContext.Test.Name, DriverManager.driver);
                ExtentReportHelper.Flush();
                DriverManager.driver.Quit();
            }


        }
    }




    //string enviroment = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "enviroment");
    //string functionName = TestContext.CurrentContext.Test.MethodName;

    ////Create folder "TestResults"
    //string projectDirectory = Directory.GetCurrentDirectory();
    //string testResultsDirectory = Path.Combine(projectDirectory, "TestResults");
    //Directory.CreateDirectory(testResultsDirectory);

    ////Create subfolder by Test Class's name
    //string testClassName = TestContext.CurrentContext.Test.ClassName;
    //string classNameWithoutNamespace = testClassName.Substring(testClassName.LastIndexOf('.') + 1);

    //string classTestDirectory = Path.Combine(testResultsDirectory, classNameWithoutNamespace);
    //Directory.CreateDirectory(classTestDirectory);

    ////Create subfolder by Test Case's name
    //string functionTestDirectory = Path.Combine(classTestDirectory, $"Result_{date}_{functionName}");
    //Directory.CreateDirectory(functionTestDirectory);


    //string reportPath = Path.Combine(functionTestDirectory, "result.html");


    //ExtentReportHelper.InitializeReport(reportPath, "DemoQA", enviroment, browser);
    //ExtentReportHelper.CreateTest(TestContext.CurrentContext.Test.ClassName);
    //ExtentReportHelper.CreateNode(TestContext.CurrentContext.Test.Name);
    //ExtentReportHelper.LogTestStep("Initialize webdriver");





}
