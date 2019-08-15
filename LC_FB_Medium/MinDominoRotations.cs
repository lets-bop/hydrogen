using System;
using System.Collections.Generic;

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
            else return minARotations;
        }

        private int CalculateRotations(int[] A, int[] B, int element) {
            // the critical properties are:
            // 1. either of A or B must have the element, and 
            // 2. the element will either need to remain in A or will need to be rotated to B.
            // Because of 2, we will need to keep track of 2 counts - 
            // count of rotations needed if element needs to go to A 
            // count of rotations needed if element needs to go to B
            int minARotations = 0;
            int minBRotations = 0;
            for (int i = 0; i < A.Length; i++) {
                if (A[i] != element && B[i] != element) return -1;
                if (A[i] != element) minARotations++;
                if (B[i] != element) minBRotations++;
            }

            return Math.Min(minARotations, minBRotations);
        }
    }
}