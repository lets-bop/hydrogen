using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given two words (beginWord and endWord), and a dictionary's word list, 
        find the length of shortest transformation sequence from beginWord to endWord, such that:
        Only one letter can be changed at a time.
        Each transformed word must exist in the word list. Note that beginWord is not a transformed word.

        Note: 
            Return 0 if there is no such transformation sequence.
            All words have the same length.
            All words contain only lowercase alphabetic characters.
            You may assume no duplicates in the word list.
            You may assume beginWord and endWord are non-empty and are not the same.
        Example 1:
        Input:
            beginWord = "hit",
            endWord = "cog",
            wordList = ["hot","dot","dog","lot","log","cog"]

        Output: 5

        Explanation: As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
        return its length 5.

        Example 2:
        Input:
            beginWord = "hit"
            endWord = "cog"
            wordList = ["hot","dot","dog","lot","log"]

        Output: 0
        Explanation: The endWord "cog" is not in wordList, therefore no possible transformation.
    */
    class WordLadder
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
            
            // validate input
            if (beginWord == null && endWord == null) return 0;
            if (beginWord.Length == 0 && endWord.Length == 0) return 1;
            if (beginWord == null || endWord == null || beginWord.Length != endWord.Length) return 0;
            if (wordList == null || wordList.Count == 0) return 0;
            
            // convert word list to hashset for faster lookup
            HashSet<string> words = new HashSet<string>();
            foreach (string word in wordList) words.Add(word);
            
            // return 0 if either beginWord or endWord is not present 
            if (!words.Contains(endWord)) return 0;
            if (beginWord == endWord) return 1;
            if (words.Contains(beginWord)) words.Remove(beginWord);
            
            // perform BFS
            Queue<(char[], int)> queue = new Queue<(char[], int)>();
            queue.Enqueue((beginWord.ToCharArray(), 1));
            return this.DoBFS(queue, words, endWord);
        }
        
        public int DoBFS(Queue<(char[], int)> queue, HashSet<string> words, string endWord) {
            while (queue.Count > 0) {
                (char[], int) tup = queue.Dequeue();
                char[] w_Arr = tup.Item1;
                int level = tup.Item2;
                
                for (int i = 0; i < w_Arr.Length; i++) {
                    char actualChar = w_Arr[i];
                    for (char c = 'a'; c <= 'z'; c++) {
                        w_Arr[i] = c;
                        string newW = new string(w_Arr);
                        if (words.Contains(newW)) {
                            if (newW == endWord) return level + 1;
                            queue.Enqueue((newW.ToCharArray(), level + 1));
                            words.Remove(newW);
                        }
                    }
                    
                    w_Arr[i] = actualChar;
                }
            }

            return 0;
        }
    }
}