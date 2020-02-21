using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace SeleniumWebdriver.Testscript.RadioButton
{
    [TestClass]
    public class TestMultiElements
    {
        [TestMethod]
        public void MultiElements()
        {
            NavigationHelper.NavigationToURL(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            Thread.Sleep(100);

            TextBoxHelper.ClearTextbox(By.Id("Bugzilla_login"));
            TextBoxHelper.TypeInTextbox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());

            TextBoxHelper.ClearTextbox(By.Id("Bugzilla_password"));
            TextBoxHelper.TypeInTextbox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());

            ButtonHelper.ClickOnButton(By.Id("log_in"));

            Thread.Sleep(100);

            ReadOnlyCollection<IWebElement> elements = ObjectRepository.Driver.FindElements(By.LinkText("Administration"));
            Console.WriteLine(elements[0].Text.ToString());
            Console.WriteLine(elements[1].Text.ToString());

        }
    }
}