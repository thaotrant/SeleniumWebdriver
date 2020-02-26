using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriver.Settings;
using System;

namespace SeleniumWebdriver.ComponentHelper
{
    public class GenericHelpers
    {
        public static bool IsElenmentPresent(By locator)
        {
            try
            {
                return ObjectRepository.Driver.FindElements(locator).Count == 1;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public static IWebElement GetElement(By locator)
        {
            if (IsElenmentPresent(locator))
                return ObjectRepository.Driver.FindElement(locator);
            else
                throw new NoSuchElementException("Element Not Found: " + locator.ToString());
        }

        public static void TakeScreenShot(String filename = "Screen")
        {
            Screenshot screenshot = ObjectRepository.Driver.TakeScreenshot();
            if (filename.Equals("Screen"))
            {
                filename = filename + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
                screenshot.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
                return;
            }
            screenshot.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
        }
        public static bool WaitForElement(By locator, TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            bool flag = wait.Until(WaitForElementFunc(locator));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeout());
            return flag;
        }
        private static Func<IWebDriver, bool> WaitForElementFunc(By locator)
        {
            return ((x) =>
             {
                 if (x.FindElements(locator).Count == 1)
                     return true;
                 return false;
             });
        }
        public static IWebElement WaitForElementInPage(By locator, TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            IWebElement flag = wait.Until(WaitForElementFuncInPage(locator));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeout());
            return flag;
        }

        public static WebDriverWait GetWebDriverWait(TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            //đó là cách viết gọn của việc thay vì set value for each property thì gom chung lại set values cho cả đám trong 1 statement
            //Instead of code wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
            };            
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            return wait;
        }
                
        private static Func<IWebDriver, IWebElement> WaitForElementFuncInPage(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return x.FindElement(locator);
                return null;
            });
        }
        
        //on FF, CTR + T: open new tab
        //Ctr + Shift + A: Open Addons
        //Alt + F: Open File menu
    }
}
