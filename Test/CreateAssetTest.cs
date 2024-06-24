using AssetManagement.Core.Helper;
using AssetManagement.Models;
using AssetManagement.Page;
using AssetManagement.Test.AssetManagement.Core.Test;

namespace AssetManagement.Test
{
    public class CreateAssetTest : BaseTest
    {
        private LoginPage _loginPage;
        private BasePage _basePage;
        private ManageAssetPage _manageAssetPage;
        private string login_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url");

        [SetUp]
        public void PageSetUp()
        {
            _loginPage = new LoginPage();
            _basePage = new BasePage();
            _manageAssetPage = new ManageAssetPage();
        }


        [Test, Description("Create Asset ")]
        [TestCase("valid_account1", "create_asset")]

        //[TestCase("valid_account1")]

        public void TC1_CreateAssetSuccessfully(string accountKey, string assetKey)
        {
            Account account = AccountData[accountKey];
            Asset asset = AssetData[assetKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            DriverHelper.NavigateTo(login_url);

            ExtentReportHelper.LogTestStep("Enter valid account");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();

            ExtentReportHelper.LogTestStep("Go to ManageAssetPage");
            _basePage.GoToManageAssetPage();
            
            ExtentReportHelper.LogTestStep("Create new Asset");
            _manageAssetPage.CreateAsset(asset);


        }
    }
}
