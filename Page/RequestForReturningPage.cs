using AssetManagement.Core;
using AssetManagement.Core.Helper;
using AssetManagement.Page.AuthenticationPage;
using OpenQA.Selenium;
using static System.Net.Mime.MediaTypeNames;


namespace AssetManagement.Page
{
    public class RequestForReturningPage : BasePage
    {
        private WebObject _txtSearchRequestList = new WebObject(By.XPath("//input[@data-id='input-search']"));
        private WebObject _btnState = new WebObject(By.XPath("//button[@role='combobox']"));
        private WebObject _dllState(string state) { return new WebObject(By.XPath($"//div[@role='group']//button[text()='{state}']")); }

        private WebObject _svgOpenMenu = new WebObject(By.XPath("//span[text()='Open menu']/parent::button"));
        private WebObject _ddlCompleteRequest = new WebObject(By.XPath("//div[text()='Complete request']"));
        private WebObject _ddlCancelRequest = new WebObject(By.XPath("//div[text()='Cancel request']"));

        private WebObject _btnAccept = new WebObject(By.XPath("//button[@data-id='yes-button']"));
        private WebObject _btnCancel = new WebObject(By.XPath("//button[@data-id='no-button']"));

        private WebObject _msgCancelReturningRequest = new WebObject(By.XPath("//div[contains(text(),'Cancelled returning request')]"));
        private WebObject _msgCompleteReturningRequest = new WebObject(By.XPath("//div[contains(text(),'Cancelled returning request')]"));

        private WebObject _rowEmpty = new WebObject(By.XPath("//td[text()='No requests to display.']"));
        private WebObject _statusState = new WebObject(By.CssSelector("tbody>tr:last-child>td:nth-child(8)>p"));
        private WebObject _btnSortNumber = new WebObject(By.CssSelector("thead>tr>th:first-child>button"));
        public void CompleteReturningRequest(string codeSearch, string state)
        {
            _txtSearchRequestList.EnterText(codeSearch);
            _btnState.ClickOnElement();
            _dllState(state).ClickOnElement();
            _btnState.ClickOnElement();
            _svgOpenMenu.ClickOnElement();
            _ddlCompleteRequest.ClickOnElement();
            _btnAccept.ClickOnElement();

        }

        public void CancelReturningRequest(string codeSearch, string state)
        {
          
            _txtSearchRequestList.EnterText(codeSearch);
            _btnState.ClickOnElement();
            _dllState(state).ClickOnElement();
            _btnState.ClickOnElement();
            DriverHelper.Wait(3000);
            _svgOpenMenu.ClickOnElement();
            _ddlCancelRequest.ClickOnElement();
            _btnAccept.ClickOnElement();
        }


        public void VerifyReturningRequestSuccessfully(string codeSearch, string state)
        {
            
            _rowEmpty.ClickOnElement();
            var text = _rowEmpty.GetTextFromElement();
            Assert.That(text, Is.EqualTo("No requests to display."));


        }

    }
}
