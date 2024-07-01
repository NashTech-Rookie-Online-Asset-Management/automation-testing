using AssetManagement.Core;
using AssetManagement.Models.Create;
using AssetManagement.Models.Edit;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace AssetManagement.Page.EditPage
{
    public class EditAssetPage : BasePage
    {


        private WebObject _txtName = new WebObject(By.XPath("//input[@name='name']"));
        private WebObject _txaSpecication = new WebObject(By.XPath("//textarea[@name='specification']"));
        private WebObject _dtpInstallDate = new WebObject(By.XPath("//input[@name='installedDate']"));

        private WebObject State(string state) { return new WebObject(By.XPath($"//label[text()='{state}']")); }


        private WebObject _btnSave = new WebObject(By.XPath("//button[@type='submit']"));
        private WebObject _btnCancel = new WebObject(By.XPath("//a[text()='Cancel']"));



        public void EnterName(string Name)
        {
            _txtName.EnterValue(Name);
        }
        public void EnterSpecification(string specification)
        {
            _txaSpecication.EnterValue(specification);
        }

        public void SelectInstallDated(string installDated)
        {
            _dtpInstallDate.EnterText(installDated);
        }
        public void SelectState(string state)
        {
            State(state).ClickOnElement();
        }

        public void ClickSaveButton()
        {
            _btnSave.ClickOnElement();
        }

        public void EditAsset(AssetEdit assetData)
        {
            EnterName(assetData.Name);
            EnterSpecification(assetData.Specification);
            SelectInstallDated(assetData.InstalledDate);
            SelectState(assetData.State);
            //_btnCancel.ClickOnElement();
            ClickSaveButton();

        }



    }
}
