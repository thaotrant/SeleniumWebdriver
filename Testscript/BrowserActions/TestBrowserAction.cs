using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.Testscript.BrowserActions
{
    [TestClass]
    public class TestBrowserAction
    {
        [TestMethod]
        public void TestActions()
        {
            NavigationHelper.NavigationToURL("localhost:5001/enter_bug.cgi");
            ObjectRepository.Driver.Manage().Window.Maximize();
            ButtonHelper.ClickOnButton(By.LinkText("create a new account"));
            ObjectRepository.Driver.Navigate().Back();
            ObjectRepository.Driver.Navigate().Forward();
            ObjectRepository.Driver.Navigate().Refresh();
        }
    }
}
