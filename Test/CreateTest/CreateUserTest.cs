using AssetManagement.Core.Helper;
using AssetManagement.DataProvider;
using AssetManagement.Models;
using AssetManagement.Models.Create;
using AssetManagement.Page;
using AssetManagement.Test.AssetManagement.Core.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Test.CreateTest
{
    public class CreateUserTest : BaseTest
    {
        private LoginPage _loginPage;
        private BasePage _basePage;
        private ManangeUserPage _manageUserPage;
        private CreateUserPage _createUserPage;
        private string login_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url");

        [SetUp]
        public void PageSetUp()
        {
            _loginPage = new LoginPage();
            _basePage = new BasePage();
            _manageUserPage = new ManangeUserPage();
            _createUserPage = new CreateUserPage();
        }


        [Test, Description("Create User")]
        [TestCase("admin_account", "create_user1")]
        //[TestCase("admin_account2", "create_user2")]
        //[TestCase("admin_account", "create_user3")]
        //[TestCase("admin_account", "create_user4")]
        //[TestCase("admin_account", "create_user5")]

        public void TC1_CreateUserSuccessfully(string accountKey, string userKey)
        {
            Account account = AccountData[accountKey];
            UserCreate user = UserCreateData[userKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            DriverHelper.NavigateTo(login_url);

            ExtentReportHelper.LogTestStep("Enter valid account");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();


            ExtentReportHelper.LogTestStep("Go to ManageUserPage");
            _manageUserPage.GoToManageUserPage();

            ExtentReportHelper.LogTestStep("Create new User");
            _createUserPage.CreateUser(user);

            ExtentReportHelper.LogTestStep("Verify create new User successfully");
            _manageUserPage.AssertUserDetails(user);
        }

        [Test, Description("Create User")]
        [TestCase("admin_account")]
        public void TC2_CreateUserSuccessfully(string accountKey)
        {
            Account account = AccountData[accountKey];
            UserCreate user = UserDataGenerator.GenerateSingleUser();

            ExtentReportHelper.LogTestStep("Go to Login page");
            DriverHelper.NavigateTo(login_url);

            ExtentReportHelper.LogTestStep("Enter valid account");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();

            ExtentReportHelper.LogTestStep("Go to ManageUserPage");
            _manageUserPage.GoToManageUserPage();

            ExtentReportHelper.LogTestStep("Create new User");
            _createUserPage.CreateUser(user);

            ExtentReportHelper.LogTestStep("Verify create new User successfully");
            _manageUserPage.AssertUserDetails(user);
        }
    }
}
