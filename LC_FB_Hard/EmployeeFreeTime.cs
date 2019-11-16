using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    /*
        We are given a list schedule of employees, which represents the working time for each employee.
        Each employee has a list of non-overlapping Intervals, and these intervals are in sorted order.
        Return the list of finite intervals representing common, positive-length free time for all employees, also in sorted order.

        Example 1:
        Input: schedule = [[[1,2],[5,6]],[[1,3]],[[4,10]]]
        Output: [[3,4]]
        Explanation:
        There are a total of three employees, and all common
        free time intervals would be [-inf, 1], [3, 4], [10, inf].
        We discard any intervals that contain inf as they aren't finite.
        
        Example 2:
        Input: schedule = [[[1,3],[6,7]],[[2,4]],[[2,5],[9,12]]]
        Output: [[5,6],[7,9]]
        (Even though we are representing Intervals in the form [x, y], the objects inside are Intervals, 
        not lists or arrays. For example, schedule[0][0].start = 1, schedule[0][0].end = 2, and schedule[0][0][0] is not defined.)
        Also, we wouldn't include intervals like [5, 5] in our answer, as they have zero length.

        Note:
        schedule and schedule[i] are lists with lengths in range [1, 50].
        0 <= schedule[i].start < schedule[i].end <= 10^8.
    */
    public class EmployeeFreeTime
    {
        public class Interval {
            public int start;
            public int end;

            public Interval(){}
            public Interval(int _start,int _end) {
                start = _start;
                end = _end;
            }
        }
        public IList<Interval> FindFreeTime(IList<IList<Interval>> schedule) {
            // add the working intervals of all employees into list and sort it
            // merge the working intervals
            // find gaps between merged intervals = free time intervals
            
            List<Interval> result = new List<Interval>();
            List<Interval> all = new List<Interval>();

            foreach (List<Interval> interval in schedule) all.AddRange(interval);
            all.Sort(CompareIntervals);

            // merge the intervals
            List<Interval> merged = new List<Interval>();
            Interval prev = null;
            
            foreach (Interval i in all) {
                if (prev == null) prev = new Interval(i.start, i.end);
                else {
                    if (prev.end > i.start) prev.end = Math.Max(prev.end, i.end);
                    else {
                        merged.Add(prev);
                        prev = new Interval(i.start, i.end);
                    }
                }
            }

            if (prev != null) merged.Add(prev);

            // lets find the free times
            for (int i = 0; i < merged.Count - 1; i++) {
                if (merged[i].end != merged[i+1].start) result.Add(new Interval(merged[i].end, merged[i+1].start));
            }

            return result;
        }

        public static int CompareIntervals(Interval i1, Interval i2) {
            if (i1.start != i2.start) return i1.start - i2.start;
            else return i1.end - i2.end;
        }
    }
}