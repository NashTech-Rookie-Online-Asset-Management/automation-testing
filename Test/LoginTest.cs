
using AssetManagement.Core.Helper;
using AssetManagement.Models;
using AssetManagement.Page;
using AssetManagement.Test.AssetManagement.Core.Test;



namespace AssetManagement.Test
{
    public class LoginTest : BaseTest
    {

        private LoginPage _loginPage;
        private BasePage _basePage;
        private string login_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url");

        [SetUp]
        public void PageSetUp()
        {
            _loginPage = new LoginPage();
            _basePage = new BasePage();
        }

        [Test, Description("Log in with valid account")]
        [TestCase("valid_account")]
        public void TC1_LoginSucceced(string accountKey)
        {
            Account account = AccountData[accountKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            DriverHelper.NavigateTo(login_url);

            ExtentReportHelper.LogTestStep("Enter valid account");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();

            ExtentReportHelper.LogTestStep("Verify login successfully");
            Assert.That(_basePage.VerifyPopupChangePassword(), Is.EqualTo("Change Password"));

        }

        [Test, Description("Log in with valid account and changepassword first time")]
        [TestCase("valid_account_firsttime")]
        public void TC2_LoginSucceced(string accountKey)
        {
            Account account = AccountData[accountKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            DriverHelper.NavigateTo(login_url);

            ExtentReportHelper.LogTestStep("Enter valid account");
            //_loginPage.LoginFirstTime(account.username, account.password, account.changePassword);
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();
            
            ExtentReportHelper.LogTestStep("Verify login successfully");
            Assert.That(_basePage.CheckLoggedInAsStaff, Is.True);

        }


        [Test, Description("Log in with missing fields")]
        [TestCase("invalid_account1")]
        [TestCase("invalid_account2")]

        public void TC3_LoginFailed(string accountKey)

        {
            Account account = AccountData[accountKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            DriverHelper.NavigateTo(login_url);

            ExtentReportHelper.LogTestStep("Enter account with missing username or password");
            _loginPage.Login(account.username, account.password);
           
            ExtentReportHelper.LogTestStep("Verify login unsuccessfully");
            Assert.That(_loginPage.IsLoginButtonEnabled(), Is.False, "The Login button should be disabled when fields are missing.");
           
        }


        [Test, Description("Log in with invalid account")]
        [TestCase("invalid_account3")]
        public void TC4_LoginFailed(string accountKey)
        {
            Account account = AccountData[accountKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            DriverHelper.NavigateTo(login_url);

            ExtentReportHelper.LogTestStep("Enter account with invalid username or password");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();
            
            ExtentReportHelper.LogTestStep("Verify login unsuccessfully");
            Assert.That(_loginPage.getIncorrecUsernamePasswordMessage(), Is.EqualTo("Username or Password is incorrect. Please try again"));
        }
    }
}



