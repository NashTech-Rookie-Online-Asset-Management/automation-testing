
using AssetManagement.Core;
using AssetManagement.Core.Helper;
using AssetManagement.Models.Create;

using OpenQA.Selenium;


namespace AssetManagement.Page
{
    public class ManangeUserPage : BasePage
    {

        private WebObject _rowVerifyUser = new WebObject(By.CssSelector("tbody>tr:first-child"));

        private WebObject _firstrowStaffCodeUser = new WebObject(By.CssSelector("tbody>tr:first-child>td:first-child"));



        public string GetUserDetail(string label)
        {
            WebObject detailElement = new WebObject(By.XPath($"//p[text()='{label}']/following-sibling::p"));
            return detailElement.GetTextFromElement();
        }

        public void AssertUserDetails(UserCreate expectedUser)
        {
            _rowVerifyUser.ClickOnElement();
            var _expectedStaffCode = _firstrowStaffCodeUser.GetTextFromElement();
            string expectedFullName = $"{expectedUser.firstName} {expectedUser.lastName}";
            Assert.AreEqual(_expectedStaffCode, GetUserDetail("Staff Code"), "Staff Code does not match.");
            Assert.AreEqual(expectedFullName, GetUserDetail("Full Name"), "Full name does not match.");
            Assert.AreEqual(StringHelper.FormatDate(expectedUser.dateOfBirth), GetUserDetail("Date of Birth"), "Date of birth does not match.");
            Assert.AreEqual(expectedUser.gender, GetUserDetail("Gender").ToLower(), "Gender does not match.");
            Assert.AreEqual(StringHelper.FormatDate(expectedUser.joinedDate), GetUserDetail("Joined Date"), "Joined date does not match.");
            Assert.AreEqual(expectedUser.type, GetUserDetail("Type"), "Type does not match.");
        }


    

    }
}

