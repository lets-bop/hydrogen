/*
Given an array nums, write a function to move all 0's to the end of it while maintaining the 
relative order of the non-zero elements.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Easy
{
    class MoveZeros
    {
        public void Move(int[] nums) {
            // validate the input
            if (nums == null || nums.Length == 0) return;
            
            int i = -1, j = 0;
            while (j < nums.Length) {
                if (nums[j] == 0) {
                    if (i == -1) i = j;
                } else if (i >=0 && i != j) {
                    nums[i] = nums[j];
                    i++;
                }
                j++;
            }
            
            while (i >= 0 && i < nums.Length) {
                nums[i] = 0;
                i++;
            }
        }
    }
}