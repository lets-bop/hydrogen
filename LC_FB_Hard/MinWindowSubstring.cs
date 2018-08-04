/*
Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).

Example:

Input: S = "ADOBECODEBANC", T = "ABC"
Output: "BANC"
Note:

If there is no such window in S that covers all characters in T, return the empty string "".
If there is such window, you are guaranteed that there will always be only one unique minimum window in S.

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class MinWindowSubstring
    {
        public static string Execute(string s, string t)
        {
            string output = string.Empty;
            if (s == null || t == null) return output;
            
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for(int j = 0; j < t.Length; j++)
            {
                if (dic.ContainsKey(t[j])) dic[t[j]] += 1;
                else dic[t[j]] = 1;
            }

            int count = t.Length;
            int windowStart = 0;
            int windowEnd = 0;
            int minWindow = int.MaxValue;
            Dictionary<char, int> readMap = new Dictionary<char, int>();

            while(windowEnd < s.Length || windowStart < s.Length)
            {
                if (count > 0 && windowEnd < s.Length)
                {
                    // Increase the window size as long as the count > 0. i.e. you increment the windowEnd
                    if(dic.ContainsKey(s[windowEnd]))
                    {
                        if (windowStart == -1) windowStart = windowEnd;
                        if (readMap.ContainsKey(s[windowEnd])) readMap[s[windowEnd]]++;
                        else readMap[s[windowEnd]] = 1;

                        // As long as the character that we are reading hasn't exceeded its expected count, we decrement the count of characters left to match.
                        if (readMap[s[windowEnd]] <= dic[s[windowEnd]]) count--;
                    }

                    windowEnd++;
                }
                else if (windowStart < s.Length)
                {
                    // Otherwise, you decrease the window size by increasing windowStart
                    if (dic.ContainsKey(s[windowStart]))
                    {
                        // While reducing the window size we need to ensure that the character being removed doesn't affect the expected counts in t.
                        readMap[s[windowStart]]--;
                        if (readMap[s[windowStart]] < dic[s[windowStart]]) count++;
                    }

                    windowStart++;
                }

                if (count == 0)
                {
                    int windowSize = windowEnd - windowStart;
                    if(windowSize < minWindow)
                    {
                        minWindow = windowSize;
                        output = s.Substring(windowStart, windowSize);
                    }
                }                
            }

            return output;
        }
    }
}
