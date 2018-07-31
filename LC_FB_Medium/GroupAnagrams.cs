using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    class GroupAnagrams
    {
        public static void Process(string[] words)
        {
            Dictionary<string, HashSet<string>> map = new Dictionary<string, HashSet<string>>();
            foreach (string word in words)
            {
                char[] chWord = word.ToCharArray();
                Array.Sort(chWord);
                string sortedWord = new string(chWord);
                if (map.ContainsKey(sortedWord))
                    map[sortedWord].Add(word);
                else 
                {
                    HashSet<string> set = new HashSet<string>();
                    set.Add(word);
                    map.Add(sortedWord, set);
                }
            }

            foreach (KeyValuePair<string, HashSet<string>> kv in map)
            {
                Console.Write("Key:{0}\t\t Values:", kv.Key);
                foreach (string anagram in kv.Value)
                {
                    Console.Write("{0}\t", anagram);
                }
                Console.WriteLine();
            }
        }
    }
}