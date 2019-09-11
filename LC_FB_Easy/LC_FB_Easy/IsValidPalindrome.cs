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
        public bool IsPalindrome(string s) {
            if (s == null) return false;
            if (s.Length == 0) return true;
            
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
                
                if (this.IsSameCharsIgnoreCase(s[i], s[j])) {
                    i++;
                    j--;
                } else return false;
            }
            
            return true;
        }
        
        private bool IsAlphaNumeric(char c) {
            if ((c >= 65 && c <= 90) || 
                (c >= 97 && c <= 122) || 
                (c >= 48 && c <= 57)) {
                return true;
            }
            
            return false;
        }
        
        private bool IsSameCharsIgnoreCase(char c1, char c2) {
            if (c1 == c2) return true;
            
            // handle special cases like "0P"
            if ((c1 >= 48 && c1 <= 57) || (c2 >= 48 && c2 <= 57)) {
                if (c1 - 48 == c2 - 48) return true;
                return false;
            }

            if (c1 - 65 == c2 - 65 || c1 - 65 == c2 - 97) return true;
            if (c1 - 97 == c2 - 65 || c1 - 97 == c2 - 97) return true;
            if (c1 - 48 == c2 - 48) return true;
            return false;
        }
    }
}