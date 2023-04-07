using System;
using System.Numerics;
using System.Collections.Generic;

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            PatternOfRational.Init();

            int numOfRepeats = int.Parse(Console.ReadLine());
            int targetIndex;

            for (int i = 0; i < numOfRepeats; i++)
            {
                //Get index
                targetIndex = int.Parse(Console.ReadLine());

                //If index already exists
                if (targetIndex <= PatternOfRational.allRationals.Count)
                {
                    PatternOfRational.answers.Add(PatternOfRational.allRationals[targetIndex - 1]);
                    continue;
                }

                //If indext does not exist
                int numOfExtends = targetIndex - PatternOfRational.allRationals.Count;
                for (int ii = 0; ii < numOfExtends; ii++)
                {
                    PatternOfRational.Extend();
                    //Console.WriteLine("Top is now " + PatternOfRational.allRationals[PatternOfRational.allRationals.Count - 1]);
                }
                PatternOfRational.answers.Add(PatternOfRational.allRationals[targetIndex - 1]);
            }

            foreach (var rational in PatternOfRational.answers)
            {
                Console.WriteLine(rational);
            }
        }
    }

    public static class PatternOfRational
    {
        public static List<Rational> allRationals = new List<Rational>();
        public static List<Rational> answers = new List<Rational>();

        public static void Init()
        {
            allRationals.Clear();
            allRationals.Add(new Rational(1, 2));
        }
        public static void Extend()
        {
            //Create a candidate for next rational
            Rational candidate = new Rational(allRationals[allRationals.Count - 1].num, allRationals[allRationals.Count - 1].den); //copy last rational 

            while (true)
            {
                //Get next rational
                candidate.num++;
                candidate.den--;

                //If next rational would be greater than or equal to 1.0
                if (candidate.den <= candidate.num)
                {
                    allRationals.Add(new Rational(1, candidate.sum));
                    return;
                }

                //Check if Greatest Common Divisor is equal to 1; if not, skip to next
                if (candidate.GCD != 1) continue;

                //Add results
                allRationals.Add(candidate);
                break;
            }
        }
    }

    public class Rational
    {
        public int num;
        public int den;
        public int sum
        {
            get => num + den;
        }
        public int GCD
        {
            get => (int)BigInteger.GreatestCommonDivisor(num, den);
        }
        public Rational(int numerator, int denominator)
        {
            num = numerator;
            den = denominator;
        }

        public override string ToString() => string.Format("{0} {1}", num, den);
    }
}