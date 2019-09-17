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
            int start = 0;
            int end = 0;
            int minWindow = int.MaxValue;
            Dictionary<char, int> readMap = new Dictionary<char, int>();

            while(end < s.Length || start < s.Length)
            {
                if (count > 0 && end < s.Length)
                {
                    // Increase the window size as long as the count > 0. i.e. you increment the end
                    if(dic.ContainsKey(s[end]))
                    {
                        if (start == -1) start = end;
                        if (readMap.ContainsKey(s[end])) readMap[s[end]]++;
                        else readMap[s[end]] = 1;

                        // As long as the character that we are reading hasn't exceeded its expected count, we decrement the count of characters left to match.
                        if (readMap[s[end]] <= dic[s[end]]) count--;
                    }

                    end++;
                }
                else if (start < s.Length)
                {
                    // Otherwise, you decrease the window size by increasing start
                    if (dic.ContainsKey(s[start]))
                    {
                        // While reducing the window size we need to ensure that the character being removed doesn't affect the expected counts in t.
                        readMap[s[start]]--;
                        if (readMap[s[start]] < dic[s[start]]) count++;
                    }

                    start++;
                }

                if (count == 0)
                {
                    int windowSize = end - start;
                    if(windowSize < minWindow)
                    {
                        minWindow = windowSize;
                        output = s.Substring(start, windowSize);
                    }
                }                
            }

            return output;
        }
    }
}
