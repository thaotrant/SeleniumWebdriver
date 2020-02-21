using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;

namespace SeleniumWebdriver.Testscript.WebElement
{
    [TestClass]
    public class HandleElements
    {
        [TestMethod]
        public void GetAllElements()
        {
            NavigationHelper.NavigationToURL(ObjectRepository.Config.GetWebsite());

            IReadOnlyCollection<IWebElement> elements = ObjectRepository.Driver.FindElements(By.XPath("//input"));
            foreach (var ele in elements)
            {
                Console.WriteLine($"Element {ele.GetAttribute("id")}");
            }
        }
    }
}
