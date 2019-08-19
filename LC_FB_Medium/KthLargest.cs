using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Find the kth largest element in an unsorted array. 
        Note that it is the kth largest element in the sorted order, not the kth distinct element.

        Example 1:
        Input: [3,2,1,5,6,4] and k = 2
        Output: 5

        Example 2:
        Input: [3,2,3,1,2,4,5,5,6] and k = 4
        Output: 4
        Note: You may assume k is always valid, 1 ≤ k ≤ array's length.
    */
    class KthLargetst
    {
        Random random = new Random();

        public int FindKthLargest(int[] nums, int k) {
            // finding kth largest is same as finding (n-k)th smallest
            int toFindIndex = nums.Length - k;
            int pivotIndex;
            int i = 0;
            int j = nums.Length - 1;

            while (i <= j) {
                pivotIndex = this.QuickSelect(nums, i, j);
                if (pivotIndex == toFindIndex) return nums[pivotIndex];
                if (toFindIndex < pivotIndex) j = pivotIndex - 1;
                else i = pivotIndex + 1;
            }

            return -1;
        }

        private int QuickSelect(int[] nums, int i, int j) {
            int pivot = i;

            // exchange pivot with any # between i and j
            this.Swap(nums, i, random.Next(i, j + 1));
            i++;

            while (true) {
                while (i < j && nums[i] <= nums[pivot]) i++;
                while (i <= j && nums[j] > nums[pivot]) j--;
                if (i >= j) break;
                this.Swap(nums, i, j);
            }

            this.Swap(nums, pivot, j);
            return j;
        }

        private void Swap(int[] nums, int i, int j) {
            int tmep = nums[i];
            nums[i] = nums[j];
            nums[j] = tmep;
        }
    }
}