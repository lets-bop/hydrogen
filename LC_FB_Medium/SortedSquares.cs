using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given an array of integers A sorted in non-decreasing order, 
        return an array of the squares of each number, also in sorted non-decreasing order.

        Example 1:
        Input: [-4,-1,0,3,10]
        Output: [0,1,9,16,100]

        Example 2:
        Input: [-7,-3,2,3,11]
        Output: [4,9,9,49,121]
    */
    class SortedSquares
    {
        public int[] Calculate(int[] nums) {
            // The straight forward way is to simply square the numbers and sort the array thereafter.
            // This would take O(nlogn) time.
            // What if we can walk the numbers according to their magnitude?
            if (nums == null || nums.Length == 0) return new int[] {};

            int[] result = new int[nums.Length];
            int k = nums.Length - 1, left = 0, right = nums.Length - 1;

            while (left <= right) {
                if (Math.Abs(nums[left]) >= Math.Abs(nums[right])) {
                    result[k--] = nums[left] * nums[left];
                    left++;
                } else {
                    result[k--] = nums[right] * nums[right];
                    right--;
                }
            }

            return result;
        }
    }
}