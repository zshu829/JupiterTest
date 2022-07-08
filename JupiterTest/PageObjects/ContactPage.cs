using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace JupiterTest.PageObjects
{
    internal class ContactPage
    {
        private IWebDriver driver = Browser.Driver;

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
            IWebElement forename = driver.FindElement(By.Id("forename"));
            forename.SendKeys(name);
            Thread.Sleep(1000);
        }

        public void EnterSurname(string name)
        {
            IWebElement surname = driver.FindElement(By.Id("surname"));
            surname.SendKeys(name);
            Thread.Sleep(1000);
        }

        public void EnterEmail(string m)
        {
            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys(m);
            Thread.Sleep(1000);
        }

        public void EnterTelephone(string telnumber)
        {
            IWebElement telephone = driver.FindElement(By.Id("telephone"));
            telephone.SendKeys(telnumber);
            Thread.Sleep(1000);
        }

        public void EnterMsg(string msg)
        {
            IWebElement message = driver.FindElement(By.Id("message"));
            message.SendKeys(msg);
            Thread.Sleep(1000);
        }

        public Boolean VerifySubmissionMessage(string msg)
        {
            Boolean result = false;
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("body > div.container-fluid > div > div")));
            IWebElement submissionMsg = driver.FindElement(By.CssSelector("body > div.container-fluid > div > div"));
            
            if(msg.Equals(submissionMsg.Text))
            {
                result = true;
            }
            return result;
        }

        public String GetHeaderError()
        {
            IWebElement errorMsg = driver.FindElement(By.CssSelector("#header-message > div"));
            String text = "";
            if(errorMsg.Displayed)
            {
                text = errorMsg.Text;
            }
            
            return text;
        }

        public String GetForenameError()
        {
            String text = "";
            try
            {
                IWebElement ForeError = driver.FindElement(By.Id("forename-err"));

                if (ForeError.Displayed)
                {
                    text = ForeError.Text;
                }
            }
            catch (Exception ex)
            {
                return text;
            }

            return text;
        }

        public String GetEmailError()
        {
            String text = "";
            try 
            {
                IWebElement emailError = driver.FindElement(By.Id("email-err"));

                if (emailError.Displayed)
                {
                    text = emailError.Text;
                }
            }
            catch (Exception ex)
            {
                return text;
            }

            return text;
        }

        public String GetMessageError()
        {
            String text = "";
            try
            {
                IWebElement emailError = driver.FindElement(By.Id("message-err"));

                if (emailError.Displayed)
                {
                    text = emailError.Text;
                }
            }
            catch (Exception ex)
            {
                return text;
            }
            return text;
        }

    }
}
