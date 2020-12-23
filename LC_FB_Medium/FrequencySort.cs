using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LC_FB_Medium
{
    /*
        Given a string, sort it in decreasing order based on the frequency of characters.

        Example 1:
        Input: "tree"
        Output: "eert"

        Explanation:
        'e' appears twice while 'r' and 't' both appear once.
        So 'e' must appear before both 'r' and 't'. Therefore "eetr" is also a valid answer.

        Example 2:
        Input: "cccaaa"
        Output:"cccaaa"

        Explanation:
        Both 'c' and 'a' appear three times, so "aaaccc" is also a valid answer.
        Note that "cacaca" is incorrect, as the same characters must be together.
        Example 3:

        Input: "Aabb"
        Output: "bbAa"

        Explanation:
        "bbaA" is also a valid answer, but "Aabb" is incorrect.
        Note that 'A' and 'a' are treated as two different characters.
    */

    class FrequencySort
    {
        public string FreqSort(string s) {
            string result = null;
            if (s == null) return result;

            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in s) charCount[c] = charCount.GetValueOrDefault(c, 0) + 1;

            // You could use bucket sort to get O(n) time and space, n is size of string.
            // Or sort the dictionary like below which is O(n lg n)
            StringBuilder sb = new StringBuilder();
            foreach (var kv in charCount.OrderByDescending(key => key.Value)) {
                for (int i = 0; i < kv.Value; i++) sb.Append(kv.Key);
            }

            return sb.ToString();
        }
    }
}