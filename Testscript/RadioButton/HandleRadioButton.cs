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

namespace SeleniumWebdriver.Testscript.RadioButton
{
    [TestClass]
    public class HandleRadioButton
    {
        [TestMethod]
        public void CheckRadioButton()
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

            LinkHelper.ClickLink(By.XPath("//div[@id='header']/ul[1]/li[9]/a"));
            LinkHelper.ClickLink(By.LinkText("Parameters"));
            Thread.Sleep(100);
            Console.WriteLine("Radio button status: {0}", RadioButtonHelper.IsRadioButtonChecked(By.Id("ssl_redirect-on")));

            RadioButtonHelper.CheckedRadioButton(By.Id("ssl_redirect-on"));
            Console.WriteLine("Radio button status: {0}", RadioButtonHelper.IsRadioButtonChecked(By.Id("ssl_redirect-on")));
            Console.WriteLine(GenericHelpers.GetElement(By.XPath("//div[@id='header']/ul[1]/li[11]/a")).Text);
            LinkHelper.ClickLink(By.XPath("//div[@id='header']/ul[1]/li[11]/a"));
        }
    }
}