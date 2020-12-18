/*
Given a string s and a non-empty string p, find all the start indices of p's anagrams in s.

Strings consists of lowercase English letters only and the length of 
both strings s and p will not be larger than 20,100. The order of output does not matter.

Example 1:
Input:
s: "cbaebabacd" p: "abc"
Output:
[0, 6]
Explanation:
The substring with start index = 0 is "cba", which is an anagram of "abc".
The substring with start index = 6 is "bac", which is an anagram of "abc".

Example 2:
Input:
s: "abab" p: "ab"
Output:
[0, 1, 2]
Explanation:
The substring with start index = 0 is "ab", which is an anagram of "ab".
The substring with start index = 1 is "ba", which is an anagram of "ab".
The substring with start index = 2 is "ab", which is an anagram of "ab".
*/

using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    class FindAllAnagramsInString
    {
        /*
            Store the char count of p in a dictionary.
            Use a 2 pointer technique to look for the anagram in s.
        */
        public IList<int> FindAnagrams(string s, string p) {
            List<int> res = new List<int>();
            if (p == null || p.Length == 0 || s == null || s.Length == 0) return res;
            
            int i = 0, j = 0;
            Dictionary<char, int> pCount = new Dictionary<char, int>();
            for (int k = 0; k < p.Length; k++) {
                pCount[p[k]] = pCount.GetValueOrDefault(p[k], 0) + 1;
            }
            
            int charsToMatch = pCount.Count;
            while (i <= j && j < s.Length) {
                while (j < s.Length) {
                    if (pCount.ContainsKey(s[j])) {
                        pCount[s[j]]--;
                        if (pCount[s[j]] == 0) charsToMatch--;
                        if (charsToMatch == 0) { j++; break; }
                    }
                    j++;
                }
                
                while (charsToMatch == 0) {
                    if (j - i == p.Length) res.Add(i);
                    if (pCount.ContainsKey(s[i])) { 
                        pCount[s[i]]++;
                        if (pCount[s[i]] > 0) charsToMatch++;
                    }
                    i++;
                }
            }
            
            return res;
        }
    }
}