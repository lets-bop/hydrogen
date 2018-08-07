/*
Given an input string (s) and a pattern (p), implement wildcard pattern matching with support for '?' and '*'.

'?' Matches any single character.
'*' Matches any sequence of characters (including the empty sequence).

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class WildcardMatching
    {
        public static bool IsMatch(string s, string p)
        {
            if (s == null || p == null) return false;
            if (s.Length == 0 && p.Length == 0) return true;

            int starIndex = -1;
            int sIndexAtStar = -1;
            int sIndex = 0, pIndex = 0;

            while(sIndex < s.Length && pIndex <= p.Length)
            {
                if ((pIndex < p.Length) && (s[sIndex] == p[pIndex] || p[pIndex] == '?'))
                {
                    sIndex++;
                    pIndex++;
                }
                else if (pIndex < p.Length && p[pIndex] == '*')
                {
                    starIndex = pIndex;
                    sIndexAtStar = sIndex;
                    pIndex++;
                }
                else
                {
                    if (starIndex != -1)
                    {
                        pIndex = starIndex + 1;
                        sIndex = sIndexAtStar + 1;
                        sIndexAtStar++;
                    }
                    else return false;
                }
            }

            // To handle s = "" and p="*"
            while(pIndex < p.Length && p[pIndex] == '*') pIndex++;

            if (sIndex == s.Length && pIndex == p.Length) return true;
            return false;
        }
    }  
}