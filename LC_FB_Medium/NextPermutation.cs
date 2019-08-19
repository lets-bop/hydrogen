using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.
        If such arrangement is not possible, it must rearrange it as the lowest possible order (ie, sorted in ascending order).
        The replacement must be in-place and use only constant extra memory.
        Here are some examples. Inputs are in the left-hand column and its corresponding outputs are in the right-hand column.

        1,2,3 → 1,3,2
        3,2,1 → 1,2,3
        1,1,5 → 1,5,1
    */
    class NextPermutation
    {
        /* 
        Notice that in an array 4 3 2 1, from the right, the numbers are stricly increasing.
        1 2 3 4
        1 2 4 3
        1 3 2 4
        1 3 4 2
        1 4 2 3
        1 4 3 2

        So if we are given 1 2 4 3. 
        1. From the right we find the first occurrence where nums[i] > nums[i - 1]. This happens when i = 2 (4 > 2).
        2. We swap nums[i - 1] with the least number greater than it.
        3. Last step is to reverse list beginning from nums[i] until end.
        */
        public void Next(int[] nums) {
            if (nums == null || nums.Length < 2) return;

            int i = nums.Length - 1;
            int j = -1;
            int temp;
            while (i > 0) {
                // Find the first occurrence of nums[i] > nums[i - 1]
                if (nums[i] > nums[i - 1]) {
                    // Find the number slightly greater than nums[i - 1]
                    j = i;
                    while (j < nums.Length && nums[j] > nums[i - 1]) j++;

                    // swap nums[j - 1] & nums[i - 1] as nums[j-1] will be the least number greater than nums[i - 1]
                    temp = nums[i - 1];
                    nums[i - 1] = nums[j - 1];
                    nums[j - 1] = temp;

                    break;
                }

                i--;
            }

            // now reverse the array from i to the end
            j = nums.Length - 1;
            while (i < j) {
                temp = nums[j];
                nums[j] = nums[i];
                nums[i] = temp;
                i++; j--;
            }
        }
    }
}