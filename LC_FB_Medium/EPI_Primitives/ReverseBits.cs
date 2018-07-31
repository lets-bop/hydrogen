/*
    Given a million 64 bit words, reverse their bits.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class ReverseBits
    {
        public static void Execute(List<long> nums)
        {
            Dictionary<int, int> cache = BuildCache();
            foreach (long num in nums)
            {                           
                int bitMask = 0xFFFF;
                long result = (long) cache[(int) num & bitMask] << 48 | 
                                (long) cache[(int) (num >> 16) & bitMask] << 32 |
                                (long) cache[(int) (num >> 32) & bitMask] << 16 |
                                (long) cache[(int) (num >> 48) & bitMask];

                Console.WriteLine("Num is {0}, Reversed num is {1}", num, result);              
            }
        }

        private static Dictionary<int, int> BuildCache()
        {
            // Builds the cache for 16 bit words
            Dictionary<int, int> cache = new Dictionary<int, int>();
            for (int num = 0; num < 0xFFFF; num++)
            {
                int reversedNum = num;
                for (int i = 0; i < 8; i++)
                {
                    reversedNum = SwapBits(reversedNum, i, 15 - i);
                }

                // Console.WriteLine("Num is {0}, reversed num is {1}", num, reversedNum);

                cache[num] = reversedNum;
            }
            
            return cache;
        }

        private static int SwapBits(int num, int i, int j)
        {
            // Swaps the bits at index i and j
            // We need to swap only if the bits at index i and j are different. Else leave as is.
            int bitMask_i = 0x1; 
            int temp = i;
            while (temp != 0)
            {
                bitMask_i = bitMask_i << 1;
                temp--;
            }

            int bitMask_j = 0x1;
            temp = j;
            while (temp != 0)
            {
                bitMask_j = bitMask_j << 1;
                temp--;
            }

            int bitAtIndexI = num & bitMask_i;
            int bitAtIndexJ = num & bitMask_j;

            if (bitAtIndexI != bitAtIndexJ)
            {
                int bitMask = bitMask_i | bitMask_j;
                return num ^ bitMask;
            }

            return num;
        }
    }
}