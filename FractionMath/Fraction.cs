using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionMath
{
    public class Fraction
    {

        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public Fraction(string fractionText)
        {
            string[] splitString = fractionText.Split('/');
            if (splitString.Length < 2)
                throw new FormatException("Expected string in format xx/yy.");

            for (int i = 0; i < splitString.Length; i++)
            {
                int result;
                if (int.TryParse(splitString[i], out result))
                    if (i == 0)
                        Numerator = result;
                    else
                        Denominator = result;
                else
                    throw new FormatException("Expected string in format xx/yy.");
            }
        }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public override string ToString()
        {
            return Numerator.ToString() + '/' + Denominator.ToString();
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + this.Numerator.GetHashCode();
                hash = hash * 23 + this.Denominator.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Fraction f = (Fraction)obj;
            return (this.Numerator == f.Numerator) && (this.Denominator == f.Denominator);
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            int lowestCommonDenominator = LowestCommonDenominator(f1, f2);
            int f1Factor = lowestCommonDenominator/f1.Denominator;
            int f2Factor = lowestCommonDenominator/f2.Denominator;
            int summedNominator = f1.Numerator * f1Factor + f2.Numerator * f2Factor;
            return new Fraction(summedNominator, lowestCommonDenominator);
        }

        public static int LowestCommonDenominator(Fraction f1, Fraction f2)
        {
            int lowestDenominator = Math.Min(f1.Denominator, f2.Denominator);
            int highestDenominator = Math.Max(f1.Denominator, f2.Denominator);
            int lowestCommonDenominator = lowestDenominator;
            int multiple = 1;
            while (lowestCommonDenominator % highestDenominator != 0)
            {
                lowestCommonDenominator = lowestDenominator * ++multiple; 
            }
            return lowestCommonDenominator;
        }

        public Fraction Simplify()
        {
            var numeratorFactors = Factors(this.Numerator);
            var denominatorFactors = Factors(this.Denominator);
            var commonFactors = numeratorFactors.Intersect(denominatorFactors);
            if (commonFactors.Count() == 0)
                return this;
            else
            {
                var greatestCommonFactor = commonFactors.Max();
                return new Fraction(this.Numerator / greatestCommonFactor, this.Denominator / greatestCommonFactor);
            }
        }

        // Return list of Factors in descending order
        private List<int> Factors(int num)
        {
            var factors = new List<int>();
            for (int i = num; i > 0; i--)
            {
                if (num % i == 0)
                    factors.Add(i);
            }
            return factors;
        }
    }
}
