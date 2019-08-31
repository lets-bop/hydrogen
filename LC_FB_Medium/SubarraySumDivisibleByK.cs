using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given an array A of integers, return the number of (contiguous, non-empty) subarrays that have a sum divisible by K.

        Example 1:
        Input: A = [4,5,0,-2,-3,1], K = 5
        Output: 7
        Explanation: There are 7 subarrays with a sum divisible by K = 5:
        [4, 5, 0, -2, -3, 1], [5], [5, 0], [5, 0, -2, -3], [0], [0, -2, -3], [-2, -3]
    */
    class SubarraySumDivisibleByK
    {
        public int Calculate(int[] A, int K)
        {
            int result = 0;
            int k = K == 0 ? 1 : K;
            int[] sumCount = new int[k];
            sumCount[0] = 1;    // if number % K == 0
            int runningSumModK = 0;

            foreach (int a in A) {
                runningSumModK = (runningSumModK + a) % K;
                if (runningSumModK < 0) runningSumModK += K;    // -4 % 5 = -4. Instead, this converts it to (-4 + 5) % 5 = 1
                result += sumCount[runningSumModK];
                sumCount[runningSumModK]++;
            }

            return result;
        }
    }
}