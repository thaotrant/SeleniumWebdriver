using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.ExcelReader;
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
        public void CreateABugCSV()
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

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"D:\Git\SeleniumWebdriver\DataFiles\TestData.xml", "Row", DataAccessMethod.Sequential)]
        public void CreateABugXML()
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
        [TestMethod]
        [DataSource("System.Data.Odbc", @"Dsn=Excel Files;dbq=D:\Git\SeleniumWebdriver\DataFiles\DataForBug.xlsx;", "TestExcelData$", DataAccessMethod.Sequential)]
        public void CreateABugXcel()
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
        [TestMethod]
        public void CreateBugDDF()
        {
            string xlPath = @"D:\Git\SeleniumWebdriver\DataFiles\DataForBug.xlsx";
            Console.WriteLine(ExcelReaderHelper.GetCellData(xlPath, "Sheet1", 0, 0));

            NavigationHelper.NavigationToURL(ObjectRepository.Config.GetWebsite());
            HomePage hPage = new HomePage(ObjectRepository.Driver);
            LoginPage loginPage = hPage.NavigateToLogin();
            BugDetail bugDetail = loginPage.LoginToPage(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            bugDetail.SelectDropdownList(ExcelReaderHelper.GetCellData(xlPath,"Sheet1", 1, 0).ToString(),
                ExcelReaderHelper.GetCellData(xlPath, "Sheet1", 1, 1).ToString(), ExcelReaderHelper.GetCellData(xlPath, "Sheet1", 1, 2).ToString());
            bugDetail.FillInTextbox(ExcelReaderHelper.GetCellData(xlPath, "Sheet1", 1, 3).ToString(), ExcelReaderHelper.GetCellData(xlPath, "Sheet1", 1, 4).ToString());
            bugDetail.SubmitBug();
            hPage = bugDetail.Logout();
        }
    }
}
