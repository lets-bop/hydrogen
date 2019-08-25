using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    class SubArrayProductLessThanK
    {
        /*
            Your are given an array of positive integers nums.
            Count and print the number of (contiguous) subarrays where the product of all the elements in the subarray is less than k.

            Example 1:
            Input: nums = [10, 5, 2, 6], k = 100
            Output: 8
            Explanation: The 8 subarrays that have product less than 100 are: [10], [5], [2], [6], [10, 5], [5, 2], [2, 6], [5, 2, 6].
            Note that [10, 5, 2] is not included as the product of 100 is not strictly less than k.
        */
        public int Calculate(int[] nums, int k) {
            int prod = 1;
            int result = 0;
            int left = 0; 
            int right = 0;

            while (right < nums.Length) {
                prod *= nums[right];
                // shrink the subarray from the left if prod >= k
                while (prod >= k && left < nums.Length) prod /= nums[left++];
                if (left <= right) result += (right - left + 1);
                right++;
            }

            return result;
        }
    }
}