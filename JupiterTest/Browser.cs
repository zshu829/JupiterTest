using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            webDriver.Close();
        }

        public static void Quit()
        {
            webDriver.Quit();
        }

    }
}
