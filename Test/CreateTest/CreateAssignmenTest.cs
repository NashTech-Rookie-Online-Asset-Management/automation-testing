using AssetManagement.Core.Helper;
using AssetManagement.Models;
using AssetManagement.Models.Create;
using AssetManagement.Page;
using AssetManagement.Page.CreatePage;
using AssetManagement.Test.AssetManagement.Core.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Test.CreateTest
{
    public class CreateAssignmenTest :BaseTest
    {
        private LoginPage _loginPage;
        private BasePage _basePage;
        private CreateAssignmentPage _assignmentCreatePage;
        private string login_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url");
        private string createassignment_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "assignment_url");

        [SetUp]
        public void PageSetUp()
        {
            _loginPage = new LoginPage();
            _basePage = new BasePage();
            _assignmentCreatePage = new CreateAssignmentPage(); 
        
        }


        [Test, Description("Create Asset ")]
        [TestCase("admin_account", "create_assignment")]
        //[TestCase("admin_account2", "create_asset3")]


        public void TC1_CreateAssignmenttSuccessfully(string accountKey,string assignmenKey)
        {
            Account account = AccountData[accountKey];
            AssignMentCreate assignment = AssignmentCreateData[assignmenKey];
  
            ExtentReportHelper.LogTestStep("Go to Login page");
            DriverHelper.NavigateTo(login_url);

            ExtentReportHelper.LogTestStep("Enter valid account");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();
            _loginPage.VerifyLoginSucess();

            ExtentReportHelper.LogTestStep("Go to CreateAssignment Page");
            DriverHelper.NavigateTo(createassignment_url);


            ExtentReportHelper.LogTestStep("Create new Asset");
            _assignmentCreatePage.FillAssignmenInformation(assignment);

            //ExtentReportHelper.LogTestStep("Verify create new Asset successfully");

        }
    }
}
