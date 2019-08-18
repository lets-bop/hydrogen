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
        int[][] points;
        Random random = new Random();

        public int[][] KClosest(int[][] points, int K) {
            List<int[]> result = new List<int[]>();
            if (points == null || points.Length == 0 || K <= 0) return result.ToArray();
            if (K >= points.Length) return points;

            this.points = points;
            this.Sort(0, points.Length - 1, K);

            // Copy k elements
            for (int i = 0; i < K; i++) {
                result.Add(new int[] {points[i][0], points[i][1]});
            }

            return result.ToArray();
        }

        private void Sort(int i, int j, int k) {
            if (i >= j) return;
            
            // swap i with some random element between i and j.
            // i is used as pivot and we want to randomize it
            int randIndex = this.random.Next(i, j + 1);
            this.Swap(i, randIndex);

            // Partition and calculate the left length.
            int mid = this.Partition(i, j);
            int leftLength = i - mid + 1;
            if (leftLength == k) return;
            if (k < leftLength) this.Sort(i, mid - 1, k);
            else this.Sort(mid + 1, j, k - leftLength);
        }

        private int Partition(int i, int j)
        {
            int i_mem = i;
            int pivot = Dist(i);
            i++;

            while (true) {
                while (i < j && this.Dist(i) <= pivot) i++;
                while (i <= j && this.Dist(j) >= pivot) j--;
                if (i >= j) break;
                this.Swap(i, j);
            }

            // j will be pointing to an element less than pivot.
            this.Swap(i_mem, j);
            return j;
        }

        private int Dist(int i) {
            // euclidean distance of point i from origin[0,0] = sqrt((points[i][0] - 0)^2 + (points[i][1] - 0)^2)
            return points[i][0] * points[i][0] + points[i][1] * points[i][1];
        }

        private void Swap(int i, int j) {
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