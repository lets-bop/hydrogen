/*
The number of elements initialized in nums1 and nums2 are m and n respectively.
You may assume that nums1 has enough space (size that is greater or equal to m + n) to hold additional elements from nums2.
 */

using System;
using System.Collections.Generic;

namespace LC_FB_Easy
{
    class MergeSortedArrays
    {
        public static void Merge(int[] nums1, int m, int[] nums2, int n) {
            int i = m - 1;
            int j = n - 1;
            int k = m + n - 1;
            
            while (k >= 0) {
                if (j < 0 || (i >=0 && nums1[i] > nums2[j])) nums1[k--] = nums1[i--];
                else nums1[k--] = nums2[j--];
            }
        }
    }
}