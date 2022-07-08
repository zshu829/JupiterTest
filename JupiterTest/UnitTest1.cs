
using JupiterTest.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace JupiterTest
{
    public class UnitTest1
    {
        //IWebDriver driver = new ChromeDriver();
        HomePage homePage = new HomePage();
        ContactPage contactPage = new ContactPage();
        ShopPage shopPage = new ShopPage();
        CartPage cartPage = new CartPage();
        [Fact]
        public void Test1()
        {
            //1.From the home page go to contact page
            Browser.Goto("https://jupiter2.cloud.planittesting.com");
            homePage.ClickContact();
            //2.Click submit button
            contactPage.ClickSubmit();
            //3.Validate errors
            String errorInfo = Browser.Driver.FindElement(By.XPath("//div[@id='header-message']//strong[.='We welcome your feedback']")).Text;
            Assert.Contains("We welcome your feedback", errorInfo);

            String forenameError = Browser.Driver.FindElement(By.Id("forename-err")).Text;
            Assert.Contains("Forename is required", forenameError);

            String emailError = Browser.Driver.FindElement(By.Id("email-err")).Text;
            Assert.Contains("Email is required", emailError);

            String messageError = Browser.Driver.FindElement(By.Id("message-err")).Text;
            Assert.Contains("Message is required", messageError);
            //4.Populate mandatory fields
            contactPage.EnterForename("Shu");
            //5.Validate errors are gone

            //Thread.Sleep(5000);
            //contactPage.EnterEmail("shuz@gmail.com");
            //Thread.Sleep(2000);
            //contactPage.EnterMsg("Test1");
            //Thread.Sleep(2000);



        }

        [Fact]
        public void Test2()
        {
            //1.From the home page go to contact page
            Browser.Goto("https://jupiter2.cloud.planittesting.com");
            homePage.ClickContact();
            //2.Populate mandatory fields
            contactPage.EnterForename("Shu");
            contactPage.EnterEmail("shuz@gmail.com");
            contactPage.EnterMsg("Test1");
            //3.Click submit button
            contactPage.ClickSubmit();
            //4.Validate successful submission message

        }

        [Fact]
        public void Test3()
        {
            //1. From the home page go to shop page
            Browser.Goto("https://jupiter2.cloud.planittesting.com");
            homePage.ClickShop();
            //2. Click buy button 2 times on “Funny Cow”
            shopPage.BuyFunnyCow(2);
            //3. Click buy button 1 time on “Fluffy Bunny”
            shopPage.BuyFluffyBunny(1);
            //4. Click the cart menu
            homePage.ClickCart();
            //5. Verify the items are in the cart
            Assert.True(cartPage.VerifyItemQuantity("Funny Cow", "2", 1));
            Assert.True(cartPage.VerifyItemQuantity("Fluffy Bunny", "1", 2));
            //quit 
            Browser.Close();

        }
        [Fact]
        public void Test4()
        {
            //1.Buy 2 Stuffed Frog, 5 Fluffy Bunny, 3 Valentine Bear
            Browser.Goto("https://jupiter2.cloud.planittesting.com");
            homePage.ClickShop();
            shopPage.BuyStuffedFrog(2);
            shopPage.BuyFluffyBunny(5);
            shopPage.BuyValentineBear(2);
            //2.Go to the cart page
            homePage.ClickCart();
            //3.Verify the price for each product
            Assert.True(cartPage.VerifyItemPrice("Stuffed Frog", "2", 1, "$10.99"));
            Assert.True(cartPage.VerifyItemPrice("Fluffy Bunny", "5", 2, "$8.99"));
            Assert.True(cartPage.VerifyItemPrice("Valentine Bear", "2", 3, "$13.99"));
            //4.Verify that each product’s sub total = product price * quantity
            Assert.True(cartPage.VerifySubTotalPrice("Stuffed Frog", "2", 1));
            Assert.True(cartPage.VerifySubTotalPrice("Fluffy Bunny", "5", 2));
            Assert.True(cartPage.VerifySubTotalPrice("Valentine Bear", "2", 3));
            //5.Verify that total = sum(sub totals)
            Assert.True(cartPage.VerifyTotalPrice());
            //6. quit 
            //Browser.Close();

        }

    }
}