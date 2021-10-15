using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestScriptDemoProject1.BaseFunctions;

namespace TestScriptDemoProject1.WebPages
{
    class DressPage
    {
        private IWebDriver driver;

        public DressPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void AddFourItemsToWishList()
        {
            //Select Clothing option from Main Page
            var clothigElement = driver.FindElement(By.CssSelector("a.envo-categories-menu-first"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(clothigElement).Perform();

            var clothingMenu = driver.FindElement(By.XPath("//a[@title='Clothing']"));
            clothingMenu.Click();

            //Add Four Items to the WishList

            var AddElementsToWishList = driver.FindElements(By.CssSelector("a.add_to_wishlist"));
            int maxLength = 3;
            if (AddElementsToWishList.Count < 3)
            {
                maxLength = AddElementsToWishList.Count;
            }

            for (int i = 0; i <= maxLength; i++)
            {
                AddElementsToWishList[i].Click();
                Thread.Sleep(2000);
            }
        }
       
    }
}
