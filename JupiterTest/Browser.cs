using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JupiterTest
{
    public static class Browser
    {
       
        static IWebDriver webDriver = new ChromeDriver();
        public static IWebDriver Driver
        {
            get { return webDriver; }
        }

        public static void Goto(string url)
        {
            webDriver.Navigate().GoToUrl(url);
            Thread.Sleep(2000);
        }

        public static void Close()
        {
            webDriver.Quit();
        }


    }
}
