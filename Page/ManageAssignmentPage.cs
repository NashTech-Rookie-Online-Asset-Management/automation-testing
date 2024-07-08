using AssetManagement.Core;
using AssetManagement.Core.Helper;
using AssetManagement.Models.Create;
using AssetManagement.Models.Edit;
using OpenQA.Selenium;

namespace AssetManagement.Page
{
    public class ManageAssignmentPage : BasePage
    {

        private WebObject _rowVerifyAssignment = new WebObject(By.CssSelector("tbody>tr:first-child"));
        private WebObject _firstAssignMentCode = new WebObject(By.CssSelector("tbody>tr:first-child>td:nth-child(2)"));

        public string GetAssignmentDetail(string label)
        {
            WebObject detailElement = new WebObject(By.XPath($"//p[text()='{label}']/following-sibling::p"));
            return detailElement.GetTextFromElement();
        }


        public void AssertAssignmentCreateDetails(AssignMentCreate expectedAssignMent)
        {
            _rowVerifyAssignment.ClickOnElement();
            var _expectedAssignmentCode = _firstAssignMentCode.GetTextFromElement();
            Assert.AreEqual(_expectedAssignmentCode, GetAssignmentDetail("Asset Code"), "Asset Code does not match.");           
            Assert.AreEqual(StringHelper.FormatDate(expectedAssignMent.AssigneddDated), GetAssignmentDetail("Assigned date"), "Assigned date does not match.");
            Assert.AreEqual(expectedAssignMent.State, GetAssignmentDetail("State"), "State does not match.");
            Assert.AreEqual(expectedAssignMent.Note, GetAssignmentDetail("Note"), "Note does not match.");
        }
    }
}
