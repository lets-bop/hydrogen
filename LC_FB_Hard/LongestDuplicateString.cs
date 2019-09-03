using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    class LongestDuplicateString
    {
        string longestSoFar;

        public string LongestDupSubstring(string S) {
            List<string> suffixes = new List<string>();
            this.longestSoFar = string.Empty;

            for (int i = 0; i < S.Length; i++) suffixes.Add(S.Substring(i));
            suffixes.Sort();

            string result = string.Empty;
            for (int i = 1; i < suffixes.Count; i++) {
                this.Lcp(suffixes[i], suffixes[i-1]);
            }

            return this.longestSoFar;
        }

        private void Lcp(string s1, string s2) {
            if (s1 == null || s2 == null || s1.Length == 0 || s2.Length == 0) return;

            int i = 0;
            while (i < s1.Length && i < s2.Length && s1[i] == s2[i]) i++;
            if (i > this.longestSoFar.Length) this.longestSoFar = s1.Substring(0, i);
        }
    }
}