using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    /*
        Given n points on a 2D plane, find the maximum number of points that lie on the same straight line.

        Example 1:
        Input: [[1,1],[2,2],[3,3]]
        Output: 3

        Example 2:
        Input: [[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]
        Output: 4
    */
    class MaxPointsOnLine
    {
        public int MaxPoints(int[][] points) {
            // The key idea is that points on a line will have the same slope.
            // So we will use a dictionary that has the key as the slope and value the count of points with that slope
            // slope of ppints (x1, y1) & (x2, y2) = y2-y1/x2-x1.
            // The corner cases:
            //      There can be cases with infinite slope when x2 and x1 are the same and will lead to exception.
            //      We need to differentiate same points (x1==x2 and y1 == y2) from infinite slope
            // So we just do a normal walk of the points (O(n^2)) and calculate the slope and keep filling in the dictionary

            Dictionary<double, int> slopeCount = new Dictionary<double, int>();
            int x1, y1, x2, y2;
            double slope;
            int maxPoints = 0;

            for (int i = 0; i < points.Length; i++) {
                int localMax = 0;
                int samePoints = 1; //1 is to include itself

                for (int j = i + 1; j < points.Length; j++) {
                    x1 = points[i][0]; y1 = points[i][1];
                    x2 = points[j][0]; y2 = points[j][1];
                    if (x1 == x2 && y1 == y2) samePoints++;
                    else if (x1 == x2) {
                        slopeCount[double.NaN] = slopeCount.GetValueOrDefault(double.NaN, 0) + 1;
                        localMax = Math.Max(localMax, slopeCount[double.NaN]);
                    }
                    else {
                        slope = (double) (y2 - y1) / (double) (x2 - x1);
                        slopeCount[slope] = slopeCount.GetValueOrDefault(slope, 0) + 1;
                        localMax = Math.Max(localMax, slopeCount[slope]);
                    }
                }

                localMax += samePoints;
                maxPoints = Math.Max(maxPoints, localMax);
                slopeCount.Clear();
            }

            return maxPoints;
        }
    }
}