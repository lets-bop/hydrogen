using System;
using System.Collections.Generic;

namespace LC_FB_Easy
{
    /*
    */

    class ValidPalindrome2
    {
        public bool ValidPalindrome(string s) {
            if (s == null) return false;
            if (s.Length == 0) return true;

            int i = 0;
            int j = s.Length - 1;

            while(i <= j) 
            {
                if (s[i] == s[j]) {
                    i++;
                    j--;
                } else return ValidPalindromeInRange(s, i + 1, j) || ValidPalindromeInRange(s, i, j - 1);
            }

            return true;
        }

        private bool ValidPalindromeInRange(string s, int i, int j) {
            if (i > j) return false;

            while(i <= j) {
                if (s[i] == s[j]) {
                    i++;
                    j--;
                } else return false;
            }

            return true;
        }
    }
}