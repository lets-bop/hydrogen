using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
        (i.e.,  [0,1,2,4,5,6,7] might become  [4,5,6,7,0,1,2]).
        Find the minimum element. You may assume no duplicate exists in the array.

        Example 1:
        Input: [3,4,5,1,2] 
        Output: 1

        Example 2:
        Input: [4,5,6,7,0,1,2]
        Output: 0
    */
    class FindMinimumInSortedRotatedArray
    {
        public int Find(int[] nums) {
            if (nums == null || nums.Length == 0) return -1;

            int i = 0;
            int j = nums.Length - 1;
            int mid;
            while (i <= j) {
                // handle duplicates, handle cases like [3, 1, 3]
                while(nums[i]==nums[j] && i!=j) i++;
                if (nums[i] <= nums[j]) return nums[i];
                mid = i + (j - i) / 2;
                if (nums[mid] >= nums[i]) i = mid + 1;
                else j = mid;
            }

            return nums[i];
        }
    }
}