using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using QA_automation.Pages.GoogleAndSoftuni;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using HomeWork2.Extentions;

namespace QA_automation
{
    [TestFixture]

    class GoogleAndSoftuni
    {
        private ChromeDriver _driver;
        //private WebDriverWait _wait;
        private GooglePage _googlePage;
        private SoftuniPage _softuniPage;

        [SetUp]
        public void CalssInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _googlePage = new GooglePage(_driver);
            _softuniPage = new SoftuniPage(_driver);

        }
      
        
        [Test]
        public void GoogleSearch()
        {
            _googlePage.Navigate();
            _googlePage.SearchField.Type("Selenium");
            _googlePage.SearchField.Submit();
            _googlePage.Results[0].Click();

            var title = _googlePage.Title.GetAttribute("textContent");

            _googlePage.AssertAreEqual(title);
        }
        [Test]
        public void SoftUniQA()
        {
            _softuniPage.Navigate();

            _softuniPage.NavBarLearnings.Click();
            _softuniPage.QaCourse.Click();

            var heading = _softuniPage.Heading.Text;

            _softuniPage.AssertAreEqual(heading);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
