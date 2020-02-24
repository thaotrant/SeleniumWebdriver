using OpenQA.Selenium;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.ComponentHelper
{
    public class BrowserHelper
    {
        public static void BrowserMaximize()
        {
            ObjectRepository.Driver.Manage().Window.Maximize();
        }

        public static void GoBack()
        {
            ObjectRepository.Driver.Navigate().Back();
        }

        public static void GoForward()
        {
            ObjectRepository.Driver.Navigate().Forward();
        }

        public static void RefreshPage()
        {
            ObjectRepository.Driver.Navigate().Refresh();
        }
        public static void SwitchToWindow(int index)
        {
            ReadOnlyCollection<string> windows = ObjectRepository.Driver.WindowHandles;
            if(windows.Count < index)
            {
                throw new NoSuchWindowException("Invalid browser Window Index" + index);
            }
            ObjectRepository.Driver.SwitchTo().Window(windows[index]);
            BrowserMaximize();
        }
        public static void SwitchToParentWindow()
        {
            var windows = ObjectRepository.Driver.WindowHandles;
            for (int i = windows.Count; i > 1; i--)
            {
                ObjectRepository.Driver.SwitchTo().Window(windows[i-1]);
                ObjectRepository.Driver.Close();                
            }
            ObjectRepository.Driver.SwitchTo().Window(windows[0]);           
        }
    }
}
