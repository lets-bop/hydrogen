/*
Given a collection of intervals, merge all overlapping intervals.

Example 1:

Input: [[1,3],[2,6],[8,10],[15,18]]
Output: [[1,6],[8,10],[15,18]]
Explanation: Since intervals [1,3] and [2,6] overlaps, merge them into [1,6].
Example 2:

Input: [[1,4],[4,5]]
Output: [[1,5]]
Explanation: Intervals [1,4] and [4,5] are considerred overlapping.

*/

using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    public class Interval {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }

    class MergeIntervals
    {
        public IList<Interval> Merge(IList<Interval> intervals1)
        {
            IList<Interval> merged = new List<Interval>();
            if (intervals1 == null || intervals1.Count == 0) return merged;
            
            List<Interval> intervals = new List<Interval>(intervals1);
            intervals.Sort(CompareIntervals);

            Interval prevInterval = null;
            foreach (Interval interval in intervals) {
                if (prevInterval == null) {
                    prevInterval = interval;
                    continue;
                }

                if(prevInterval.end >= interval.start) {
                    // intervals overlap, check and update end times.
                    if (prevInterval.end < interval.end) prevInterval.end = interval.end;
                } else {
                    // no overlap, add prevInterval into result
                    merged.Add(prevInterval);
                    prevInterval = interval;
                }
            }

            merged.Add(prevInterval); // since list count > 1, prevInterval will be present.
            return merged;
        }

        public static int CompareIntervals(Interval i1, Interval i2) {
            if (i1.start != i2.start) return i1.start - i2.start;
            return i1.end - i2.end;
        }
    }
}