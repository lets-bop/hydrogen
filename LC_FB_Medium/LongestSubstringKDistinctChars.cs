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
                char c = s[end++];
                if (check.ContainsKey(c)) check[c]++;
                else {
                    while (check.Count >= k) {
                        char sc = s[start];
                        if (--check[sc] == 0) check.Remove(sc);
                        start++;
                    }

                    check[c] = 1;
                }

                maxLength = Math.Max(maxLength, end - start);
            }

            return maxLength;
        }
    }
}