using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_FB_Easy
{
    /*
        Given a string, find the first non-repeating character in it and return it's index. If it doesn't exist, return -1.

        Examples:
        s = "leetcode"
        return 0.

        s = "loveleetcode",
        return 2.
     * */
    class FirstUniqueCharInString
    {
        public int FirstUniqChar(string s)
        {
            if (string.IsNullOrEmpty(s)) return -1;

            // First pass:
            // We will use a char count map to hold the first occurring position (index + 1) of the char
            // If the char is a duplicate, we will reset the count to -1
            // Second pass:
            // Find the minimum index among all entries. Algorithm is O(n) where n is length of the string.
            int[] charMap = new int[58];

            for (int i = 0; i < s.Length; i++)
            {
                // ASCII of z = 122, a = 97. A = 65, Z = 90
                int charAscii = (int)s[i];

                if (charMap[charAscii - 65] == 0)
                    charMap[charAscii - 65] = i + 1; // First occurrence
                else
                    charMap[charAscii - 65] = -1;  // duplicate occurrence
            }

            // Find min
            int minIndex = int.MaxValue;
            for (int i = 0; i < charMap.Length; i++)
            {
                if (charMap[i] > 0 && (charMap[i] - 1) < minIndex) minIndex = charMap[i] - 1;
            }

            if (minIndex != int.MaxValue) return minIndex;
            return -1;
        }
    }
}
