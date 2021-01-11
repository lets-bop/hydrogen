using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    class LongestCommonPrefix
    {
        public string Find(string[] strs) {
            if (strs == null || strs.Length == 0) return string.Empty;
            
                string smallest = strs[0];
                for (int i = 0; i < strs.Length; i++) {
                    if (strs[i].Length < smallest.Length) smallest = strs[i];
                }
                
                int low = 0, high = smallest.Length - 1, mid = 0;
                bool noMatch = false;
                while (low <= high) {
                    noMatch = false;
                    mid = low + (high - low) / 2;
                    string check = smallest.Substring(0, mid + 1);
                    foreach (string s in strs) {
                        if (!s.StartsWith(check)) {
                            high = mid - 1;
                            noMatch = true;
                            break;
                        }
                    }
                    if (!noMatch) low = mid + 1;
                }
            
            return smallest.Substring(0, low);
        }
    }
}