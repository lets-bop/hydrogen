using System;
using System.Collections.Generic;

/*
You are climbing a stair case. It takes n steps to reach to the top.
Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
Note: Given n will be a positive integer.

Example 1:
Input: 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps

Example 2:
Input: 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step
*/
namespace LC_FB_Easy
{
    class ClimbingStairs
    {
        public int ClimbStairs(int n) {
            return ClimbStairsLikeFib(n);
        }

        public int ClimbStairsBrute(int stair, int n) {
            // At every stair we call ClimbStairsBrute with the option of taking 1 step and 2 steps
            // from the current stair. It will take O(2^n) time and O(n) space
            if (stair > n) return 0;
            if (stair == n) return 1;
            return ClimbStairsBrute(stair + 1, n) + ClimbStairsBrute(stair + 2, n);
        }

        public int ClimbStairsMemo(int stair, int n, int[] memo) {
            // At every stair we call ClimbStairsBrute with the option of taking 1 step and 2 steps
            // from the current stair. It will take O(n) time and O(n) space
            if (stair > n) return 0;
            if (stair == n) return 1;
            if (memo[stair] > 0) return memo[stair];

            memo[stair] = ClimbStairsBrute(stair + 1, n) + ClimbStairsBrute(stair + 2, n);
            return memo[stair];
        }

        public int ClimbStairsDp(int n)
        {
            // The number of ways to get to step i is to either take 1 step from step (i-1) or
            // taking 2 steps from (i-2). Apply the same logic to step (i-1) and (i-2) to get a recursive sol
            // O(n) time and space.
            if (n <= 0) return 0;
            if (n <= 2) return n;

            int[] dp = new int[n+1];
            dp[1] = 1;
            dp[2] = 2;

            for (int i = 3; i <= n; i++) {
                dp[i] = dp[i - 1] + dp [i - 2];
            }

            return dp[n];
        }

        public int ClimbStairsLikeFib(int n) {
            // O(n) time and O(1) space
            if (n == 1) return 1;
            int first = 1;
            int second = 2;
            int third;
            for (int i = 3; i <= n; i++) {
                third = first + second;
                first = second;
                second = third;
            }

            return second;
        }
    }
}