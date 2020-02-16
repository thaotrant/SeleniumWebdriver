using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.ComponentHelper
{
    public class CheckboxHelper
    {
        private static IWebElement element;
        public static bool IsChecboxChecked(By locator)
        {
            element = GenericHelpers.GetElement(locator);
            string flag = element.GetAttribute("checked");
            if (flag == null)
                return false;
            else
                return flag.Equals("true") || flag.Equals("checked");
        }
        public static void CheckedCheckbox(By locator)
        {
            element = GenericHelpers.GetElement(locator);
            element.Click();
        }
    }
}
