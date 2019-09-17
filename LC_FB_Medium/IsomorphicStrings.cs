using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given two strings s and t, determine if they are isomorphic.
        Two strings are isomorphic if the characters in s can be replaced to get t.
        All occurrences of a character must be replaced with another character while preserving the order of characters. 
        No two characters may map to the same character but a character may map to itself.

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

            Dictionary<char, char> replacements1 = new Dictionary<char, char>();
            Dictionary<char, char> replacements2 = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; i++) {
                if (replacements1.ContainsKey(s[i])) {
                    if (replacements1[s[i]] != t[i]) return false;
                } else if (replacements2.ContainsKey(t[i])) return false;

                replacements1[s[i]] = t[i];
                replacements2[t[i]] = s[i];
            }

            return true;
        }
    }
}