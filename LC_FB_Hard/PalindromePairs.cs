using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    /*
        Given a list of unique words, find all pairs of distinct indices (i, j) in the given list, 
        so that the concatenation of the two words, i.e. words[i] + words[j] is a palindrome.

        Example 1:
        Input: ["abcd","dcba","lls","s","sssll"]
        Output: [[0,1],[1,0],[3,2],[2,4]] 
        Explanation: The palindromes are ["dcbaabcd","abcddcba","slls","llssssll"]
        Example 2:
        Input: ["bat","tab","cat"]
        Output: [[0,1],[1,0]] 
        Explanation: The palindromes are ["battab","tabbat"]
    */
    class PalindromePairs
    {
        public IList<IList<int>> Find(string[] words) {
            IList<IList<int>> result = new List<IList<int>>();
            Dictionary<string, int> wordToIndexMap = new Dictionary<string, int>();

            // assuming that words don't have duplicates
            for (int i = 0; i < words.Length; i++) wordToIndexMap[words[i]] = i;

            foreach (string word in words) {
                for (int k = 0; k <= word.Length; k++) {
                    string left = word.Substring(0, k);
                    string right = word.Substring(k);

                    if (this.IsPalindrome(left)) {
                        // example: if the word is rared, left = rar, right = ed.
                        // left is a palindrome. we look for reverse right in the dictionary. i.e. de
                        // then de + rared is a palindrome.
                        char[] arr = right.ToCharArray();
                        Array.Reverse(arr);
                        string look = new string(arr);
                        if (wordToIndexMap.ContainsKey(look) && wordToIndexMap[look] != wordToIndexMap[word]) {
                            result.Add(new List<int>{wordToIndexMap[look], wordToIndexMap[word]});
                        }
                    }

                    if (right.Length !=0 && this.IsPalindrome(right)) {
                        // example: if the word is basis, left = ba, right = sis.
                        // right is a palindrome. we look for reverse left in the dictionary. i.e. ab
                        // then basic + ab is a palindrome.
                        char[] arr = left.ToCharArray();
                        Array.Reverse(arr);
                        string look = new string(arr);
                        if (wordToIndexMap.ContainsKey(look) && wordToIndexMap[look] != wordToIndexMap[word]) {
                            result.Add(new List<int>{wordToIndexMap[word], wordToIndexMap[look]});
                        }
                    }
                }
            }

            return result;
        }

        private bool IsPalindrome(string word) {
            if (word != null && word.Length > 1) {
                int i = 0;
                int j = word.Length - 1;
                while (i < j) {
                    if (word[i++] != word[j--]) return false;
                }
            }

            return true;
        }
    }
}