using ExcelDataReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.ExcelReader
{
    [TestClass]
    public class TestExcelReader
    {
        [TestMethod]
        public void TestReadExcel()
        {
            FileStream stream = new FileStream(@"D:\Git\SeleniumWebdriver\DataFiles\Data.xlsx", FileMode.Open, FileAccess.Read);
            IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataTable table = reader.AsDataSet().Tables["Bugzilla"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Rows[i].ItemArray.Length; j++)
                {
                    Console.WriteLine($"Data: {table.Rows[i][j]}");
                }
            }            
        }
    }
}
