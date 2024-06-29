using AssetManagement.Core;
using AssetManagement.Models.Create;
using OpenQA.Selenium;


namespace AssetManagement.Page
{
    public class CreateAssetPage: BasePage
    {
        private WebObject _txtName = new WebObject(By.XPath("//input[@name='name']"));
        private WebObject _ddlCategory = new WebObject(By.Id("open_category_list_btn"));
        private WebObject _txaSpecification = new WebObject(By.XPath("//textarea[@name='specification']"));
        private WebObject _dtpInstallDate = new WebObject(By.XPath("//input[@name='installedDate']"));
        private WebObject _btnSave = new WebObject(By.XPath("//button[text()='Save']"));
        private WebObject _btnCancel = new WebObject(By.XPath("//a[text()='Cancel']"));


        private WebObject _btnCreateAsset = new WebObject(By.XPath("//a[text()='Create new asset']"));


        private WebObject Category(string category) { return new WebObject(By.XPath($"//span[text()='{category}']")); }
        private WebObject State(string state) { return new WebObject(By.XPath($"//label[text()='{state}']")); }


        public void CreateAsset(AssetCreate assetData)
        {
            _btnCreateAsset.ClickOnElement();
            EnterName(assetData.Name);
            SelectCatergory(assetData.Category);
            EnterSpecification(assetData.Specification);
            SelectInstallDated(assetData.InstalledDate);
            SelectState(assetData.State);
            _btnSave.ClickOnElement();
            Thread.Sleep(2000);

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
           
        }

    }
}
