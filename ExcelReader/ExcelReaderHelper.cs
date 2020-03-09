using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.ExcelReader
{
    public class ExcelReaderHelper
    {
        private static IDictionary<string, IExcelDataReader> _cache;
        private static FileStream fileStream;
        private static IExcelDataReader reader;

        static ExcelReaderHelper()
        {
            _cache = new Dictionary<string, IExcelDataReader>();
        }
        public static object GetCellData(string xlPath, string sheetName, int row, int column)
        {
            if(_cache.ContainsKey(sheetName))
            {
                reader = _cache[sheetName];
            }
            else
            {
                fileStream = new FileStream(xlPath, FileMode.Open, FileAccess.Read);
                reader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
                _cache.Add(sheetName, reader);
            }
            DataTable table = reader.AsDataSet().Tables[sheetName];
            //return table.Rows[row][column].ToString();
            return GetData(table.Rows[row][column].GetType(), table.Rows[row][column]);
        }
        private static object GetData(Type type, object data)
        {
            switch (type.Name)
            {
                case "String":
                    return data.ToString();
                case "Double":
                    return Convert.ToDouble(data);
                case "DateTime":
                    return Convert.ToDateTime(data);
                case "Int32":
                    return Convert.ToInt32(data);
                default:
                    return data.ToString();
            }
        }
     }
}
