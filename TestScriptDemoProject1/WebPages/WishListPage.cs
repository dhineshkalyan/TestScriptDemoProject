using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestScriptDemoProject1.BaseFunctions;

namespace TestScriptDemoProject1.WebPages
{
    class WishListPage
    {
        private IWebDriver driver;

        public WishListPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToWishListPage()
        {
            //Navigate to the WishList Page
            driver.FindElement(By.XPath("//i[@class='lar la-heart']")).Click();
        }

        public IList<IWebElement> GetWishListElements()
        {
            var elements = driver.FindElements(By.CssSelector("tbody.wishlist-items-wrapper tr"));
            return elements;
        }

        public void GetTheLowestPriceProduct()
        {
            //Search for the lowest price product
            var elements = driver.FindElements(By.CssSelector("td.product-price ins bdi"));

            List<string> priceList = new List<string>();
            foreach (var pdtprice in elements)
            {
                var price = pdtprice.Text;
                priceList.Add(price);
            }
            priceList.Sort();
            var lowest = priceList.First();
        }

        public void AddTheLowestPriceItemToCart()
        {
            Thread.Sleep(5000);
            var element = driver.FindElements(By.XPath("//a[text() = 'Add to cart']"));
            element.ElementAt(2).Click();
        }
    }
}
