using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given a set of points in the xy-plane, determine the minimum area of a rectangle formed from these points, 
        with sides parallel to the x and y axes. If there isn't any rectangle, return 0. 

        Example 1:
        Input: [[1,1],[1,3],[3,1],[3,3],[2,2]]
        Output: 4

        Example 2:
        Input: [[1,1],[1,3],[3,1],[3,3],[4,1],[4,3]]
        Output: 2
    */
    class MinimumAreaRectangle
    {
        public int MinAreaRect(int[][] points)
        {
            int area = int.MaxValue;
            bool foundArea = false;

            // for every point (x,y) create a dictionary where x is key and valeu is a hashset containing y.
            // this allow easy look up of points later on
            Dictionary<int, HashSet<int>> dict = new Dictionary<int, HashSet<int>>();
            foreach (int[] point in points) {
                HashSet<int> set = dict.GetValueOrDefault(point[0], new HashSet<int>());
                set.Add(point[1]);
                dict[point[0]] = set;
            }

            // For each point (a, b) find a diagonal point (x, y) where x !=a and y != b
            // Then you need to only look for (a, y) (x, b)
            foreach (int[] pointA in points){
                foreach (int[] pointB in points) {
                    if (pointA[0] == pointB[0] || pointA[1] == pointB[1]) continue;// not a diagnoal point

                    // look for (a, y) && (x, b)
                    if ((dict.ContainsKey(pointA[0]) && dict[pointA[0]].Contains(pointB[1])) && 
                        (dict.ContainsKey(pointB[0]) && dict[pointB[0]].Contains(pointA[1]))) {
                            // found the rectangle points. Find area
                            foundArea = true;
                            area = Math.Min(area, Math.Abs(pointA[0] - pointB[0]) * Math.Abs(pointA[1] - pointB[1]));
                        }
                }
            }

            if (foundArea) return area;
            return 0;
        }
    }
}