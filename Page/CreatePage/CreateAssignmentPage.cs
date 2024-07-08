using AssetManagement.Core;
using AssetManagement.Models.Create;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Page.CreatePage
{
    public class CreateAssignmentPage : BasePage
    {
        private WebObject _btnCreateAssigntMent = new WebObject(By.XPath("//a[text()='Create new assignment']"));

        private WebObject _txtSearchUser = new WebObject(By.XPath("//input[@name='assignedTo.fullName']"));
        private WebObject _txtSearchAsset = new WebObject(By.XPath("//input[@name='asset.name']"));

        // SelectUser
        private WebObject _txtFindUser = new WebObject(By.XPath("//input[@placeholder='Search by name or staff code']"));

        // SelectAsset
        private WebObject _txtFindAsset = new WebObject(By.XPath("//input[@placeholder='Search by name or asset code']"));


        private WebObject _dtpAssignDate = new WebObject(By.Id("assignedDate"));
        private WebObject _txaNote = new WebObject(By.XPath("//textarea[@name='note']"));

        private WebObject _btnSaveSearchAssigntMent = new WebObject(By.XPath("//div[@role='radiogroup']//following-sibling::div//button[text()='Save']"));
        private WebObject _btnCancelSearchAssigntMent = new WebObject(By.XPath("//div[@role='radiogroup']//following-sibling::div//button[text()='Cancel']"));
        private WebObject _btnSaveAssignmentPage = new WebObject(By.XPath("//button[text()='Save']"));
        private WebObject _firstRowInfo = new WebObject(By.CssSelector("tbody>tr:first-child"));

        public void GoToCreateAssignMentPage()
        {
            _btnCreateAssigntMent.ClickOnElement();
        }

        public void SearchUser(AssignMentCreate assignment)
        {
            _txtSearchUser.ClickOnElement();
            _txtFindUser.EnterText(assignment.StaffCode);
            _firstRowInfo.ClickOnElement();
            //_btnCancelSearchAssigntMent.ClickOnElement();
            _btnSaveSearchAssigntMent.ClickOnElement();
        }

        public void SearchAsset(AssignMentCreate assignment)
        {
            _txtSearchAsset.ClickOnElement();
            _txtFindAsset.EnterText(assignment.AssetCode);
            _firstRowInfo.ClickOnElement();
            //_btnCancelSearchAssigntMent.ClickOnElement();
            _btnSaveSearchAssigntMent.ClickOnElement();

        }

        public void FillAssignmenInformation(AssignMentCreate assignment)
        {
            GoToCreateAssignMentPage();
            SearchUser(assignment);
            SearchAsset(assignment);
            AssignedDate(assignment.AssigneddDated);
            EnterNote(assignment.Note);
            _btnSaveAssignmentPage.ClickOnElement();
            Thread.Sleep(2000);

        }
        public void AssignedDate(string date)
        {
            _dtpAssignDate.ClickOnElement();
            _dtpAssignDate.EnterText(date);
        }
        public void EnterNote(string note)
        {
            _txaNote.EnterText(note);
        }

    }
}

