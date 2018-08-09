/*
There are two sorted arrays nums1 and nums2 of size m and n respectively.

Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).

You may assume nums1 and nums2 cannot be both empty.

 

Example 1:

nums1 = [1, 3]
nums2 = [2]

The median is 2.0
Example 2:

nums1 = [1, 2]
nums2 = [3, 4]

The median is (2 + 3)/2 = 2.5

*/
using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    public class MedianOfTwoSortedArrays
    {
        public double Find(int[] nums1, int[] nums2)
        {
            if (nums1 == null && nums2 == null) throw new Exception("Invalid input");
            if (nums1 == null || nums1.Length == 0) return FindMedianInArray(nums2);
            if (nums2 == null || nums2.Length == 0) return FindMedianInArray(nums1);

            int l1 = nums1.Length;
            int l2 = nums2.Length;
            int medianIndex1 = (l1 + l2) / 2;
            int medianIndex2 = (l1 + l2) % 2 != 0 ? -1 : medianIndex1 + 1;
            if (medianIndex2 != -1)
                return (FindKthLargest(nums1, nums2, medianIndex1 + 1) + FindKthLargest(nums1, nums2, medianIndex2 + 1)) / 2;
            return FindKthLargest(nums1, nums2, medianIndex1 + 1);
        }

        private static double FindMedianInArray(int[] num)
        {
            if (num != null && num.Length % 2 == 0) return (double) num[num.Length / 2] / 2 + (double) num[num.Length / 2 - 1] / 2;
            else if (num != null && num.Length % 2 != 0) return (double) num[num.Length / 2];
            throw new Exception("Invalid input");
        }

        private static int FindMid(int[] nums, int start, int end)
        {
            return start + (end - start ) / 2;
        }

        private static double FindKthLargest(int[] nums1, int[] nums2, int k)
        {
            int start1= 0; int end1 = nums1.Length - 1;
            int start2 = 0; int end2 = nums2.Length - 1;

            while(true)
            {
                int l1 = end1 - start1 + 1;
                int l2 = end2 - start2 + 1;
                int mid = 0;

                if (l1 >= l2){
                    mid = FindMid(nums1, start1, end1);
                    int index = BinarySearchWithTwist.Find(nums1[mid], nums2);
                    int total = (mid + 1) + index;
                    if (total == k) 
                        return (double)nums1[mid];
                    else if (total < k){
                        start1 = mid + 1;
                        start2 = index;
                    }
                    else {
                        end1 = mid - 1;
                        end2 = index;
                    }
                }
                else{
                    mid = FindMid(nums2, start2, end2);
                    int index = BinarySearchWithTwist.Find(nums2[mid], nums1);
                    int total = (mid + 1) + index;
                    if (total == k) 
                        return (double)nums2[mid];
                    else if (total < k){
                        start2 = mid + 1;
                        start1 = index;
                    }
                    else {
                        end2 = mid - 1;
                        end1 = index;
                    }
                }         
            }            
        }
    }    
}