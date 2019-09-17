using System;
using System.Collections.Generic;

namespace LC_FB_Hard
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
    class LongestSubstringWithAtMostKDistinct
    {
        public int Find(string s, int k) {
            if (k == 0 || s == null || s.Length == 0) return 0;
            
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            int distinctCount = 0;
            int start = 0, end = 0;
            int longest = 0;

            while (end < s.Length) {
                if (distinctCount < k || (distinctCount == k && charCount.ContainsKey(s[end]))) {
                    if (charCount.ContainsKey(s[end])) charCount[s[end]]++;
                    else {
                        distinctCount++;
                        charCount[s[end]] = 1;
                    }

                    end++;
                } else {
                    // we have hit the limit k
                    longest = Math.Max(longest, end - start);
                    while (distinctCount >= k) {
                        charCount[s[start]]--;
                        if (charCount[s[start]] == 0) {
                            charCount.Remove(s[start]); // optional
                            distinctCount--;
                        }

                        start++;
                    }
                }
            }

            longest = Math.Max(longest, end - start);
            return longest;
        }
    }
}