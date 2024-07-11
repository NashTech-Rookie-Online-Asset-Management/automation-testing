using AssetManagement.Constant;
using AssetManagement.Core;
using AssetManagement.Core.Helper;
using AssetManagement.Models;
using AssetManagement.Page;
using AssetManagement.Page.AuthenticationPage;
using AssetManagement.Test.AssetManagement.Core.Test;
using System.Xml;


namespace AssetManagement.Test.UserManagementTest
{
    public class LoginTest : BaseTest
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

        [Test, Description("Log in with valid account first time")]
        [TestCase("valid_account_dev_TC01")]
        public void TC1_LoginSucceced(string accountKey)
        {
            Account account = AccountData[accountKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            //DriverHelper.NavigateTo(login_url_dev);
            DriverHelper.NavigateTo(login_url);

            ExtentReportHelper.LogTestStep("Enter valid account");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();

            ExtentReportHelper.LogTestStep("Verify login successfully");
            Assert.That(_basePage.VerifyPopupChangePassword(), Is.EqualTo("Change Password"));
            

            
        }

        [Test, Description("Log in with valid account and changepassword first time")]
        //[TestCase("valid_account_dev_TC02")]
        [TestCase("valid_account")]

        public void TC2_LoginSucceced(string accountKey)
        {
            Account account = AccountData[accountKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            //DriverHelper.NavigateTo(login_url_dev);
            DriverHelper.NavigateTo(login_url);


            //Create New Account before running test
            ExtentReportHelper.LogTestStep("Enter valid account");
            _loginPage.LoginFirstTime(account.username, account.password, account.changePassword);
          

            //ExtentReportHelper.LogTestStep("Verify login successfully");
            //_basePage.VerifyMenuDropDown();


            _basePage.Logout();
            _loginPage.Login(account.username, account.changePassword);
            _loginPage.ClickLoginButton();


            ExtentReportHelper.LogTestStep("Verify login successfully");
            _basePage.VerifyMenuDropDown();
        }


        [Test, Description("Log in with missing fields")]
        [TestCase("invalid_accountTC03_1")]
        [TestCase("invalid_accountTC03_2")]

        public void TC3_LoginFailed(string accountKey)

        {
            Account account = AccountData[accountKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            DriverHelper.NavigateTo(login_url);
            //DriverHelper.NavigateTo(login_url_dev);

            ExtentReportHelper.LogTestStep("Enter account with missing username or password");
            _loginPage.Login(account.username, account.password);

            ExtentReportHelper.LogTestStep("Verify login unsuccessfully");
            Assert.That(_loginPage.IsLoginButtonEnabled(), Is.False, "The Login button should be disabled when fields are missing.");

        }


        [Test, Description("Log in with invalid account")]
        [TestCase("invalid_accountTC04")]
        public void TC4_LoginFailed(string accountKey)
        {
            Account account = AccountData[accountKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            DriverHelper.NavigateTo(login_url);
            //DriverHelper.NavigateTo(login_url_dev);

            ExtentReportHelper.LogTestStep("Enter account with invalid username or password");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();

            ExtentReportHelper.LogTestStep("Verify login unsuccessfully");
            Assert.That(_loginPage.getIncorrecUsernamePasswordMessage(), Is.EqualTo("Username or Password is incorrect. Please try again"));
        }
    }
}



