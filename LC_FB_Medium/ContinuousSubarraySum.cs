using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given a list of non-negative numbers and a target integer k, 
        write a function to check if the array has a continuous subarray of size at least 2 
        that sums up to a multiple of k, that is, sums up to n*k where n is also an integer.
        Example 1:
        Input: [23, 2, 4, 6, 7],  k=6
        Output: True
        Explanation: Because [2, 4] is a continuous subarray of size 2 and sums up to 6.
        Example 2:
        Input: [23, 2, 6, 4, 7],  k=6
        Output: True
        Explanation: Because [23, 2, 6, 4, 7] is an continuous subarray of size 5 and sums up to 42.
        Note: You may assume the sum of all the numbers is in the range of a signed 32-bit integer.
    */
    class ContinuousSubarraySum
    {
        // O(n^2) algorithm using prefix sum array
        public bool CheckSubarraySum2(int[] nums, int k) 
        {
            // calculate prefix sum
            if (nums == null || nums.Length == 0) return false;

            int[] prefixSum = new int[nums.Length + 1];
            prefixSum[0] = 0;
            for (int i = 1; i < prefixSum.Length; i++) {
                prefixSum[i] = prefixSum[i - 1] + nums[i - 1]; // sum of nums upto and not including i
            }

            int sum = 0;
            for (int i = 0; i < prefixSum.Length; i++) {
                for (int j = i + 2; j < prefixSum.Length; j++) { // min size of 2
                    sum = prefixSum[j] - prefixSum[i];
                    if (sum == k || (k != 0 && sum % k == 0)) {
                        return true;
                    }
                }
            }

            return false;
        }

        // O(n) using dictionary. At each step update sum to be = (prev result of sum % k) + nums[i] % k
        // The new sum is present in the dictionary and difference of its index and current index > 2. return true
        public bool CheckSubarraySum(int[] nums, int k) {
            int sum = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict[0] = -1;

            for (int i = 0; i < nums.Length; i++)  {
                sum += nums[i];
                if (k != 0) sum = sum % k;
                if (dict.ContainsKey(sum) && (i - dict[sum] > 1)) return true;
                dict[sum] = i;
            }

            return false;
        }
    }
}