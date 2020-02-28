using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebdriver.BaseClasses;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.PageObject
{
    public class BugDetail : PageBase
    {
        private IWebDriver _driver;
        #region WebElements
        [FindsBy(How = How.Id, Using = "bug_severity")]
        private IWebElement severityDropdown;

        [FindsBy(How = How.Id, Using = "rep_platform")]
        private IWebElement hardwareDropdown;

        [FindsBy(How = How.Id, Using = "op_sys")]
        private IWebElement osDropdown;

        [FindsBy(How = How.Id, Using = "short_desc")]
        private IWebElement summaryTextbox;

        [FindsBy(How = How.Id, Using = "comment")]
        private IWebElement descriptionTextbox;

        [FindsBy(How = How.Id, Using = "commit")]
        private IWebElement submitButton;
       

        //private By severityDropdown = By.Id("bug_severity");
        //private By summary = By.Id("short_desc");        
        //private By description = By.Id("comment");
        //private By homeLink = By.XPath("//div[@id='header']/descendant::a[text()='Home']");
        
        #endregion
        public BugDetail(IWebDriver driver) : base(driver)
        {
            this._driver = driver;
        }

        #region Actions
        public void SelectDropdownList(string severity = null, string hardware = null, string os = null)
        {
            if(severity != null)
                DropdownListHelper.SelectElement(severityDropdown, severity);
            if (hardware != null)
                DropdownListHelper.SelectElement(hardwareDropdown, hardware);
            if (os != null)
                DropdownListHelper.SelectElement(osDropdown, os);
        }
        public void FillInTextbox(string summary = null, string description = null)
        {
            if (summary != null)
            {
                TextBoxHelper.ClearTextbox(summaryTextbox);
                TextBoxHelper.TypeInTextbox(summaryTextbox, summary);
            }
            if (description != null)
            {
                TextBoxHelper.ClearTextbox(descriptionTextbox);
                TextBoxHelper.TypeInTextbox(descriptionTextbox, description);
            }
        }
        
        public void SubmitBug()
        {
            submitButton.Click();
            GenericHelpers.WaitForElementInPage(By.Id("bugzilla-body"), TimeSpan.FromSeconds(30));
        }
        #endregion

        #region Navigation
        public HomePage Logout()
        {
            base.Logout();
            return new HomePage(_driver);
        }        
        #endregion
    }
}
