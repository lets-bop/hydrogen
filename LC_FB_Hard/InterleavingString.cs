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
            int s1Index = 0, s1MatchSoFar = -1;
            int s2Index = 0, s2MatchSoFar = -1;
            int s3Index = 0;

            while(s3Index < s3.Length){
                if (s1Index < s1.Length && s2Index < s2.Length && s3[s3Index] == s1[s1Index] && s3[s3Index] == s2[s2Index]){
                    s1Index++;
                    s2Index++;
                }
                else if (s1Index < s1.Length && s3[s3Index] == s1[s1Index]){
                    if (s2MatchSoFar != s2Index - 1) s2Index = s2MatchSoFar + 1;
                    s1MatchSoFar = s1Index;
                    s1Index++;
                }
                else if (s2Index < s2.Length && s3[s3Index] == s2[s2Index]){
                    if (s1MatchSoFar != s1Index - 1) s1Index = s1MatchSoFar + 1;
                    s2MatchSoFar = s2Index;
                    s2Index++;
                }
                else return false;

                s3Index++;   
            }

            if (s1Index == s1.Length && s2Index == s2.Length) return true;
            return false;
        }        
    }
}