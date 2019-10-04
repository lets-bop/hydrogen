using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given an array A of integers, return the length of the longest arithmetic subsequence in A.
        Recall that a subsequence of A is a list A[i_1], A[i_2], ..., A[i_k] with 0 <= i_1 < i_2 < ... < i_k <= A.length - 1, 
        and that a sequence B is arithmetic if B[i+1] - B[i] are all the same value (for 0 <= i < B.length - 1).

        Example 1:
        Input: [3,6,9,12]
        Output: 4
        Explanation: The whole array is an arithmetic sequence with steps of length = 3.

        Example 2:
        Input: [9,4,7,2,10]
        Output: 3
        Explanation: The longest arithmetic subsequence is [4,7,10].

        Example 3:
        Input: [20,1,15,3,10,5,8]
        Output: 4
        Explanation: The longest arithmetic subsequence is [20,15,10,5].

        Note:
        2 <= A.length <= 2000
        0 <= A[i] <= 10000
    */
    class LongestArithmeticSequence
    {
        public int LongestArithmeticSequenceLen(int[] A) {
            if (A == null) return 0;
            if (A.Length <= 2) return A.Length;

            // Idea: At every index i, for every other index j < i, 
            // calculate the difference d = A[i] - A[j] and see if 
            // index at j recorded a subsequence with that difference.
            // If so, we add 1 to it. O(n^2) time.
            Dictionary<int, int>[] differenceToLengthMapAtIndex = new Dictionary<int, int>[A.Length];
            for (int i = 0; i < differenceToLengthMapAtIndex.Length; i ++) 
                differenceToLengthMapAtIndex[i] = new Dictionary<int,int>();

            int j, len, diff, max = 0;
            for (int i = 1; i < A.Length; i++) {
                j = 0;
                while (j < i) {
                    len = 2; // min length for every pair is 2
                    diff = A[i] - A[j];

                    // if the dic at index j has the difference, we just add 1 to it. Else we take 0
                    len = Math.Max(len, differenceToLengthMapAtIndex[j].GetValueOrDefault(diff, -1) + 1);
                    
                    if (!differenceToLengthMapAtIndex[i].ContainsKey(diff)) differenceToLengthMapAtIndex[i][diff] = len;
                    else differenceToLengthMapAtIndex[i][diff] = Math.Max(differenceToLengthMapAtIndex[i][diff], len);

                    if (max < len) max = len;
                    j++;
                }
            }

            return max;
        }
    }
}