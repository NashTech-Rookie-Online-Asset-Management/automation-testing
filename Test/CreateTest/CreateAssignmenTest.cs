using AssetManagement.Core.Helper;
using AssetManagement.Models;
using AssetManagement.Models.Create;
using AssetManagement.Page;
using AssetManagement.Page.AuthenticationPage;
using AssetManagement.Page.CreatePage;
using AssetManagement.Test.AssetManagement.Core.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Test.CreateTest
{
    public class CreateAssignmenTest : BaseTest
    {
        private LoginPage _loginPage;
        private BasePage _basePage;
        private CreateAssignmentPage _assignmentCreatePage;
        private ManageAssignmentPage _manageAssignmentPage;
        private string login_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url");
        private string login_url_dev = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url_dev");
        private string createassignment_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "assignment_url_dev");

        [SetUp]
        public void PageSetUp()
        {
            _loginPage = new LoginPage();
            _basePage = new BasePage();
            _assignmentCreatePage = new CreateAssignmentPage();
            _manageAssignmentPage = new ManageAssignmentPage();

        }


        [Test, Description("Create Asset ")]
        [TestCase("admin_account_dev", "create_assignment")]
        //[TestCase("admin_account2", "create_asset3")]



        public void TC1_CreateAssignmenttSuccessfully(string accountKey, string assignmenKey)
        {
            Account account = AccountData[accountKey];
            AssignMentCreate assignment = AssignmentCreateData[assignmenKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            //DriverHelper.NavigateTo(login_url);
            DriverHelper.NavigateTo(login_url_dev);


            ExtentReportHelper.LogTestStep("Enter valid account");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();
            _basePage.VerifyMenuDropDown();

            ExtentReportHelper.LogTestStep("Go to CreateAssignment Page");
            _basePage.GoToManageAssignmentPage();
            //DriverHelper.NavigateTo("https://asset-management-fe-staging.azurewebsites.net/assignments/create");

            ExtentReportHelper.LogTestStep("Create new Asset");
            _assignmentCreatePage.FillAssignmenInformation(assignment);

            ExtentReportHelper.LogTestStep("Verify create new Asset successfully");
            _manageAssignmentPage.AssertAssignmentCreateDetails(assignment);

        }
    }
}
