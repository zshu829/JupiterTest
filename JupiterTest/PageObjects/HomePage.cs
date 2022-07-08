using OpenQA.Selenium;


namespace JupiterTest.PageObjects
{
    internal class HomePage
    {
        private IWebDriver driver = Browser.Driver;

        public void ClickContact()
        {
            IWebElement Contact = driver.FindElement(By.LinkText("Contact"));
            Contact.Click();
            Thread.Sleep(2000);
        }

        public void ClickHome()
        {
            IWebElement Home = driver.FindElement(By.LinkText("Home"));
            Home.Click();
            Thread.Sleep(2000);
        }

        public void ClickShop()
        {
            IWebElement Shop = driver.FindElement(By.LinkText("Shop"));
            Shop.Click();
            Thread.Sleep(2000);
        }

        
        public void ClickCart()
        {
            IWebElement Cart = driver.FindElement(By.XPath("//li[@id='nav-cart']/a[@href='#/cart']"));
            Cart.Click();
            Thread.Sleep(2000);
        }

    }
}
