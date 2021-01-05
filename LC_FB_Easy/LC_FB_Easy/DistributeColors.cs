using System;
using System.Collections.Generic;
using System.Linq;

namespace LC_FB_Easy
{
    /*
        If you are given colors and count of buckets, distribute the colors as evenly as possible across the buckets.
        For example, RRRGGB & 3 buckets, should look like RG, RG, RB
    */
    class DistributeColors
    {
        public List<string> Distribute(string s, int buckets) {
            string[] result = new string[buckets];
            if (string.IsNullOrEmpty(s)) return new List<string> (result);
            char[] arr = s.ToCharArray();
            Dictionary<char, int> colorCount = new Dictionary<char, int>();

            foreach (char ch in arr) {
                colorCount[ch] = colorCount.GetValueOrDefault(ch) + 1;
            }

            int k = 0;
            foreach (char ch in colorCount.Keys.ToList()) {
                while (colorCount[ch] != 0) {
                    result[k++] += ch;
                    colorCount[ch]--;
                    if (k == buckets) k = 0;
                    if (colorCount[ch] == 0) break;
                }
            }

            return new List<string> (result);
        }
    }
}