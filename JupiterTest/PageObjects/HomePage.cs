using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace JupiterTest.PageObjects
{
    internal class HomePage
    {
        private IWebDriver driver = Browser.Driver;

        private IWebElement Home => driver.FindElement(By.LinkText("Home"));
        private IWebElement Contact => driver.FindElement(By.LinkText("Contact"));
        private IWebElement Shop => driver.FindElement(By.LinkText("Shop"));
        private IWebElement Cart => driver.FindElement(By.XPath("//li[@id='nav-cart']/a[@href='#/cart']"));
        public void ClickContact()
        {
            //WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Contact")));
           
            Contact.Click();
            Thread.Sleep(2000);
        }

        public void ClickHome()
        {
            //WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Home")));
            
            Home.Click();
            Thread.Sleep(2000);
        }

        public void ClickShop()
        {
            //WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Shop")));
            Shop.Click();
            Thread.Sleep(2000);
        }

        
        public void ClickCart()
        {
            Cart.Click();
            Thread.Sleep(2000);
        }

    }
}
