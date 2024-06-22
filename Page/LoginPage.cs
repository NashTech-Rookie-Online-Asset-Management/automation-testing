
using AssetManagement.Constant;
using AssetManagement.Core;
using OpenQA.Selenium;


namespace AssetManagement.Page
{
    public class LoginPage
    {
        private WebObject _txtUserName = new WebObject(By.XPath("//input[@name='username']"));
        private WebObject _txtPassword = new WebObject(By.XPath("//input[@name='password']"));
        private WebObject _btnLogin = new WebObject(By.XPath("//button[text()='Login']"));
        private WebObject _msgIncorrectMessage = new WebObject(By.XPath("//div[@class='relative']/following-sibling::p"));
        private WebObject _titleHomePage = new WebObject(By.XPath("//h1[text()='Home']"));
        private WebObject _titleLogin = new WebObject(By.CssSelector("h3"));

        public void Login(string username, string password)
        {
            _txtUserName.EnterText(username);
            _txtPassword.EnterText(password);
        }

        public string getIncorrecUsernamePasswordMessage()
        {
            return _msgIncorrectMessage.GetTextFromElement();
        }

        public string getTitleText()
        {
            return _titleLogin.GetTextFromElement();
        }

        public bool IsLoginButtonEnabled()
        {
            return _btnLogin.WaitForElementToBeVisible().Enabled;
        }

        public void ClickLoginButton()
        {
            _btnLogin.ClickOnElement();
        }


    }
}
