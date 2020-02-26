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

namespace SeleniumWebdriver.Testscript.MouseAndKeyboardActions
{
    [TestClass]
    public class TestMouseKeyboardActions
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
        [TestMethod]
        public void TestKeyboardActions()
        {
            //Some change in the WebDriver so that this kind of action does not work. 
            //Will be investigated
            NavigationHelper.NavigationToURL(ObjectRepository.Config.GetWebsite());
            Actions actions = new Actions(ObjectRepository.Driver);
            // ctrl + t
            //actions.KeyDown(Keys.LeftControl)
            //    .SendKeys("t")
            //    .KeyUp(Keys.LeftControl)
            //    .Build()
            //    .Perform();
            
            // ctrl + shift +a

            //act.KeyDown(Keys.LeftControl)
            //    .KeyDown(Keys.LeftShift)
            //    .SendKeys("a")
            //    .KeyUp(Keys.LeftShift)
            //    .KeyUp(Keys.LeftControl)
            //    .Build()
            //    .Perform();

            // alt + f + x

            //act.KeyDown(Keys.LeftAlt)
            //    .SendKeys("f")
            //    .SendKeys("x")
            //    .Build()
            //    .Perform();

            var ele1 = ObjectRepository.Driver.FindElement(By.Id("quicksearch_top"));
            var ele2 = ObjectRepository.Driver.FindElement(By.Id("quicksearch_main"));

            actions.SendKeys(ele1, "f").SendKeys(ele1, "x").Build().Perform();

            actions.KeyDown(ele2, Keys.Shift)
                .SendKeys(ele2, "fx")                
                .KeyUp(Keys.Shift)
                .Build()
                .Perform();
            
            Thread.Sleep(2000);
        }
    }
}
