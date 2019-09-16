using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given two strings s and t, determine if they are isomorphic.
        Two strings are isomorphic if the characters in s can be replaced to get t.
        All occurrences of a character must be replaced with another character while preserving the order of characters. No two characters may map to the same character but a character may map to itself.

        Example 1:
        Input: s = "egg", t = "add"
        Output: true
        Example 2:
        Input: s = "foo", t = "bar"
        Output: false
        Example 3:
        Input: s = "paper", t = "title"
        Output: true

        Note:
        You may assume both s and t have the same length.
    */
    class IsomorphicStrings
    {
        public bool IsIsomorphic(string s, string t) {
            if (s == null && t == null) return true;
            if (s == null || t == null || s.Length != t.Length) return false;

            Dictionary<char, char> replacements = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; i++) {
                if (s[i] == t[i]) continue;
                if (replacements.ContainsKey(s[i]) && replacements.ContainsKey(t[i])) {
                    if (s[i] != replacements[t[i]] || t[i] != replacements[s[i]]) return false;
                    continue;
                }
                if (!replacements.ContainsKey(s[i]) && !replacements.ContainsKey(t[i])) {
                    replacements[s[i]] = t[i];
                    replacements[t[i]] = s[i];
                    continue;
                }

                return false;
            }

            return true;
        }
    }
}