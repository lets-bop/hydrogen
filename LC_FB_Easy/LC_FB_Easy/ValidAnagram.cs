using System;
using System.Collections.Generic;

namespace LC_FB_Easy
{
    /*
        Given two strings s and t , write a function to determine if t is an anagram of s.

        Example 1:

        Input: s = "anagram", t = "nagaram"
        Output: true
        Example 2:

        Input: s = "rat", t = "car"
        Output: false
        Note:
        You may assume the string contains only lowercase alphabets.

        Follow up:
        What if the inputs contain unicode characters? How would you adapt your solution to such case?
    */
    class ValidAnagram
    {
        public bool IsAnagram(string s, string t) {
            int[] check = new int[26];
            if (s.Length != t.Length) return false;

            for(int i =0; i < s.Length; i++) {
                check[s[i] - 'a']++;
                check[t[i] - 'a']--;
            }

            for (int i = 0; i < check.Length; i++) {
                if (check[i] != 0) return false;
            }

            return true;
        }
    }
}