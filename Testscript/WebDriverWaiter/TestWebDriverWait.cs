using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.Testscript.WebDriverWaiter

{
    [TestClass]
    public class TestWebDriverWait
    {
        [TestMethod]
        public void TestWait()
        {
            NavigationHelper.NavigationToURL("https://www.udemy.com/");
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            //TextBoxHelper.TypeInTextbox(By.Id("header-search-field"), "C#");
            TextBoxHelper.TypeInTextbox(By.XPath("//*[@id='billboard-search-bar']"), "Health");
        }
        [TestMethod]
        public void TestDynamicWait()
        {
            NavigationHelper.NavigationToURL("https://www.udemy.com/");
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(50));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(WaitForElement()).SendKeys("Health");
            ButtonHelper.ClickOnButton(By.CssSelector(".udlite-search-form-autocomplete-input-group-reversed > button:nth-child(2)"));
            wait.Until(WaitForLastElement()).Click();
            Console.WriteLine(wait.Until(WaitForPageTitle()));
        }

        private Func<IWebDriver, bool> WaitForSearchBox()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for searching box");
                return x.FindElements(By.XPath("//*[@id='billboard-search-bar']")).Count == 1;
            });
        }

        private Func<IWebDriver, string> WaitForTitle()
        {
            return ((x) =>
            {
                if (x.Title.Contains("Main"))
                    return x.Title;
                return string.Empty;
            });
        }
        private Func<IWebDriver, IWebElement> WaitForElement()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for element");
                if(x.FindElements(By.CssSelector("#header-desktop-search-bar")).Count == 1)
                    return x.FindElement(By.CssSelector("#header-desktop-search-bar"));
                return null;
            });
        }
        private Func<IWebDriver, IWebElement> WaitForLastElement()
        {
            return ((x) =>
            {
                Console.WriteLine("Wait for last element");
                if (x.FindElements(By.XPath("//*[contains(text(),'37 Intermediate Health & Fat-Burning Hacks')]")).Count == 1)
                    return x.FindElement(By.XPath("//*[contains(text(),'37 Intermediate Health & Fat-Burning Hacks')]"));
                return null;
            });
        }

        private Func<IWebDriver, string> WaitForPageTitle()
        {
            return ((x) =>
            {
                Console.WriteLine("Wait for page title");
                if (x.FindElement(By.CssSelector(".clp-lead__title")).Text.Contains("37 Intermediate Health & Fat-Burning Hacks"))
                    return x.FindElement(By.CssSelector(".clp-lead__title")).Text;
                return null;
            });
        }
    }
}
