using AssetManagement.Core.Helper;
using AssetManagement.DataProvider;
using AssetManagement.Models;
using AssetManagement.Models.Create;
using AssetManagement.Page;
using AssetManagement.Page.AuthenticationPage;
using AssetManagement.Page.CreatePage;
using AssetManagement.Test.AssetManagement.Core.Test;


namespace AssetManagement.Test.CreateTest
{
    public class CreateUserTest : BaseTest
    {
        private LoginPage _loginPage;
        private BasePage _basePage;
        private ManangeUserPage _manageUserPage;
        private CreateUserPage _createUserPage;
        private string login_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url");
        private string login_url_dev = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url_dev");

        [SetUp]
        public void PageSetUp()
        {
            _loginPage = new LoginPage();
            _basePage = new BasePage();
            _manageUserPage = new ManangeUserPage();
            _createUserPage = new CreateUserPage();
        }


        [Test, Description("Create User")]
        [TestCase("admin_account_dev", "create_user1")]  

        public void TC1_CreateUserSuccessfully(string accountKey, string userKey)
        {
            Account account = AccountData[accountKey];
            UserCreate user = UserCreateData[userKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            //DriverHelper.NavigateTo(login_url);
            DriverHelper.NavigateTo(login_url_dev);

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
        [TestCase("admin_account_dev")]

        public void TC2_CreateUserSuccessfully(string accountKey)
        {
            Account account = AccountData[accountKey];
            UserCreate user = UserDataGenerator.GenerateSingleUser();

            ExtentReportHelper.LogTestStep("Go to Login page");
            //DriverHelper.NavigateTo(login_url);
            DriverHelper.NavigateTo(login_url_dev);


            ExtentReportHelper.LogTestStep("Enter valid account");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();

            ExtentReportHelper.LogTestStep("Go to ManageUserPage");
            _manageUserPage.GoToManageUserPage();

            ExtentReportHelper.LogTestStep("Create new User");
            _createUserPage.CreateUser(user);

            ExtentReportHelper.LogTestStep("Verify create new User successfully");
            _manageUserPage.AssertUserDetails(user);
            _manageUserPage.DisabledNewUserCreate();
        }
    }
}
