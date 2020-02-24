using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.Testscript.MultipleBrowsers
{
    [TestClass]
    public class TestMultipleBrowserWindows
    {
        [TestMethod]
        public void TestMultipleBrowser()
        {
            NavigationHelper.NavigationToURL("https://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickOnButton(By.XPath("//div[@id='main']/descendant::a[position()=3]"));
            BrowserHelper.SwitchToWindow(0);
            ButtonHelper.ClickOnButton(By.XPath("//div[@id='main']/descendant::a[position()=3]"));
            BrowserHelper.SwitchToWindow(1);
            ButtonHelper.ClickOnButton(By.XPath("//div[@class='w3-bar']/descendant::button"));
            //ButtonHelper.ClickOnButton(By.XPath("//div[@id='main']/descendant::a[position()=2]"));
            //ObjectRepository.Driver.Close();
            //BrowserHelper.SwitchToWindow(0);
            //ObjectRepository.Driver.Quit();
            BrowserHelper.SwitchToParentWindow();
        }
        [TestMethod]
        public void TestFrame()
        {
            NavigationHelper.NavigationToURL("https://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickOnButton(By.XPath("//div[@id='main']/descendant::a[position()=3]"));
            BrowserHelper.SwitchToWindow(1);
            //switch to iframe to work on Iframe
            ObjectRepository.Driver.SwitchTo().Frame(ObjectRepository.Driver.FindElement(By.Id("iframeResult")));
            ButtonHelper.ClickOnButton(By.XPath("//button[text()='Try it']")); 
            IAlert alert = ObjectRepository.Driver.SwitchTo().Alert();
            alert.Accept();

            //switch to default data in the page
            ObjectRepository.Driver.SwitchTo().DefaultContent();
            ButtonHelper.ClickOnButton(By.XPath("//div[@class='w3-bar']/descendant::button"));
        }
    }
}
