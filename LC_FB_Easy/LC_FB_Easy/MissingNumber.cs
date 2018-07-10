/*

Given an array containing n distinct numbers taken from 0, 1, 2, ..., n, find the one that is missing from the array.
Has to run in O(n).

Input: [3,0,1]
Output: 2

Input: [9,6,4,2,3,5,7,0,1]
Output: 8

 */

using System;
using System.Collections.Generic;

namespace LC_FB_Easy
{
    class MissingNumber
    {
        public static int Find(int[] input)
        {
            int n = input.Length;
            int sumOfN = (n * (n+1)) / 2;

            foreach (int i in input)
                sumOfN -= i;

            return sumOfN;
        }
    }
}