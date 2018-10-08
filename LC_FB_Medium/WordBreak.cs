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
        public bool Check(string word, IList<string> wordDict){
            HashSet<string> dict = new HashSet<string>(wordDict);
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);

            while(queue.Count > 0){
                int start = queue.Dequeue();
                if (start == word.Length) return true;
                StringBuilder sb = new StringBuilder();
                sb.Append(word[start]);
                if (dict.Contains(sb.ToString())) queue.Enqueue(start + 1);
                for (int end = start + 1; end - start < 10 && end < word.Length; end++){
                    sb.Append(word[end]);
                    if (dict.Contains(sb.ToString())) queue.Enqueue(end + 1);
                }
            }

            return false;
        }
    }
}