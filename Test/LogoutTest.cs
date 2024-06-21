using AssetManagement.Core;
using AssetManagement.Core.Helper;
using AssetManagement.Models;
using AssetManagement.Page;
using AssetManagement.Test.AssetManagement.Core.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Test
{


    public class LogoutTest : BaseTest
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
        [TestCase("valid_account1")]
        public void TC_LogouSucceced(string accountKey)
        {
            Account account = AccountData[accountKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            DriverHelper.NavigateTo(login_url);

            ExtentReportHelper.LogTestStep("Enter valid account");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();

            ExtentReportHelper.LogTestStep("Logout ");
            _basePage.Logout();

            ExtentReportHelper.LogTestStep("Verify logout successfully");
            Assert.That(_loginPage.getTitleText, Is.EqualTo("Login"));


        }
    }

}





