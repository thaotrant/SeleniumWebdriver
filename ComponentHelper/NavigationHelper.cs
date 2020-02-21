using SeleniumWebdriver.Settings;

namespace SeleniumWebdriver.ComponentHelper
{
    public static class NavigationHelper
    {
        public static void NavigationToURL(string url)
        {
            ObjectRepository.Driver.Navigate().GoToUrl(url);
        }
    }
}
