/*
    Given a million 64 bit words, compute the parity of all of them. 
    Parity is 1 if the # of 1s in the word is odd and 0 otherwise.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
    If we were computing the parity of just 1 word 'x', we could just count how many times we can perform x & (x-1) until 0.
    Since we have a million of them, we do the above step for 16-bit words, cache the result and use that for 
    calculations. Use a 16-bit mask 0xFFFF to extract 16-bit values
    */

    class Parity
    {

        public static void Execute(List<long> nums)
        {
            int bitMask = 0xFFFF; // 65535
            Dictionary<int, int> cache = BuildCache();

            foreach (long num in nums)
            {
                int finalParity = cache[(int)num & bitMask] 
                            ^ cache[(int) (num >> 16) & bitMask]
                            ^ cache[(int) (num >> 32) & bitMask]
                            ^ cache[(int) (num >> 48) & bitMask];

                Console.WriteLine("Final Parity for {0} is {1}", num, finalParity);
            }
        }

        private static Dictionary<int, int> BuildCache()
        {
            Dictionary<int, int> cache = new Dictionary<int, int>();
            for (int i = 0; i <= 0xFFFF; i++)
            {
                cache[i] = FindParity(i);
            }

            return cache;
        }

        private static int FindParity(int num)
        {
            int result = 0;
            while (num != 0)
            {
                num = num & (num - 1);
                result ^= 1;
            }

            return result;
        }     
    }



}