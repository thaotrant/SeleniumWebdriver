using OpenQA.Selenium;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.ComponentHelper
{
    public static class NavigationHelper
    {
        public static void NavigationToURL(string url)
        {
           ObjectRepository.Driver.Navigate().GoToUrl(url);
        }
    }
}
