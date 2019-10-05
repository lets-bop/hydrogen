using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given a string, find the length of the longest substring T that contains at most k distinct characters.

        Example 1:

        Input: s = "eceba", k = 2
        Output: 3
        Explanation: T is "ece" which its length is 3.
        Example 2:

        Input: s = "aa", k = 1
        Output: 2
        Explanation: T is "aa" which its length is 2.
    */
    class LongestSubstringKDistinctChars
    {
        public int LengthOfLongestSubstringKDistinct(string s, int k) {
            if (s == null || s.Length == 0) return 0;
            if (k == 0) return 0;

            Dictionary<char, int> check = new Dictionary<char, int>();
            int start = 0, end = 0, maxLength = 1, tempK = k;

            while (end < s.Length) {
                char c = s[end];
                if (!check.ContainsKey(c) || check[c] == 0) {
                    tempK--;
                    check[c] = 1;
                } else check[c]++;

                if (tempK < 0) maxLength = Math.Max(maxLength, end - start);
                while (tempK < 0) {
                    check[s[start]]--;
                    if (check[s[start]] == 0) tempK++;
                    start++;
                }

                end++;
            }

            maxLength = Math.Max(maxLength, end - start);
            return maxLength;
        }
    }
}