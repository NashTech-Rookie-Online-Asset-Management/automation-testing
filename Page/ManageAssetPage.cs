
using AssetManagement.Core;
using AssetManagement.Core.Helper;
using AssetManagement.Models.Create;

using OpenQA.Selenium;


namespace AssetManagement.Page
{
    public class ManageAssetPage : BasePage
    {
        private WebObject _rowVerifyAsset = new WebObject(By.CssSelector("tbody>tr:first-child"));
        private WebObject _txtSearchAsset = new WebObject(By.XPath("//input[@placeholder='Search by name, asset code']"));
        private WebObject _svgOpenMenu = new WebObject(By.XPath("//span[text()='Open menu']/parent::button"));
        private WebObject _svgEdit = new WebObject(By.XPath("//a[@role='menuitem']"));
        private WebObject _firstrowAssetCodeEdit = new WebObject(By.CssSelector("tbody>tr:first-child>td:first-child"));
        private WebObject _msgEditSuccessfully = new WebObject(By.XPath("//div[text()='Successfully edited asset KB000001']"));


        private WebObject msgEditSuccessfully(string assetCode) { return new WebObject(By.XPath($"//div[text()='Successfully edited asset {assetCode}']")); }

        
        public string GetAssetDetail(string label)
        {
            WebObject detailElement = new WebObject(By.XPath($"//p[text()='{label}']/following-sibling::p"));
            return detailElement.GetTextFromElement();
        }


        public void AssertAssetCreateDetails(AssetCreate expectedAsset)
        {
            _rowVerifyAsset.ClickOnElement();


            Assert.AreEqual(expectedAsset.Name, GetAssetDetail("Asset Name"), "Asset Name does not match.");
            Assert.AreEqual(expectedAsset.Category, GetAssetDetail("Category"), "Category does not match.");
            Assert.AreEqual(StringHelper.FormatDate(expectedAsset.InstalledDate), GetAssetDetail("Installed Date"), "Installed date does not match.");
            Assert.AreEqual(expectedAsset.State, GetAssetDetail("State"), "State does not match.");
            Assert.AreEqual(expectedAsset.Specification, GetAssetDetail("Specification"), "Specification does not match.");
        }




    }
}

