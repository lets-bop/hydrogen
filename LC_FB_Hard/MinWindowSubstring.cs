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
        // Find s in t
        public static string Execute(string t, string s) {
            if (s == null || t == null) return string.Empty;

            // Create a dictionary of chars in s and a dictionary to maintain the chars in the window
            Dictionary<char, int> s_count = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++) s_count[s[i]] = s_count.GetValueOrDefault(s[i], 0) + 1;
            Dictionary<char, int> win_count = new Dictionary<char, int>();

            int start = 0, end = 0, curr_count = 0, to_match_count = s_count.Count;
            StringBuilder win = new StringBuilder();
            string result = null;

            for (end = 0; end < t.Length && start <= end; end++) {
                char currChar = t[end];
                int countInS = s_count.GetValueOrDefault(currChar, 0);
                win.Append(currChar);
                if (countInS == 0) continue; // char not in s. no match possible

                int countInWin = win_count.GetValueOrDefault(currChar, 0);
                if (countInWin + 1 == countInS) curr_count++; // found a new match
                win_count[currChar] = countInWin + 1;

                while (curr_count >= to_match_count && win.Length > 0) {
                    // keep reducing the window size
                    if (result == null || win.Length < result.Length) result = win.ToString();
                    win.Remove(0, 1);
                    if (win_count.ContainsKey(t[start])) {
                        win_count[t[start]]--;
                        if (win_count[t[start]] < s_count[t[start]]) curr_count--;
                    }
                    start++;
                }
            }

            while (curr_count >= to_match_count && win.Length > 0) {
                // keep reducing the window size
                if (result == null || win.Length < result.Length) result = win.ToString();
                win.Remove(0, 1);
                if (win_count.ContainsKey(t[start])) {
                    win_count[t[start]]--;
                    if (win_count[t[start]] < s_count[t[start]]) curr_count--;
                }
                start++;
            }

            return result;
        }

        public static string ExecuteOld(string s, string t)
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
