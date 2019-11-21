using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    /*
        Return the length of the shortest, non-empty, contiguous subarray of A with sum at least K.
        If there is no non-empty subarray with sum at least K, return -1.
        Note: 
            1 <= A.length <= 50000
            -10 ^ 5 <= A[i] <= 10 ^ 5
            1 <= K <= 10 ^ 9 (K is positive)

        Example 1:
        Input: A = [1], K = 1
        Output: 1
        Example 2:
        Input: A = [1,2], K = 4
        Output: -1
        Example 3:
        Input: A = [2,-1,2], K = 3
        Output: 3
    */
    class ShortestSubArraySumAtleastK
    {
        public int ShortestSubarray(int[] A, int K) {
            int res = A.Length + 1;

            int[] prefixSum = new int[A.Length + 1]; //prefix sums
            for (int i = 0; i < A.Length; i++) 
                prefixSum[i + 1] = prefixSum[i] + A[i];
            
            /*
                Keep a dequeue of the 'best' prefix sums found so far. This will be increasing both in index as well as in value. 
                When we go from left to right, we add new prefix sums to the back (making sure it stays 
                increasing in value) and remove prefix sums from the front 
                (if we cant use it here, it will never be better to use it later).
            */
            var d = new List<int>(); // List as a dequeue
            for (int i = 0; i < A.Length + 1; i++) 
            {
                while (d.Count > 0 && prefixSum[i] <= prefixSum[d[d.Count - 1]]) 
                    d.RemoveAt(d.Count - 1);
                
                while (d.Count > 0 && prefixSum[i] - prefixSum[d[0]] >=  K) {
                    res = Math.Min(res, i - d[0]);
                    if (res == 1) break;
                    d.RemoveAt(0);
                }

                d.Add(i);
            }
            
            return res <= A.Length ? res : -1;
        }
    }
}