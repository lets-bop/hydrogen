using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class PartitionToKEqualSumSubsets
    {
        public bool CanPartitionKSubsets(int[] nums, int k) {
            int sum = 0;
            foreach (int i in nums){
                sum += i;
            }

            if (sum % k != 0) return false;
            if (nums.Length == 0 && k > 0) return false;
            if (nums.Length == 0 && k == 0) return true;
            int target = sum / k;
            Array.Sort(nums);
            if (nums[nums.Length - 1] > target) return false;

            int j = nums.Length - 1;
            while (k > 0 && nums[j] == target){
                k--;
                j--;
            }

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