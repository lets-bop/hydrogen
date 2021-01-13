/*
Given s1, s2, s3, find whether s3 is formed by the interleaving of s1 and s2.

Example 1:

Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac"
Output: true
Example 2:

Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbbaccc"
Output: false
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class InterleavingString
    {
        public bool IsInterleave(string s1, string s2, string s3) {
            if (s1.Length + s2.Length != s3.Length) return false;
            if (s1.Length == 0) return s3 == s2;
            if (s2.Length == 0) return s3 == s1;
            return this.IsInterleave(
                s1.ToCharArray(), 
                s2.ToCharArray(), 
                s3.ToCharArray(), 0, 0, 0, new bool[s1.Length + 1, s2.Length + 1]);
        }

        private bool IsInterleave(char[] c1, char[] c2, char[] c3, int i, int j, int k, bool[,] invalid) {
            if (k == c3.Length) return true;
            if (invalid[i,j]) return false;

            bool isValid = false;
            if (i < c1.Length && c1[i] == c3[k]) {
                isValid = this.IsInterleave(c1, c2, c3, i+1, j, k+1, invalid);
            }
            if (!isValid && j < c2.Length && c2[j] == c3[k]) {
                isValid = this.IsInterleave(c1, c2, c3, i, j+1, k+1, invalid);
            }

            if (!isValid) invalid[i,j] = true;
            return isValid;
        }
    }
}