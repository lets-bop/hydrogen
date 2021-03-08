using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    class ThreeSumSmaller
    {
        /*
            Given an array of n integers nums and a target, 
            find the number of index triplets i, j, k with 0 <= i < j < k < n that satisfy the 
            condition nums[i] + nums[j] + nums[k] < target.

            Example:
            Input: nums = [-2,0,1,3], and target = 2
            Output: 2 
            Explanation: Because there are two triplets which sums are less than 2:
                        [-2,0,1]
                        [-2,0,3]
            Follow up: Could you solve it in O(n^2) runtime?
        */

        public int Smaller(int[] nums, int target) {
            Array.Sort(nums);
            int result = 0;
            int sum;

            for(int i = 0; i < nums.Length - 2; i++) {
                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right) {
                    sum = nums[i] + nums[left] + nums[right];
                    if (sum < target) {
                        result += (right - left); // because all numbers less that right will also lead to a sum smaller than target.
                        left++;
                    } else right--;
                }
            }

            return result;
        }

        public List<List<int>> SmallerWithoutDups(int[] nums, int target) {
            Array.Sort(nums);
            List<List<int>> result = new List<List<int>>();

            for (int i = 0; i <= nums.Length - 3; i++) {
                if (i > 0 && nums[i] == nums[i-1]) continue;
                int left = i + 1, right = nums.Length - 1; 
                while (left < right) {
                    if (nums[i] + nums[left] + nums[right] < target) {
                        // add all nums between left and right to result
                        for (int j = right; j > left; j--) {
                            if (j < right && nums[j] == nums[j+1])continue; // skip dups
                            result.Add(new List<int>() {nums[i],nums[left],nums[j]});
                        }
                        left++;
                        while (left < right && nums[left] == nums[left - 1]) left++;
                    } else {
                        right--;
                        while (left < right && nums[right] == nums[right + 1]) right--;
                    }
                }
            }

            return result;
        }
    }
}