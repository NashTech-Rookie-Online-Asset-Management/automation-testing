using AssetManagement.Core;
using AssetManagement.Models.Edit;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Page.EditPage
{
    public class EditStaffPage : BasePage
    {
        private WebObject _rdoGender(string gender) { return new WebObject(By.XPath($"//button[@role='radio' and @value='{gender.ToUpper()}']")); }
        private WebObject _dtpDateOfBirth = new WebObject(By.XPath("//input[@name='dob']"));
        private WebObject _dtpJoinedDate = new WebObject(By.XPath("//input[@name='joinedAt']"));
        private WebObject _btnSave = new WebObject(By.XPath("//button[text()='Save']"));

        public void EnterDateOfBirth(string dateOfBirth)
        {
            _dtpDateOfBirth.EnterText(dateOfBirth);
        }
        public void SelectGender(string gender)
        {
            _rdoGender(gender).ClickOnElement();
        }

        public void EnterJoinedDate(string joinedDate)
        {

            _dtpJoinedDate.EnterText(joinedDate);
        }

        public void EditStaff(StaffEdit staffData)
        {
            EnterDateOfBirth(staffData.dateOfBirth);
            SelectGender(staffData.gender); 
            EnterJoinedDate(staffData.joinDate);
            _btnSave.ClickOnElement();

        }
    }
}
