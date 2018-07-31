/*
Multiply 2 numbers without using * efficiently.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class Multiply
    {
        public static long Execute(int x, int y)
        {
            if (x == 0 || y == 0) return 0;
            // Eliminate the sign.
            long sign = 1;
            if (x < 0 && y >= 0 || x >= 0 && y < 0) sign = -1;
            if (x < 0) x = -x;
            if (y < 0) y = -y;

            if (x > y)
            {
                int temp = x;
                x = y;
                y = temp;
            }

            long result = 0;
            int twoPower = 1;

            while (y > 0)
            {
                twoPower = 1;
                int tempX = x;
                while ((twoPower << 1) <= y)
                {
                    twoPower = twoPower << 1;
                    tempX = tempX << 1;
                }
                    
                y -= twoPower;

                result += tempX;
            }

            result = sign * result;
            return result;
        }
    }
}