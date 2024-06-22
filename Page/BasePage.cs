
using AssetManagement.Core;
using OpenQA.Selenium;


namespace AssetManagement.Page
{
    public class BasePage
    {
        private WebObject _txtHeader = new WebObject(By.XPath("//h4[text()='Online Asset Management']"));
        private WebObject _txtChangePassword = new WebObject(By.XPath("//h2[text()='Change Password']"));
        private WebObject _ddlUserMenu = new WebObject(By.Id("radix-:R6av5ja:"));
        private WebObject _btnLogoutMenu = new WebObject(By.XPath("//span[text()='Logout']"));
        private WebObject _btnLogoutConfirm = new WebObject(By.XPath("//span[text()='Log out']"));
        private WebObject _btnChangepasswordMenu = new WebObject(By.XPath("//span[text()='Change password']"));




        public void GoToLogout()
        {
            _ddlUserMenu.ClickOnElement();
            _btnLogoutMenu.ClickOnElement();


        }
        public void GoToChangePassword()
        {
            _ddlUserMenu.ClickOnElement();
            _btnChangepasswordMenu.ClickOnElement();

        }

        public string VerifyPopupChangePassword()
        {
            return _txtChangePassword.GetTextFromElement();
        }

        public void Logout()
        {
            GoToLogout();
            _btnLogoutConfirm.ClickOnElement();
        }

        //public void VerifyLoginSuccessfully()
        //{
        //    Assert.That(VerifyUserName(), Is.EqualTo(FileConstant.username));
        //}

    }
}
