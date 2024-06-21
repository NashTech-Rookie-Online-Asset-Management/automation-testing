using AssetManagement.Constant;
using AssetManagement.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Page
{
    public class BasePage
    {
        private WebObject _txtHeader = new WebObject(By.XPath("//h4[text()='Online Asset Management']"));
        private WebObject _txtChangePassword = new WebObject(By.XPath("//h2[text()='Change Password']"));
        public string VerifyPopupChangePassword()
        {
            return _txtChangePassword.GetTextFromElement();
        }


        //public void VerifyLoginSuccessfully()
        //{
        //    Assert.That(VerifyUserName(), Is.EqualTo(FileConstant.username));
        //}

    }
}
