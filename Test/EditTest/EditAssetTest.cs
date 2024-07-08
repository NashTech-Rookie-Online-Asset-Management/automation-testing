using AssetManagement.Core.Helper;
using AssetManagement.Models;
using AssetManagement.Models.Edit;
using AssetManagement.Page;
using AssetManagement.Page.AuthenticationPage;
using AssetManagement.Page.EditPage;
using AssetManagement.Test.AssetManagement.Core.Test;


namespace AssetManagement.Test.EditTest
{
    public class EditAssetTest : BaseTest
    {
        private LoginPage _loginPage;
        private BasePage _basePage;
        private ManageAssetPage _manageAssetPage;
        private EditAssetPage _editAssetPage;
        private string login_url = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url");
        private string login_url_dev = ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "login_url_dev");


        [SetUp]
        public void PageSetUp()
        {
            _loginPage = new LoginPage();
            _basePage = new BasePage();
            _manageAssetPage = new ManageAssetPage();
            _editAssetPage = new EditAssetPage();
        }


        [Test, Description("Edit Asset ")]
        [TestCase("admin_account_dev", "edit_assetcode")]
        public void TC1_EditAssetSuccessfully(string accountKey, string assetKey)
        {
            Account account = AccountData[accountKey];
            AssetEdit assetEdit = AssetEditData[assetKey];

            ExtentReportHelper.LogTestStep("Go to Login page");
            DriverHelper.NavigateTo(login_url_dev);

            ExtentReportHelper.LogTestStep("Enter valid account");
            _loginPage.Login(account.username, account.password);
            _loginPage.ClickLoginButton();

            ExtentReportHelper.LogTestStep("Go to EditAssetPage");
            _basePage.GoToManageAssetPage();
            _manageAssetPage.GoToEditAssetPage(assetEdit);


            ExtentReportHelper.LogTestStep("Edit Asset");
            _editAssetPage.EditAsset(assetEdit);

            ExtentReportHelper.LogTestStep("Verify edit Asset successfully");
            _manageAssetPage.AssertAssetEditDetails(assetEdit);
        }
    }
}

