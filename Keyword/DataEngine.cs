using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.CustomException;
using SeleniumWebdriver.ExcelReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.Keyword
{
    public class DataEngine
    {
        private readonly int _keywordCol;
        private readonly int _locatorTypeCol;
        private readonly int _locatorValueCol;
        private readonly int _parameterCol;

        public DataEngine(int keywordCol = 2, int locatorTypeCol = 3, int locatorValueCol = 4, int parameterCol = 5)
        {
            this._keywordCol = keywordCol;
            this._locatorTypeCol = locatorTypeCol;
            this._locatorValueCol = locatorValueCol;
            this._parameterCol = parameterCol;            
        }
        private By GetElementLocator(string locatorType, string locatorValue)
        {
            switch (locatorType)
            {
                case "Id":
                    return By.Id(locatorValue);
                case "XPath":
                    return By.XPath(locatorValue);
                case "LinkText":
                    return By.LinkText(locatorValue);
                case "ClassName":
                    return By.ClassName(locatorValue);
                case "CssSelector":
                    return By.CssSelector(locatorValue);
                case "Name":
                    return By.Name(locatorValue);
                case "PartialLinkText":
                    return By.PartialLinkText(locatorValue);
                default:
                    return By.Id(locatorValue);
            }
        }
        public void PerformActions(string keyword, string locatorType, string locatorValue, params string[] parameters)
        {
            switch (keyword)
            {
                case "Click":
                    ButtonHelper.ClickOnButton(GetElementLocator(locatorType, locatorValue));
                    break;
                case "SendKeys":
                    {
                       TextBoxHelper.ClearTextbox(GetElementLocator(locatorType, locatorValue));
                       TextBoxHelper.TypeInTextbox(GetElementLocator(locatorType, locatorValue), parameters[0]);
                    }
                    break;                    
                case "Navigate":
                    NavigationHelper.NavigationToURL(parameters[0]);
                    break;
                case "Select":
                    DropdownListHelper.SelectElement(GetElementLocator(locatorType, locatorValue), parameters[0]);
                    break;
                case "WaitForEle":
                    GenericHelpers.WaitForElementInPage(GetElementLocator(locatorType, locatorValue),
                        TimeSpan.FromSeconds(60));
                    break;                
                default:
                    throw new NoSuchKeywordException("No such keyword found" + keyword);                    
            }
        }
        public void ExecuteScripts(string xlPath, string sheetName)
        {
            int totalRows = ExcelReaderHelper.GetTotalExcelColumns(xlPath, sheetName);
            for (int i = 1; i < totalRows; i++)
            {
                var keyword = ExcelReaderHelper.GetCellData(xlPath, sheetName, i, _keywordCol).ToString();
                var locatorType = ExcelReaderHelper.GetCellData(xlPath, sheetName, i, _locatorTypeCol).ToString();
                var locatorVal = ExcelReaderHelper.GetCellData(xlPath, sheetName, i, _locatorValueCol).ToString();
                var para = ExcelReaderHelper.GetCellData(xlPath, sheetName, i, _parameterCol).ToString();
                PerformActions(keyword, locatorType, locatorVal, para);
            }
        }
    }
}
