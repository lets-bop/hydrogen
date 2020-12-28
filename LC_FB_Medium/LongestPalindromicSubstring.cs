using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
    Given a string s, return the longest palindromic substring in s.
    
    Example 1:
    Input: s = "babad" Output: "bab". Note: "aba" is also a valid answer.

    Example 2:
    Input: s = "cbbd" Output: "bb"

    Example 3:
    Input: s = "a" Output: "a"

    Example 4:
    Input: s = "ac" Output: "a"
    */
    public class LongestPalindromicSubstring
    {
        public string LongestPalindrome(string s) {
            // return LongestPalindromeBrute(s);
            int len = 0;
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++) {
                int l1 = this.ExpandFromMiddle(s, i, i); // to handle odd length palindrome. Ex: bab & i = 1.
                int l2 = this.ExpandFromMiddle(s, i, i + 1); // to handle even length pandrome. Ex: baab & i = 1.
                len = Math.Max(l1, l2);
                if (len > end - start) {
                    start = i - ((len - 1) / 2);
                    end = i + (len / 2);
                }
            }

            return s.Substring(start, end - start + 1);
        }

        private int ExpandFromMiddle(string s, int i, int j) {
            if (s == null || i > j) return 0;

            while (i >= 0 && j < s.Length && s[i] == s[j]) {
                i--; j++;
            }

            return j - i - 1;
        }

        private string LongestPalindromeBrute(string s) {
            // O(n^3). Generate all possible substrings of s and check if its a palindrome.
            // It takes O(n^2) to generate all substrings and for each of those, 
            // it takes 0(n) time to check if its a palindrome. 
            // Example: if you have a string "abcd". 
            // Start with a and for lengths 1 to (s.Length - 1), find all substrings. 
            // Then go to b and do the same.
            int max = 0;
            string pal = string.Empty;
            for(int i = 0; i < s.Length; i++) {
                string str;
                for (int l = 1; l <= s.Length - i; l++) {
                    str = s.Substring(i, l);
                    if(IsPalindrome(str) && (max < str.Length)) {
                        max = str.Length;
                        pal = str;
                    }
                }
            }

            return pal;
        }

        private static bool IsPalindrome(string s) {
            if (s == null || s.Length == 0 || s.Length == 1) return true;
            int i = 0, j = s.Length - 1;
            while (i < j) if (s[i++] != s[j--]) return false;
            return true;
        }
    }
}