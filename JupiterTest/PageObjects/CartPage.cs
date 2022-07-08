using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            IList<IWebElement> i = driver.FindElements(By.XPath("//tr[@class]"));
            int x = i.Count();




            String subTotal1 = GetItemValue(1, 4, "text", false);
            String subTotal2 = GetItemValue(2, 4, "text", false);
            String subTotal3 = GetItemValue(3, 4, "text", false);
            String total = actuaTotal.Text;
            String countTotal = "";
            Boolean result = false;

            //divide the "$"
            subTotal1 = subTotal1.Substring(1, subTotal1.Length - 1);
            subTotal2 = subTotal2.Substring(1, subTotal2.Length - 1);
            subTotal3 = subTotal3.Substring(1, subTotal3.Length - 1);
            total = total.Replace("Total: ", "");

            float a = Convert.ToSingle(subTotal1);
            float b = Convert.ToSingle(subTotal2);
            float c = Convert.ToSingle(subTotal3);

            //float d = Convert.ToSingle(total);
            //String totalPrice = (Math.Round(d, 2)).ToString();
            //countTotal = (a + b + c).ToString();
            //        //verify subtotal price
            //        if (totalPrice.Equals(countTotal))
            //        {
            //            result = true;
            //        }

            return result;

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

                    Debug.Print($"Input: {value}");

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
