using AngleSharp.Dom;
using AssetManagement.Core;
using AssetManagement.Models;
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
        private WebObject _txtName = new WebObject(By.XPath("//input[@name='name']"));
        private WebObject _ddlCategory = new WebObject(By.Id("open_category_list_btn"));
        private WebObject _txaSpecification = new WebObject(By.XPath("//textarea[@name='specification']"));
        private WebObject _dtpInstallDate = new WebObject(By.XPath("//input[@name='installedDate']"));
        private WebObject _btnState = new WebObject(By.XPath("//button[@value='AVAILABLE']"));
        private WebObject _btnSave = new WebObject(By.XPath("//button[text()='Save']"));
        private WebObject _btnCancel = new WebObject(By.XPath("//a[text()='Cancel']"));
        
        
        private WebObject _btnCreateAsset = new WebObject(By.XPath("//a[text()='Create new asset']"));


        private WebObject Category(string category) { return new WebObject(By.XPath($"//span[text()='{category}']")); }
        private WebObject State(string state) { return new WebObject(By.XPath($"//button[@value='{state.ToUpper()}']")); }


        public void CreateAsset(Asset assetData)
        {
            _btnCreateAsset.ClickOnElement();
            EnterName(assetData.Name);
            SelectCatergory(assetData.Category);
            EnterSpecification(assetData.Specification);
            SelectInstallDated(assetData.InstalledDate);
            SelectState(assetData.State);
            _btnCancel.ClickOnElement();

        }

        public void EnterName(string name)
        {
            _txtName.EnterText(name);
        }

        public void SelectCatergory(string catergory)
        {
            _ddlCategory.ClickOnElement();
            Category(catergory).ClickOnElement();
        }
        public void EnterSpecification(string specification)
        {
            _txaSpecification.EnterText(specification);
        }
        public void SelectInstallDated(string installDated)
        {
            _dtpInstallDate.EnterText(installDated);
        }
        public void SelectState(string state)
        {
            State(state).ClickOnElement();
            //IWebElement elem = DriverCommand.FindElements(By.CssSelector("tr td").[0]
        }

    }
}

