using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;


namespace JupiterTest.PageObjects
{
    internal class CartPage
    {
        private IWebDriver driver = Browser.Driver;
        IWebElement actuaTotal => driver.FindElement(By.CssSelector("body > div.container-fluid > div > form > table > tfoot > tr:nth-child(1) > td > strong"));
       
        public Boolean VerifyItemQuantity(string itemName, string quantity, int rowNum)
        {
            String actualQuantity = GetItemValue(rowNum, 1, "value", true);
            String actualItemName = GetItemValue(rowNum, 2, "text", false);

            Boolean result = false;
            //verify the quantity
            if (quantity.Equals(actualQuantity))
            {
                //verify the item name
                if (itemName.Equals(actualItemName))
                {
                    result = true;
                }
            }
            return result;

        }

        public Boolean VerifyItemPrice(string itemName, string quantity, int rowNum, string price)
        {
            String actualQuantity = GetItemValue(rowNum, 1, "value", true);
            String actualItemName = GetItemValue(rowNum, 2, "text", false);
            String actuaItemPrice = GetItemValue(rowNum, 3, "text", false);
            Boolean result = false;
            //verify the quantity
            if (quantity.Equals(actualQuantity))
            {
                //verify the item name
                if (itemName.Equals(actualItemName))
                {
                    //verify item price
                    if(price.Equals(actuaItemPrice))
                    {
                        result = true;
                    }
                    
                }
            }
            return result;

        }

        public Boolean VerifySubTotalPrice(string itemName, string quantity, int rowNum)
        {
            String actualQuantity = GetItemValue(rowNum, 1, "value", true);
            String actualItemName = GetItemValue(rowNum, 2, "text", false);
            String actuaItemPrice = GetItemValue(rowNum, 3, "text", false);
            String actuaSubTotal = GetItemValue(rowNum, 4, "text", false);

            Boolean result = false;
            //verify the quantity
            if (quantity.Equals(actualQuantity))
            {
                //verify the item name
                if (itemName.Equals(actualItemName))
                {
                    //divide the "$"
                    actuaSubTotal = actuaSubTotal.Substring(1, actuaSubTotal.Length - 1);

                    if (actuaSubTotal.Equals(GetItemSubTotal(actualQuantity, actuaItemPrice)))
                    {
                        result = true;
                    }
                }
            }
            return result;

        }


        public Boolean VerifyTotalPrice()
        {
            Boolean result = false;
            //get the items' row
            IList<IWebElement> rowTotal = driver.FindElements(By.XPath("//tr[@class]"));
            String[] subTotal = new string[rowTotal.Count()];
            float[] floats = new float[rowTotal.Count()];  
            float countTotal = 0;
            for(int i=0;i< rowTotal.Count(); i++)
            {
                //get the each subTotal value
                subTotal[i] = GetItemValue(i+1, 4, "text", false);
                //divide the "$"
                subTotal[i] = subTotal[i].Substring(1, subTotal[i].Length - 1);
                //convert string to float
                floats[i] = Convert.ToSingle(subTotal[i]);
                //add sub totals
                countTotal = countTotal + floats[i];
            }

            String total = actuaTotal.Text;
            //delete the "Total: " in total price
            total = total.Replace("Total: ", "");
            //convert String to float
            float d = Convert.ToSingle(total);
            String totalPrice = (Math.Round(d, 2)).ToString();

            //verify subtotal price
            if (totalPrice.Equals(countTotal.ToString()))
            {
                result = true;
            }
            return result;

        }

        public void ClickEmptyCart()
        {
            IWebElement EmptyCart = driver.FindElement(By.CssSelector("body > div.container-fluid > div > form > table > tfoot > tr:nth-child(2) > td > ng-confirm > a"));
            EmptyCart.Click();
            Thread.Sleep(3000);
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("body > div.popup.modal.hide.ng-scope.in > div.modal-footer > a.btn.btn-success")));
            IWebElement confirmMsg = driver.FindElement(By.CssSelector("body > div.popup.modal.hide.ng-scope.in > div.modal-footer > a.btn.btn-success"));
            confirmMsg.Click();
            Thread.Sleep(3000);
        }

        private String GetItemSubTotal(String quantity, String price)
        {
            String result = "";
            //divide the "$"
            price = price.Substring(1, price.Length - 1);       
            float a = Convert.ToSingle(quantity);
            float b = Convert.ToSingle(price);
            result = Math.Round(a * b, 2).ToString();

            return result;
        }

        private string GetItemValue(int rowId, int colId, string elementType, Boolean isInput)
        {
            var cssResource = $"body > div.container-fluid > div > form > table > tbody > tr:nth-child({rowId}) > td:nth-child({colId})";
            var inputCssResource = $"body > div.container-fluid > div > form > table > tbody > tr:nth-child({rowId}) > td:nth-child({colId}) > input";
            string value = "";
            try
            {
                By byMethod;
                if (isInput)
                {
                    byMethod = By.CssSelector(inputCssResource);
                }
                else
                {
                    byMethod = By.CssSelector(cssResource);
                }
                
                var element = driver.FindElement(byMethod);
                if (element.Displayed)
                {
                    if (elementType.Equals("value"))
                    {
                        value = element.GetAttribute("value");
                    }
                    else
                    {
                        value = element.Text;
                    }
                    //Debug.Print($"Input: {value}");

                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return value;
        }

    }

        
}
