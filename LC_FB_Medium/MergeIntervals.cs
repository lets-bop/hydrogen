using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    class Interval : IComparable
    {
        public int Start;
        public int End;

        public Interval(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }

        public int CompareTo(object obj)
        {
            Interval other = (Interval) obj;
            if (this.Start == other.Start && this.End == other.End)
                return 0;
            if (this.Start < other.Start)
                return -1;
            else if (this.Start == other.Start && this.End < other.End)
                return -1;
            return 1;
        }
    }

    class MergeIntervals
    {
        public static List<Interval> Merge(List<Interval> intervals)
        {
            if (intervals == null)
                return null;

            intervals.Sort();

            List<Interval> merged = new List<Interval>();
            Interval prevInterval = null;

            foreach (Interval interval in intervals)
            {
                if (prevInterval == null)
                {
                    prevInterval = interval;
                    continue;
                }

                if(prevInterval.End >= interval.Start)
                {
                    prevInterval.End = interval.End;
                }
                else
                {
                    merged.Add(prevInterval);
                    prevInterval = interval;
                }
            }

            merged.Add(prevInterval);

            return merged;
        }
    }
}