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

            Dictionary<char, int> tCount = new Dictionary<char, int>();
            foreach(char c in t.ToCharArray()) tCount[c] = tCount.GetValueOrDefault(c) + 1;

            int start = 0, end = 0;
            Dictionary<char, int> sCount = new Dictionary<char, int>();
            int charsToMatch = tCount.Count;
            HashSet<char> matchedChars = new HashSet<char>();
            int minStart = 0, minWindow = int.MaxValue;

            while (end < s.Length) {
                while (charsToMatch > 0 && end < s.Length) {
                    char c = s[end];
                    sCount[c] = sCount.GetValueOrDefault(c) + 1;
                    if (tCount.ContainsKey(c) && sCount[c] >= tCount[c] && !matchedChars.Contains(c)) {
                        matchedChars.Add(c);
                        charsToMatch--;
                    }

                    end++;
                }

                while (charsToMatch == 0 && start < end) {
                    if (charsToMatch == 0 && (end - start) < minWindow) {
                        minStart = start;
                        minWindow = end - start;
                    }

                    char c = s[start++];
                    sCount[c]--;
                    if (tCount.ContainsKey(c) && sCount[c] < tCount[c]) {
                        charsToMatch++;
                        matchedChars.Remove(c);
                    }
                }
            }

            if (minWindow != int.MaxValue) return s.Substring(minStart, minWindow);
            return string.Empty;
        }
    }
}
