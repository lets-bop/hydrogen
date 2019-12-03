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
        public IList<int> FindAnagrams(string s, string p) {
            List<int> result = new List<int>();
            if (p == null || s == null || p.Length > s.Length) return result;

            // create a dictionary of the chars in p and count
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            for (int i = 0; i < p.Length; i++) {
                char c = p[i];
                charCount[c] = charCount.GetValueOrDefault(c, 0) + 1;
            }

            int start = 0, end = 0, charsToMatch = charCount.Count;
            while (end < s.Length) {
                char c = s[end];
                if (charCount.ContainsKey(c)) {
                    charCount[c]--;
                    if (charCount[c] == 0) charsToMatch--;
                }

                end++;

                while(charsToMatch == 0) {
                    c = s[start];
                    if (charCount.ContainsKey(c)) {
                        charCount[c]++;
                        if(charCount[c] > 0) charsToMatch++;
                    }

                    if (end - start == p.Length) result.Add(start);
                    start++;
                }
            }

            return result;
        }
    }
}