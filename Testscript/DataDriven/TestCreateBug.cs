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
        private TestContext _testContext;
        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value; }
        }
        
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"D:\Git\SeleniumWebdriver\DataFiles\CreateData.csv", "CreateData#csv", DataAccessMethod.Sequential)]
        public void CreateABug()
        {
            NavigationHelper.NavigationToURL(ObjectRepository.Config.GetWebsite());
            HomePage hPage = new HomePage(ObjectRepository.Driver);
            LoginPage loginPage = hPage.NavigateToLogin();
            BugDetail bugDetail = loginPage.LoginToPage(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            bugDetail.SelectDropdownList(TestContext.DataRow["Severity"].ToString(), TestContext.DataRow["HardWare"].ToString(), TestContext.DataRow["OS"].ToString());
            bugDetail.FillInTextbox(TestContext.DataRow["Summary"].ToString(), TestContext.DataRow["Desc"].ToString());
            bugDetail.SubmitBug();
            hPage = bugDetail.Logout();
        }
    }
}
