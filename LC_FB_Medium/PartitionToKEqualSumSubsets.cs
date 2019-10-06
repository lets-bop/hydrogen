using System;
using System.Collections.Generic;
using System.Text;
/*
Given an array of integers nums and a positive integer k, find whether it's possible to divide 
this array into k non-empty subsets whose sums are all equal.

Example 1:
Input: nums = [4, 3, 2, 3, 5, 2, 1], k = 4
Output: True
Explanation: It's possible to divide it into 4 subsets (5), (1, 4), (2,3), (2,3) with equal sums.

Note:
1 <= k <= len(nums) <= 16.
0 < nums[i] < 10000.
*/
namespace LC_FB_Medium
{
    public class PartitionToKEqualSumSubsets
    {
        public bool CanPartitionKSubsets(int[] nums, int k) {
            if (nums == null || nums.Length == 0 && k > 0) return false;
            if (nums.Length == 0 && k == 0) return true;

            // Find the total sum of the nums and see if its divisible by k
            int sum = 0;
            foreach (int i in nums) sum += i;
            if (sum % k != 0) return false;

            // make sure that no value is > than sum/k. If so, we cannot split evenly.
            int target = sum / k;
            Array.Sort(nums);
            if (nums[nums.Length - 1] > target) return false;

            // all numbers == (sum / k) go into each subset of its own.
            int j = nums.Length - 1;
            while (k > 0 && nums[j] == target){
                k--;
                j--;
            }

            // partition the remainder of the elements into subsets
            int[] partition = new int[k];
            return Rec(nums, target, j, partition);
        }

        private bool Rec(int[] nums, int target, int index, int[] partition){
            if (index < 0) return true;
            for (int i = 0; i < partition.Length; i++){
                if (partition[i] + nums[index] <= target){
                    partition[i] += nums[index];
                    if (this.Rec(nums, target, index - 1, partition)) return true;
                    partition[i] -= nums[index];
                }

                // if this partition = 0 after trying the current index,
                // we dont need to try other partitions
                if (partition[i] == 0) break;
            }

            return false;
        }
    }
}