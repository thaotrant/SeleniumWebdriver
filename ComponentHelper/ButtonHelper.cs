﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.ComponentHelper
{
    public class ButtonHelper
    {
        private static IWebElement element;
        public static bool IsButtonEnabled(By locator)
        {
            element = GenericHelpers.GetElement(locator);
            return element.Enabled;
        }
        public static void ClickOnButton(By locator)
        {
            element = GenericHelpers.GetElement(locator);
            element.Click();
        }
        public static string GetButtonText(By locator)
        {
            element = GenericHelpers.GetElement(locator);
            if (element.GetAttribute("value") == null)
                return string.Empty;
            else
            return element.GetAttribute("value");
        }        
    }
}