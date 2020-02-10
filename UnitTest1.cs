using System;
using System.Configuration;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebdriver.Configuration;
using SeleniumWebdriver.Interfaces;

namespace SeleniumWebdriver
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*IConfig config = new AppConfigReader();
            Console.WriteLine(config.GetBrowser());
            Console.WriteLine(config.GetUsername());
            Console.WriteLine(config.GetPassword());
            */
            Console.WriteLine("Test");
        }
    }
}
