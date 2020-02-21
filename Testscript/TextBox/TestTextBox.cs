using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System.Threading;

namespace SeleniumWebdriver.Testscript.TextBox
{
    [TestClass]
    public class TestTextBox
    {
        [TestMethod]
        public void Textbox()
        {
            NavigationHelper.NavigationToURL(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            Thread.Sleep(100);

            TextBoxHelper.ClearTextbox(By.Id("Bugzilla_login"));
            TextBoxHelper.TypeInTextbox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());

            TextBoxHelper.ClearTextbox(By.Id("Bugzilla_password"));
            TextBoxHelper.TypeInTextbox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());
        }
    }
}
