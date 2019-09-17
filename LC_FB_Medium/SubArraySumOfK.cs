using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
        Given an array of integers and an integer k, 
        you need to find the total number of continuous subarrays whose sum equals to k.

        Example 1:

        Input:nums = [1,1,1], k = 2
        Output: 2
        Note:

        The length of the array is in range [1, 20,000].
        The range of numbers in the array is [-1000, 1000] and the range of the integer k is [-1e7, 1e7].
     */
    class SubArraySumOfK
    {

        // If sum[i] represents the sum upto (including) index i 
        // and sum[j] represents the sum upto (including) index j,
        // and if sum[i] == sum[j], then the sum of the elements between i & j = 0.
        // Extending this logic, if the difference between sum[i] & sum[j] == k, then
        // the numbers between i & j sum to k.
        // Based on these thoughts, we make use of a hashmap map which is used to store the 
        // cumulative sum upto all the indices possible along with the number of times the same sum occurs. 
        // We store the data in the form: (sum_i, no. of occurences of sum_i). 
        // We traverse over the array nums and keep on finding the cumulative sum. 
        // Every time we encounter a new sum, we make a new entry in the hashmap corresponding to that sum. 
        // If the same sum occurs again, we increment the count corresponding to that sum in the hashmap. 
        // Further, for every sum encountered, we also determine the number of times the sum sum-k has occurred already, 
        // since it will determine the number of times a subarray with sum k has occurred upt o the current index. 
        // We increment the count by the same amount.
        public int SubarraySum(int[] nums, int k)
        {
            Dictionary<int, int> sumToCountMap = new Dictionary<int, int>();
            int prefixSum = 0;
            int count = 0;
            sumToCountMap.Add(0, 1); // if sum-upto-now - k == 0, then it means that we have found 1 match at least.
            for (int i = 0; i < nums.Length; i++)
            {
                prefixSum += nums[i];
                if (sumToCountMap.ContainsKey(prefixSum - k)) 
                    count += sumToCountMap[prefixSum - k];

                if (sumToCountMap.ContainsKey(prefixSum)) 
                    sumToCountMap[prefixSum]++; // add 1 to existing sum
                else sumToCountMap[prefixSum] = 1; // we have 1 count for this sum
            }

            return count;
        }
        
        // Time O(n^2). Space O(1)
        // We can choose a start point and while iterating over the end points, 
        // we can add the element corresponding to the end point to the sum formed until now.
        // If the sum = k, we increment a counter. We do so while iterating over all possible end indices
        // for a given start index. When we reset the start index, we need to reset the sum as well.
        public int SubarraySum1(int[] nums, int k)
        {
            int count = 0;
            int sum = 0;
            for (int start = 0; start < nums.Length; start++)
            {
                sum = 0;
                for (int end = start; end < nums.Length; end++)
                {
                    sum += nums[end];
                    if (sum == k) count++;
                }
            }

            return count;
        }
    }
}