using AssetManagement.Core.Helper;
using AssetManagement.Page.AuthenticationPage;
using AssetManagement.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManagement.Models;
using AssetManagement.Test.AssetManagement.Core.Test;

namespace AssetManagement.Test
{
    public class RequestReturningTest : BaseTest
    {
        private LoginPage _loginPage;
        private BasePage _basePage;
        private RequestForReturningPage _requestForReturningPage;
        private string login_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url");
        private string login_url_dev = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url_dev");


        [SetUp]
        public void PageSetUp()
        {
            _loginPage = new LoginPage();
            _basePage = new BasePage();
            _requestForReturningPage = new RequestForReturningPage();
        }

        [Test, Description("Admin complete returning request")]
        //[TestCase("admin_account_dev", "LP000049", "Waiting for returning")]
        [TestCase("admin_account", "KB000005", "Waiting for returning")]

        public void TC1_AdminCompleteReturningRequest(string accountKey, string codeSearch, string state)
        {
            Account account = AccountData[accountKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            //DriverHelper.NavigateTo(login_url_dev);
            DriverHelper.NavigateTo(login_url);

            ExtentReportHelper.LogTestStep("Enter valid account");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();

            ExtentReportHelper.LogTestStep("Go to RequestForReturning Page");
            _basePage.GoToRequestForReturnPage();
            _requestForReturningPage.CompleteReturningRequest(codeSearch, state);

            ExtentReportHelper.LogTestStep("Verify Returning Request successfully");
            _requestForReturningPage.VerifyReturningRequestSuccessfully(codeSearch, state);

        }


        [Test, Description("Admin cancel returning request")]
        //[TestCase("admin_account_dev", "LP000049", "Waiting for returning")]
        [TestCase("admin_account", "KB000001", "Waiting for returning")]


        public void TC2_AdminCancelReturningRequestd(string accountKey, string codeSearch, string state)
        {
            Account account = AccountData[accountKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            //DriverHelper.NavigateTo(login_url_dev);
            DriverHelper.NavigateTo(login_url);

            ExtentReportHelper.LogTestStep("Enter valid account");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();

            ExtentReportHelper.LogTestStep("Go to RequestForReturning Page");
            _basePage.GoToRequestForReturnPage();
            _requestForReturningPage.CancelReturningRequest(codeSearch,state);

            ExtentReportHelper.LogTestStep("Verify Cancel Returning Request successfully");
            _requestForReturningPage.VerifyReturningRequestSuccessfully(codeSearch, state);

        }
    }
}
