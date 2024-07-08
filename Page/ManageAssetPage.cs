using AngleSharp.Dom;
using AssetManagement.Core;
using AssetManagement.Core.Helper;
using AssetManagement.Models.Create;
using AssetManagement.Models.Edit;
using AventStack.ExtentReports.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Page
{
    public class ManageAssetPage : BasePage
    {
        private WebObject _rowVerifyAsset = new WebObject(By.CssSelector("tbody>tr:first-child"));
        private WebObject _txtSearchAsset = new WebObject(By.XPath("//input[@placeholder='Search by name, asset code']"));
        
        private WebObject _svgOpenMenu = new WebObject(By.XPath("//span[text()='Open menu']/parent::button"));
        private WebObject _svgEdit = new WebObject(By.XPath("//a[@role='menuitem']"));
        private WebObject _svgDelete = new WebObject(By.XPath("//div[@role='menuitem']"));
        private WebObject _btnDelete = new WebObject(By.XPath("//button[@data-id='delete-button']"));

        private WebObject _btnClose = new WebObject(By.XPath("//div[@role='dialog']//button"));
        private WebObject _firstrowAssetCodeEdit = new WebObject(By.CssSelector("tbody>tr:first-child>td:first-child"));
        private WebObject _msgEditSuccessfully = new WebObject(By.XPath("//div[text()='Successfully edited asset KB000001']"));



        private WebObject msgEditSuccessfully(string assetCode) { return new WebObject(By.XPath($"//div[text()='Successfully edited asset {assetCode}']")); }


        public string GetAssetDetail(string label)
        {
            WebObject detailElement = new WebObject(By.XPath($"//p[text()='{label}']/following-sibling::p"));
            return detailElement.GetTextFromElement();
        }

        public void GoToEditAssetPage(AssetEdit assetData)
        {
            DriverHelper.Wait(2000);
            _txtSearchAsset.EnterText(assetData.assetCode);
            DriverHelper.Wait(3000);

            //Thread.Sleep(2000);
            _svgOpenMenu.ClickOnElement();
            _svgEdit.ClickOnElement();

            //Thread.Sleep(3000);

        }


        public void DeleteNewAssetCreate()
        {
            var _expectedCodeAsset = _firstrowAssetCodeEdit.GetTextFromElement();
            _txtSearchAsset.EnterText(_expectedCodeAsset);
            DriverHelper.Wait(3000);
            _svgOpenMenu.ClickOnElement();
            _svgDelete.ClickOnElement();
            _btnDelete.ClickOnElement();


        }
        public void AssertAssetCreateDetails(AssetCreate expectedAsset)
        {
            _rowVerifyAsset.ClickOnElement();
            Assert.AreEqual(expectedAsset.Name, GetAssetDetail("Asset Name"), "Asset Name does not match.");
            Assert.AreEqual(expectedAsset.Category, GetAssetDetail("Category"), "Category does not match.");
            Assert.AreEqual(StringHelper.FormatDate(expectedAsset.InstalledDate), GetAssetDetail("Installed Date"), "Installed date does not match.");
            Assert.AreEqual(expectedAsset.State, GetAssetDetail("State"), "State does not match.");
            Assert.AreEqual(expectedAsset.Specification, GetAssetDetail("Specification"), "Specification does not match.");
            _btnClose.ClickOnElement();
        }


        public void AssertAssetEditDetails(AssetEdit expectedAsset)
        {
            _rowVerifyAsset.ClickOnElement();

            // Assert Popup message Edit Successfully
            WebObject successMessage = msgEditSuccessfully(expectedAsset.assetCode);
            Assert.IsTrue(successMessage.IsElementDisplayed(), "The success message was not displayed.");

            string expectedMessage = $"Successfully edited asset {expectedAsset.assetCode}";
            DriverHelper.Wait(3000);
            Assert.AreEqual(expectedMessage, successMessage.GetTextFromElement(), "The success message text was not correct.");
            //Thread.Sleep(3000);
            // Assert Detail Diaglog Infomation 
            Assert.AreEqual(expectedAsset.assetCode, GetAssetDetail("Asset Code"), "Asset Code does not match.");
            Assert.AreEqual(expectedAsset.Name, GetAssetDetail("Asset Name"), "Asset Name does not match.");
            Assert.AreEqual(StringHelper.FormatDate(expectedAsset.InstalledDate), GetAssetDetail("Installed Date"), "Joined date does not match.");
            Assert.AreEqual(expectedAsset.State, GetAssetDetail("State"), "State does not match.");
            Assert.AreEqual(expectedAsset.Specification, GetAssetDetail("Specification"), "Specification does not match.");
        }

    }
}

