using AssetManagement.Core.Helper;
using AssetManagement.Models;
using AssetManagement.Models.Create;
using AssetManagement.Page;
using AssetManagement.Test.AssetManagement.Core.Test;

namespace AssetManagement.Test
{
    public class CreateAssetTest : BaseTest
    {
        private LoginPage _loginPage;
        private BasePage _basePage;
        private ManageAssetPage _manageAssetPage;
        private CreateAssetPage _createAssetPage;   
        private string login_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url");

        [SetUp]
        public void PageSetUp()
        {
            _loginPage = new LoginPage();
            _basePage = new BasePage();
            _manageAssetPage = new ManageAssetPage();
            _createAssetPage = new CreateAssetPage();
        }


        [Test, Description("Create Asset ")]
        [TestCase("admin_account", "create_asset")]
        [TestCase("admin_account", "create_asset3")]
        [TestCase("admin_account", "create_asset4")]
        [TestCase("admin_account", "create_asset5")]
        [TestCase("admin_account", "create_asset6")]
        [TestCase("admin_account", "create_asset7")]

       

        public void TC1_CreateAssetSuccessfully(string accountKey, string assetKey)
        {
            Account account = AccountData[accountKey];
            AssetCreate asset = AssetCreateData[assetKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            DriverHelper.NavigateTo(login_url);

            ExtentReportHelper.LogTestStep("Enter valid account");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();

            ExtentReportHelper.LogTestStep("Go to ManageAssetPage");
            _basePage.GoToManageAssetPage();
            
            ExtentReportHelper.LogTestStep("Create new Asset");
            _createAssetPage.CreateAsset(asset);

            ExtentReportHelper.LogTestStep("Verify create new Asset successfully");
            _manageAssetPage.AssertAssetCreateDetails(asset);
        }
    }
}
