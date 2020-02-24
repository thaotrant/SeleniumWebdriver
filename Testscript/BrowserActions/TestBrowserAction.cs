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
            //NavigationHelper.NavigationToURL("localhost:5001/enter_bug.cgi");
            ButtonHelper.ClickOnButton(By.LinkText("Open a New Account"));
            BrowserHelper.GoBack();
            BrowserHelper.GoForward();
            BrowserHelper.RefreshPage();
        }
    }
}
