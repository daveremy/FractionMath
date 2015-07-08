using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FractionMath;

namespace FractionMathTest
{
    [TestClass]
    public class FractionTest
    {
        [TestMethod]
        public void TestFractionCreation()
        {
            Fraction fraction = new Fraction("1/4");
            Assert.AreEqual(1, fraction.Numerator);
            Assert.AreEqual(4, fraction.Denominator);
        }

    }
}
