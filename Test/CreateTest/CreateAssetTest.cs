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
    public class CreateAssetTest : BaseTest
    {
        private LoginPage _loginPage;
        private BasePage _basePage;
        private ManageAssetPage _manageAssetPage;
        private CreateAssetPage _createAssetPage;
        private string login_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url");
        private string login_url_dev = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url_dev");


        [SetUp]
        public void PageSetUp()
        {
            _loginPage = new LoginPage();
            _basePage = new BasePage();
            _manageAssetPage = new ManageAssetPage();
            _createAssetPage = new CreateAssetPage();
        }


        [Test, Description("Create Asset ")]
        [TestCase("admin_account_dev", "create_asset3")]
        //[TestCase("admin_account2", "create_asset3")]


        public void TC1_CreateAssetSuccessfully(string accountKey, string assetKey)
        {
            Account account = AccountData[accountKey];
            AssetCreate asset2 = AssetDataGenerator.GenerateSingleAsset();
            //AssetCreate asset = AssetCreateData[assetKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            //DriverHelper.NavigateTo(login_url);
            DriverHelper.NavigateTo(login_url_dev);

            ExtentReportHelper.LogTestStep("Enter valid account");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();

            ExtentReportHelper.LogTestStep("Go to ManageAssetPage");
            _basePage.GoToManageAssetPage();

            ExtentReportHelper.LogTestStep("Create new Asset");
            _createAssetPage.CreateAsset(asset2);

            ExtentReportHelper.LogTestStep("Verify create new Asset successfully");
            _manageAssetPage.AssertAssetCreateDetails(asset2);
            _manageAssetPage.DeleteNewAssetCreate();
        }
    }
}
