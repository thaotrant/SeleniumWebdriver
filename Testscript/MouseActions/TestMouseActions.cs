using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumWebdriver.Testscript.MouseActions
{
    [TestClass]
    public class TestMouseActions
    {
        [TestMethod]
        public void TestContextClick()
        {
            //ContextClick is right click on the mouse
            NavigationHelper.NavigationToURL("https://demos.telerik.com/kendo-ui/dragdrop/events");
            Actions actions = new Actions(ObjectRepository.Driver);


            actions.ContextClick(ObjectRepository.Driver.FindElement(By.Id("draggable")))
                .Build()
                .Perform();
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void TestDragNDrop()
        {
            NavigationHelper.NavigationToURL("https://demos.telerik.com/kendo-ui/dragdrop/events");
            Actions actions = new Actions(ObjectRepository.Driver);

            //actions.ClickAndHold(ObjectRepository.Driver.FindElement(By.Id("draggable")));
            actions.DragAndDrop(ObjectRepository.Driver.FindElement(By.Id("draggable")), ObjectRepository.Driver.FindElement(By.Id("droptarget")))
                .Build()
                .Perform();
        }
        [TestMethod]
        public void TestClickNHold()
        {
            //click and hold then move to element is used to drag drop to order elements
            NavigationHelper.NavigationToURL("http://demos.telerik.com/kendo-ui/sortable/index");
            Actions actions = new Actions(ObjectRepository.Driver);

            var src = ObjectRepository.Driver.FindElement(By.XPath("//ul[@id='sortable-basic']/li[12]"));
            var tar = ObjectRepository.Driver.FindElement(By.XPath("//ul[@id='sortable-basic']/li[1]"));

            actions.ClickAndHold(src)
                .MoveToElement(tar)
                .Release()
                .Build()
                .Perform();

            Thread.Sleep(1000);
            
        }
    }
}
