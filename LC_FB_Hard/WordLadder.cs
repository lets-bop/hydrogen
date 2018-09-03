/*
Given two words (beginWord and endWord), and a dictionary's word list, find all shortest transformation sequence(s) from beginWord to endWord, such that:

Only one letter can be changed at a time
Each transformed word must exist in the word list. Note that beginWord is not a transformed word.
Note:

Return an empty list if there is no such transformation sequence.
All words have the same length.
All words contain only lowercase alphabetic characters.
You may assume no duplicates in the word list.
You may assume beginWord and endWord are non-empty and are not the same.

Example 1:

Input:
beginWord = "hit",
endWord = "cog",
wordList = ["hot","dot","dog","lot","log","cog"]

Output:
[
  ["hit","hot","dot","dog","cog"],
  ["hit","hot","lot","log","cog"]
]
Example 2:

Input:
beginWord = "hit"
endWord = "cog"
wordList = ["hot","dot","dog","lot","log"]

Output: []

Explanation: The endWord "cog" is not in wordList, therefore no possible transformation.

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class WordLadder
    {
        int minDepthSoFar = int.MaxValue;

        public class Node
        {
            public string Word;
            public int Depth;
            public List<string> Ladder;

            public Node(string word, List<string> ladderSoFar, int depth)
            {
                this.Word = word;
                this.Ladder = new List<string>(ladderSoFar);
                this.Depth = depth;
                this.Ladder.Add(word);
            }
        }
    
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
                if (beginWord == null || endWord == null || beginWord.Length != endWord.Length) return new List<IList<string>>();
                Queue<Node> queue = new Queue<Node>();
                Node node = new Node(beginWord, new List<string>(), 0);
                queue.Enqueue(node);
                wordList.Remove(beginWord);
                HashSet<string> set = new HashSet<string>();
                foreach (string word in wordList) set.Add(word);
                return Find(endWord, set, queue);        
        }
    
        private IList<IList<string>> Find(string endWord, HashSet<string> wordList, Queue<Node> queue)
        {
            IList<IList<string>> finalList = new List<IList<string>>();
            int prevDepth = 0;
            HashSet<string> wordsToRemoveFromWordList = new HashSet<string>();

            while(queue.Count > 0)
            {
                Node node = queue.Dequeue();
                if (node.Depth != prevDepth)
                {
                    prevDepth = node.Depth;
                    foreach (string s in wordsToRemoveFromWordList) wordList.Remove(s);
                    wordsToRemoveFromWordList.Clear();
                }

                string word = node.Word;
                if (word == endWord)
                {
                    if (node.Depth <= this.minDepthSoFar)
                    {
                        finalList.Add(node.Ladder);
                        this.minDepthSoFar = node.Depth;
                    }
                    
                    continue;
                }

                char[] wordArray = word.ToCharArray();
                for (int i = 0; i < wordArray.Length; i++)
                {
                    char currentChar = wordArray[i];

                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        wordArray[i] = c;
                        string s = new string(wordArray);
                        if (wordList.Contains(s))
                        {
                            if (node.Depth > this.minDepthSoFar) continue;
                            wordsToRemoveFromWordList.Add(s);
                            Node newNode = new Node(s, node.Ladder, node.Depth + 1);
                            queue.Enqueue(newNode);
                        }
                    }

                    wordArray[i] = currentChar;
                }
            }

            return finalList;
        }           
    }
}