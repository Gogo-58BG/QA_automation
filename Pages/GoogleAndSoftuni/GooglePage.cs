using HomeWork2.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace QA_automation.Pages.GoogleAndSoftuni
{
    class GooglePage : BasePage
    {
        public GooglePage(IWebDriver driver)
            : base(driver)
        {
        }

        public IWebElement SearchField => Driver.FindElement(By.XPath(@"//*[@id=""tsf""]/div[2]/div[1]/div[1]/div/div[2]/input"));

        //*[@id="rso"]/div[1]/div/div/div/div[1]/a/h3
        public IList<IWebElement> Results => Wait.Until(d => d.FindElements(By.XPath(@"//*[@id=""rso""]/div[1]/div/div/div/div[1]/a/h3")));
        public IWebElement Title => Driver.FindElement(By.XPath(@"/html/head/title"));

        public override void Navigate()
        {
            Driver.Url = "http://www.google.com/";
        }

        public void AssertAreEqual(string expected)
        {
            Assert.AreEqual(expected, "Selenium - Web Browser Automation");
        }
    }
}
