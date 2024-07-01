using AngleSharp.Dom;
using AssetManagement.Core;
using AssetManagement.Core.Helper;
using AssetManagement.Models.Create;
using AssetManagement.Models.Edit;
using MongoDB.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Page
{
    public class ManangeUserPage : BasePage
    {

        private WebObject _rowVerifyUser = new WebObject(By.CssSelector("tbody>tr:first-child"));
        private WebObject _firstrowStaffCodeUser = new WebObject(By.CssSelector("tbody>tr:first-child>td:first-child"));

        private WebObject _txtSearchStaff = new WebObject(By.XPath("//input[@placeholder='Search by name, staff code']"));
        private WebObject _svgOpenMenu = new WebObject(By.XPath("//span[text()='Open menu']/parent::button"));
        private WebObject _svgEdit = new WebObject(By.XPath("//a[@role='menuitem']"));

        private WebObject _msgEditUserSuccessfully = new WebObject(By.XPath("//div[text()='Successfully edited user']"));

        public string GetUserDetail(string label)
        {
            WebObject detailElement = new WebObject(By.XPath($"//p[text()='{label}']/following-sibling::p"));
            return detailElement.GetTextFromElement();
        }

        public string getCorrecEditUserMessage()
        {
            return _msgEditUserSuccessfully.GetTextFromElement();
        }

        public void GoToEditStaffPage(StaffEdit staffData)
        {
            _txtSearchStaff.EnterText(staffData.staffCode);
            Thread.Sleep(2000);
            _svgOpenMenu.ClickOnElement();
            _svgEdit.ClickOnElement();
            

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


        public void AssertEditUserDetails(StaffEdit expectedUser)
        {
            Assert.That(getCorrecEditUserMessage(), Is.EqualTo("Successfully edited user"));

            _rowVerifyUser.ClickOnElement();
            var _expectedStaffCode = _firstrowStaffCodeUser.GetTextFromElement();
            Thread.Sleep(2000);

            Assert.AreEqual(_expectedStaffCode, GetUserDetail("Staff Code"), "Staff Code does not match.");
            Assert.AreEqual(StringHelper.FormatDate(expectedUser.dateOfBirth), GetUserDetail("Date of Birth"), "Date of birth does not match.");
            Assert.AreEqual(expectedUser.gender, GetUserDetail("Gender").ToLower(), "Gender does not match.");
            Assert.AreEqual(StringHelper.FormatDate(expectedUser.joinDate), GetUserDetail("Joined Date"), "Joined date does not match.");

        }
    }



}


