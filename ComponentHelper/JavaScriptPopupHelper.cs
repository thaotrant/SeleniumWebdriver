using OpenQA.Selenium;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.ComponentHelper
{
    public class JavaScriptPopupHelper
    {
        public static bool IsPopupPresent()
        {
            try
            {
                ObjectRepository.Driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        public static string GetPopupText()
        {
            if (!IsPopupPresent())
                return string.Empty;
            return ObjectRepository.Driver.SwitchTo().Alert().Text;
        }
        public static void ClickOKonPopup()
        {
            if (!IsPopupPresent())
                return;
            ObjectRepository.Driver.SwitchTo().Alert().Accept();
        }
        public static void ClickCancelOnPopup()
        {
            if (!IsPopupPresent())
                return;
            ObjectRepository.Driver.SwitchTo().Alert().Dismiss();
        }

        public static void SendKeys(string text)
        {
            if (!IsPopupPresent())
                return;
            ObjectRepository.Driver.SwitchTo().Alert().SendKeys(text);
        }
    }
}
