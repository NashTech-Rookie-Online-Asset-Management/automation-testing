using AssetManagement.Core.Helper;
using AssetManagement.Models;
using AssetManagement.Page;
using AssetManagement.Page.AuthenticationPage;
using AssetManagement.Test.AssetManagement.Core.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Test.UserManagementTest
{
    public class ChangePasswordTest : BaseTest
    {
        private LoginPage _loginPage;
        private BasePage _basePage;
        private ChangePasswordPage _changePasswordPage;
        private string login_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url");
        private string login_url_dev = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url_dev");


        [SetUp]
        public void PageSetUp()
        {
            _loginPage = new LoginPage();
            _basePage = new BasePage();
            _changePasswordPage = new ChangePasswordPage();
        }

        [Test, Description("Log in with valid account")]
        [TestCase("valid_account_dev")]

        public void TC1_ChangePasswordStaff(string accountKey)
        {
            Account account = AccountData[accountKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            DriverHelper.NavigateTo(login_url_dev);
            DriverHelper.NavigateTo(login_url);

            ExtentReportHelper.LogTestStep("Enter valid account");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();
            _basePage.GoToChangePassword();
            
            ExtentReportHelper.LogTestStep("ChangepassWord");
            _changePasswordPage.ChangePassWord(account);
               
            ExtentReportHelper.LogTestStep("Login with new passWord successfully");
            _basePage.Logout();
            _loginPage.Login(account.username,account.newpassword);
            _loginPage.ClickLoginButton();

            ExtentReportHelper.LogTestStep("Login with new passWord successfully");
            _basePage.VerifyMenuDropDown();

        }


    }
}
