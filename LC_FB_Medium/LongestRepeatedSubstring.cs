using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
    Given a string S, find out the length of the longest repeating substring(s). 
    Return 0 if no repeating substring exists.

    Example 1:
    Input: S = "abcd" Output: 0
    Explanation: There is no repeating substring.

    Example 2:
    Input: S = "abbaba" Output: 2
    Explanation: The longest repeating substrings are "ab" and "ba", each of which occurs twice.

    Example 3:
    Input: S = "aabcaabdaab" Output: 3
    Explanation: The longest repeating substring is "aab", which occurs 3 times.

    Example 4:
    Input: S = "aaaaa" Output: 4
    Explanation: The longest repeating substring is "aaaa", which occurs twice.
    */

    class LongestRepeatedSubstring
    {
        public int LongestRepeatingSubstring(string S) {
            int longest = int.MinValue;
            List<string> suffixes = new List<string>();

            // Idea: generate suffix arrays and sort them and run Longest common prefix (LCP) on adjacent pairs.
            // suffix array of a string starting at index 0 is all characters of the string
            // suffix array of a string starting at index 1, is the all characters except the first char and so on.
            // Max of N substring calls and N lcp calls
            // Empirical analysis confirmed O(N lg N) time until 2012 in Java. Why?
            // Until 2012, a substring call would not copy characters. It would just refer to the same underlying string
            // and limit access beginning from the start to the end characters. Just references.
            // After 2012, they started copying the characters with every substring call. This requires linear time and space.
            // To fix this, implement your own implementation of the old string class,
            // implement a CompareTo to enable sorting
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