using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    class Pow
    {
        public static double Calculate(float x, int n)
        {
            if (n < 0)
                return CalculateRecursively(1/x, -n);
            // return CalculateRecursively(x, n);
            return CalculateIteratively(x, n);
        }
        private static double CalculateRecursively(float x, int n)
        {
            if (n == 0)
                return (double) 1.0;
            
            double half = CalculateRecursively(x, n/2);
            if (n % 2 == 0)
                return half * half;
            else
                return half * half * x;
        }

        private static double CalculateIteratively(float x, int n)
        {
            double result = 1.0;
            if (n < 0)
            {
                n *= -1;
                x = 1/x;
            }

            while(n != 0)
            {
                if ((n & 1) != 0) // not divisible by 2
                    result = result * x;

                x *= x;
                n = n >> 1;
            }

            return result;
        }
    }
}