/*
Given an unsorted array of integers, find the length of the longest consecutive elements sequence.
Your algorithm should run in O(n) complexity.

Example:
    Input: [100, 4, 200, 1, 3, 2], Output: 4
    Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class LongestConsecutiveSequence
    {
        public int LongestConsecutive(int[] nums)  {
            if (nums == null || nums.Length == 0) return 0;
            
            HashSet<int> hs = new HashSet<int>();
            foreach (int num in nums) hs.Add(num);

            int longest = 0;
            foreach (int num in nums) {
                if (!hs.Contains(num)) break;
                int currentLongest = 1;
                int value = num;
                while (true) {
                   if (!hs.Contains(++value)) break;
                   currentLongest++;
                }

                value = num;
                while (true) {
                   if (!hs.Contains(--value)) break;
                   currentLongest++;
                }

                longest = Math.Max(currentLongest, longest);
            }

            return longest;
        }
    }
}