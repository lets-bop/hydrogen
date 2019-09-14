using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
        A string S of lowercase letters is given. We want to partition this string into as many parts as possible 
        so that each letter appears in at most one part, and return a list of integers representing the size of these parts.

        Example 1:
        Input: S = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation: The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits S into less parts.

        Note:
        S will have length in range [1, 500].
        S will consist of lowercase letters ('a' to 'z') only.
    */
    class PartitionLabels
    {
        public IList<int> Partition(string S) {
            IList<int> result = new List<int>();
            if (S == null || S.Length == 0) {
                result.Add(0);
                return result;
            }

            Dictionary<char, int> charToLastSeenIndex = new Dictionary<char, int>(); // holds the index char was last seen

            int i;
            for(i = 0; i < S.Length; i++) charToLastSeenIndex[S[i]] = i;

            int max = -1;
            i = 0;

            for (int j = 0; j < S.Length; j++) {
                max = Math.Max(max, charToLastSeenIndex[S[j]]);
                if (max == j) {
                    result.Add(j - i + 1);
                    i = j + 1;
                }
            }

            return result;
        }
    }
}