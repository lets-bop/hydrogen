using System;
using System.Collections.Generic;

/*
Given a string containing only three types of characters: '(', ')' and '*', 
write a function to check whether this string is valid. We define the validity of a string by these rules:

Any left parenthesis '(' must have a corresponding right parenthesis ')'.
Any right parenthesis ')' must have a corresponding left parenthesis '('.
Left parenthesis '(' must go before the corresponding right parenthesis ')'.
'*' could be treated as a single right parenthesis ')' or a single left parenthesis '(' or an empty string.

An empty string is also valid.
Example 1:
Input: "()"
Output: True

Example 2:
Input: "(*)"
Output: True

Example 3:
Input: "(*))"
Output: True
*/
namespace LC_FB_Medium
{
    class ValidParenthesisString
    {
        public bool CheckValidString(string s) {
            /*
            For example, if we have string '(***)', then as we parse each symbol, 
            the set of possible values for the balance is [1] for '('; 
            [0, 1, 2] for '(*'; [0, 1, 2, 3] for '(**'; [0, 1, 2, 3, 4] for '(***', 
            and [0, 1, 2, 3] for '(***)'.

            Let lo, hi respectively be the smallest and largest possible number of open 
            left brackets after processing the current character in the string.
            */

            int lo = 0, hi = 0;
            for (int i = 0; i < s.Length; i++) {
                
                if (s[i] == '(') lo++;
                else lo--;
                lo = Math.Max(lo, 0);

                if (s[i] == ')') hi--;
                else hi++;
                if (hi < 0) return false;
            }

            return lo == 0;
        }

        public bool CheckValidString2(string s) {
            int parenthesis_count = 0;
            int asterisk_count = 0;
            
            for (int i = 0; i < s.Length; i++) {
                if (s[i] == '(') parenthesis_count++;
                else if (s[i] == ')') parenthesis_count--;
                else if (s[i] == '*') asterisk_count++;
                
                if (parenthesis_count < 0) {
                    if (asterisk_count > 0){
                        parenthesis_count++;
                        asterisk_count--;
                    } else return false;
                }
            }
            
            if (parenthesis_count > asterisk_count) return false;
            return true;
        }
    }
}