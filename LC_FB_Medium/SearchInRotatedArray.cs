/*
Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

(i.e., [0,1,2,4,5,6,7] might become [4,5,6,7,0,1,2]).

You are given a target value to search. If found in the array return its index, otherwise return -1.

You may assume no duplicate exists in the array.

Your algorithm's runtime complexity must be in the order of O(log n).

 */

using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    class SearchInRotatedArray
    {
        public static int GetIndex(int[] array, int itemToSearch)
        {
            if (array == null || array.Length == 0)
                return -1;

            int start = 0;
            int end = array.Length - 1;

            while(start <= end)
            {
                int mid = start + (end - start) / 2;

                if (itemToSearch == array[mid])
                    return mid;

                if (array[start] <= array[end] && itemToSearch >= array[start] && itemToSearch <= array[end])
                {
                    // Perform a regular binary search
                    if (itemToSearch < array[mid])
                        end = mid - 1;
                    else
                        start = mid + 1;
                }
                else if (array[mid] <= array[start])
                {
                    if (itemToSearch <= array[start] && itemToSearch < array[mid])
                        end = mid - 1;
                    else
                        start = mid + 1;
                }
                else
                {
                    if (itemToSearch >= array[start] && itemToSearch < array[mid])
                        end = mid - 1;
                    else
                        start = mid + 1;
                }
            }

            return -1;
        }
    }
}