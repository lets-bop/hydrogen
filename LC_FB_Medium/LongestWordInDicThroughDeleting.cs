using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LC_FB_Medium
{
    /*
        Given a string and a string dictionary, find the longest string in the dictionary 
        that can be formed by deleting some characters of the given string. 
        If there are more than one possible results, return the longest word with the 
        smallest lexicographical order. If there is no possible result, return the empty string.

        Example 1:
        Input:
        s = "abpcplea", d = ["ale","apple","monkey","plea"]
        Output: 
        "apple"

        Example 2:
        Input:
        s = "abpcplea", d = ["a","b","c"]
        Output: 
        "a"
     */
    class LongestWordInDicThroughDeleting
    {
        public string FindLongestWord(string s, IList<string> d) {
            string longestWord = string.Empty;
            int wordInDicIter;

            // The key to reducing the time complexity 
            // is to sort the list by length descending order and then lexicographically.
            foreach (string wordInDic in d.OrderByDescending(x => x.Length).ThenBy(x => x)) {
                if (wordInDic.Length == 0) continue;
                wordInDicIter = 0;

                for (int i = 0; i < s.Length; i++) {
                    if (s[i] == wordInDic[wordInDicIter]) wordInDicIter++;
                    if (wordInDicIter >= wordInDic.Length) {
                        return wordInDic;
                    }
                }
            }

            return longestWord;
        }
    }
}