using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Assume you have an array of length n initialized with all 0's and are given k update operations.
        Each operation is represented as a triplet: [startIndex, endIndex, inc] which increments each 
        element of subarray A[startIndex ... endIndex] (startIndex and endIndex inclusive) with inc.
        Return the modified array after all k operations were executed.

        Example:
        Input: length = 5, updates = [[1,3,2],[2,4,3],[0,2,-2]]
        Output: [-2,0,3,5,3]
        Explanation: 
            Initial state:
            [0,0,0,0,0]
            After applying operation [1,3,2]:
            [0,2,2,2,0]
            After applying operation [2,4,3]:
            [0,2,5,5,3]
            After applying operation [0,2,-2]:
            [-2,0,3,5,3]
    */
    class RangeAddition
    {
        public int[] GetModifiedArray(int length, int[][] updates) {
            // We can do this in O(n). For each range update,
            // we add the value at the start of the rangeIndex
            // and we subtract the value at the end of the rangeIndex (if the index is less than length)
            // Finally, we just need to walk the recorded values to get the aggregate

            // validate the input
            if (length == 0) return new int[] {};
            int[] result = new int[length];

            foreach (int[] update in updates) {
                int start = update[0];
                int end = update[1] + 1;
                result[start] += update[2];
                if (end < length) result[end] -= update[2];
            }

            int finalVal = 0;
            for (int i = 0; i < result.Length; i++) {
                finalVal += result[i];
                result[i] = finalVal;
            }

            return result;
        }
    }
}