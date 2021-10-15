using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestScriptDemoProject1.BaseFunctions
{
    class PageBase
    {
        IWebDriver driver;

        public IWebDriver WebDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            return driver;
        }


        public IWebDriver Initialize()
        {
            //Navigate to the URL
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://testscriptdemo.com/");
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
