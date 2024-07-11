using AssetManagement.Core;
using AssetManagement.Core.Helper;
using AssetManagement.Models.Edit;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AssetManagement.Page.CreatePage
{
    public class CreateRequestPage : BasePage
    {
        private WebObject _txtSearchCreateRequest = new WebObject(By.XPath("//input[@placeholder='Search by name, asset code']"));


        private WebObject _svgOpenMenu = new WebObject(By.XPath("//span[text()='Open menu']/parent::button"));
        private WebObject _dllRequestForReturning = new WebObject(By.XPath("//div[text()='Request for returning']"));


        private WebObject _btnYes = new WebObject(By.XPath("//button[@data-id='returning-assignment-yes-button']"));
        private WebObject _btnNo = new WebObject(By.XPath("//button[@data-id='returning-assignment-no-button']"));


        private WebObject _rowVerifyAssignment = new WebObject(By.CssSelector("tbody>tr:first-child"));

        private WebObject _firstrowAssetCode = new WebObject(By.CssSelector("tbody>tr:first-child>td:first-child"));

        private WebObject _assetCode(string assetCode) { return new WebObject(By.XPath($"//td[.='{assetCode}']/..//button")); }
        private WebObject _rowVerifyAsset(string assetCode) { return new WebObject(By.XPath($"//td[.='{assetCode}']/..")); }

        private WebObject _ddlAccept = new WebObject(By.XPath("//div[text()='Accept']"));
        private WebObject _btnAccept = new WebObject(By.XPath("//button[text()='Accept']"));
        private WebObject _btnClose = new WebObject(By.XPath("//div[@role='dialog']//button"));



        public void AcceptAssignMent(string assetCode)
        {
            _assetCode(assetCode).ClickOnElement();
            _ddlAccept.ClickOnElement();
            _btnAccept.ClickOnElement();
            DriverHelper.Wait(2000);
        }


        public void CreateRequestWithAssetCode(string asssetCode)
        {
            _assetCode(asssetCode).ClickOnElement();
            _dllRequestForReturning.ClickOnElement();
            _btnYes.ClickOnElement();
        }
        public string GetAssetDetail(string label)
        {
            WebObject detailElement = new WebObject(By.XPath($"//p[text()='{label}']/following-sibling::p"));
            return detailElement.GetTextFromElement();
        }

        public void CreateRequestForReturning()
        {
            //_txtSearchCreateRequest.EnterText(code);
            _svgOpenMenu.ClickOnElement();
            _dllRequestForReturning.ClickOnElement();
            _btnYes.ClickOnElement();
        }


        public void VerifyCreateRequestSuccessfully(string codeAsset, string State)
        {



            //_rowVerifyAssignment.ClickOnElement();
            _rowVerifyAsset(codeAsset).ClickOnElement();
            DriverHelper.Wait(3000);
            var _expectedAssetCode = codeAsset;
            
            Assert.AreEqual(_expectedAssetCode, GetAssetDetail("Asset Code"), "Asset Code does not match.");
            Assert.AreEqual(State, GetAssetDetail("State"), "State does not match.");
            _btnClose.ClickOnElement();

        }

    }
}

