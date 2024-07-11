using AssetManagement.Core.Helper;
using AssetManagement.Page.AuthenticationPage;
using AssetManagement.Page;
using AssetManagement.Test.AssetManagement.Core.Test;
using AssetManagement.Models;
using AssetManagement.Page.CreatePage;
using AssetManagement.Models.Create;

namespace AssetManagement.Test.CreateTest
{
    public class USFlowTest : BaseTest
    {
        private LoginPage _loginPage;
        private BasePage _basePage;
        private CreateAssignmentPage _createAssignmentPage;
        private CreateRequestPage _createRequestPage;
        private RequestForReturningPage _requestForReturningPage;
        private string login_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url");
        private string login_url_dev = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url_dev");


        [SetUp]
        public void PageSetUp()
        {
            _loginPage = new LoginPage();
            _basePage = new BasePage();
            _createRequestPage = new CreateRequestPage();
            _createAssignmentPage = new CreateAssignmentPage();
            _requestForReturningPage = new RequestForReturningPage();
        }

        [Test, Description("Users Create Request successfully")]
        //[TestCase("admin_account_dev", "LP000034", "Waiting for returning", "create_assignment2"
        //        , "test_account_dev")]
        [TestCase("admin_account", "LP000028", "Waiting for returning", "create_assignment2"
                , "test_account")]

        public void TC_USFLowTest(string accountKey, string codeSearch, string state,
                                                  string assignmenKey, string accountKey2)

        {
            Account account = AccountData[accountKey];
            Account account2 = AccountData[accountKey2];
            AssignMentCreate assignment = AssignmentCreateData[assignmenKey];


            ExtentReportHelper.LogTestStep("1. Go to Login page");
            //DriverHelper.NavigateTo(login_url_dev);
            DriverHelper.NavigateTo(login_url);

            ExtentReportHelper.LogTestStep("2. Login with Admin account");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();


            // Create AssignMent
            ExtentReportHelper.LogTestStep("3. Create New Assigment");
            _basePage.GoToManageAssignmentPage();
            _createAssignmentPage.FillAssignmenInformation(assignment);
            _basePage.Logout();

            ExtentReportHelper.LogTestStep("4. Login with user account for accept assignment");
            _loginPage.Login(account2.username, account2.password);
            _loginPage.ClickLoginButton();

            //Accept Assignment
            _createRequestPage.AcceptAssignMent(codeSearch);

            ExtentReportHelper.LogTestStep("5. Create Request For Returning");
            _createRequestPage.CreateRequestWithAssetCode(codeSearch);
            _createRequestPage.VerifyCreateRequestSuccessfully(codeSearch, state);
            _basePage.Logout();

            ExtentReportHelper.LogTestStep("6. Login with Admin account");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();


            // Complete ReturningRequest
            ExtentReportHelper.LogTestStep("7. Admin complete request for returning");
            _basePage.GoToRequestForReturnPage();
            _requestForReturningPage.CompleteReturningRequest(codeSearch, state);
            _requestForReturningPage.VerifyReturningRequestSuccessfully(codeSearch, state);


        }

    }
}
