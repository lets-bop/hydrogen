/*
Given a non-empty string s and a dictionary wordDict containing a list of 
non-empty words, determine if s can be segmented into a space-separated sequence 
of one or more dictionary words.

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
Explanation: Return true because "applepenapple" can be segmented as "apple pen apple"
Note that you are allowed to reuse a dictionary word.
Example 3:

Input: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
Output: false
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class WordBreak
    {
        Dictionary<int, bool> memo = new Dictionary<int, bool>();

        // O(n^2). Leetcode accepted with memo.
        public bool Check2(string s, IList<string> wordDict) {
            if (s == null || s.Length == 0 || wordDict == null || wordDict.Count == 0) return false;
            this.memo.Clear();
            HashSet<string> set = new HashSet<string>();
            foreach(string w in wordDict) set.Add(w);
            return this.WordBreak2Rec(s, set, 0);
        }

        private bool WordBreak2Rec(string s, HashSet<string> words, int startIndex) {
            if (s == null || startIndex >= s.Length) return false;

            if (this.memo.ContainsKey(startIndex)) return this.memo[startIndex];
            List<string> list = new List<string>();
            for (int l = 1; l <= s.Length - startIndex; l++) {
                if (words.Contains(s.Substring(startIndex, l))) {
                    if (startIndex + l == s.Length) return true;
                    if (this.WordBreak2Rec(s, words, startIndex + l)) {
                        this.memo[startIndex] = true;
                        return true;
                    }
                }
            }

            this.memo[startIndex] = false;
            return false;
        }

        public bool Check3(string word, IList<string> wordDict)
        {
            HashSet<string> dict = new HashSet<string>(wordDict);
            Stack<MatchedWord> stack = new Stack<MatchedWord>();
            Dictionary<int, bool> mem = new Dictionary<int, bool>();
            int maxWordLengthInDic = 0;

            foreach (string w in wordDict) {
                if (w.Length > maxWordLengthInDic) maxWordLengthInDic = w.Length;
            }

            int start = 0;
            int end = word.Length - 1;

            // Find the first match
            do {
                StringBuilder sb = new StringBuilder();
                Queue<MatchedWord> queue = new Queue<MatchedWord>(); // collect the words that could lead to the split.
                for (int i = start; i <= end && i < start + maxWordLengthInDic; i++) {
                    sb.Append(word[i]);
                    if (wordDict.Contains(sb.ToString())) {
                        if (i <= end) {
                            // we can short circuit here as we'd be here only if the word prior to this was found.
                            if (i == end) {
                                return true;
                            }

                            // Collect the word in the queue only if we can satisfy the split from the end of this word
                            // or we don't know as yet if we can satisfy the split.
                            if (!mem.ContainsKey(i + 1) || (mem.ContainsKey(i+1) && mem[i+1])) {
                                queue.Enqueue(new MatchedWord(sb.ToString(), start, i));
                            }
                        }
                    }
                }

                if (queue.Count > 0) {
                    foreach (MatchedWord item in queue) {
                        stack.Push(item);
                        if (item.end < end && mem.ContainsKey(item.end + 1) && mem[item.end + 1]) mem[item.start] = true;
                    }
                }
                else {
                    // the queue being empty means that no split starting at the index was satisfactory.
                    mem[start] = false;
                }

                if (stack.Count == 0) {
                    return false;
                }
                
                MatchedWord mw = stack.Pop();
                start = mw.end + 1;

            } while (stack.Count >= 0);

            return false;
        }

        public class MatchedWord
        {
            public string word; // the matching word
            public int start; // the start index in the provided word
            public int end;   // the end index in the provided word

            public MatchedWord(string word, int start, int end)
            {
                this.word = word;
                this.start = start;
                this.end = end;
            }
        }
    }
}