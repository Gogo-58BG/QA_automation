using HomeWork2;
using HomeWork2.Extentions;
using HomeWork2.Pages.RegistrationPage;
using HomeWork2.Pages.RegistrationPageExtended;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace HomeWork3Task1
{
    [TestFixture]
    public class HomeWork3Task1
    {
        private ChromeDriver _driver;
        //private WebDriverWait _wait;
        private RegistrationPage _registrationPage;
        private RegistrationPageExtended _registrationPageExtended;
        private RegistrationUser _user;

        [SetUp]
        public void CalssInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _registrationPage = new RegistrationPage(_driver);
            _registrationPageExtended = new RegistrationPageExtended(_driver);

            _registrationPage.Navigate();
            //_registrationPage.Authentication.Click();
            _registrationPage.Email.SendKeys(_registrationPage.GenerateMail());
            _registrationPage.Submit.Click();

            _user = UserFactory.CreateValidUser();
        }

        [Test]

        public void MissingFirstNameAndLastName()
        {
            _registrationPageExtended.FillForm(_user);
            _registrationPageExtended.FirstName.Type("");
            _registrationPageExtended.LastName.Type("");
            _registrationPageExtended.Submit.Click();

            _registrationPageExtended.AssertErrorMessage("lastname is required.");
        }

        [Test]

        public void MissingFirstName()
        {
            _registrationPageExtended.FillForm(_user);
            _registrationPageExtended.FirstName.Type("");
            _registrationPageExtended.Submit.Click();

            _registrationPageExtended.AssertErrorMessage("firstname is required.");
        }

        [Test]

        public void MissingAddress()
        {
            _registrationPageExtended.FillForm(_user);
            _registrationPageExtended.Address.Type("");
            _registrationPageExtended.Submit.Click();

            _registrationPageExtended.AssertErrorMessage("address1 is required.");
        }

        [Test]
        public void MissingDate()
        {
            _registrationPageExtended.FillForm(_user);
            _registrationPageExtended.Date.SelectByValue("");
            _registrationPageExtended.Submit.Click();

            _registrationPageExtended.AssertErrorMessage("Invalid date of birth");
        }

        //DO NOT EXECUTE THIS TEST THE SITE REGISTERS YOU WITHOUT SELECTED GENDER
        [Test]
        public void RadioButtons()
        {
            //_registrationPageExtended.FillFormWithoutRadio(_user);

            //_registrationPageExtended.Submit.Click();

            //_registrationPageExtended.AssertErrorMessage("");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
