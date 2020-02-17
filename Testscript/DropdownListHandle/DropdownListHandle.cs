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

namespace SeleniumWebdriver.Testscript.DropdownListHandle
{
    public class DropdownListHandle
    {
        [TestClass]
        public class HandleRadioButton
        {
            [TestMethod]
            public void CheckDropDownList()
            {
                NavigationHelper.NavigationToURL(ObjectRepository.Config.GetWebsite());
                LinkHelper.ClickLink(By.LinkText("File a Bug"));
                Thread.Sleep(100);

                TextBoxHelper.ClearTextbox(By.Id("Bugzilla_login"));
                TextBoxHelper.TypeInTextbox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());

                TextBoxHelper.ClearTextbox(By.Id("Bugzilla_password"));
                TextBoxHelper.TypeInTextbox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());

                ButtonHelper.ClickOnButton(By.Id("log_in"));                

                IList<string> getAllOptions = DropdownListHelper.GetAllItems(By.Id("bug_severity"));
                foreach(string var in getAllOptions)
                {
                    Console.WriteLine(var);
                }

            }
        }

    }
}
