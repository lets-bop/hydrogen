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

            Dictionary<char, int> dict = new Dictionary<char, int>();
            int start = 0;
            int end = 0;
            int distinctCount = 0;  // keeps the count of the distinct chars in the window
            int maxLength = 0;

            dict[s[start]] = 1;
            distinctCount++;

            while (end < s.Length) {
                if (distinctCount <= k) {
                    maxLength = Math.Max(maxLength, end - start + 1);
                    end++;
                    if (end >= s.Length) break;
                    if (dict.ContainsKey(s[end])) dict[s[end]]++;
                    else {
                        dict[s[end]] = 1;
                        distinctCount++;
                    }
                } else {
                    while (distinctCount > k) {
                        // keep reducing the size of the window
                        dict[s[start]]--;
                        if (dict[s[start]] == 0){
                            distinctCount--;
                            dict.Remove(s[start]);
                        }
                        start++;
                    }
                }
            }

            return maxLength;
        }
    }
}