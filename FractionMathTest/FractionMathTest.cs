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

            fraction = new Fraction("01/4");
            Assert.AreEqual(1, fraction.Numerator);
            Assert.AreEqual(4, fraction.Denominator);

            fraction = new Fraction(" 1/ 4");
            Assert.AreEqual(1, fraction.Numerator);
            Assert.AreEqual(4, fraction.Denominator);

        }

        [TestMethod]
        public void TestBadFraction()
        {
            try
            {
                Fraction fraction = new Fraction("one/4");
                fraction = new Fraction("1");
                fraction = new Fraction("/");
                fraction = new Fraction("1/fourth");
                fraction = new Fraction(null);
            }
            catch (System.FormatException)
            {
                return;
            }
            Assert.Fail("Expected FormatException");
        }

    }
}
