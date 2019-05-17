using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAmazon.Assembly;

namespace TestAmazon.Pages
{
    class SignInPage
    {
        //Locator;
        [FindsBy(How=How.XPath,Using = CREATEACCOUNTBUTTON )]        
        private IWebElement createAccountButton;

        //Constant
        public const string CREATEACCOUNTBUTTON = "//a[@id='createAccountSubmit']";

        //Action;
        public void CreateAccountClick()
        {
            Assert.True(createAccountButton.ControlDisplayed());
            createAccountButton.ClickWrapper("Create Account Amazon Click");
        }
    }
}
