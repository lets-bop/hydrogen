using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Write a program to find the n-th ugly number.
        Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. 
        Example:
        Input: n = 10
        Output: 12
        Explanation: 1, 2, 3, 4, 5, 6, 8, 9, 10, 12 is the sequence of the first 10 ugly numbers.
        Note: 1 is typically treated as an ugly number.
        n does not exceed 1690.
    */
    class UglyNumber2
    {
        public int NthUglyNumber(int n) {
            List<int> uglies = new List<int>();
            uglies.Add(1);

            int p2 = 0, p3 = 0, p5 = 0;
            while(uglies.Count < n) {
                int m2 = uglies[p2] * 2;
                int m3 = uglies[p3] * 3;
                int m5 = uglies[p5] * 5;
                int min = Math.Min(m2, Math.Min(m3, m5));
                uglies.Add(min);
                if (min == m2) p2++;
                if (min == m3) p3++;
                if (min == m5) p5++;
            }

            return uglies[n - 1];
        }
    }
}