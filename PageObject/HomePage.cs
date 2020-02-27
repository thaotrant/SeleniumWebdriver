using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.PageObject
{
    public class HomePage
    {
        #region WebElements
        [FindsBy(How = How.Id, Using = "quicksearch_top")]
        private IWebElement quickSearchBox;

        [FindsBy(How = How.Id, Using = "find_top")]
        private IWebElement searchButton;

        [FindsBy(How = How.LinkText, Using = "File a Bug")]
        private IWebElement fileABugLink;

        //private By quickSearchBox = By.Id("quicksearch_top");
        //private By searchButton = By.Id("find_top");
        //private By fileABugLink = By.LinkText("File a Bug");
        //private By searchLink = By.CssSelector(".bz_common_actions #query");
        #endregion

        public HomePage()
        {
            PageFactory.InitElements(ObjectRepository.Driver, this);
        }
        #region Actions
        public void QuickSearch(string searchText)
        {
            quickSearchBox.SendKeys(searchText);
            searchButton.Click();
        }
        #endregion

        #region Navigations
        public LoginPage NavigateToLogin()
        {
            fileABugLink.Click();
            return new LoginPage();
        }
        #endregion
    }
}
