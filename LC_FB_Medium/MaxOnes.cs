using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    class MaxOnes
    {
        public int LongestOnes(int[] A, int K) {

            if (A == null || A.Length == 0) return 0;

            int maxLength = 0;
            int start = 0;
            int end = 0;
            int flipped = 0;

            while (end < A.Length && A.Length - start >= maxLength) {
                if ((flipped < K && A[end] == 0) || (flipped <= K && A[end] == 1)) {
                    if (A[end] == 0) flipped++;
                    maxLength = Math.Max(maxLength, end - start + 1);
                    end++;
                } else {
                    while (flipped >= K) {
                        if (A[start] == 0) flipped--;
                        start++;
                    }
                }
            }

            return maxLength;
        }
    }
}