using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Threading;

namespace SeleniumWebdriver.Testscript
{
    [TestClass]
    public class TestPageNavigation
    {
        [TestMethod]
        public void OpenPage()
        {
            NavigationHelper.NavigationToURL(ObjectRepository.Config.GetWebsite());
            Thread.Sleep(500);
            Console.WriteLine("Title of page: {0}", WindowHelper.GetTitle());
        }

    }
}
