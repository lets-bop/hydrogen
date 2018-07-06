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
        public static void Merge(int[] arr1, int[] arr2, int m, int n)
        {
            int insertIndex = m + n - 1;
            m = m - 1;
            n = n - 1;
            while (insertIndex >= 0)
            {
                while (m >= 0 && n >= 0)
                {
                    if (arr1[m] > arr2[n])
                        arr1[insertIndex--] = arr1[m--];
                    else
                        arr1[insertIndex--] = arr2[n--];
                }

                while(m >= 0)
                    arr1[insertIndex--] = arr1[m--];

                while(n >= 0)
                    arr1[insertIndex--] = arr2[n--];
            }

            for (int i = 0; i < arr1.Length; i++)
                Console.Write(arr1[i] + "\t");

            Console.WriteLine("\n");
        }
    }
}