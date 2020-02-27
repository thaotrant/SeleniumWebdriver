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
    public class BugDetail
    {
        #region WebElements
        [FindsBy(How = How.Id, Using = "bug_severity")]
        private IWebElement severityDropdown;

        [FindsBy(How = How.Id, Using = "short_desc")]
        private IWebElement summary;

        [FindsBy(How = How.Id, Using = "comment")]
        private IWebElement description;

        [FindsBy(How = How.XPath, Using = "//div[@id='header']/descendant::a[text()='Home']")]
        private IWebElement homeLink;

        //private By severityDropdown = By.Id("bug_severity");
        //private By summary = By.Id("short_desc");        
        //private By description = By.Id("comment");
        //private By homeLink = By.XPath("//div[@id='header']/descendant::a[text()='Home']");

        public IWebElement Summary { get { return summary; } }
        public IWebElement Description { get { return description; }}
        #endregion
        public BugDetail()
        {
            PageFactory.InitElements(ObjectRepository.Driver, this);
        }

        #region Actions
        public void SelectSeverity(string text)
        {
            DropdownListHelper.SelectElement(severityDropdown, "minor");
        }
        public void FillTextBox(IWebElement element, string text)
        {
            TextBoxHelper.ClearTextbox(element);
            TextBoxHelper.TypeInTextbox(element, text);
        }        
        #endregion

        #region Navigation
        public HomePage NavigationToHomePage()
        {
            homeLink.Click();
            return new HomePage();
        }
        #endregion
    }
}
