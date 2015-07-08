using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionMath
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction oneFourth = new Fraction("1/4");
        }
    }

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
                    if (i ==0)
                        Numerator = result;
                    else
                        Denominator = result;
                else
                    throw new FormatException("Expected string in format xx/yy.");
            }            
        }
    }
}
