using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given a string s that consists of only uppercase English letters, you can perform at most k operations on that string.
        In one operation, you can choose any character of the string and change it to any other uppercase English character.
        Find the length of the longest sub-string containing all repeating letters you can get after performing the above operations.
        Note: Both the string's length and k will not exceed 10^4.
        Example 1:
        Input: s = "ABAB", k = 2
        Output: 4
        Explanation: Replace the two 'A's with two 'B's or vice versa.

        Example 2:
        Input: s = "AABABBA", k = 1
        Output: 4
        Explanation: Replace the one 'A' in the middle with 'B' and form "AABBBBA".
        The substring "BBBB" has the longest repeating letters, which is 4.
    */
    class LongestRepeatingChar
    {
        public int CharacterReplacement(string s, int k) {
            /*
            Let's say there were no constraints like the k. Given a string convert it to a string with all 
            same characters with minimal changes. The answer to this is: s.Length - maxOccuringCharCount
            Given this, we can apply the at most k changes constraint and maintain a sliding window such that:
            (length of substring - maxOccuringCharCount) <= k
            */

            if (s == null || s.Length == 0) return 0;
            if (s.Length == 1) return 1;

            int maxOccuringCharCount = 0;
            int start = 0;
            int end = 0;
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            int maxLength = 0;

            while (end < s.Length && s.Length - start >= maxLength) {
                if (charCount.ContainsKey(s[end])) charCount[s[end]]++;
                else charCount[s[end]] = 1;
                maxOccuringCharCount = Math.Max(maxOccuringCharCount, charCount[s[end]]);

                if (end - start + 1 - maxOccuringCharCount <= k){
                    maxLength = Math.Max(maxLength, end - start + 1);
                    end++;
                }
                else {
                    while (end - start + 1 - maxOccuringCharCount > k) {
                        // keep reducing the window size
                        charCount[s[start]]--;
                        start++;
                        
                        // need to recaculate maxOccuringCharCount
                        maxOccuringCharCount = 0;
                        foreach (var entry in charCount){
                            maxOccuringCharCount = Math.Max(entry.Value, maxOccuringCharCount);
                        }
                    }
                    end++;
                }
            }

            return maxLength;
        }
    }
}