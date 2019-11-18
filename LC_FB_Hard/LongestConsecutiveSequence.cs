/*
Given an unsorted array of integers, find the length of the longest consecutive elements sequence.

Your algorithm should run in O(n) complexity.

Example:

Input: [100, 4, 200, 1, 3, 2]
Output: 4
Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class LongestConsecutiveSequence
    {
        private Dictionary<int, int> dic = new Dictionary<int, int>();
        int longest = 0;

        public int LongestConsecutive(int[] nums) 
        {
            if (nums == null || nums.Length == 0) return 0;

            foreach (int num in nums) dic[num] = num;

            List<int> keys = new List<int>(dic.Keys);

            foreach (int key in keys)
            {
                int currentLongest = 0;
                int value = key;
                while (dic.ContainsKey(value))
                {
                    dic.Remove(value);
                    value++;
                    currentLongest++;
                }

                value = key;
                --value;
                while (dic.ContainsKey(value))
                {
                    dic.Remove(value);
                    value--;
                    currentLongest++;
                }      

                if (currentLongest > longest) this.longest = currentLongest;      
            }

            return this.longest;
        }
    }
}