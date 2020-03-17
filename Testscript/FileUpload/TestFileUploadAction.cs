using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.PageObject;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWebdriver.Testscript.FileUpload
{
    [TestClass]
    public class TestFileUploadAction
    {
        [TestMethod]
        public void TestUpload()
        {
            NavigationHelper.NavigationToURL(ObjectRepository.Config.GetWebsite());
            HomePage hPage = new HomePage(ObjectRepository.Driver);
            LoginPage loginPage = hPage.NavigateToLogin();
            BugDetail bugDetail = loginPage.LoginToPage(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            bugDetail.AttachmentClick();
            //bugDetail.ChooseFileClick();           

            IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.Driver);
            executor.ExecuteScript("arguments[0].click();", ObjectRepository.Driver.FindElement(By.Id("data")));

            var fileToUploadPath = @"Desktop\Phim_tat_chrome.png";
                //@"D:\Git\SeleniumWebdriver\DataFiles\Data.xlsx";
            ProcessStartInfo processInfo = new ProcessStartInfo()
            {
                //FileName = @"D:\Git\SeleniumWebdriver\AutoITScripts\FileUpload.exe",
                FileName = @"D:\Learning coding\BDD_Specflow\FileUpload\FileUpload.exe",
                Arguments = fileToUploadPath,
                UseShellExecute = false
        };            
            using (var process = Process.Start(processInfo))
            {
                process.WaitForExit();
            }      

            Thread.Sleep(5000);
        }
    }
}
