using OpenQA.Selenium;

namespace SeleniumWebdriver.ComponentHelper
{
    public class LinkHelper
    {
        public static IWebElement element;
        public static void ClickLink(By locator)
        {
            element = GenericHelpers.GetElement(locator);
            element.Click();
        }
    }
}
