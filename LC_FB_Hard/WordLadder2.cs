/*
Given two words (beginWord and endWord), and a dictionary's word list, 
find all shortest transformation sequence(s) from beginWord to endWord, such that:

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
    public class WordLadder2
    {    
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
                if (beginWord == null || endWord == null || beginWord.Length != endWord.Length) return new List<IList<string>>();
                
                // Create a Hashset of the wordList for faster lookup & remove beginWord from it
                HashSet<string> set = new HashSet<string>();
                foreach (string word in wordList) set.Add(word);
                set.Remove(beginWord);

                // create a queue for BFS and enqueue beginWord to it
                Queue<(string, int, IList<string>)> queue = new Queue<(string, int, IList<string>)>();
                List<string> list = new List<string>() {beginWord};
                var node = (beginWord, 0, list);
                queue.Enqueue(node);

                IList<IList<string>> finalList = new List<IList<string>>();
                int depthToProcess = 0;

                while (queue.Count > 0 && finalList.Count == 0) {
                    finalList = this.Find(new HashSet<string>() {endWord}, set, queue, depthToProcess);
                    depthToProcess++;
                }

                return finalList;
        }

        private IList<IList<string>> Find(
            HashSet<string> endWord, 
            HashSet<string> wordList, 
            Queue<(string, int, IList<string>)> queue, // word, depth, ladder_of_words_leading_to_word
            int depthToProcess)
        {
            IList<IList<string>> finalList = new List<IList<string>>();
            HashSet<string> wordsToRemoveFromWordList = new HashSet<string>();

            while(queue.Count > 0 && queue.Peek().Item2 <= depthToProcess)
            {
                var node = queue.Dequeue();

                string word = node.Item1;
                char[] wordArray = word.ToCharArray();
                for (int i = 0; i < wordArray.Length; i++)
                {
                    char currentChar = wordArray[i];

                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        wordArray[i] = c;
                        string s = new string(wordArray);
                        if (wordList.Contains(s)) {
                            IList<string> list = new List<string>(node.Item3);
                            list.Add(s);
                            if (endWord.Contains(s)) finalList.Add(list); // we found the end word
                            else {
                                wordsToRemoveFromWordList.Add(s);
                                queue.Enqueue((s, depthToProcess + 1, list));
                            }
                        }
                    }

                    wordArray[i] = currentChar;
                }
            }

            foreach (string w in wordsToRemoveFromWordList) wordList.Remove(w);

            return finalList;
        }
    }
}