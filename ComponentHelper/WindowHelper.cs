using SeleniumWebdriver.Settings;

namespace SeleniumWebdriver.ComponentHelper
{
    public class WindowHelper
    {
        public static string GetTitle()
        {
            return ObjectRepository.Driver.Title;
        }
    }
}
