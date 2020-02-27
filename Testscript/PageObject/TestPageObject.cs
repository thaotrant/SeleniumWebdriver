using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.PageObject;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.Testscript.PageObject
{
    [TestClass]
    public class TestPageObject
    {
        [TestMethod]
        public void CreateABug()
        {
            HomePage hPage = new HomePage();
            LoginPage loginPage = hPage.NavigateToLogin();
            BugDetail bugDetail = loginPage.LoginToPage(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            bugDetail.SelectSeverity("minor");
            bugDetail.FillTextBox(bugDetail.Summary, "Bug Summary");
            bugDetail.FillTextBox(bugDetail.Description, "Description");
        }
    }
}
