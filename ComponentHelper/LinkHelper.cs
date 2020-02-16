using OpenQA.Selenium;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWebdriver.ComponentHelper
{
    public class LinkHelper
    {
        public static IWebElement element;
        public static void ClickLink(By locator)
        {
            element = GenericHelpers.GetElement(locator);
            element.Click();            
        }
    }
}
