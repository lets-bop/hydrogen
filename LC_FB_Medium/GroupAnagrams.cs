using System;
using System.Collections.Generic;

/*
Given an array of strings, group anagrams together.
Example: 
Input: ["eat", "tea", "tan", "ate", "nat", "bat"],
Output:
[
  ["ate","eat","tea"],
  ["nat","tan"],
  ["bat"]
]
Note:
    All inputs will be in lowercase.
    The order of your output does not matter.
*/
namespace LC_FB_Medium
{
    class GroupAnagrams
    {
        public IList<IList<string>> Group(string[] strs) {
            IList<IList<string>> ret = new List<IList<string>>();
            if (strs == null || strs.Length == 0) return ret;
            
            Dictionary<string, List<string>> anagrams = new Dictionary<string, List<string>>();
            foreach (string s in strs) {
                char[] arr = s.ToCharArray();
                Array.Sort(arr);
                string str = new string(arr);
                if (anagrams.ContainsKey(str)) anagrams[str].Add(s);
                else anagrams[str] = new List<string>() {s};
            }
            
            foreach (List<string> list in anagrams.Values) ret.Add(list);
            return ret;
        }
    }
}