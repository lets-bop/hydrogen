using System;
using System.Collections.Generic;

/*
In a row of dominoes, A[i] and B[i] represent the top and bottom halves of the i-th domino. 
(A domino is a tile with two numbers from 1 to 6 - one on each half of the tile.)
We may rotate the i-th domino, so that A[i] and B[i] swap values.
Return the minimum number of rotations so that all the values in A are the same, 
or all the values in B are the same. If it cannot be done, return -1.
Input: A = [2,1,2,4,2,2], B = [5,2,6,2,3,2]
Output: 2
Explanation: 
The first figure represents the dominoes as given by A and B: before we do any rotations.
If we rotate the second and fourth dominoes, we can make every value in the top row equal to 2, 
as indicated by the second figure.

Example 2:
Input: A = [3,5,1,2,3], B = [3,6,3,3,4]
Output: -1
Explanation: 
In this case, it is not possible to rotate the dominoes to make one row of values equal.

Note:
1 <= A[i], B[i] <= 6
2 <= A.length == B.length <= 20000
*/
namespace LC_FB_Medium
{
    class MinDominoRotations
    {
        public int CalcMinDominoRotations(int[] A, int[] B) {
            if (A == null && B == null) return 0;
            if (A.Length == 0 && B.Length == 0) return 0;
            if (A.Length == 0 || B.Length == 0) return -1;

            int minARotations = this.CalculateRotations(A, B, A[0]);
            if (minARotations == -1) return this.CalculateRotations(A, B, B[0]);
            return minARotations;
        }

        private int CalculateRotations(int[] A, int[] B, int element) {
            // the critical properties are:
            // 1. either of A or B must have the element, and 
            // 2. the element will either need to remain in A or will need to be rotated to B.
            // Because of 2, we will need to keep track of 2 counts - 
            // count of rotations needed if element needs to go to A 
            // count of rotations needed if element needs to go to B
            int aRotations = 0;
            int bRotations = 0;
            for (int i = 0; i < A.Length; i++) {
                if (A[i] != element && B[i] != element) return -1;
                if (A[i] != element) aRotations++;
                if (B[i] != element) bRotations++;
            }

            return Math.Min(aRotations, bRotations);
        }
    }
}