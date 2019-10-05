using System;
using System.Collections.Generic;

namespace LC_FB_Easy
{
    /*
        Given an array of meeting time intervals consisting of 
        start and end times [[s1,e1],[s2,e2],...] (si < ei), 
        determine if a person could attend all meetings.

        Example 1:
        Input: [[0,30],[5,10],[15,20]]
        Output: false
        
        Example 2:
        Input: [[7,10],[2,4]]
        Output: true
    */
    class MeetingRooms
    {
        public bool CanAttendMeetings(int[][] intervals) {
            Array.Sort(intervals, CompareIntervals);
            for (int i = 1; i < intervals.Length; i++) {
                // overlap if max(start) < min(end)
                if (Math.Max(intervals[i - 1][0], intervals[i][0]) < Math.Min(intervals[i - 1][1], intervals[i][1]))
                    return false;
            }

            return true;
        }

        public static int CompareIntervals(int[] interval1, int[] interval2) {
            if (interval1[0] != interval2[0]) return interval1[0] - interval2[0];
            return interval1[1] - interval2[1];
        }
    }
}