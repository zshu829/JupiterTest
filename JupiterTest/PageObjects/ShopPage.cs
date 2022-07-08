using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterTest.PageObjects
{
    internal class ShopPage
    {
        private IWebDriver driver = Browser.Driver;

        private IWebElement FunnyCow => driver.FindElement(By.CssSelector("#product-6 > div > p:nth-child(4) > a"));
        
        private IWebElement FluffyBunny => driver.FindElement(By.CssSelector("#product-4 > div > p:nth-child(4) > a"));
        private IWebElement StuffedFrog => driver.FindElement(By.CssSelector("#product-2 > div > p:nth-child(4) > a"));
        private IWebElement ValentineBear => driver.FindElement(By.CssSelector("#product-7 > div > p:nth-child(4) > a"));

        public void BuyFunnyCow(int times)
        {
            if (FunnyCow.Displayed)
            {
                for (int i = 0; i < times; i++)
                {
                    FunnyCow.Click();
                }
                Thread.Sleep(2000);
            }
            
        }

        public void BuyFluffyBunny(int times)
        {
            for (int i = 0; i < times; i++)
            {
                FluffyBunny.Click();
            }
            Thread.Sleep(2000);
        }

        public void BuyStuffedFrog(int times)
        {
            for (int i = 0; i < times; i++)
            {
                StuffedFrog.Click();
            }
            Thread.Sleep(2000);
        }

        public void BuyValentineBear(int times)
        {
            for (int i = 0; i < times; i++)
            {
                ValentineBear.Click();
            }
            Thread.Sleep(2000);
        }


    }
}
