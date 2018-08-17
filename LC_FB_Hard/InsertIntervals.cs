/*
Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).

You may assume that the intervals were initially sorted according to their start times.

Example 1:

Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
Output: [[1,5],[6,9]]
Example 2:

Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
Output: [[1,2],[3,10],[12,16]]
Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].

*/

using System;
using System.Collections.Generic;
using System.Text;

public class InsertInterval {

    public class Interval {
        public int Start;
        public int End;
        public Interval() { Start = 0; End = 0; }
        public Interval(int s, int e) { Start = s; End = e; }
    }

    public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval) {
        List<Interval> newList = new List<Interval>();
        Interval prevInterval = newInterval;

        foreach (Interval interval in intervals){
            if (prevInterval.End < interval.Start){
                newList.Add(prevInterval);
                prevInterval = interval;
            }
            else if (interval.End < prevInterval.Start){
                newList.Add(interval);
            }
            else{
                prevInterval.Start = Math.Min(prevInterval.Start, interval.Start);
                prevInterval.End = Math.Max(prevInterval.End, interval.End);
            }
        }

        newList.Add(prevInterval);

        return newList;        
    }
}