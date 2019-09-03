using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    class LongestRepeatedSubstring
    {
        public int LongestRepeatingSubstring(string S) {
            int longest = int.MinValue;
            List<string> suffixes = new List<string>();

            for (int i = 0; i < S.Length; i++) suffixes.Add(S.Substring(i));
            suffixes.Sort();

            for (int i = 1; i < suffixes.Count; i++) {
                longest = Math.Max(longest, this.Lcp(suffixes[i], suffixes[i-1]));
            }

            return longest;
        }

        private int Lcp(string s1, string s2) {
            if (s1 == null || s2 == null || s1.Length == 0 || s2.Length == 0) return 0;

            int i = 0;
            while (i < s1.Length && i < s2.Length && s1[i] == s2[i]) i++;
            return i;
        }
    }
}