using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    /*
        A sequence of numbers is called arithmetic if it consists of at least three elements and 
        if the difference between any two consecutive elements is the same.

        For example, these are arithmetic sequences:

        1, 3, 5, 7, 9
        7, 7, 7, 7
        3, -1, -5, -9
        The following sequence is not arithmetic.

        1, 1, 2, 5, 7
        
        A zero-indexed array A consisting of N numbers is given. A subsequence slice of that array is any 
        sequence of integers (P0, P1, ..., Pk) such that 0 ≤ P0 < P1 < ... < Pk < N.

        A subsequence slice (P0, P1, ..., Pk) of array A is called arithmetic if the sequence A[P0], A[P1], ..., A[Pk-1], A[Pk] 
        is arithmetic. In particular, this means that k ≥ 2.

        The function should return the number of arithmetic subsequence slices in the array A.

        The input contains N integers. Every integer is in the range of -231 and 231-1 and 0 ≤ N ≤ 1000. 
        The output is guaranteed to be less than 231-1.

        
        Example:

        Input: [2, 4, 6, 8, 10]

        Output: 7

        Explanation:
        All arithmetic subsequence slices are:
        [2,4,6]
        [4,6,8]
        [6,8,10]
        [2,4,6,8]
        [4,6,8,10]
        [2,4,6,8,10]
        [2,6,10]
    */
    class ArithmeticSlices2
    {
        public int NumberOfArithmeticSlices(int[] A) {
            int result = 0;

            // Create lookup dictionary where the key is the number and value is the index at which the number was found
            Dictionary<long, List<int>> lookup = new Dictionary<long, List<int>>();
            for (int i = 0; i < A.Length; i++) {
                if (lookup.ContainsKey(A[i])) lookup[A[i]].Add(i);
                else lookup[A[i]] = new List<int>() {i};
            }

            // Create an array of dictionaries where we assign a dictionary to every index.
            // Dictionary: key is the diff for the subsequence and value is the count
            Dictionary<long, int>[] dp = new Dictionary<long, int>[A.Length];
            for (int i = 0; i < dp.Length; i++) dp[i] = new Dictionary<long, int>();

            long diff;
            long numToFind;
            for (int i = 1; i < A.Length; i++) {
                for (int j = 0; j < i; j++) {
                    diff = (long) A[i] - (long) A[j];
                    numToFind = (long) A[j] - diff;
                    if (lookup.ContainsKey(numToFind)) {
                        // check if the number occurred at index less than j
                        foreach (int index in lookup[numToFind]) {
                            if (index < j) dp[i][diff] = dp[i].GetValueOrDefault(diff, 0) + 1;
                        }
                    }

                    if (dp[j].ContainsKey(diff)) dp[i][diff] = dp[i].GetValueOrDefault(diff, 0) + dp[j][diff];
                }
            }

            foreach (Dictionary<long, int> dict in dp) {
                foreach (long d in dict.Keys) result += dict[d];
            }

            return result;
        }
    }
}