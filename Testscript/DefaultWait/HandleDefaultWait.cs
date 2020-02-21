using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.Testscript.DefaultWait
{
    [TestClass]
    public class HandleDefaultWait
    {
        [TestMethod]
        public void TestDefaultWait()
        {
            NavigationHelper.NavigationToURL(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            
            TextBoxHelper.ClearTextbox(By.Id("Bugzilla_login"));
            TextBoxHelper.TypeInTextbox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());

            TextBoxHelper.ClearTextbox(By.Id("Bugzilla_password"));
            TextBoxHelper.TypeInTextbox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());

            ButtonHelper.ClickOnButton(By.Id("log_in"));

            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            GenericHelpers.WaitForElement(By.Id("bug_severity"), TimeSpan.FromSeconds(50));
            IWebElement ele = GenericHelpers.WaitForElementInPage(By.Id("bug_severity"), TimeSpan.FromSeconds(50));
            SelectElement select = new SelectElement(ele);
            select.SelectByText("major");

            //DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(ObjectRepository.Driver.FindElement(By.Id("bug_severity")));
            //wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            //wait.Timeout = TimeSpan.FromSeconds(50);
            //wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            //Console.WriteLine($"After wait: {wait.Until(WaitForValueChange())}");
        }
        private Func<IWebElement, string> WaitForValueChange()
        {   
            return ((x) =>
             {
                 Console.WriteLine("Wait for value change");
                 SelectElement select = new SelectElement(x);
                 if (select.SelectedOption.Text.Equals("major"))
                     return select.SelectedOption.Text;
                 return null;
             });
        }
    }
}
