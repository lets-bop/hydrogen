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
    public class MedianOfTwoSortedArrays
    {
        public double Find(int[] nums1, int[] nums2) {
            
            int total = nums1.Length + nums2.Length;
            if(total % 2 == 0)
                return (getKth(nums1, 0, nums1.Length - 1, nums2, 0, nums2.Length - 1, total/2) 
                    + getKth(nums1, 0, nums1.Length - 1, nums2, 0, nums2.Length - 1, total / 2 - 1))/2.0;
            else return getKth(nums1,0, nums1.Length - 1, nums2, 0, nums2.Length - 1, total / 2);
        }

        //k is the index starting from 0
        private int getKth(int[] nums1, int start1, int end1, int[] nums2, int start2, int end2, int k) {
            if(end1 < start1) return nums2[start2 + k];
            if(end2 < start2) return nums1[start1 + k];
            if(k == 0) return Math.Min(nums1[start1], nums2[start2]);
        
            int len1 = end1 - start1 + 1;
            int len2 = end2 - start2 + 1;
        
            int m1 = k * len1 / (len1+len2);
            int m2 = k - m1 - 1;
        
            m1 += start1;
            m2 += start2;
        
            if(nums1[m1]<nums2[m2]){
                    k = k-(m1-start1+1); // subtract the size of elements between m1 and start1 from k
                    end2 = m2;
                    start1 = m1+1;
            } else {
                    k = k-(m2-start2+1); // subtract the size of elements between m2 and start2 from k
                    end1 = m1;
                    start2 = m2+1;
            }
        
            return getKth(nums1, start1, end1, nums2, start2, end2, k);
        }
    }    
}