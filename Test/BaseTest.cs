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
            protected Dictionary<string, Asset> AssetData;

            [SetUp]
            public void SetUp()
            {
                
                AccountData = JsonHelper.ReadAndParse<Dictionary<string, Account>>(FileConstant.AccountFilePath.GetAbsolutePath());
                AssetData = JsonHelper.ReadAndParse<Dictionary<string, Asset>>(FileConstant.AssetFilePath.GetAbsolutePath());
               
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








}
