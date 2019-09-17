using System;
using System.Collections.Generic;

namespace LC_FB_Easy
{
    /*
        Given an array of size n, find the majority element. 
        The majority element is the element that appears more than ⌊ n/2 ⌋ times.
        You may assume that the array is non-empty and the majority element always exist in the array.

        Example 1:
        Input: [3,2,3]
        Output: 3

        Example 2:
        Input: [2,2,1,1,1,2,2]
        Output: 2
    */
    class MajorityElement
    {
        public int Find(int[] nums) {
            // O(1) if the array is sorted. Just need to return the num at the middle of array.
            // We'll assume that it's not.
            int count = 1, num = nums[0];
            for (int i = 1; i < nums.Length; i++) {
                if (nums[i] == num) count++;
                else {
                    if (count == 0) {
                        num = nums[i];
                        count++;
                    } else count--;
                }
            }
            return num;
        }
    }
}