using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    class ThreeSumClosest
    {
        /*
        Given an array nums of n integers and an integer target, find three integers in nums such that 
        the sum is closest to target. Return the sum of the three integers. 
        You may assume that each input would have exactly one solution.

        Example:
        Given array nums = [-1, 2, 1, -4], and target = 1.
        The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
        */

        public int Closest(int[] nums, int target) {
            Array.Sort(nums);
            int closest = int.MaxValue;
            int closestMag = int.MaxValue; // needed for online judge to not barf!
            int sum;

            for(int i = 0; i < nums.Length - 2; i++) {
                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right) {
                    sum = nums[i] + nums[left] + nums[right];
                    if (sum == target) return target;
                    if (Math.Abs(target - sum) < Math.Abs(closestMag)) {
                        closest = sum;
                        closestMag = target - sum;
                    }
                    if (sum > target) right--;
                    else  left++;
                }
            }

            return closest;
        }
    }
}