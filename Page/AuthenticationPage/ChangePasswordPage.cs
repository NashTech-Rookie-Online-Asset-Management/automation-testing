using AssetManagement.Core;
using AssetManagement.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Page.AuthenticationPage
{
    public class ChangePasswordPage : BasePage
    {
        private WebObject _txtOldPassword = new WebObject(By.XPath("//input[@name='oldPassword']"));
        private WebObject _txtNewPassword = new WebObject(By.XPath("//input[@name='newPassword']"));
        private WebObject _btnSave = new WebObject(By.XPath("//button[@data-id='change-password-button']"));
        private WebObject _btnCancel = new WebObject(By.XPath("//button[@data-id='change-password-cancel-button']"));
        private WebObject _btnClose = new WebObject(By.XPath("//button[@data-id='cancel-button']"));


        public void ChangePassWord(Account account)
        {
            EnterOldPassword(account.password);
            EnterNewPassword(account.newpassword); 
            _btnSave.ClickOnElement();
            _btnClose.ClickOnElement();
        }

        public void EnterOldPassword(string oldPassword)
        {
            _txtOldPassword.EnterText(oldPassword);

        }
        public void EnterNewPassword(string newPassword)
        {
            _txtNewPassword.EnterText(newPassword);
        }
    }
}
