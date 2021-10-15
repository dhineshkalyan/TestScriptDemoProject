using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TestScriptDemoProject1.BaseFunctions;

namespace TestScriptDemoProject1.WebPages
{
    class CartPage
    {
        private IWebDriver driver;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToTheCartPage()
        {
            var element = driver.FindElement(By.CssSelector("i.la-shopping-bag"));
            element.Click();

            Thread.Sleep(3000);
        }

        public IList<IWebElement> GetCartItems()
        {
            var cartItems = driver.FindElements(By.CssSelector("tbody tr.cart_item"));
            return cartItems;
        }
    }
}
