using AutoFixture;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace HomeWork2.Pages.RegistrationPage
{
    class RegistrationPage : BasePage
    {

        public RegistrationPage(IWebDriver driver)
            : base(driver)
        {
        }

        //public IWebElement Authentication => Driver.FindElement(By.XPath(@"//*[@id=""header""]/div[2]/div/div/nav/div[1]/a"));
        public IWebElement Email => Driver.FindElement(By.Id("email_create"));
        public IWebElement Submit => Driver.FindElement(By.Id("SubmitCreate"));


        public override void Navigate()
        {
            Driver.Url = "http://automationpractice.com/index.php?controller=my-account";
        }

        public string GenerateMail()
        {

            var fixture = new Fixture();
            
            var mail = $"{fixture.Create<string>().Substring(0, 6)}@test.com";

            return mail;
        }
    }

}
