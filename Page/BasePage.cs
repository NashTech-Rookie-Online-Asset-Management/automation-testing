
using AngleSharp.Dom;
using AssetManagement.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace AssetManagement.Page
{
    public class BasePage
    {
        private WebObject _txtHeader = new WebObject(By.XPath("//h4[text()='Online Asset Management']"));
        private WebObject _mnuUserMenu = new WebObject(By.XPath("//button[@data-id='header-dropdown']"));
        private WebObject _btnLogoutMenu = new WebObject(By.XPath("//span[text()='Logout']"));
        private WebObject _btnLogoutConfirm = new WebObject(By.XPath("//span[text()='Log out']"));
        private WebObject _btnChangepasswordMenu = new WebObject(By.XPath("//span[text()='Change password']"));

        private WebObject _tabHome = new WebObject(By.XPath("//li[text()='Home']"));
        private WebObject _tabManageUser = new WebObject(By.XPath("//a[@data-id='side-bar-manage-user']"));
        private WebObject _tabManageAsset = new WebObject(By.XPath("//li[text()='Manage Asset']"));
        private WebObject _tabManageAssignment = new WebObject(By.XPath("//li[text()='Manage Assignment']"));
        private WebObject _tabRequestForReturn = new WebObject(By.XPath("//li[text()='Request for Returning']"));
        private WebObject _tabReport = new WebObject(By.XPath("//li[text()='Report']']"));
       
        private WebObject _tabButton(string tabName) { return new WebObject(By.XPath($"//li[text()='{tabName}']")); }

        private WebObject _lblChangePassword = new WebObject(By.XPath("//h2[text()='Change Password']"));
        private WebObject _lblFirstChangePassword = new WebObject(By.XPath("//div[@class='pb-4']"));

        public void GoToLogout()
        {
            _mnuUserMenu.ClickOnElement();
            _btnLogoutMenu.ClickOnElement();


        }
        public void GoToChangePassword()
        {
            _mnuUserMenu.ClickOnElement();
            _btnChangepasswordMenu.ClickOnElement();

        }

        public string VerifyPopupChangePassword()
        {
            return _lblChangePassword.GetTextFromElement();
        }



        public void Logout()
        {
            GoToLogout();
            _btnLogoutConfirm.ClickOnElement();
        }

        public void GoToHomePage()
        {
            _tabHome.ClickOnElement();
        }

        public void GoToManageUserPage()
        {
       
            _tabManageUser.ClickOnElement();

        }

        public void GoToManageAssetPage()
        {
            _tabManageAsset.ClickOnElement();
        }

        public void GoToManageAssignmentPage()
        {
            _tabManageAssignment.ClickOnElement();
        }

        public void GoToRequestForReturnPage()
        {
            _tabRequestForReturn.ClickOnElement();
        }

        public void GoToReportPage()
        {
            _tabReport.ClickOnElement();
        }

        public bool CheckLoggedInAsStaff()
        {
            _tabButton("Home").WaitForElementToBeVisible();
            return (!_tabButton("Manage User").CheckElementExistWithoutWait() &&
                    !_tabButton("Manage Asset").CheckElementExistWithoutWait() &&
                    !_tabButton("Manage Assignment").CheckElementExistWithoutWait() &&
                    !_tabButton("Request For Return").CheckElementExistWithoutWait() &&
                    !_tabButton("Report").CheckElementExistWithoutWait());
        }

    }
}
