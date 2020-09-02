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
        // O(n^2) time and O(n) space
        public bool CanBreak(String s, List<String> wordDict) {
            HashSet<string> wordDictSet = new HashSet<string>(wordDict);
            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();
            queue.Enqueue(0);

            while (queue.Count > 0) {
                int start = queue.Dequeue();
                if (!visited.Contains(start)) {
                    visited.Add(start);
                    for (int end = start + 1; end <= s.Length; end++) {
                        if (wordDictSet.Contains(s.Substring(start, end))) {
                            queue.Enqueue(end);
                            if (end == s.Length) {
                                return true;
                            }
                        }
                    }
                }
            }
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

        public bool Check2(string word, IList<string> wordDict)
        {
            HashSet<string> dict = new HashSet<string>(wordDict);
            Stack<MatchedWord> stack = new Stack<MatchedWord>();
            Dictionary<int, bool> mem = new Dictionary<int, bool>();
            int maxWordLengthInDic = 0;

            foreach (string w in wordDict)
            {
                if (w.Length > maxWordLengthInDic) maxWordLengthInDic = w.Length;
            }

            int start = 0;
            int end = word.Length - 1;

            // Find the first match
            do
            {
                StringBuilder sb = new StringBuilder();
                Queue<MatchedWord> queue = new Queue<MatchedWord>(); // collect the words that could lead to the split.
                for (int i = start; i <= end && i < start + maxWordLengthInDic; i++)
                {
                    sb.Append(word[i]);
                    if (wordDict.Contains(sb.ToString()))
                    {
                        if (i <= end)
                        {
                            if (i == end) {
                                // we can short circuit here as we'd be here only if the word prior to this was found. 
                                return true;
                            }

                            // Collect the word in the queue only if we can satisfy the split from the end of this word
                            // or we don't know as yet if we can satisfy the split.
                            if (!mem.ContainsKey(i + 1) || (mem.ContainsKey(i+1) && mem[i+1]))
                            {
                                queue.Enqueue(new MatchedWord(sb.ToString(), start, i));
                            }
                        }
                    }
                }

                if (queue.Count > 0)
                {
                    foreach (MatchedWord item in queue)
                    {
                        stack.Push(item);
                        if (item.end < end && mem.ContainsKey(item.end + 1) && mem[item.end + 1]) {
                            mem[item.start] = true;
                        }
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
    }
}