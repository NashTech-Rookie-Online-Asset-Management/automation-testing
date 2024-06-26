using AngleSharp.Dom;
using AssetManagement.Core;
using AssetManagement.Models;
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

        public string GetUserDetail(string label)
        {
            WebObject detailElement = new WebObject(By.XPath($"//p[text()='{label}']/following-sibling::p"));
            return detailElement.GetTextFromElement();
        }

        public void AssertUserDetails(User expectedUser)
        {
            _rowVerifyUser.ClickOnElement();

            string expectedFullName = $"{expectedUser.firstName} {expectedUser.lastName}";
            Assert.AreEqual(expectedFullName, GetUserDetail("Full Name"), "Full name does not match.");
            Assert.AreEqual(FormatDate(expectedUser.dateOfBirth), GetUserDetail("Date of Birth"), "Date of birth does not match.");
            Assert.AreEqual(expectedUser.gender, GetUserDetail("Gender").ToLower(), "Gender does not match.");
            Assert.AreEqual(FormatDate(expectedUser.joinedDate), GetUserDetail("Joined Date"), "Joined date does not match.");
            Assert.AreEqual(expectedUser.type, GetUserDetail("Type"), "Type does not match.");
        }


        public static string FormatDate(string date)
        {
            if (date.Length != 8)
            {
                throw new ArgumentException("Date string must be exactly 8 characters long.");
            }
            string month = date.Substring(0, 2);
            string day = date.Substring(2, 2);
            string year = date.Substring(4, 4);
            string formattedDate = $"{day}/{month}/{year}";

            return formattedDate;
        }

    }
}

