using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.RationalNumbers
{
    public class Rational
    {
        public readonly int Numerator;
        public readonly int Denominator;
        public readonly bool IsNan;

        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                IsNan = true;
                return;
            }
            else IsNan = false;

            if (numerator == 0)
            {
                Numerator = 0;
                Denominator = 1;
                return;
            }
       
            int NOM = 1;
            int ABSnum = Math.Abs(numerator);
            int ABSden = Math.Abs(denominator);
            int max = ABSnum < ABSden ? ABSnum : ABSden;
            for (int i = max; i > 1; i--)
                if ((ABSnum % i == 0) & (ABSden % i == 0))
                {
                    NOM = i;
                    break;
                }
            if (numerator * denominator < 0)
            {
                Numerator = -1 * ABSnum / NOM;
                Denominator = ABSden / NOM;
            }
            else
            {
                Numerator = ABSnum / NOM;
                Denominator = ABSden / NOM;
            }
        }

        public Rational(int numerator)
        {
            Numerator = numerator;
            Denominator = 1;
            IsNan = false;
        }

        public static Rational operator *(Rational x,Rational y)
        {
            if (x.IsNan || y.IsNan) return new Rational(0, 0);
            return new Rational(x.Numerator * y.Numerator, x.Denominator * y.Denominator);
        }

        public static Rational operator +(Rational x, Rational y)
        {
            if (x.IsNan || y.IsNan) return new Rational(0, 0);
            return new Rational(x.Numerator * y.Denominator + y.Numerator * x.Denominator, x.Denominator * y.Denominator);
        }

        public static Rational operator -(Rational x, Rational y)
        {
            if (x.IsNan || y.IsNan) return new Rational(0, 0);
            return new Rational(x.Numerator * y.Denominator - y.Numerator * x.Denominator, x.Denominator * y.Denominator);
        }

        public static Rational operator /(Rational x, Rational y)
        {
            if (x.IsNan || y.IsNan) return new Rational(0, 0);
            if (y.Numerator == 0) return new Rational(0, 0);
            return new Rational(x.Numerator * y.Denominator, x.Denominator * y.Numerator);
        }

        public static implicit operator Double(Rational x)
        {
            return (double) x.Numerator / x.Denominator;
        }

        public static implicit operator int(Rational x)
        {
            if (x.Numerator % x.Denominator != 0) throw new ArgumentException();
            return x.Numerator / x.Denominator;
        }

        public static implicit operator Rational(int x)
        {
            return new Rational(x);
        }

    }
}
