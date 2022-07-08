
using JupiterTest.PageObjects;



namespace JupiterTest
{
    [TestCaseOrderer("JupiterTest.Orders.TestCaseOrderer", "JupiterTest")]
    public class UnitTest1 
    {
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
            Assert.Contains("but we won't get it unless you complete the form correctly.", contactPage.GetHeaderError());
            Assert.Contains("Forename is required", contactPage.GetForenameError());
            Assert.Contains("Email is required", contactPage.GetEmailError());
            Assert.Contains("Message is required", contactPage.GetMessageError());
            
            //4.Populate mandatory fields
            contactPage.EnterForename("Shu");
            contactPage.EnterEmail("shuz@gmail.com");
            contactPage.EnterMsg("Test1");
            //5.Validate errors are gone
            Assert.Contains("", contactPage.GetForenameError());
            Assert.Contains("", contactPage.GetEmailError());
            Assert.Contains("", contactPage.GetMessageError());

        }

        [Fact]
        public void Test2()
        {
            //1.From the home page go to contact page
            homePage.ClickHome();
            homePage.ClickContact();
            //2.Populate mandatory fields
            contactPage.EnterForename("Shu");
            contactPage.EnterEmail("shuz@gmail.com");
            contactPage.EnterMsg("Test2");
            //3.Click submit button
            contactPage.ClickSubmit();
            //4.Validate successful submission message
            contactPage.VerifySubmissionMessage("Thanks Shu, we appreciate your feedback.");

        }

        [Fact]
        public void Test3()
        {
            //1. From the home page go to shop page
            homePage.ClickHome();
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


        }
        [Fact]
        public void Test4()
        {
            //1.Empty Cart
            cartPage.ClickEmptyCart();
            //2. From the home page go to shop page
            homePage.ClickHome();
            //3.Buy 2 Stuffed Frog, 5 Fluffy Bunny, 3 Valentine Bear
            homePage.ClickShop();
            shopPage.BuyStuffedFrog(2);
            shopPage.BuyFluffyBunny(5);
            shopPage.BuyValentineBear(2);
            //4.Go to the cart page
            homePage.ClickCart();
            //5.Verify the price for each product
            Assert.True(cartPage.VerifyItemPrice("Stuffed Frog", "2", 1, "$10.99"));
            Assert.True(cartPage.VerifyItemPrice("Fluffy Bunny", "5", 2, "$8.99"));
            Assert.True(cartPage.VerifyItemPrice("Valentine Bear", "2", 3, "$13.99"));
            //6.Verify that each product’s sub total = product price * quantity
            Assert.True(cartPage.VerifySubTotalPrice("Stuffed Frog", "2", 1));
            Assert.True(cartPage.VerifySubTotalPrice("Fluffy Bunny", "5", 2));
            Assert.True(cartPage.VerifySubTotalPrice("Valentine Bear", "2", 3));
            //7.Verify that total = sum(sub totals)
            Assert.True(cartPage.VerifyTotalPrice());
            //8. quit 
            //Browser.Quit();

        }

    }
}