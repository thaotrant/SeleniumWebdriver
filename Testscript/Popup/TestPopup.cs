using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SeleniumWebdriver.Testscript.Popup
{
    [TestClass]
    public class TestPopup
    {
        [TestMethod]
        public void TestAlert()
        {
            //NavigationHelper.NavigationToURL("https://www.w3schools.com/js/js_popup.asp");
            //ButtonHelper.ClickOnButton(By.XPath("//div[@id='main']/descendant::a[position()=3]"));
            //BrowserHelper.SwitchToWindow(1);
            //switch to iframe to work on Iframe
            NavigationHelper.NavigationToURL("https://www.w3schools.com/js/tryit.asp?filename=tryjs_alert");
            ObjectRepository.Driver.SwitchTo().Frame(ObjectRepository.Driver.FindElement(By.Id("iframeResult")));
            ButtonHelper.ClickOnButton(By.XPath("//button[text()='Try it']"));
            if(JavaScriptPopupHelper.IsPopupPresent())
            {
                var text = JavaScriptPopupHelper.GetPopupText();
                JavaScriptPopupHelper.ClickOKonPopup();
                ObjectRepository.Driver.SwitchTo().DefaultContent();
                // Add this line before the line of code , where you are trying to clear the text area
                IWebElement textarea = ObjectRepository.Driver.FindElement(By.Id("textareaCode"));
                ExecuteScript("document.getElementById('textareaCode').setAttribute('style','display: inline;')");

                TextBoxHelper.ClearTextbox(By.Id("textareaCode"));
                TextBoxHelper.TypeInTextbox(By.Id("textareaCode"), text);
            }       
        }
        public static object ExecuteScript(string script)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.Driver);

            return executor.ExecuteScript(script);

        }
        [TestMethod]
        public void TestConfirmPopup()
        {
            NavigationHelper.NavigationToURL("https://www.w3schools.com/js/tryit.asp?filename=tryjs_confirm");
            ObjectRepository.Driver.SwitchTo().Frame(ObjectRepository.Driver.FindElement(By.Id("iframeResult")));
            ButtonHelper.ClickOnButton(By.XPath("//button[text()='Try it']"));
            JavaScriptPopupHelper.ClickOKonPopup();
            ButtonHelper.ClickOnButton(By.XPath("//button[text()='Try it']"));
            JavaScriptPopupHelper.ClickCancelOnPopup();

        }
        [TestMethod]
        public void TestPromp()
        {
            NavigationHelper.NavigationToURL("https://www.w3schools.com/js/tryit.asp?filename=tryjs_prompt");
            ObjectRepository.Driver.SwitchTo().Frame(ObjectRepository.Driver.FindElement(By.Id("iframeResult")));
            ButtonHelper.ClickOnButton(By.XPath("//button[text()='Try it']"));
            var popupText = JavaScriptPopupHelper.GetPopupText();
            //IAlert promp = ObjectRepository.Driver.SwitchTo().Alert();
            //promp.SendKeys("Thao");
            //promp.Accept();
            JavaScriptPopupHelper.SendKeys(popupText);
            JavaScriptPopupHelper.ClickOKonPopup();

            //ButtonHelper.ClickOnButton(By.XPath("//button[text()='Try it']"));
            //promp = ObjectRepository.Driver.SwitchTo().Alert();
            //promp.SendKeys("Thao123");
            //promp.Dismiss();
        }
    }
}
