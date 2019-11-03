using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        A sequence of number is called arithmetic if it consists of at least three elements and 
        if the difference between any two consecutive elements is the same.

        For example, these are arithmetic sequence:

        1, 3, 5, 7, 9
        7, 7, 7, 7
        3, -1, -5, -9
        The following sequence is not arithmetic.

        1, 1, 2, 5, 7

        A zero-indexed array A consisting of N numbers is given. A slice of that array is any pair of integers (P, Q)
        such that 0 <= P < Q < N.

        A slice (P, Q) of array A is called arithmetic if the sequence:
        A[P], A[p + 1], ..., A[Q - 1], A[Q] is arithmetic. In particular, this means that P + 1 < Q.

        The function should return the number of arithmetic slices in the array A.
    */
    class ArithmeticSlices
    {
        /*
            The difference between this and ArithmeticSlices2 is that we 
            only need to consider consecutive elements in this.
            Whereas in ArithmeticSlices2, its a subsequence.
        */
        public int CountSlices(int[] A) {
            return this.CountSlicesDp(A);
        }

        private int CountSlicesNaive(int[] A){
            // O(n^2) time, O(1) space
            // Example: Console.WriteLine("Expected: 10. Actual: " + ar.CountSlices(new int[] {1,2,3,4,5,6}));
            // [1,2,3],[1,2,4],[1,2,5],[1,2,6],[2,3,4],[2,3,5],[2,3,6],[3,4,5],[3,4,6],[4,5,6]
            int count = 0;
            for (int s = 0; s < A.Length - 2; s++) {
                int d = A[s + 1] - A[s];
                for (int e = s + 2; e < A.Length; e++) {
                    if (A[e] - A[e - 1] == d)
                        count++;
                    else
                        break;
                }
            }

            return count;
        }

        private int CountSlicesDp(int[] A){
            // O(n) time and space
            int count = 0;
            int[] dp = new int[A.Length];
            for (int i = 2; i < A.Length; i++) {
                if (A[i] - A[i - 1] == A[i - 1] - A[i - 2]) {
                    dp[i] = dp[i - 1] + 1;
                    count += dp[i];
                }
            }

            return count;
        }
    }
}