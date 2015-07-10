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

        [TestMethod]
        public void TestAddFractionSimple()
        {
            Fraction f1 = new Fraction("4/9");
            Fraction f2 = new Fraction("11/12");
            Assert.AreEqual(new Fraction("49/36"), f1 + f2);
        }

        [TestMethod]
        public void TestLowestCommonDenominator()
        {
            Fraction fourNinths = new Fraction("4/9");
            Fraction elevenTwelths = new Fraction("11/12");
            Assert.AreEqual(36, Fraction.LowestCommonDenominator(fourNinths, elevenTwelths));
        }

        [TestMethod]
        public void TestSimplify()
        {
            Assert.AreEqual(new Fraction("1/4"), new Fraction("4/16").Simplify());
            Assert.AreEqual(new Fraction("1/4"), new Fraction("1/4").Simplify());
        }

    }
}
