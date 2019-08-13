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
    class Sum3
    {
        public IList<IList<int>> ThreeSum(int[] nums) 
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (nums == null || nums.Length < 3) return result;

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] > 0) break;
                if (i > 0 && nums[i] == nums[i-1]) continue; // avoid processing duplicates
                HashSet<int> numbers = new HashSet<int>();

                // a + b + c = 0 can be written as a + b = -c
                // b = -c - a
                int c = nums[i];
                for (int j = i + 1; j < nums.Length; j++) {
                    if (numbers.Contains(0 - c - nums[j])) {
                        List<int> threePair = new List<int>() {c, nums[j], 0 - c - nums[j]};
                        result.Add(threePair);
                        while (j+1 < nums.Length && nums[j] == nums[j+1]) j++; // avoid processing duplicates
                    }

                    numbers.Add(nums[j]);
                }
            }
            
            return result;
        }
    }
}