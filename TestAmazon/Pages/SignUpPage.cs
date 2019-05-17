using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestAmazon.Assembly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAmazon.Pages
{
    class SignUpPage
    {
        //Locator
        [FindsBy(How=How.Id,Using = "ap_customer_name")]
        private IWebElement txtUserName;

        [FindsBy(How=How.Id,Using = "ap_email")]
        private IWebElement txtEmail;

        [FindsBy(How = How.Id, Using = "ap_password")]
        private IWebElement txtPassword;

        [FindsBy(How=How.Id, Using = "ap_password_check")]
        private IWebElement txtPasswordConfirm;

        [FindsBy(How=How.XPath, Using = BTNCREATEACCOUNT)]
        private IWebElement btnCreateAccount;

        //Constant;
        public const string BTNCREATEACCOUNT = "//input[@id='continue']";

        //Action;
        public void FilledTheForm()
        {
            //UserName;
            Assert.True(txtUserName.ControlDisplayed());
            txtUserName.SendKeys("Test User");

            //Email;
            Assert.True(txtEmail.ControlDisplayed());
            txtEmail.SendKeys("testuser@gmail.com");

            //Password;
            Assert.True(txtPassword.ControlDisplayed());
            txtPassword.SendKeys("adminroot@123");

            //Confirm Password;
            Assert.True(txtPasswordConfirm.ControlDisplayed());
            txtPasswordConfirm.SendKeys("adminroot@123");
        }

        public void VerifyCreateAcccountButtonExist()
        {
            //Exist;
            bool bool_CreateAccountExist = WebDriverFacade.getDriver.ControlExists(By.XPath("//input[@id='continue']"));
            Assert.IsTrue(bool_CreateAccountExist);
        }
        public void VerifyCreateAccountButtonDisplay()
        {
            //Display;
            Assert.IsTrue(btnCreateAccount.ControlDisplayed());
        }
    }
}
