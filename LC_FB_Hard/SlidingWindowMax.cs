/*
Given an array nums, there is a sliding window of size k 
which is moving from the very left of the array to the very right. 
You can only see the k numbers in the window. Each time the sliding window 
moves right by one position. Return the max sliding window.

Example:

Input: nums = [1,3,-1,-3,5,3,6,7], and k = 3
Output: [3,3,5,5,6,7] 
Explanation: 

Window position                Max
---------------               -----
[1  3  -1] -3  5  3  6  7       3
 1 [3  -1  -3] 5  3  6  7       3
 1  3 [-1  -3  5] 3  6  7       5
 1  3  -1 [-3  5  3] 6  7       5
 1  3  -1  -3 [5  3  6] 7       6
 1  3  -1  -3  5 [3  6  7]      7
Note: 
You may assume k is always valid, 1 ≤ k ≤ input array's size for non-empty array.

Follow up:
Could you solve it in linear time?

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class SlidingWindowMax
    {
        // C# doesn't have a concept of a double ended queue. hence we need to implement one.
        // Note: Use a linked list to replicate dequeue behavior
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            return this.DequeuBased(nums, k);
            // return this.HammerApproach(nums, k);
        }

        private int[] DequeuBased(int[] nums, int k) {
            // O(n) time
            // Invariant: We maintain a deque with size at most k (only keep the index)
            // Imagine a window that ends at the current element, we will maintain a linked list of decreasing sequence.
            // First element of the list will be max and last element will be least.
            // 1. keep removing elements from the end of the list as long as 
            //    current element > element at the end of the queue 
            // 2. Remove elements that are outside window of size k
            if (nums == null || nums.Length == 0) return new int[] {};
            int[] result = new int[nums.Length - k + 1];

            // the front of the deque will have the largest element
            // the rear of the deque will have the smallest element
            LinkedList<int> q = new LinkedList<int>();

            for (int i = 0; i < nums.Length; i++) {
                // while current element > last element of deque keep popping it
                while(q.Count > 0 && nums[q.Last.Value] < nums[i]) q.RemoveLast();

                q.AddLast(i);

                // Remove elements that are outside of the window of size k (pop front)
                while(q.Count > 1 && q.Last.Value - q.First.Value >= k) q.RemoveFirst();

                // Add to result if count >= k. Front of the deque will have the max element.
                if ((i+1) >= k) result[i - k + 1] = nums[q.First.Value];
            }

            return result;
        }

        public int[] HammerApproach(int[] nums, int k) {
            // O(nk) time
            if (nums == null || nums.Length == 0) return new int[] {};
            int[] ret = new int[nums.Length - k + 1];
            int max = int.MinValue;

            for (int i = 0; i < nums.Length - k; i++) {
                for (int j = i; j < i + k; j++) max = Math.Max(nums[j], max);
                ret[i] = max;
            }

            return ret;
        }
    }
}