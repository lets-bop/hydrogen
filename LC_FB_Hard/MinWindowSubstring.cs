/*
Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).

Example:

Input: S = "ADOBECODEBANC", T = "ABC"
Output: "BANC"
Note:

If there is no such window in S that covers all characters in T, return the empty string "".
If there is such window, you are guaranteed that there will always be only one unique minimum window in S.

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class MinWindowSubstring
    {
        public static string ExecuteSlidingWindow(string t, string s) {
            if (s == null || t == null || s.Length > t.Length) return string.Empty;
            string result = string.Empty;
            int minLength = int.MaxValue;

            // Dictionary with all chars in s along with count
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++) {
                char c = s[i];
                charCount[c] = charCount.GetValueOrDefault(c, 0) + 1;
            }

            int start = 0, end = 0, charsToMatch = charCount.Count;

            while (end < t.Length) {
                char c = t[end];
                if (charCount.ContainsKey(c)) {
                    charCount[c]--;
                    if (charCount[c] == 0) charsToMatch--;
                }

                end++;
                while (charsToMatch == 0) {
                    if (minLength > end - start) {
                        result = t.Substring(start, end - start);
                        minLength = end - start;
                    }

                    c = t[start];
                    if (charCount.ContainsKey(c)) {
                        charCount[c]++;
                        if (charCount[c] > 0) charsToMatch++;
                    }
                    start++;
                }
            }

            return result;
        }
    }
}
