using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Requirements_Application;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ExcelTestMethod1()
        {
            ExcelProvider provider = new ExcelProvider();
            provider.RequirementNumber = 2;
            provider.Init();

            Assert.AreEqual("Yes", provider.Description);

            Assert.AreEqual("Some Other Req", provider.Name);
        }
    }
}
