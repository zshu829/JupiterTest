using OpenQA.Selenium;

namespace JupiterTest.PageObjects
{
    internal class ShopPage
    {
        private IWebDriver driver = Browser.Driver;

        public void BuyFunnyCow(int times)
        {
            IWebElement FunnyCow = driver.FindElement(By.CssSelector("#product-6 > div > p:nth-child(4) > a"));
            if (FunnyCow.Displayed)
            {
                for (int i = 0; i < times; i++)
                {
                    FunnyCow.Click();
                }
                Thread.Sleep(1000);
            }
            
        }

        public void BuyFluffyBunny(int times)
        {
            IWebElement FluffyBunny = driver.FindElement(By.CssSelector("#product-4 > div > p:nth-child(4) > a"));
            for (int i = 0; i < times; i++)
            {
                FluffyBunny.Click();
            }
            Thread.Sleep(1000);
        }

        public void BuyStuffedFrog(int times)
        {
            IWebElement StuffedFrog = driver.FindElement(By.CssSelector("#product-2 > div > p:nth-child(4) > a"));
            for (int i = 0; i < times; i++)
            {
                StuffedFrog.Click();
            }
            Thread.Sleep(1000);
        }

        public void BuyValentineBear(int times)
        {
            IWebElement ValentineBear = driver.FindElement(By.CssSelector("#product-7 > div > p:nth-child(4) > a"));
            for (int i = 0; i < times; i++)
            {
                ValentineBear.Click();
            }
            Thread.Sleep(1000);
        }


    }
}
