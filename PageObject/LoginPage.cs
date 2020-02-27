using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.PageObject
{
    public class LoginPage
    {
        #region WebElements
        [FindsBy(How = How.Id, Using = "Bugzilla_login")]
        private IWebElement loginField;

        [FindsBy(How = How.Id, Using = "Bugzilla_password")]
        private IWebElement passwordField;

        [FindsBy(How = How.Id, Using = "log_in")]
        private IWebElement loginButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='header']/descendant::a[text()='Home']")]
        private IWebElement homeLink;

        //private By loginField = By.Id("Bugzilla_login");
        //private By passwordField = By.Id("Bugzilla_password");
        //private By loginButton = By.Id("log_in");
        //private By homeLink = By.XPath("//div[@id='header']/descendant::a[text()='Home']");
        #endregion
        public LoginPage()
        {
            PageFactory.InitElements(ObjectRepository.Driver, this);
        }
        #region Actions
        public BugDetail LoginToPage(string username, string password)
        {
            loginField.SendKeys(username);
            passwordField.SendKeys(password);
            loginButton.Click();
            return new BugDetail();
        }
        #endregion
        #region
        public HomePage NavigateToHomePage()
        {
            homeLink.Click();
            return new HomePage();
        }

        #endregion
    }
}
