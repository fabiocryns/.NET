using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        PrimeFinder finder = new PrimeFinder();

        [TestMethod]
        public void TestIsPrimeWithPrimeNumer()
        {
            Assert.IsTrue(finder.IsPrime(59));    
        }

        [TestMethod]
        public void TestIsPrimeWithNonPrimeNumer()
        {
            Assert.IsFalse(finder.IsPrime(10));
        }
    }
}
