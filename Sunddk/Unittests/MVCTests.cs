using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unittests
{
    [TestClass]
    public class MVCTests
    {
        [TestMethod]
        public void BMR()
        {
            Sunddk.Utilities.Calculate calc = new Sunddk.Utilities.Calculate();
            double expectedMan = 1829.915;
            double expectedWomen = 1451.017;
            Assert.AreEqual(Math.Floor(expectedMan), Math.Floor(calc.CalculateBMR(Convert.ToDateTime("1980-01-01"), "Mand", 80.0, 180)));
            Assert.AreEqual(Math.Floor(expectedWomen), Math.Floor(calc.CalculateBMR(Convert.ToDateTime("1987-01-01"), "Kvinde", 65.0, 165)));
        }
    }
}
