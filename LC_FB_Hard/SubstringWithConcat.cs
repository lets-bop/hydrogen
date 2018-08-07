/*
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

            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach(string word in words)
            {
                if (dic.ContainsKey(word)) dic[word]++;
                else dic[word] = 1;
            }

            Dictionary<string, int> windowCount = new Dictionary<string, int>();
            int wordCount = 0;
            int windowStart = 0;
            int windowIter = 0;
            int wordLength = words[0].Length;
            for (  ; windowIter <= s.Length - wordLength ; )
            {
                string sub = s.Substring(windowIter, wordLength);
                if (dic.ContainsKey(sub))
                {
                    if (windowCount.ContainsKey(sub)) windowCount[sub]++;
                    else windowCount[sub] = 1;

                    wordCount++;

                    if (windowCount[sub] <= dic[sub])
                    {
                        if (wordCount == words.Length)
                        {
                            result.Add(windowStart);
                            windowStart += 1;
                            windowIter = windowStart;
                            windowCount.Clear();
                            wordCount = 0;
                            continue;                        
                        } 
                    }
                    else 
                    {
                        windowCount.Clear();
                        wordCount = 0;
                        windowStart += 1;
                        windowIter = windowStart;
                        continue;                      
                    }

                    windowIter = windowIter + wordLength;
                }
                else
                {
                    // reset all counters
                    windowCount.Clear();
                    wordCount = 0;
                    windowStart += 1;
                    windowIter = windowStart;
                }
            }         

            foreach (int r in result)
            {
                Console.Write(r + "\t");
            }
            Console.WriteLine();

            return result;

        }
    }
}