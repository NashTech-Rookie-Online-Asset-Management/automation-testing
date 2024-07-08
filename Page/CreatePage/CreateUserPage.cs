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
    public class CreateUserPage : BasePage
    {
        private WebObject _bthCreateUser = new WebObject(By.XPath("//a[text()='Create new user']"));

        private WebObject _txtFirstName = new WebObject(By.XPath("//input[@name='firstName']"));
        private WebObject _txtLastName = new WebObject(By.XPath("//input[@name='lastName']"));
        private WebObject _rdoGender(string gender) { return new WebObject(By.XPath($"//button[@role='radio' and @value='{gender.ToUpper()}']")); }
        //private WebObject _rdoGender(string gender) { return new WebObject(By.XPath($"//label[text()='{gender}']//preceding-sibling::button]")); }


        private WebObject _ddlType = new WebObject(By.XPath("//select[@aria-hidden='true']"));
        private WebObject _dtpDateOfBirth = new WebObject(By.XPath("//input[@name='dob']"));
        private WebObject _dtpJoinedDate = new WebObject(By.XPath("//input[@name='joinedAt']"));


        private WebObject _btnSave = new WebObject(By.XPath("//button[@type='submit']"));
        private WebObject _btnCancel = new WebObject(By.XPath("//button[text()='Cancel']"));

        private WebObject _btnConfirm = new WebObject(By.XPath("//button[text()='Confirm']"));

        public void EnterFirstName(string firstName)
        {
            _txtFirstName.EnterText(firstName);
        }

        public void EnterLastName(string lastName)
        {
            _txtLastName.EnterText(lastName);
        }

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

        public void SelectType(string type)
        {
            _ddlType.SelectFromDropdown(type);
        }

        public void ClickSaveButton()
        {
            _btnSave.ClickOnElement();
        }
        public void GoToCreateUserPage()
        {
            _bthCreateUser.ClickOnElement();
        }

        public void CreateUser(UserCreate staffUser)
        {
            GoToCreateUserPage();
            EnterFirstName(staffUser.firstName);
            EnterLastName(staffUser.lastName);
            EnterDateOfBirth(staffUser.dateOfBirth);
            SelectGender(staffUser.gender);
            EnterJoinedDate(staffUser.joinedDate);
            SelectType(staffUser.type);
            ClickSaveButton();
            _btnConfirm.ClickOnElement();
            Thread.Sleep(2000);

        }
    }
}
