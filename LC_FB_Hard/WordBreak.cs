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
        public class Node
        {
            public int StartIndex;
            public int CurrentLength;
            public bool IsIterationRequired;

            public Node(int startIndex, int length, bool isIterationRequired = true)
            {
                this.StartIndex = startIndex;
                this.CurrentLength = length;
                this.IsIterationRequired = isIterationRequired;
            }
        }

        private Dictionary<int, List<string>> lookup = new Dictionary<int, List<string>>();
        private Stack<Node> stack = new Stack<Node>();

        public IList<string> Execute(string s, IList<string> wordDict)
        {
            if (s == null || s.Length == 0) return new List<string>();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (string word in wordDict) dict[word] = word;
            this.stack.Push(new Node(0, 1));
            this.ExecuteWithMemoAndStack1(s, dict);
            if (this.lookup.ContainsKey(0) && this.lookup[0] != null) return this.lookup[0];
            else return new List<string>();
        }

        private void ExecuteWithMemoAndStack1(string s, Dictionary<string, string> dict)
        {
            while (this.stack.Count != 0)
            {
                Node currNode = stack.Peek();
                int startIndex = currNode.StartIndex;
                int currentLength = currNode.CurrentLength;

                if (startIndex == s.Length){
                    this.stack.Pop(); //done processing
                    this.lookup[startIndex] = new List<string>();
                    continue;
                }

                for (int length = currentLength; length + startIndex <= s.Length; length++){
                    string strToSearch = s.Substring(startIndex, length);
                    this.stack.Peek().CurrentLength = length;

                    if (dict.ContainsKey(strToSearch)){
                        if (!this.lookup.ContainsKey(startIndex + length)) {
                            this.stack.Push(new Node(startIndex + length, 1)); // next node
                            break;
                        }
                        else this.AddToLookup(strToSearch, startIndex, startIndex + length);
                    }
                }

                if (this.stack.Peek() == currNode && currNode.StartIndex + currNode.CurrentLength >= s.Length){
                    this.stack.Pop();
                    if(!this.lookup.ContainsKey(startIndex)) this.lookup[startIndex] = null;
                }
            }
        }

        private void AddToLookup(string strToAdd, int currentIndex, int indexToAdd)
        {
            if (this.lookup.ContainsKey(indexToAdd) && this.lookup[indexToAdd] != null)
            {
                if (this.lookup[indexToAdd].Count == 0){
                    if (this.lookup.ContainsKey(currentIndex)) {
                        if (this.lookup[currentIndex] == null) this.lookup[currentIndex] = new List<string>() {strToAdd};
                        else this.lookup[currentIndex].Add(strToAdd);
                    }
                    else this.lookup[currentIndex] = new List<string>() {strToAdd};
                }
                else{
                    List<string> list = new List<string>();
                    foreach (string str in this.lookup[indexToAdd]) list.Add(strToAdd + " " + str);
                    if (this.lookup.ContainsKey(currentIndex))
                    {
                        if (this.lookup[currentIndex] == null) this.lookup[currentIndex] = list;
                        else this.lookup[currentIndex].AddRange(list);
                    }
                    else this.lookup[currentIndex] = list;
                }
            }
            else if (!this.lookup.ContainsKey(currentIndex)) this.lookup[currentIndex] = null;
        }
    }
}