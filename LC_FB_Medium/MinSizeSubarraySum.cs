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

class MinSizeSubarraySum
{
    public static int Find(int[] arr, int s)
    {
        int minSize = int.MaxValue;
        int start = 0;
        int end = 0;
        int sum = 0;

        while(true)
        {
            if (start == end && start == arr.Length) break;

            if (sum <= s){
                if (end == arr.Length) sum -= arr[start++]; // corner case
                else sum += arr[end++];
            }
            else if (sum > s) sum -= arr[start++];
            
            if (sum >= s) minSize = Math.Min(minSize, end == start ? 1 : end - start);
            
            if (start > end) end = start;
        }

        if (minSize == int.MaxValue) return 0;
        return minSize;
    }
}