/*
Given an input string (s) and a pattern (p), implement regular expression matching with support for '.' and '*'.

'.' Matches any single character.
'*' Matches zero or more of the preceding element.
The matching should cover the entire input string (not partial).

Note:

s could be empty and contains only lowercase letters a-z.
p could be empty and contains only lowercase letters a-z, and characters like . or *

For example:
Input:
s = "aa"
p = "a"
Output: false
Explanation: "a" does not match the entire string "aa".
Example 2:

Input:
s = "aa"
p = "a*"
Output: true
Explanation: '*' means zero or more of the precedeng element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".
Example 3:

Input:
s = "ab"
p = ".*"
Output: true
Explanation: ".*" means "zero or more (*) of any character (.)".
Example 4:

Input:
s = "aab"
p = "c*a*b"
Output: true
Explanation: c can be repeated 0 times, a can be repeated 1 time. Therefore it matches "aab".
Example 5:

Input:
s = "mississippi"
p = "mis*is*p*."
Output: false
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class RegexMatching
    {
        public static bool Execute(string str, string pattern)
        {
            if (str == null || pattern == null) return false;
            if (pattern.Length > 0 && pattern[0] == '*') throw new Exception("Invalid regex");

            bool[,] dp = new bool[str.Length + 1, pattern.Length + 1];
            dp[0,0] = true;

            for (int row = 0; row < str.Length + 1; row++)
            {
                for (int col = 1; col < pattern.Length + 1; col++)
                {
                    if (row > 0 && (pattern[col - 1] == str[row - 1] || pattern[col - 1] == '.'))
                        dp[row, col] = dp[row - 1, col - 1];
                    else if (pattern[col - 1] == '*')
                    {
                        if (row == 0) dp[row, col] = dp[row, col - 2];
                        else
                        {
                            dp[row, col] = 
                                dp[row, col - 2] || 
                                ((str[row - 1] == pattern[col - 2] || pattern[col - 2] == '.')?dp[row-1,col]:false);
                        }
                    }
                }
            }

            return dp[str.Length, pattern.Length];
        }
    }
}

