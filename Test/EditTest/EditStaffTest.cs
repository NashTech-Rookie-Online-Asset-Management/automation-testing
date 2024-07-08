using AssetManagement.Core.Helper;
using AssetManagement.Models.Edit;
using AssetManagement.Page.EditPage;
using AssetManagement.Page;
using AssetManagement.Models;
using AssetManagement.Test.AssetManagement.Core.Test;
using AssetManagement.Models.Create;
using AssetManagement.Page.AuthenticationPage;

namespace AssetManagement.Test.EditTest
{
    public class EditStaffTest :BaseTest
    {
        private LoginPage _loginPage;
        private BasePage _basePage;
        private ManangeUserPage _manageUserPage;
        private EditStaffPage _editStaffPage;
        private string login_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url");
        private string login_url_dev = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url_dev");

        [SetUp]
        public void PageSetUp()
        {
            _loginPage = new LoginPage();
            _basePage = new BasePage();
            _manageUserPage = new ManangeUserPage();
            _editStaffPage = new EditStaffPage();
        }


        [Test, Description("Edit Staff ")]
        [TestCase("admin_account_dev", "edit_usercode")]
        public void TC1_EditStaffSuccessfully(string accountKey, string staffKey)
        {
            Account account = AccountData[accountKey];
            
            StaffEdit staffEdit = StaffEditData[staffKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            DriverHelper.NavigateTo(login_url_dev);

            ExtentReportHelper.LogTestStep("Enter valid account");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();

            ExtentReportHelper.LogTestStep("Go to EditUserPage");
            _basePage.GoToManageUserPage();
            _manageUserPage.GoToEditStaffPage(staffEdit);


            ExtentReportHelper.LogTestStep("Edit Asset");
            _editStaffPage.EditStaff(staffEdit);

            ExtentReportHelper.LogTestStep("Verify edit Asset successfully");
            _manageUserPage.AssertEditUserDetails(staffEdit);
        }
    }
}
