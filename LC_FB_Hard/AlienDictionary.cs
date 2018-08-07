/*
There is a new alien language which uses the latin alphabet. However, the order among letters are unknown to you. You receive a list of non-empty words from the dictionary, where words are sorted lexicographically by the rules of this new language. Derive the order of letters in this language.

Example 1:

Input:
[
  "wrt",
  "wrf",
  "er",
  "ett",
  "rftt"
]

Output: "wertf"
Example 2:

Input:
[
  "z",
  "x"
]

Output: "zx"
Example 3:

Input:
[
  "z",
  "x",
  "z"
] 

Output: "" 

Explanation: The order is invalid, so return "".
Note:

You may assume all letters are in lowercase.
You may assume that if a is a prefix of b, then a must appear before b in the given dictionary.
If the order is invalid, return an empty string.
There may be multiple valid order of letters, return any one of them is fine.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class AlienDictionary
    {
        public string AlienOrder(string[] words)
        {
            StringBuilder sb = new StringBuilder();
            if (words == null || words.Length == 0) return sb.ToString();
            Dictionary<char, int> orderToIndex = new Dictionary<char, int>();
            char prevChar = words[0][0];
            sb.Append(prevChar);

            for (int i = 0; i < words.Length; i++)
            {
                char currentChar = words[i][0];
                
                if (currentChar != prevChar)
                {
                    sb.Append(currentChar);
                    prevChar = currentChar;
                }

                if (orderToIndex.ContainsKey(currentChar))
                {
                    if (orderToIndex[currentChar] + 1 < i) return string.Empty;
                }

                orderToIndex[currentChar] = i;
            }

            return sb.ToString();
        }     
    }
}