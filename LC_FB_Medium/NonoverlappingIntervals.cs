using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given a collection of intervals, find the minimum number of intervals 
        you need to remove to make the rest of the intervals non-overlapping.

        Example 1:
        Input: [[1,2],[2,3],[3,4],[1,3]]
        Output: 1
        Explanation: [1,3] can be removed and the rest of intervals are non-overlapping.
        Example 2:
        Input: [[1,2],[1,2],[1,2]]
        Output: 2
        Explanation: You need to remove two [1,2] to make the rest of intervals non-overlapping.
        Example 3:
        Input: [[1,2],[2,3]]
        Output: 0
        Explanation: You don't need to remove any of the intervals since they're already non-overlapping.

        Note:
        You may assume the interval's end point is always bigger than its start point.
        Intervals like [1,2] and [2,3] have borders "touching" but they don't overlap each other.
    */
    class NonoverlappingIntervals
    {
        public int EraseOverlapIntervals(int[][] intervals) {
            int result = 0;
            Array.Sort(intervals, CompareIntervals);

            int[] prev = null;
            foreach (int[] interval in intervals) {
                if (prev == null) {
                    prev = interval;
                    continue;
                }

                if (prev[1] > interval[0]) {
                    result++;
                    // there is overlap. If prev's end > interval's end, drop prev. Else drop current interval
                    if (prev[1] > interval[1]) {
                        prev = interval;
                    }
                } else {
                    prev = interval;
                }
            }
            
            return result;
        }

        public static int CompareIntervals(int[] int1, int[] int2) {
            if (int1[0] != int2[0]) {
                // int1 start and int2 start are different
                return int1[0] - int2[0];
            } else return int1[1] - int2[1]; // starts are the same, sort by end
        }
    }
}