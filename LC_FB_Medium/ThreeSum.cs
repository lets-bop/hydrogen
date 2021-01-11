using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{

    /*
        Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.
        Note: The solution set must not contain duplicate triplets.

        Example:
            Given array nums = [-1, 0, 1, 2, -1, -4],

            A solution set is:
            [
                [-1, 0, 1],
                [-1, -1, 2]
            ]
    */
    class ThreeSum
    {
        public IList<IList<int>> Calculate(int[] nums) 
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (nums == null || nums.Length == 0) return result;
            
            Array.Sort(nums);
            // since its sorted, we can exit if nums[i] is not <= 0.
            // nums[i - 1] != nums[i] check avoids duplicates
            for (int i = 0; i < nums.Length && nums[i] <= 0; i++) {
                if (i == 0 || nums[i - 1] != nums[i]) 
                    this.TwoSum2Pointer(nums, i, result);
                    // this.TwoSum(nums, i, result);
            }
            
            return result;
        }

        private void TwoSum2Pointer(int[] nums, int i, IList<IList<int>> result) {
            // we will look for 2 numbers that sum to (-nums[i])
            int start = i + 1, end = nums.Length - 1;
            while (start < end) {
                if (nums[start] + nums[end] == -nums[i]) {
                    result.Add(new List<int>() {nums[i], nums[start], nums[end]});
                    // skip duplicates
                    while (start+1 < end && nums[start + 1] == nums[start]) start++;
                    while (end - 1 > start && nums[end - 1] == nums[end]) end--;
                }

                if (nums[start] + nums[end] > -nums[i]) end--;
                else start++;
            }
        }

        private void TwoSum(int[] nums, int i, IList<IList<int>> result) {
            HashSet<int> seen = new HashSet<int>();
            for (int j = i + 1; j < nums.Length; j++) {
                int sum = 0 - (nums[i] + nums[j]);
                if (seen.Contains(sum)) {
                    result.Add(new List<int>() {nums[i], nums[j], sum});
                    while (j+1 < nums.Length && nums[j+1] == nums[j]) j++;
                }
                
                seen.Add(nums[j]);
            }
        }
    }
}