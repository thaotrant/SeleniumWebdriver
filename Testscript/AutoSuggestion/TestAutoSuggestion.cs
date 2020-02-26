using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWebdriver.Testscript.AutoSuggestion
{
    [TestClass]
    public class TestAutoSuggestion
    {
        [TestMethod]
        public void TestAutoSuggest()
        {
            NavigationHelper.NavigationToURL("https://demos.telerik.com/kendo-ui/autocomplete/index");
            //Step 1 - to supply the initial string
            //var textbox = ObjectRepository.Driver.FindElement(By.Id("countries"));
            TextBoxHelper.TypeInTextbox(By.Id("countries"), "a");
            Thread.Sleep(1000);

            // Step 2 - Wait for auto suggestion list
            var wait = GenericHelpers.GetWebDriverWait(TimeSpan.FromSeconds(40));
            var elements = wait.Until(GetAllElements(By.XPath("//ul[@id='countries_listbox']/child::li")));

            foreach (var ele in elements)
            {
                if(ele.Text.Equals("Albania"))
                {
                    ele.Click();
                }
            }
            Thread.Sleep(1000);
        }
        private Func<IWebDriver, IList<IWebElement>> GetAllElements(By locator)
        {
            return ((x) =>
            {
                return x.FindElements(locator);
            });
        }
    }
}
