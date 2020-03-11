using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.CustomException;
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

        public DataEngine(int keywordCol, int locatorTypeCol, int locatorValueCol, int parameterCol)
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
                        TimeSpan.FromMilliseconds(100));
                    break;                
                default:
                    throw new NoSuchKeywordException("No such keyword found" + keyword);                    
            }
        }
    }
}
