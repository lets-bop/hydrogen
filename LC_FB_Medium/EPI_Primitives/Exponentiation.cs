using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class Exponentiation
    {
        public static double Execute(float base1, int exponent)
        {
            if (exponent < 0)
            {
                base1 = 1 / base1;
                exponent = Math.Abs(exponent);
            }
            
            if (exponent == 0)
                return 1;
            
            return ExecuteRecursive(base1, exponent);
        }

        private static double ExecuteRecursive(float base1, int exponent)
        {
            if (exponent == 0) return (double)1.0;
            double half = ExecuteRecursive(base1, exponent / 2);
            if ((exponent & 1) == 0) return half * half;
            else return base1 * half * half;
        }
    }   
}