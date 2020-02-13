﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleniumWebdriver.Configuration;
using SeleniumWebdriver.CustomException;
using SeleniumWebdriver.Settings;

namespace SeleniumWebdriver.BaseClasses
{
    [TestClass]
    public class BaseClass
    {
        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            //option.AddExtension(@"")
            return option;
        }
        private static InternetExplorerOptions GetInternetExplorerOptions()
        {
            InternetExplorerOptions option = new InternetExplorerOptions();
            option.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            option.EnsureCleanSession = true;
            return option;
        }

        private static FirefoxOptions GetFirefoxOptions()
        {
            FirefoxOptions options = new FirefoxOptions();
            //Add options here
            return options;
        }
        private static IWebDriver GetFirefoxDriver()
        {
            IWebDriver driver = new FirefoxDriver(GetFirefoxOptions());
            return driver;
        }
        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }
        private static IWebDriver GetIExplorerDriver()
        {
            IWebDriver driver = new InternetExplorerDriver(GetInternetExplorerOptions());
            return driver;
        }

        [AssemblyInitialize]
        public static void InitWebdriver(TestContext tc)
        {
            ObjectRepository.Config = new AppConfigReader();
            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Firefox:
                    ObjectRepository.Driver = GetFirefoxDriver();
                    break;

                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver();
                    break;

                case BrowserType.IExplorer:
                    ObjectRepository.Driver = GetIExplorerDriver();
                    break;

                default:
                    throw new NoSuitableDriverFound("No suitable driver found for {0}" + ObjectRepository.Config.GetBrowser());
                   
            }
        }
        [AssemblyCleanup]
        public static void TearDown()
        {
            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
            }
        }
    }
}