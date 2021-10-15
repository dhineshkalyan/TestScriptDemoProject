
using System.Threading;
using TechTalk.SpecFlow;
using NUnit.Framework;
using TestScriptDemoProject1.BaseFunctions;
using TestScriptDemoProject1.WebPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestScriptDemoProject1.StepDefinitions
{
    [Binding]
    public class TestScriptDemoSteps
    {
        IWebDriver driver = new ChromeDriver();

        [Given(@"I add four different products to my wish list")]
        public void GivenIAddFourDifferentProductsToMyWishList()
        {
            PageBase baseDriver = new PageBase();
            driver =  baseDriver.Initialize() ;

            DressPage dressPage = new DressPage(driver);
            dressPage.AddFourItemsToWishList();
        }

        [When(@"I view my wishlist table")]
        public void WhenIViewMyWishlistTable()
        {
           WishListPage wishListPage = new WishListPage(driver);
           wishListPage.NavigateToWishListPage();
        }

        [Then(@"I find total four selected items in my Wishlist")]
        public void ThenIFindTotalFourSelectedItemsInMyWishlist()
        {
            //Validate the 4 Items added to the cart
            WishListPage wishListPage = new WishListPage(driver);
            var totalElements = wishListPage.GetWishListElements();
            Assert.AreEqual(4, totalElements.Count);
        }

        [When(@"I search for lowest price product")]
        public void WhenISearchForLowestPriceProduct()
        {
            //Search for the lowest price product
            WishListPage wishListPage = new WishListPage(driver);
            wishListPage.GetTheLowestPriceProduct();
        }

        [When(@"I am able to add the lowest price item to my cart")]
        public void WhenIAmAbleToAddTheLowestPriceItemToMyCart()
        {
            WishListPage wishListPage = new WishListPage(driver);
            wishListPage.AddTheLowestPriceItemToCart();
            Thread.Sleep(3000);
        }

        [Then(@"I am able to verify the item in my cart")]
        public void ThenIAmAbleToVerifyTheItemInMyCart()
        {
            CartPage cartPage = new CartPage(driver);
            cartPage.NavigateToTheCartPage();

            var cartItems = cartPage.GetCartItems();
            Assert.AreEqual(1, cartItems.Count);
        }
    }
}
