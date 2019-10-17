using HomeWork2.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace QA_automation.Pages.GoogleAndSoftuni
{
    class SoftuniPage : BasePage
    {
        public SoftuniPage(IWebDriver driver)
            : base(driver)
        {
        }

        public IWebElement NavBarLearnings => Driver.FindElement(By.XPath(@"//*[@id=""header-nav""]/div[1]/ul/li[2]/a/span"));
        public IWebElement Heading => Driver.FindElement(By.XPath(@"/html/body/div[2]/header/h1"));
        public IWebElement QaCourse => Driver.FindElement(By.XPath(@"//*[@id=""header-nav""]/div[1]/ul/li[2]/div/div/div[2]/div[2]/div/div[1]/ul[2]/div[1]/ul/li/a"));

        public override void Navigate()
        {
            Driver.Url = "https://www.softuni.bg";
        }

        public void AssertAreEqual(string expected)
        {
            Assert.AreEqual(expected, "QA Automation - септември 2019");
        }
    }
}
