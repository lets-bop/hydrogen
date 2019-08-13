using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
        On a campus represented as a 2D grid, there are N workers and M bikes, with N <= M. 
        Each worker and bike is a 2D coordinate on this grid.
        Our goal is to assign a bike to each worker. Among the available bikes and workers, we choose 
        the (worker, bike) pair with the shortest Manhattan distance between each other, and assign the bike to that worker. 
        (If there are multiple (worker, bike) pairs with the same shortest Manhattan distance, 
        we choose the pair with the smallest worker index; if there are multiple ways to do that, 
        we choose the pair with the smallest bike index). 
        We repeat this process until there are no available workers.

        The Manhattan distance between two points p1 and p2 is Manhattan(p1, p2) = |p1.x - p2.x| + |p1.y - p2.y|.
        Return a vector ans of length N, where ans[i] is the index (0-indexed) of the bike that the i-th worker is assigned to.

        Input: workers = [[0,0],[2,1]], bikes = [[1,2],[3,3]]
        Output: [1,0]
        Explanation: 
        Worker 1 grabs Bike 0 as they are closest (without ties), and Worker 0 is assigned Bike 1. So the output is [1, 0].

        Input: workers = [[0,0],[1,1],[2,0]], bikes = [[1,0],[2,2],[2,1]]
        Output: [0,2,1]
        Explanation: 
        Worker 0 grabs Bike 0 at first. Worker 1 and Worker 2 share the same distance to Bike 2, 
        thus Worker 1 is assigned to Bike 2, and Worker 2 will take Bike 1. So the output is [0,2,1].
    */
    class CampusBikes
    {
        public class WorkerBike
        {
            public int manhattanDistance;
            public int workerIndex;
            public int bikeIndex;

            public WorkerBike(int[] worker, int[] bike, int workerIndex, int bikeIndex)
            {
                this.manhattanDistance = Math.Abs(worker[0] - bike[0]) + Math.Abs(worker[1] - bike[1]);
                this.workerIndex = workerIndex;
                this.bikeIndex = bikeIndex;
            }
        }

        public int[] AssignBikes(int[][] workers, int[][] bikes) {

            List<WorkerBike> list = new List<WorkerBike>();

            for (int i = 0; i < workers.Length; i++) {
                for (int j = 0; j < bikes.Length; j++) {
                    list.Add(new WorkerBike(workers[i], bikes[j], i, j));
                }
            }

            // The below sort logic will sort the results based on the requirement:
            // manhattan distance in ascending. 
            // If manhattan distance is same, sort by worker index ascending. 
            // And if worker index is the same, sort by bike index (ascending)
            list.Sort(CompareWokerBikes);

            // Use hashset to quickly lookup which workers have been assigned bikes and also 
            // lookup which bikes have been assigned.
            HashSet<int> assignedBikes = new HashSet<int>();
            Dictionary<int, int> workersWithBikes = new Dictionary<int, int>();

            foreach (WorkerBike workerBike in list) {
                if (workersWithBikes.ContainsKey(workerBike.workerIndex)) continue;
                
                // we need to assign a bike to this worker
                if (assignedBikes.Contains(workerBike.bikeIndex)) continue;
                workersWithBikes[workerBike.workerIndex] = workerBike.bikeIndex;
                assignedBikes.Add(workerBike.bikeIndex);
            }

            List<int> result = new List<int>();
            for (int i = 0; i < workers.Length; i++) {
                result.Add(workersWithBikes[i]);
            }

            return result.ToArray();
        }        

        public static int CompareWokerBikes(WorkerBike wb1, WorkerBike wb2) {
            if (wb1.manhattanDistance != wb2.manhattanDistance) {
                // order by manhattan distance ascending 
                return wb1.manhattanDistance - wb2.manhattanDistance;
            }
            else if (wb1.workerIndex != wb2.workerIndex) {
                // order by worker index ascending
                return wb1.workerIndex - wb2.workerIndex;
            } else {
                // order by bike index ascending
                return wb1.bikeIndex - wb2.bikeIndex;
            }
        }
    }
}