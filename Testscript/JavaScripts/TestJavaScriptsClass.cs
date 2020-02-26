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

namespace SeleniumWebdriver.Testscript.JavaScripts
{
    [TestClass]
    public class TestJavaScriptsClass
    {
        [TestMethod]
        public void TestJavaScripts()
        {
            NavigationHelper.NavigationToURL(ObjectRepository.Config.GetWebsite());
            ButtonHelper.ClickOnButton(By.LinkText("File a Bug"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)(ObjectRepository.Driver);
            executor.ExecuteScript("document.getElementById('Bugzilla_login').value='thaotran@bugzilla.com'");
            executor.ExecuteScript("document.getElementById('Bugzilla_password').value='123456'");
            executor.ExecuteScript("document.getElementById('log_in').click()");
            Thread.Sleep(1000);

        }
        [TestMethod]
        public void TestJavaScriptScroll()
        {
            NavigationHelper.NavigationToURL("https://www.guru99.com/execute-javascript-selenium-webdriver.html");
            IJavaScriptExecutor executor = (IJavaScriptExecutor)ObjectRepository.Driver;

            var element = ObjectRepository.Driver.FindElement(By.XPath("//footer[@id='g-footer']/descendant::a[text()='Selenium']"));
            executor.ExecuteScript($"window.scroll(0, {element.Location.Y})");

        }
    }
}
