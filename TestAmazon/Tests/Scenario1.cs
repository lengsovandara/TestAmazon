using System;
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestAmazon.Assembly;

namespace TestAmazon.Tests
{
    [TestFixture]
    public class Scenario1
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
        public void VerifySearchResult()
        {
            //Go to Homepage
            Assembly.Pages.Home.IsAt();
            //Enter Text Search
            Assembly.Pages.Home.EnterSearchText("TShirt");
            //Click Button Search
            Assembly.Pages.Home.ClickSearchButton();
            String currentUrl = WebDriverFacade.getDriver.Url;
            //Verify Search Result;
            Assembly.Pages.Home.VerifySearchElementAndClick();
            //Verify element "URL";
            Assert.AreNotEqual(currentUrl, WebDriverFacade.getDriver.Url);
        }
    }
}
