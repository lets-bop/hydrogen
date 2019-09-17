using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given an array nums and a target value k, find the maximum length of a subarray that sums to k. 
        If there isn't one, return 0 instead.

        Note:
        The sum of the entire nums array is guaranteed to fit within the 32-bit signed integer range.

        Example 1:
        Input: nums = [1, -1, 5, -2, 3], k = 3
        Output: 4 
        Explanation: The subarray [1, -1, 5, -2] sums to 3 and is the longest.
        Example 2:
        Input: nums = [-2, -1, 2, 1], k = 1
        Output: 2 
        Explanation: The subarray [-1, 2] sums to 1 and is the longest.

        Follow Up: Can you do it in O(n) time?
    */
    class MaximumSizeSubarraySumK
    {
        public int MaxSubArrayLen(int[] nums, int k) {
            int result = 0;
            Dictionary<int, int> sumToIndex = new Dictionary<int, int>();
            sumToIndex.Add(0, -1); // For example, if the first num == k, sum - k should be present. First index = 0, length should be 1, hence we put -1

            int prefixSum = 0;
            for (int i = 0; i < nums.Length; i++) {
                prefixSum += nums[i];
                if (sumToIndex.ContainsKey(prefixSum - k)) {
                    // we have found a subarray that sums to k.
                    result = Math.Max(result, i - sumToIndex[prefixSum-k]);
                }

                // since we need to find max length, we will add the sum to the dictionary only if sum wasn't found so far.
                if (!sumToIndex.ContainsKey(prefixSum)) sumToIndex[prefixSum] = i;
            }

            return result;
        }
    }
}