using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.PageObject;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.BaseClasses
{
    public class PageBase
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//div[@id='header']/ul[1]/li[1]/a")]
        private IWebElement homeLink;        

        public PageBase(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        public void Logout()
        {
            if(GenericHelpers.IsElenmentPresent(By.XPath("//div[@id='header']/descendant::li[position()=11]/a")))
            {
                ButtonHelper.ClickOnButton(By.XPath("//div[@id='header']/descendant::li[position()=11]/a"));         
            }
            GenericHelpers.WaitForElementInPage(By.Id("welcome"), TimeSpan.FromSeconds(30));
        }
        protected void NavigateToHomePage()
        {
            homeLink.Click();
        }
    }
}
