using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given a string, find the length of the longest substring without repeating characters.

        Example 1:
        Input: "abcabcbb"
        Output: 3 
        Explanation: The answer is "abc", with the length of 3. 

        Example 2:
        Input: "bbbbb"
        Output: 1
        Explanation: The answer is "b", with the length of 1.

        Example 3:
        Input: "pwwkew"
        Output: 3
        Explanation: The answer is "wke", with the length of 3. 
        Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
    */
    class LongestWithoutRepeatingChars
    {
        public int LengthOfLongestSubstring(string s) {
            int maxLength = 0;
            int start = 0;
            int end = 0;
            HashSet<char> set = new HashSet<char>();

            while (end < s.Length) {
                if (!set.Contains(s[end])) {
                    set.Add(s[end]);
                    maxLength = Math.Max(maxLength, end - start + 1);
                    end++;
                } else {
                    // repeating
                    while (s[start] != s[end]) {
                        set.Remove(s[start]);
                        start++;
                    }
                    // s[start] == s[end]. increment start
                    set.Remove(s[start]);
                    start++;
                }
            }

            return maxLength;
        }
    }
}