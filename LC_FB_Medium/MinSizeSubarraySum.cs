/*
Given an array of n positive integers and a positive integer s, find the minimal length of a contiguous subarray of which the sum ≥ s. If there isn't one, return 0 instead.

Example: 

Input: s = 7, nums = [2,3,1,2,4,3]
Output: 2
Explanation: the subarray [4,3] has the minimal length under the problem constraint.

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class MinSizeSubarraySum
    {
        public static int Find(int[] a, int s)
        {
            int left = 0;
            int runningSum = 0;
            int minLength = int.MaxValue;

            for (int i = 0; i < a.Length; i++) {
                runningSum += a[i];
                while (runningSum >= s){
                    minLength = Math.Min(minLength, i - left + 1);
                    runningSum -= a[left];
                    left++;
                }
            }
        
            if (minLength == int.MaxValue) return 0;
            return minLength;
        }
    }
}