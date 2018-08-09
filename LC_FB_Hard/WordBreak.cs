/*
Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, add spaces in s to construct a sentence where each word is a valid dictionary word. Return all such possible sentences.
Note:
The same word in the dictionary may be reused multiple times in the segmentation.
You may assume the dictionary does not contain duplicate words.
Example 1:
Input:
s = "catsanddog"
wordDict = ["cat", "cats", "and", "sand", "dog"]
Output:
[
  "cats and dog",
  "cat sand dog"
]
Example 2:
Input:
s = "pineapplepenapple"
wordDict = ["apple", "pen", "applepen", "pine", "pineapple"]
Output:
[
  "pine apple pen apple",
  "pineapple pen apple",
  "pine applepen apple"
]
Explanation: Note that you are allowed to reuse a dictionary word.
Example 3:
Input:
s = "catsandog"
wordDict = ["cats", "dog", "sand", "and", "cat"]
Output:
[]
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class WordBreak
    {
        private Dictionary<int, List<string>> lookup = new Dictionary<int, List<string>>();

        public IList<string> Execute(string s, IList<string> wordDict)
        {
            if (s == null || s.Length == 0) return new List<string>();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (string word in wordDict) dict[word] = word;
            ExecuteWithMemo(s, dict, 0);
            if (this.lookup.ContainsKey(0)) return this.lookup[0];
            else return new List<string>();
        }

        private void ExecuteWithMemo(string s, Dictionary<string, string> dict, int startIndex)
        {
            if (startIndex == s.Length){
                lookup[startIndex] = new List<string>();
                return;
            }

            if (this.lookup.ContainsKey(startIndex)) return;

            int i = startIndex;
            for (int length = 1; length + i <= s.Length; length++)
            {
                string strToSearch = s.Substring(i, length);
                if (dict.ContainsKey(strToSearch))
                {
                    if (!this.lookup.ContainsKey(i + length))
                        ExecuteWithMemo(s, dict, i + length);
                                              
                    if (this.lookup.ContainsKey(i + length))
                    {
                        if (this.lookup[i + length].Count == 0)
                        {
                            if (lookup.ContainsKey(i))
                                lookup[i].Add(strToSearch);
                            else lookup[i] =  new List<string>() {strToSearch};
                        }
                        else{
                            List<string> newList = new List<string>();
                            foreach (string str in this.lookup[i + length]) newList.Add(strToSearch + " " + str);
                            if (lookup.ContainsKey(i))
                                lookup[i].AddRange(newList);
                            else lookup[i] = newList;                                
                        }
                    }
                }
            }            
        }
    }
}