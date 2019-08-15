using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
A conveyor belt has packages that must be shipped from one port to another within D days.

The i-th package on the conveyor belt has a weight of weights[i].  
Each day, we load the ship with packages on the conveyor belt (in the order given by weights). 
We may not load more weight than the maximum weight capacity of the ship.
Return the least weight capacity of the ship that will result in all the packages on the conveyor belt being shipped within D days.
Note that the cargo must be shipped in the order given

Example 1:
Input: weights = [1,2,3,4,5,6,7,8,9,10], D = 5
Output: 15
Explanation: 
A ship capacity of 15 is the minimum to ship all the packages in 5 days like this:
1st day: 1, 2, 3, 4, 5
2nd day: 6, 7
3rd day: 8
4th day: 9
5th day: 10
Note that the cargo must be shipped in the order given, 
so using a ship of capacity 14 and splitting the packages into parts like (2, 3, 4, 5), (1, 6, 7), (8), (9), (10) is not allowed.

Example 2:
Input: weights = [3,2,2,4,1,4], D = 3
Output: 6
Explanation: 
A ship capacity of 6 is the minimum to ship all the packages in 3 days like this:
1st day: 3, 2
2nd day: 2, 4
3rd day: 1, 4

Example 3:
Input: weights = [1,2,3,1,1], D = 4
Output: 3
Explanation: 
1st day: 1
2nd day: 2
3rd day: 3
4th day: 1, 1
    */
    class ShipCapacity
    {
        /*
            The largest capacity (high) we may even need is the sum of weights of all packages.
            The smallest capacity (low) is the weight of the largest package.
            Optimization: the smallest capacity cannot be less than r / D, 
            which reduces the search interval if we have a lot of small packages (and D is small).
            We use binary search to find the minimum capacity. For each capacity we analyze, 
            we count the number of days required to ship all packages.
            We decrease the capacity if it takes less days than D, and increase otherwise. 
            Note that, when the number of days equals D, this algorithm keeps decreasing the capacity while it can, 
            therefore finding the smallest capacity required.
        */
        public int ShipWithinDays(int[] weights, int D)
        {
            int high = 0;
            int low = 0;
            if (weights == null || weights.Length == 0) return 0;

            foreach (int w in weights) {
                if (w > low) low = w;
                high += w;
            }

            // optimize low in case there are a lots of low weight packages
            low = Math.Max(low, high / D);

            int mid;
            while (low + 1 < high) {
                mid = low + (high - low) / 2;
                if (this.CountDays(weights, mid, D) > D) {
                    // we need more capacity
                    low = mid;
                } else {
                    high = mid;
                }
            }

            if (this.CountDays(weights, low, D) < D) return low;
            return high;
        }

        private int CountDays(int[] weights, int capacity, int allowedDays)
        {
            int weight = 0;
            int days = 1;
            foreach (int w in weights) {
                if (weight + w > capacity) {
                    days++;
                    weight = w;
                    if (days > allowedDays) return days;
                }
                else {
                    weight += w;
                }
            }

            return days;
        }
    }
}