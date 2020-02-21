using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System.Threading;

namespace SeleniumWebdriver.HyperLinks
{
    [TestClass]
    public class TestHyperLinks
    {
        [TestMethod]
        public void ClickFileABug()
        {
            NavigationHelper.NavigationToURL(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            Thread.Sleep(200);
        }

    }
}
