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
            int low = 0;
            int high = nums.Length - 1;

            while (low <= high) {
                pivotIndex = this.QuickSelect(nums, low, high);
                if (pivotIndex == toFindIndex) return nums[pivotIndex];
                if (toFindIndex < pivotIndex) high = pivotIndex - 1;
                else low = pivotIndex + 1;
            }

            return -1;
        }

        private int QuickSelect(int[] nums, int low, int high) {
            int pivot = low;

            // exchange pivot with any # between i and j
            this.Swap(nums, low, random.Next(low, high + 1));
            low++;

            while (true) {
                while (low < high && nums[low] <= nums[pivot]) low++;
                while (low <= high && nums[high] > nums[pivot]) high--;
                if (low >= high) break;
                this.Swap(nums, low, high);
            }

            this.Swap(nums, pivot, high);
            return high;
        }

        private void Swap(int[] nums, int i, int j) {
            int tmep = nums[i];
            nums[i] = nums[j];
            nums[j] = tmep;
        }
    }
}