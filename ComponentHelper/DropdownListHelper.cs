using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriver.Settings;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumWebdriver.ComponentHelper
{
    public class DropdownListHelper
    {
        private static SelectElement selectElement;

        public static void SelectElement(By locator, int index)
        {
            selectElement = new SelectElement(ObjectRepository.Driver.FindElement(locator));
            selectElement.SelectByIndex(index);
        }

        public static void SelectElement(By locator, string visibleText)
        {
            selectElement = new SelectElement(ObjectRepository.Driver.FindElement(locator));
            selectElement.SelectByValue(visibleText);
        }

        public static IList<string> GetAllItems(By locator)
        {
            selectElement = new SelectElement(ObjectRepository.Driver.FindElement(locator));
            return selectElement.Options.Select((x => x.Text)).ToList();
        }
        public static void SelectElement(IWebElement element, string visibleText)
        {
            selectElement = new SelectElement(element);
            selectElement.SelectByValue(visibleText);
        }
    }
}
