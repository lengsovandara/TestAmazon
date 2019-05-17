using NUnit.Framework;
using OpenQA.Selenium;
using TestAmazon.Assembly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TestAmazon.Pages
{
    class HomePage
    {
        //Locator;
        [FindsBy(How = How.CssSelector, Using = "#twotabsearchtextbox")]
        private IWebElement searchStoreInput;

        [FindsBy(How = How.XPath, Using = "//input[@value='Go']")]
        private IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = HELLOSIGNIN)]        
        private IWebElement helloSignIn;

        [FindsBy(How = How.CssSelector, Using = ".s-result-list > div:first-child")]
        private IWebElement searchResult;

        //Constant
        public const string HELLOSIGNIN = "//span[contains(text(),'Hello, Sign in')]";

        //Action;
        public void IsAt()
        {
            Assert.IsTrue(WebDriverFacade.Tittle.Equals("Amazon.co.uk: Low Prices in Electronics, Books, Sports Equipment & more"));
        }
        public void EnterSearchText(string searchText)
        {
            Assert.IsTrue(searchStoreInput.ControlDisplayed());
            searchStoreInput.SendKeys(searchText);
        }
        public void ClickSearchButton()
        {
            Assert.IsTrue(searchButton.ControlDisplayed());
            searchButton.ClickWrapper("Search");
        }
        public void HelloSignInClick()
        {                       
            Assert.True(helloSignIn.ControlDisplayed());
            helloSignIn.ClickWrapper("HelloSignIn");
        }   
        public void VerifySearchElementAndClick()
        {
            //Check If the elements display
            Assert.True(searchResult.ControlDisplayed());
            //Check if the element's size greater than 0px;
            Assert.True(searchResult.Size.Width>0);
            searchResult.ClickWrapper("Results Click");
        }
    }
}
