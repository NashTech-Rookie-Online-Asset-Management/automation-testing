using AssetManagement.Core;
using AssetManagement.Core.Helper;
using AssetManagement.Models;
using AssetManagement.Page;
using AssetManagement.Page.AuthenticationPage;
using AssetManagement.Test.AssetManagement.Core.Test;


namespace AssetManagement.Test.UserManagementTest
{


    public class LogoutTest : BaseTest
    {

        private LoginPage _loginPage;
        private BasePage _basePage;
        private string login_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url");
        private string login_url_dev = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url_dev");


        [SetUp]
        public void PageSetUp()
        {
            _loginPage = new LoginPage();
            _basePage = new BasePage();
        }

        [Test, Description("Logout successfully flow")]
        [TestCase("admin_account_dev")]
        public void TC_LogouSucceced(string accountKey)
        {
            Account account = AccountData[accountKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            DriverHelper.NavigateTo(login_url_dev);

            ExtentReportHelper.LogTestStep("Enter valid account");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();

            ExtentReportHelper.LogTestStep("Go to Logout ");
            _basePage.Logout();

            ExtentReportHelper.LogTestStep("Verify logout successfully");
            Assert.That(_loginPage.getTitleText, Is.EqualTo("Login"));


        }
    }

}





