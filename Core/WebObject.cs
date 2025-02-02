﻿using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using AventStack.ExtentReports.Utils;

namespace AssetManagement.Core
{

    public class WebObject
    {
        public By By { get; set; }
        public WebObject() { }
        public WebObject(By By)
        {
            this.By = By;
            DriverManager.wait = new WebDriverWait(DriverManager.driver, TimeSpan.FromSeconds(10));
        }


        public IWebElement WaitForElementToBeVisible()
        {
            try
            {
                return DriverManager.wait.Until(ExpectedConditions.ElementIsVisible(By));
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }

        }
        public IWebElement WaitForElementToBeClickEnable()
        {
            try
            {
                return DriverManager.wait.Until(ExpectedConditions.ElementToBeClickable(By));
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }

        public void WaitForElementGotoUrl(string url)
        {

            DriverManager.wait.Until(ExpectedConditions.UrlToBe(url));
        }

        public bool IsElementDisplayed()
        {
            try
            {
                return DriverManager.driver.FindElement(By).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }

        public List<IWebElement> FindElements()
        {
            try
            {
                return DriverManager.wait.Until(d => d.FindElements(By)).ToList();
            }
            catch (WebDriverTimeoutException)
            {
                return new List<IWebElement>();
            }
        }

        
        

        public void ClickOnElement()
        {
            IWebElement element = WaitForElementToBeVisible();
            //ScrollToElement();
            element.Click();
            
        }
        public string GetTextFromElement()
        {
            IWebElement element = WaitForElementToBeVisible();
            ScrollToElement();
            return element.Text;

        }
        public void ClearText()
        {
            IWebElement element = WaitForElementToBeVisible();
            ScrollToElement();
            element.Clear();
        }
        public void InputText(string text)
        {
            IWebElement element = WaitForElementToBeVisible();
            ScrollToElement();
            element.SendKeys(text);
        }
        public void EnterText(string text)
        {
            ClearText();
            InputText(text);
        }
        public void SelectFromDropdown(string type)
        {
            IWebElement test = DriverManager.driver.FindElement(By);
            var selectElement = new SelectElement(test);
            selectElement.SelectByText(type);
        }

        public void SelectDateFromDatePicker(string date)
        {
            IWebElement elementDatePicker = WaitForElementToBeVisible();
            elementDatePicker.SendKeys(Keys.Control + "a");
            elementDatePicker.SendKeys(date);
        }

        public void ScrollToElement()
        {
            IWebElement webElement = WaitForElementToBeVisible();
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverManager.driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
        }

        public void EnterValue(string value)
        {
            IWebElement elementDatePicker = WaitForElementToBeVisible();
            elementDatePicker.SendKeys(Keys.Control + "a");
            elementDatePicker.SendKeys(value);
        }

        public IList<IWebElement> FindAllElements()
        {
            return DriverManager.driver.FindElements(By);
        }
        public bool CheckElementExistWithoutWait()
        {
            return (!FindAllElements().IsNullOrEmpty());
        }
        public void ClearTextUsingKeys()
        {
            IWebElement element = WaitForElementToBeVisible();
            ScrollToElement();
            Actions actions = new Actions(DriverManager.driver);
            actions.Click(element)
                   .KeyDown(Keys.Control)
                   .SendKeys("a")
                   .KeyUp(Keys.Control)
                   .SendKeys(Keys.Delete)
                   .Perform();
        }

        public void ClickByJs()
        {
            IWebElement element = WaitForElementToBeClickEnable();
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverManager.driver;
            js.ExecuteScript("arguments[0].click();", element);
        }


        
    }
}


