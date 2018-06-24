using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionCalculator
{
    public struct Fraction
    {
        private long numerator;
        private long denominator;
        public Fraction(long numerator, long denominator) : this()
        {
            Denominator = denominator;
            this.Numerator = numerator;
        }
        public long Numerator
        {
            get { return this.numerator; }
            private set
            {
                this.numerator = value;
            }
        }
        public long Denominator
        {
            get { return this.denominator; }
            private set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("Fraction denominator cannot be zero.");
                }
                this.denominator = value;
            }
        }
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            if(f1.denominator != f2.denominator)
            {
                long temp = f1.denominator;
                f1.denominator *= f2.denominator;
                f1.numerator *= f2.denominator;
                f2.numerator *= temp;
            }
            return new Fraction(f1.numerator + f2.numerator, f1.denominator);
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            if (f1.denominator != f2.denominator)
            {
                long temp = f1.denominator;
                f1.denominator *= f2.denominator;
                f1.numerator *= f2.denominator;
                f2.numerator *= temp;
            }
            return new Fraction(f1.numerator - f2.numerator, f1.denominator);
        }
        public override string ToString()
        {
            return $"{(decimal) numerator/denominator}";
        }
    }
}
