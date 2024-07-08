using AssetManagement.Core.Helper;
using AssetManagement.Page.AuthenticationPage;
using AssetManagement.Page;
using AssetManagement.Test.AssetManagement.Core.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManagement.Models;
using AssetManagement.Page.CreatePage;

namespace AssetManagement.Test.CreateTest
{
    public class CreateRequestTest : BaseTest
    {
        private LoginPage _loginPage;
        private BasePage _basePage;
        private CreateRequestPage _createRequestPage;
        private string login_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url");
        private string login_url_dev = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url_dev");


        [SetUp]
        public void PageSetUp()
        {
            _loginPage = new LoginPage();
            _basePage = new BasePage();
            _createRequestPage = new CreateRequestPage();
        }

        [Test, Description("Users Create Request successfully")]
        [TestCase("admin_account_dev2", "LP000049", "Waiting for returning")]
        public void TC1_CreateRequestSuccessfully(string accountKey,string codeSearch,string state)
        {
            Account account = AccountData[accountKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            DriverHelper.NavigateTo(login_url_dev);
            //DriverHelper.NavigateTo(login_url);

            ExtentReportHelper.LogTestStep("Enter valid account");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();

            ExtentReportHelper.LogTestStep("Create Request For Returning");
            //_createRequestPage.CreateRequestForReturning();
            _createRequestPage.CreateRequestWithAssetCode(codeSearch);


            ExtentReportHelper.LogTestStep("Verify Create Request successfully");
            _createRequestPage.VerifyCreateRequestSuccessfully(codeSearch,state);

        }
    }
}
