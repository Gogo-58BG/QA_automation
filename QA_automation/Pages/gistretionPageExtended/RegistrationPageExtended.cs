using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork2.Pages.RegistrationPageExtended
{
    class RegistrationPageExtended : BasePage
    {
        public RegistrationPageExtended(IWebDriver driver)
            : base(driver)
        {
        }

        public IList<IWebElement> RadioButtons => Wait.Until(d => d.FindElements(By.XPath("//div[@class='radio']//input")));
        public IWebElement FirstName => Driver.FindElement(By.Id("customer_firstname"));
        public IWebElement LastName => Driver.FindElement(By.Id("customer_lastname"));
        public IWebElement Password => Driver.FindElement(By.Id("passwd"));
        public SelectElement Date
        {
            get
            {
                IWebElement dateDD = Wait.Until(d => d.FindElement(By.Id("days")));
                SelectElement date = new SelectElement(dateDD);
                return date;
            }
        }

        public SelectElement Month
        {
            get
            {
                IWebElement monthDD = Wait.Until(d => d.FindElement(By.Id("months")));
                SelectElement month = new SelectElement(monthDD);
                return month;
            }
        }

        public SelectElement Year
        {
            get
            {
                IWebElement yearDD = Wait.Until(d => d.FindElement(By.Id("years")));
                SelectElement year = new SelectElement(yearDD);
                return year;
            }
        }
        public IWebElement Address => Driver.FindElement(By.Id("address1"));
        public IWebElement City => Driver.FindElement(By.Id("city"));
        public SelectElement State
        {
            get
            {
                IWebElement stateDD = Wait.Until(d => d.FindElement(By.Id("id_state")));
                SelectElement state = new SelectElement(stateDD);
                return state;
            }
        }
        public IWebElement Postcode => Driver.FindElement(By.Id("postcode"));
        public IWebElement Phone => Driver.FindElement(By.Id("phone_mobile"));
        public IWebElement Alias => Driver.FindElement(By.Id("alias"));

        public IWebElement Submit => Driver.FindElement(By.Id("submitAccount"));


        public override void Navigate()
        {
            Driver.Url = "http://automationpractice.com/index.php";
        }

        public IWebElement ErrorMessage => Driver.FindElement(By.XPath(@"//*[@id=""center_column""]/div/ol/li"));
        public void AssertErrorMessage(string expected)
        {
            Assert.AreEqual(expected, ErrorMessage.Text);
        }
        public void FillForm(RegistrationUser user)
        {
            RadioButtons[0].Click();
            FirstName.SendKeys(user.FirstName);
            LastName.SendKeys(user.LastName);
            Password.SendKeys(user.Password);
            Date.SelectByValue(user.Date);
            Month.SelectByValue(user.Month);
            Year.SelectByValue(user.Year);
            //FirstName.SendKeys(user.RealFirstName);
            //LastName.SendKeys(user.RealLastName);
            Address.SendKeys(user.Address);
            City.SendKeys(user.City);
            State.SelectByText(user.State);
            Postcode.SendKeys(user.PostCode);
            Phone.SendKeys(user.Phone);
            Alias.SendKeys(user.Alias);
            //Submit.Click();
        }

        //Woodcutters way to test RadioButtons
        public void FillFormWithoutRadio(RegistrationUser user)
        {
            //RadioButtons[0].Click();
            FirstName.SendKeys(user.FirstName);
            LastName.SendKeys(user.LastName);
            Password.SendKeys(user.Password);
            Date.SelectByValue(user.Date);
            Month.SelectByValue(user.Month);
            Year.SelectByValue(user.Year);
            //FirstName.SendKeys(user.RealFirstName);
            //LastName.SendKeys(user.RealLastName);
            Address.SendKeys(user.Address);
            City.SendKeys(user.City);
            State.SelectByText(user.State);
            Postcode.SendKeys(user.PostCode);
            Phone.SendKeys(user.Phone);
            Alias.SendKeys(user.Alias);
            //Submit.Click();
        }
    }
}
