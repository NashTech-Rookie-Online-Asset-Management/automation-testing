using AssetManagement.Constant;
using AssetManagement.Core;
using AssetManagement.Core.Helper;
using AssetManagement.Extensions;
using AssetManagement.Models;
using AssetManagement.Models.Create;
using AssetManagement.Models.Edit;

namespace AssetManagement.Test
{
    namespace AssetManagement.Core.Test
    {
        [TestFixture]
        public class BaseTest
        {
            protected Dictionary<string, Account> AccountData;
            protected Dictionary<string, AssetCreate> AssetCreateData;
            protected Dictionary<string, UserCreate> UserCreateData;
            protected Dictionary<string, AssetEdit> AssetEditData;



            [SetUp]
            public void SetUp()
            {

                AccountData = JsonHelper.ReadAndParse<Dictionary<string, Account>>(FileConstant.AccountFilePath.GetAbsolutePath());
                AssetCreateData = JsonHelper.ReadAndParse<Dictionary<string, AssetCreate>>(FileConstant.AssetFilePath.GetAbsolutePath());
                UserCreateData = JsonHelper.ReadAndParse<Dictionary<string, UserCreate>>(FileConstant.UserFilePath.GetAbsolutePath());
                AssetEditData = JsonHelper.ReadAndParse<Dictionary<string, AssetEdit>>(FileConstant.AssetEditFilePath.GetAbsolutePath());




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
