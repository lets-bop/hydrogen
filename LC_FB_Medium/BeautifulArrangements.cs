using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Suppose you have n integers labeled 1 through n. A permutation of those n integers perm (1-indexed) 
        is considered a beautiful arrangement if for every i (1 <= i <= n), either of the following is true:
            perm[i] is divisible by i.
            i is divisible by perm[i].
        Given an integer n, return the number of the beautiful arrangements that you can construct.

        Example 1:
            Input: n = 2; Output: 2
            Explanation: 
            The first beautiful arrangement is [1,2]:
                - perm[1] = 1 is divisible by i = 1
                - perm[2] = 2 is divisible by i = 2
            The second beautiful arrangement is [2,1]:
                - perm[1] = 2 is divisible by i = 1
                - i = 2 is divisible by perm[2] = 1
    */

    class BeautifulArrangements
    {
        int count; 
        public int CountArrangement(int n) {
            if (n == 1) return 1;
            bool[] visited = new bool[n + 1];
            this.CountPermutations(1, n, visited);
            return this.count;
        }

        // visited is a structure used to denote which numbers have been taken.
        // pos is used to denote which index position are we trying to fill.
        // if a # between 1..n has not been taken and the condition is satisifed, 
        // we fill that pos and go to the next position.
        private void CountPermutations(int pos, int n, bool[] visited) {
            if (pos > n) { 
                this.count++;
                return;
            }

            for (int i = 1; i <= n; i++) {
                if (!visited[i] && (i % pos == 0 || pos % i == 0)) {
                    visited[i] = true;
                    this.CountPermutations(pos+1, n, visited);
                    visited[i] = false;
                }
            }
        }
    }
}