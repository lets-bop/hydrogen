using System;
using System.Collections.Generic;

/*
Given a string S and a string T, count the number of distinct subsequences of S which equals T.

A subsequence of a string is a new string which is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. (ie, "ACE" is a subsequence of "ABCDE" while "AEC" is not).

Example 1:

Input: S = "rabbbit", T = "rabbit"
Output: 3
Explanation:

As shown below, there are 3 ways you can generate "rabbit" from S.
(The caret symbol ^ means the chosen letters)

rabbbit
^^^^ ^^
rabbbit
^^ ^^^^
rabbbit
^^^ ^^^
Example 2:

Input: S = "babgbag", T = "bag"
Output: 5
Explanation:

As shown below, there are 5 ways you can generate "bag" from S.
(The caret symbol ^ means the chosen letters)

babgbag
^^ ^
babgbag
^^    ^
babgbag
^    ^^
babgbag
  ^  ^^
babgbag
    ^^^
*/
namespace LC_FB_Hard
{
    class DistinctSubsequence
    {
        public int NumDistinct(string s, string t) {
            // We can solve this using DP.
            // We build the dp array with s.Length+1 cols and t.Length+1 rows
            // S[0] col and T[0] rows represent empty strings.
            // If T is empty, then dp[0][0] = 1 and all subsequent cols dp[0][j] = 1.
            // i.e. best of whatever we have found so far = 1.
            // For all other T, if S is empty, then we wont have a matching subsequence hence length = 0
            // Now if the char at T and S match, we just take subsequences found so far in (i.e. without the current char in T) 
            // and add to it the subsequences found without considering char in S or T
            // If the chars do not match, keep whatever we have found so far.
            int[,] dp = new int[t.Length + 1,s.Length + 1];
            for (int i = 0; i < dp.GetLength(1); i++) dp[0, i] = 1; // cols of row 0

            for (int i = 1; i < dp.GetLength(0); i++) // rows
            {
                for (int j = 1; j < dp.GetLength(1); j++) // cols
                {
                    if (s[j - 1] == t[i - 1]) dp[i, j] = dp[i, j - 1] + dp[i-1, j-1];
                    else dp[i,j] = dp[i, j -1];
                }
            }

            return dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1];
        }
    }
}