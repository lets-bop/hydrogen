/*
Given an array of n positive integers and a positive integer s, find the minimal length of a 
contiguous subarray of which the sum ≥ s. If there isn't one, return 0 instead.

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
        // Window based - keep increasing the window size until running sum > s
        // While running sum >= s, keep shrinking the window
        // O(n) time and O(1) space.
        public static int Find1(int[] a, int s)
        {
            int left = 0, runningSum = 0, minLength = int.MaxValue;

            for (int i = 0; i < a.Length; i++) {
                runningSum += a[i];
                while (runningSum >= s && left <= i){
                    if (runningSum == s) minLength = Math.Min(minLength, i - left + 1);
                    runningSum -= a[left];
                    left++;
                }
            }
        
            if (minLength == int.MaxValue) return 0;
            return minLength;
        }

        // Prefix sum + dictionary based.
        // O(n) time and O(n) space, but will work with negative #s also.
        public static int Find(int[] a, int s)
        {
            int runningSum = 0, minLength = int.MaxValue;
            Dictionary<int, int> sum = new Dictionary<int, int>();
            sum[0] = -1;

            for (int i = 0; i < a.Length; i++) {
                runningSum += a[i];
                if (sum.ContainsKey(runningSum - s)) minLength = Math.Min(i - sum[runningSum - s], minLength);
                sum[runningSum] = i;
            }
        
            if (minLength == int.MaxValue) return 0;
            return minLength;
        }
    }
}