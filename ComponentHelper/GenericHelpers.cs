using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if(filename.Equals("Screen"))
            {
                filename = filename + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
                screenshot.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
                return;
            }
            screenshot.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
        }

    }
}
