﻿using SeleniumWebdriver.Configuration;

namespace SeleniumWebdriver.Interfaces
{
    public interface IConfig
    {
        BrowserType GetBrowser();
        string GetUsername();
        string GetPassword();
        string GetWebsite();
        int GetPageLoadTimeout();
        int GetElementLoadTimeout();
    }
}
