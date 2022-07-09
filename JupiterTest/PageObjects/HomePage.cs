using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace JupiterTest.PageObjects
{
    internal class HomePage
    {
        private IWebDriver driver = Browser.Driver;

        public void ClickContact()
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Contact")));
            IWebElement Contact = driver.FindElement(By.LinkText("Contact"));
            Contact.Click();
            Thread.Sleep(2000);
        }

        public void ClickHome()
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Home")));
            //#nav-home > a
            IWebElement Home = driver.FindElement(By.LinkText("Home"));
            Home.Click();
            Thread.Sleep(2000);
        }

        public void ClickShop()
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Shop")));
            IWebElement Shop = driver.FindElement(By.LinkText("Shop"));
            Shop.Click();
            Thread.Sleep(2000);
        }

        
        public void ClickCart()
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//li[@id='nav-cart']/a[@href='#/cart']")));
            IWebElement Cart = driver.FindElement(By.XPath("//li[@id='nav-cart']/a[@href='#/cart']"));
            Cart.Click();
            Thread.Sleep(2000);
        }

    }
}
