using NUnit.Framework;
using TestAmazon.Assembly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestAmazon.Pages;

namespace TestAmazon.Tests
{
    [TestFixture]
    public class Scenario2
    {
        [SetUp]
        public void StartUpTest()
        {
            WebDriverFacade.Init();
        }

        [TearDown]
        public void EndTest()
        {
           WebDriverFacade.Close();
        }
        [Test]
        public void CreateAccountTest()
        {
            //Verify If currently is homepage;
            Assembly.Pages.Home.IsAt();
            
            //Click "Hello, Sign in" 
            bool helloSignInClickReady = WebDriverFacade.WaitUntilElementExists(By.XPath(HomePage.HELLOSIGNIN)) == null ? false : true;
            Assert.IsTrue(helloSignInClickReady);
            Assembly.Pages.Home.HelloSignInClick();

            //wait until Sign in Page is ready;
            bool SignInPageIsReady = WebDriverFacade.WaitUntilElementExists(By.XPath(SignInPage.CREATEACCOUNTBUTTON)) == null ? false : true;
            Assert.IsTrue(SignInPageIsReady);

            //Click "Create your Amazon account" button;
            Assembly.Pages.SignInPage.CreateAccountClick();

            //wait until Sign up Page is Ready;
            bool SignUpPageIsReady = WebDriverFacade.WaitUntilElementExists(By.XPath(SignUpPage.BTNCREATEACCOUNT)) == null ? false : true;
            Assert.IsTrue(SignUpPageIsReady);

            //Filled the form;
            Assembly.Pages.SignUpPage.FilledTheForm();
            //Verify Create Account exist and Display;
            Assembly.Pages.SignUpPage.VerifyCreateAcccountButtonExist();
            Assembly.Pages.SignUpPage.VerifyCreateAccountButtonDisplay();
        }          
    }
}

