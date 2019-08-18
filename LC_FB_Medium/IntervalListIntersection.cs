using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
        Given two lists of closed intervals, each list of intervals is pairwise disjoint and in sorted order.
        Return the intersection of these two interval lists.
        (Formally, a closed interval [a, b] (with a <= b) denotes the set of real numbers x with a <= x <= b. 
        The intersection of two closed intervals is a set of real numbers that is either empty, or can be represented as a closed interval. 
        For example, the intersection of [1, 3] and [2, 4] is [2, 3].)
        Input: A = [[0,2],[5,10],[13,23],[24,25]], B = [[1,5],[8,12],[15,24],[25,26]]
        Output: [[1,2],[5,5],[8,10],[15,23],[24,24],[25,25]]
        Reminder: The inputs and the desired output are lists of Interval objects, and not arrays or lists.
        Note:
        0 <= A.length < 1000
        0 <= B.length < 1000
        0 <= A[i].start, A[i].end, B[i].start, B[i].end < 10^9
    */
    class IntervalListIntersection
    {
        public int[][] IntervalIntersection(int[][] A, int[][] B) {
            List<int[]> list = new List<int[]>();
            if (A == null || B == null || A.Length == 0 || B.Length == 0) return list.ToArray();

            int aIndex = 0;
            int bIndex = 0;

            while (aIndex < A.Length && bIndex < B.Length) {
                // there is an intersection if Max(A.Start, B.Start) <= Min(A.End, B.End)
                if (Math.Max(A[aIndex][0], B[bIndex][0]) <= Math.Min(A[aIndex][1], B[bIndex][1])) {
                    // intersection is Max(A.Start, B.Start) & Min(A.End, B.End)
                    list.Add(new int[] { Math.Max(A[aIndex][0], B[bIndex][0]), Math.Min(A[aIndex][1], B[bIndex][1]) } );
                }

                // Increment the index of the item that has the earlier end
                if (A[aIndex][1] <= B[bIndex][1]) aIndex++;
                else bIndex++;
            }

            return list.ToArray();
        }
    }
}