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
    public class ManageAssignment : BasePage
    {
        private WebObject _txtSearchUser = new WebObject(By.XPath("//input[@name='staffCode']"));
        private WebObject _txtSearchAsset = new WebObject(By.XPath("//input[@name='assetCode']"));

        // SelectUser
        private WebObject _txtFindUser = new WebObject(By.XPath("//input[@placeholder='Finding users...']"));
        private WebObject _btnSaveSelecUser = new WebObject(By.XPath("//button[text()='Save']"));
        private WebObject _btnCancelSelectUser = new WebObject(By.XPath("//button[text()='Cancel']"));

        // SelectAsset
        private WebObject _txtFindAsset = new WebObject(By.XPath("//input[@placeholder='Finding assets...']"));
        private WebObject _btnSaveSelecAsset = new WebObject(By.XPath("//button[text()='Save']"));
        private WebObject _btnCancelSelectAsset = new WebObject(By.XPath("//button[text()='Cancel']"));

        private WebObject _dtpAssignDate = new WebObject(By.XPath("//input[@name='installedDate']"));
        private WebObject _txaNote = new WebObject(By.XPath("//textarea[@name='note']"));

        public void SearchUser(Assignment assignment)
        {
            _txtFindUser.EnterText(assignment.StaffCode);
            _btnSaveSelecUser.ClickOnElement();
        }

        public void SearchAsset(Assignment assignment)
        {
            _txtFindAsset.EnterText(assignment.AssetCode);
            _btnSaveSelecAsset.ClickOnElement();

        }
        public void AssignedDate(string date)
        {
            _dtpAssignDate.EnterText(date);
        }
        public void EnterNote(string note)
        {
            _txaNote.EnterText(note);
        }

    }
}
