using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.Keyword
{
    [TestClass]
    public class TestKeywordDriven
    {
        private string xlPath = @"D:\Git\SeleniumWebdriver\DataFiles\Keywords.xlsx";
        private string sheetName = "TC1";

        [TestMethod]
        public void RunningDataDrivenTest()
        {
            
            DataEngine dataEngine = new DataEngine();
            dataEngine.ExecuteScripts(xlPath, sheetName);                
        }
    }
}
