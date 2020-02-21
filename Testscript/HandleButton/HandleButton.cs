using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Threading;

namespace SeleniumWebdriver.Testscript.HandleButton
{
    [TestClass]
    public class HandleButton
    {
        [TestMethod]
        public void ClickLoginButton()
        {
            NavigationHelper.NavigationToURL(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            Thread.Sleep(100);

            TextBoxHelper.ClearTextbox(By.Id("Bugzilla_login"));
            TextBoxHelper.TypeInTextbox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());

            TextBoxHelper.ClearTextbox(By.Id("Bugzilla_password"));
            TextBoxHelper.TypeInTextbox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());

            Console.WriteLine(CheckboxHelper.IsChecboxChecked(By.Id("Bugzilla_restrictlogin")));
            if (CheckboxHelper.IsChecboxChecked(By.Id("Bugzilla_restrictlogin")))
                CheckboxHelper.CheckedCheckbox(By.Id("Bugzilla_restrictlogin"));
            Console.WriteLine(CheckboxHelper.IsChecboxChecked(By.Id("Bugzilla_restrictlogin")));

            Console.WriteLine(ButtonHelper.GetButtonText(By.Id("log_in")));
            Console.WriteLine(ButtonHelper.IsButtonEnabled(By.Id("log_in")));
            ButtonHelper.ClickOnButton(By.Id("log_in"));

        }
    }
}
