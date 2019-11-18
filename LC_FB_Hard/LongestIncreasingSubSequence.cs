using System;
using System.Collections.Generic;
using System.Text;
/*
Given an unsorted array of integers, find the length of longest increasing subsequence.

Example:
Input: [10,9,2,5,3,7,101,18]
Output: 4 
Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4. 

Note: There may be more than one LIS combination, it is only necessary for you to return the length.
Your algorithm should run in O(n2) complexity.
Follow up: Could you improve it to O(n log n) time complexity?

*/
namespace LC_FB_Hard
{
    public class LongestIncreasingSubsequence
    {
        public int LIS(int[] nums)
        {
            // return LISNaive(nums);

            return LISWithBinSearch(nums);
        }

        private int LISNaive(int[] nums)
        {
            if (nums == null || nums.Length < 1) return 0;

            int[] lis = new int[nums.Length];
            int maxLength = 1;

            // O(n^2) time and O(n) extra space
            for(int i = 0; i < nums.Length; i++){
                lis[i] = 1;
                for (int j = 0; j < i; j++){
                    if (nums[i] > nums[j]){
                        lis[i] = Math.Max(lis[i], lis[j] + 1);
                    }
                }

                maxLength = Math.Max(maxLength, lis[i]);
            }

            return maxLength;
        }

        private int LISWithBinSearch(int[] nums)
        {
            if (nums == null || nums.Length < 1) return 0;

            List<int> lis = new List<int>();
            for(int i = 0; i < nums.Length; i++){
                if(lis.Count == 0 || lis[lis.Count - 1] < nums[i]) lis.Add(nums[i]);
                else {
                    // binary search and remove the smallest num larger than nums[i]
                    int low = 0, high = lis.Count - 1, mid = 0;
                    while(low < high) {
                        mid = low + (high - low)/2;
                        if(lis[mid] < nums[i]) low = mid + 1;                        
                        else high = mid;
                    }

                    lis[high] = nums[i];
                }
            }

            return lis.Count;
        }
    }
}