using System;
using System.Collections.Generic;

namespace LC_FB_Easy
{
    /*
        Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
        Note: For the purpose of this problem, we define empty string as valid palindrome.

        Example 1:
        Input: "A man, a plan, a canal: Panama"
        Output: true

        Example 2:
        Input: "race a car"
        Output: false
    */
    class IsValidPalindrome
    {
        public bool IsPalindrome(string s1) {
            if (s1 == null) return false;
            if (s1.Length == 0) return true;
            
            string s = s1.ToLowerInvariant(); // ingore case
            int i = 0, j = s.Length - 1;
            bool isAlpha1;
            bool isAlpha2;
            
            while (i <= j) {
                isAlpha1 = this.IsAlphaNumeric(s[i]);
                isAlpha2 = this.IsAlphaNumeric(s[j]);

                if (!isAlpha1 || !isAlpha2) {
                    if (!isAlpha1) i++;
                    if (!isAlpha2) j--;
                    continue;
                }

                if (s[i] != s[j]) return false;
                i++; j--;
            }
            
            return true;
        }
        
        private bool IsAlphaNumeric(char c) {
            if ((c >= 'A' && c <= 'Z') || 
                (c >= 'a' && c <= 'z') || 
                (c >= '0' && c <= '9')) {
                return true;
            }

            return false;
        }
    }
}