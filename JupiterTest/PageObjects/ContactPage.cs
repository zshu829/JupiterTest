using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterTest.PageObjects
{
    internal class ContactPage
    {
        private IWebDriver driver = Browser.Driver;

        private IWebElement forename => driver.FindElement(By.Id("forename"));
        private IWebElement surname => driver.FindElement(By.Id("surname"));
        private IWebElement email => driver.FindElement(By.Id("email"));
        private IWebElement telephone => driver.FindElement(By.Id("telephone"));
        private IWebElement message => driver.FindElement(By.Id("message"));


        public void ClickSubmit()
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("contact-submit-btn")));
            IWebElement submitButton = driver.FindElement(By.Id("contact-submit-btn"));
            submitButton.Click();
            Thread.Sleep(2000);
        }

        public void EnterForename(string name)
        {
            forename.SendKeys(name);
        }

        public void EnterSurname(string name)
        {
            surname.SendKeys(name);
        }

        public void EnterEmail(string m)
        {
            email.SendKeys(m);
        }

        public void EnterTelephone(string telnumber)
        {
            telephone.SendKeys(telnumber);
        }

        public void EnterMsg(string msg)
        {

            message.SendKeys(msg);
        }

    }
}
