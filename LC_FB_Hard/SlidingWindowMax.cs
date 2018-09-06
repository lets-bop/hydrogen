/*
Given an array nums, there is a sliding window of size k which is moving from the very left of the array to the very right. You can only see the k numbers in the window. Each time the sliding window moves right by one position. Return the max sliding window.

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
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length < 1) return null;

            int[] result = new int[nums.Length - k + 1];
            int c = 0;

            // the front of the deque will have the largest element
            // the rear of the deque will have the smallest element
            Deque q = new Deque();

            for (int i = 0; i < nums.Length; i++){
                while(q.Count() > 0 && nums[q.PeekLast()] < nums[i]) q.PollLast();
                q.AddLast(i);

                while(q.Count() > 1 && q.PeekLast() - q.PeekFirst() >= k) q.PollFirst();
                if (++c >= k) result[i - k + 1] = nums[q.PeekFirst()];
            }

            return result;
        }
    }
}