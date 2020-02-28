using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.PageObject;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.Testscript.DataDriven
{
    [TestClass]
    public class TestCreateBug
    {
        [TestMethod]
        public void CreateABug()
        {
            NavigationHelper.NavigationToURL(ObjectRepository.Config.GetWebsite());
            HomePage hPage = new HomePage(ObjectRepository.Driver);
            LoginPage loginPage = hPage.NavigateToLogin();
            BugDetail bugDetail = loginPage.LoginToPage(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            bugDetail.SelectDropdownList("minor", "Other", "Linux");
            bugDetail.FillInTextbox("summary", "description");
            bugDetail.SubmitBug();
            hPage = bugDetail.Logout();
        }
    }
}
