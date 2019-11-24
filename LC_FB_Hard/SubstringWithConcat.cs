/*
You are given a string, s, and a list of words, words, that are all of the same length. 
Find all starting indices of substring(s) in s that is a concatenation of each word 
in words exactly once and without any intervening characters.

 

Example 1:
Input:
  s = "barfoothefoobarman",
  words = ["foo","bar"]
Output: [0,9]
Explanation: Substrings starting at index 0 and 9 are "barfoo" and "foobar" respectively.
The output order does not matter, returning [9,0] is fine too.

Example 2:
Input:
  s = "wordgoodgoodgoodbestword",
  words = ["word","good","best","word"]
Output: []

foo bar foo

foofoobar
foobarfoo
barfoofoo

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class SubstringWithConcat
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            IList<int> result = new List<int>();
            if (s == null || s.Length == 0 || words == null || words.Length == 0) return result;

            // create a dictionary words and its count from the list of words given.
            // Its given that words are all of the same length. This eases the substring finding part.
            // We keep running track of the words seen so far.
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach(string word in words) dic[word] = dic.GetValueOrDefault(word, 0) + 1;

            int wordLength = words[0].Length;
            for (int i = 0; i < s.Length - (words.Length * wordLength) + 1; i++) {
                Dictionary<string, int> seen = new Dictionary<string, int>();
                int matchedWords = 0;
                while (matchedWords < words.Length) {
                    string sub = s.Substring(i + matchedWords * wordLength, wordLength);
                    if (!dic.ContainsKey(sub)) break;
                    if (seen.ContainsKey(sub) && seen[sub] >= dic[sub]) break;
                    seen[sub] = seen.GetValueOrDefault(sub, 0) + 1;
                    matchedWords++;
                }

                if (matchedWords == words.Length) result.Add(i);
            }

            return result;
        }
    }
}