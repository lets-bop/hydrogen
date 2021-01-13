/*
    Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, 
    determine if s can be segmented into a space-separated sequence of one or more dictionary words.

    Note:
    The same word in the dictionary may be reused multiple times in the segmentation.
    You may assume the dictionary does not contain duplicate words.

    Example 1:
        Input: s = "leetcode", wordDict = ["leet", "code"]
        Output: true
        Explanation: Return true because "leetcode" can be segmented as "leet code".

    Example 2:
        Input: s = "applepenapple", wordDict = ["apple", "pen"]
        Output: true
        Explanation: Return true because "applepenapple" can be segmented as "apple pen apple". 
        Note that you are allowed to reuse a dictionary word.

    Example 3:
        Input: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
        Output: false
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class WordBreak
    {
        Dictionary<int, bool> memo = new Dictionary<int, bool>();
        public bool WordBreak1(string s, IList<string> wordDict) {
            if (s == null || s.Length == 0 || wordDict == null || wordDict.Count == 0) return false;
            HashSet<string> set = new HashSet<string>();
            foreach(string w in wordDict) set.Add(w);
            return this.WordBreak1(s, set, 0);
        }
        
        private bool WordBreak1(string s, HashSet<string> words, int startIndex) {
            if (s == null || startIndex >= s.Length) return false;

            if (this.memo.ContainsKey(startIndex)) return this.memo[startIndex];
            List<string> list = new List<string>();
            for (int l = 1; l <= s.Length - startIndex; l++) {
                if (words.Contains(s.Substring(startIndex, l))) {
                    if (startIndex + l == s.Length) return true;
                    if (this.WordBreak1(s, words, startIndex + l)) {
                        this.memo[startIndex] = true;
                        return true;
                    }
                }
            }
            
            this.memo[startIndex] = false;
            return false;
        } 
    }
}