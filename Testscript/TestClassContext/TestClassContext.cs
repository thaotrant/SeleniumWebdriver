using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.Testscript.TestClassContext
{
    [TestClass]
    public class TestClassContext
    {
        private TestContext _testContext;
        public TestContext TestContext
        {
            get
            { return _testContext; }
            set
            { _testContext = value; }
        }
        [TestMethod]
        public void Testcase1()
        {
            Console.WriteLine($"Test name: {TestContext.TestName}");
        }
        [TestMethod]
        public void Testcase2()
        {
            Console.WriteLine($"Test name: {TestContext.TestName}");
        }

    }
}
