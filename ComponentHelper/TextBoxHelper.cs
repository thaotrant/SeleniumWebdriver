using OpenQA.Selenium;

namespace SeleniumWebdriver.ComponentHelper
{
    public class TextBoxHelper
    {
        public static IWebElement element;
        public static void TypeInTextbox(By locator, string text)
        {
            element = GenericHelpers.GetElement(locator);
            element.Clear();
            element.SendKeys(text);
        }
        public static void ClearTextbox(By locator)
        {
            element = GenericHelpers.GetElement(locator);
            element.Clear();
        }

        public static void ClearTextbox(IWebElement element)
        {
            element.Clear();
        }
        public static void TypeInTextbox(IWebElement element, string text)
        {          
            element.Clear();
            element.SendKeys(text);
        }
    }
}
