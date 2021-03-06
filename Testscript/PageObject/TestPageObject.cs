﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.PageObject;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.Testscript.PageObject
{
    [TestClass]
    public class TestPageObject
    {
        [TestMethod]
        public void POMTest()
        {
            HomePage hPage = new HomePage(ObjectRepository.Driver);
            LoginPage loginPage = hPage.NavigateToLogin();
            BugDetail bugDetail = loginPage.LoginToPage(ObjectRepository.Config.GetUsername(), ObjectRepository.Config.GetPassword());
            bugDetail.SelectDropdownList("minor", "Other", "Linux");
            bugDetail.FillInTextbox("summary", "description");
            bugDetail.Logout();
        }
    }
}
