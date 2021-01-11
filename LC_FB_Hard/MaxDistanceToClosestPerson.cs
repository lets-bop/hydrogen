using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    /*
        Example 1:
            Input: seats = [1,0,0,0,1,0,1], Output: 2
            Explanation: 
            If Alex sits in the second open seat (i.e. seats[2]), then the closest person has distance 2.
            If Alex sits in any other open seat, the closest person has distance 1.
            Thus, the maximum distance to the closest person is 2.

        Example 2:
            Input: seats = [1,0,0,0], Output: 3
            Explanation: 
            If Alex sits in the last seat (i.e. seats[3]), the closest person is 3 seats away.
            This is the maximum distance possible, so the answer is 3.

        Example 3:
            Input: seats = [0,1]
            Output: 1

        Constraints:
            2 <= seats.length <= 2 * 104
            seats[i] is 0 or 1.
            At least one seat is empty.
            At least one seat is occupied.
    */
    class MaxDistanceToClosestPerson
    {
        public int MaxDistToClosest(int[] seats) {
            int[] distance = new int[seats.Length];
            this.Calculate(seats, distance);
            
            int max = 0;
            for (int i = 0; i < distance.Length; i++) {
                if (seats[i] != 1) max = Math.Max(max, distance[i]);
            }
            
            return max;
        }

        public void Calculate(int[] seats, int[] distance) {
            int dist = int.MaxValue;
            for (int i = 0; i < seats.Length; i++) {
                if (seats[i] == 1) dist = 0;
                else if (dist != int.MaxValue) distance[i] = ++dist;
                else distance[i] = int.MaxValue;
            }

            dist = int.MinValue;
            for (int i = seats.Length - 1; i >= 0; i--) {
                if (seats[i] == 1) dist = 0;
                else if (dist != int.MinValue) distance[i] = Math.Min(distance[i], ++dist);
            }
        }
    }
}