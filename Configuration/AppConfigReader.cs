using SeleniumWebdriver.Interfaces;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.Configuration
{
    public class AppConfigReader : IConfig
    {
        public BrowserType GetBrowser()
        {
            string browser =  ConfigurationManager.AppSettings.Get(AppConfigKeys.BROWSER);
            return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
        }

        public string GetPassword()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.PASSWORD);
        }

        public string GetUsername()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.USERNAME);
        }
        public string GetWebsite()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.WEBSITE);
        }
        public int GetPageLoadTimeout()
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.PAGELOADTIMEOUT);
            if (timeout == null)
                return 30;
            else
                return Convert.ToInt32(timeout);
        }

        public int GetElementLoadTimeout()
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.ELEMENTLOADTIMEOUT);
            if (timeout == null)
                return 30;
            else
                return Convert.ToInt32(timeout);
        }
    }
}
