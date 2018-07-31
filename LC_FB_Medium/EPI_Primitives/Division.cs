/*
Divide 2 numbers without using / or *
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class Division
    {
        public static long Execute(int dividend, int divisor)
        {
            if (divisor == 0) throw new Exception("Divide by zero error");
            if (dividend == 0) return 0;
            if (Math.Abs(dividend) < Math.Abs(divisor)) throw new Exception("Dividend lower than divisor is not supported");

            long result = 0;
            long sign = 1;
            if ((dividend < 0 && divisor > 0) || (dividend > 0 && divisor < 0)) sign = -1;
            if (dividend < 0) dividend *= -1;
            if (divisor < 0) divisor *= -1;

            while (dividend > 0 && dividend >= divisor)
            {
                int tempDivisor = divisor;
                int twoPower = 0;
                while (tempDivisor <= dividend)
                {
                    tempDivisor = tempDivisor << 1;
                    if (twoPower == 0) twoPower = 1;
                    else twoPower = twoPower << 1;
                }

                tempDivisor = tempDivisor >> 1;
                dividend -= tempDivisor;
                result = result + twoPower;                    
            }

            result = result * sign;
            
            return result;
        }
    }    
}
