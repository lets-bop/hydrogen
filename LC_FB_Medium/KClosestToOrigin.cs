using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
        We have a list of points on the plane.  Find the K closest points to the origin (0, 0).
        (Here, the distance between two points on a plane is the Euclidean distance.)
        You may return the answer in any order.  The answer is guaranteed to be unique (except for the order that it is in.)

        Example 1:
        Input: points = [[1,3],[-2,2]], K = 1
        Output: [[-2,2]]
        Explanation: 
        The distance between (1, 3) and the origin is sqrt(10).
        The distance between (-2, 2) and the origin is sqrt(8).
        Since sqrt(8) < sqrt(10), (-2, 2) is closer to the origin.
        We only want the closest K = 1 points from the origin, so the answer is just [[-2,2]].

        Example 2:
        Input: points = [[3,3],[5,-1],[-2,4]], K = 2
        Output: [[3,3],[-2,4]]
        (The answer [[-2,4],[3,3]] would also be accepted.)
    */
    class KClosestToOrigin
    {
        Random random = new Random();

        public int[][] KClosest(int[][] points, int K) {
            int toFindIndex = K - 1;
            int pivotIndex = -1;
            int i = 0;
            int j = points.Length - 1;

            while (i <= j) {
                pivotIndex = this.QuickSelect(points, i, j);
                if (pivotIndex == toFindIndex) break;
                if (toFindIndex < pivotIndex) j = pivotIndex - 1;
                else i = pivotIndex + 1;
            }

            // Copy k elements
            List<int[]> result = new List<int[]>();
            for (i = 0; i <= pivotIndex; i++) {
                result.Add(new int[] {points[i][0], points[i][1]});
            }

            return result.ToArray();
        }

        private int QuickSelect(int[][] points, int i, int j) {
            int pivot = i;

            // exchange pivot with any # between i and j
            this.Swap(points, i, random.Next(i, j + 1));
            int pivotDist = this.Dist(points, i);
            i++;

            while (true) {
                while (i < j && this.Dist(points, i) <= pivotDist) i++;
                while (i <= j && this.Dist(points, j) > pivotDist) j--;
                if (i >= j) break;
                this.Swap(points, i, j);
            }

            this.Swap(points, pivot, j);
            return j;
        }

        private int Dist(int[][] points, int i) {
            // euclidean distance of point i from origin[0,0] = sqrt((points[i][0] - 0)^2 + (points[i][1] - 0)^2)
            return points[i][0] * points[i][0] + points[i][1] * points[i][1];
        }

        private void Swap(int[][] points, int i, int j) {
            // swap the values
            int tempi0 = points[i][0];
            int tempi1 = points[i][1];
            points[i][0] = points[j][0];
            points[i][1] = points[j][1];
            points[j][0] = tempi0;
            points[j][1] = tempi1;
        }
    }
}