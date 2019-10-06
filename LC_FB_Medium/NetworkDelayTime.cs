using System;
using System.Collections.Generic;
using System.Text;

/*
    There are N network nodes, labelled 1 to N.
    Given times, a list of travel times as directed edges times[i] = (u, v, w), 
    where u is the source node, v is the target node, and w is the time it takes 
    for a signal to travel from source to target. Now, we send a signal from a certain node K. 
    How long will it take for all nodes to receive the signal? If it is impossible, return -1.
    
    Example 1:
    1 <-- 2 -- > 3 --> 4

    Input: times = [[2,1,1],[2,3,1],[3,4,1]], N = 4, K = 2
    Output: 2
*/
namespace LC_FB_Medium
{
    class NetworkDelayTime
    {
        int[] distanceToNode;

        public int CalculateDelay(int[][] times, int N, int K)
        {
            Dictionary<int, List<(int, int)>> graph = this.BuildGraph(times);
            this.distanceToNode = new int[N + 1];
            return this.DoDjikstras(graph, K, N);
        }

        private Dictionary<int, List<(int, int)>> BuildGraph(int[][] times)
        {
            Dictionary<int, List<(int, int)>> graph = new Dictionary<int, List<(int, int)>>();

            foreach (int[] time in times) {
                // item1 = dest. item2 = cost/delay
                (int, int) tup = (time[1], time[2]);
                if (!graph.ContainsKey(time[0])) graph[time[0]] = new List<(int, int)>();
                graph[time[0]].Add(tup);
            }

            return graph;
        }

        // The below algorithm takes O(n^2) time. Can be done in O(n lg n) time by using heaps.
        private int DoDjikstras(Dictionary<int, List<(int, int)>> graph, int startNode, int N)
        {
            HashSet<int> visited = new HashSet<int>();

            // item1 = node, item2 = distance/delay to node (from startNode)
            List<(int, int)> dist = new List<(int, int)>();
            dist.Add((startNode, 0));
            int exploreNode;
            int distanceToExploreNode = 0;

            int[] minDelayToNode = new int[N + 1];
            for (int i = 0; i < minDelayToNode.Length; i++) minDelayToNode[i] = int.MaxValue;
            minDelayToNode[startNode] = 0;
            minDelayToNode[0] = 0; // not relevant as node ids start from 1

            while(true)
            {
                exploreNode = -1;
                foreach (var tuple in dist) {
                    if (!visited.Contains(tuple.Item1)) {
                        visited.Add(tuple.Item1);
                        exploreNode = tuple.Item1;
                        distanceToExploreNode = tuple.Item2;
                        break;
                    }
                }

                if (exploreNode == -1) break;
                else {
                    if (graph.ContainsKey(exploreNode)) {
                        foreach (var neighbor in graph[exploreNode]) {
                            dist.Add((neighbor.Item1, neighbor.Item2 + distanceToExploreNode));
                            minDelayToNode[neighbor.Item1] = Math.Min(minDelayToNode[neighbor.Item1], neighbor.Item2 + distanceToExploreNode);
                        }

                        // Since Djikstra's is a greedy algorithm,
                        // we pick the node that has the shortest distance to it for exploration/relaxation.
                        // Once we pick the node to explore, we add it to the visited list and only pick nodes 
                        // that haven't been explored yet.
                        // Hence the sort is performed only on N nodes. 
                        // Therefore the time complexity = O (N * (N log N)) = O (N ^ 2)
                        // If we use a min-heap, this can be reduced to O(n lg n)
                        dist.Sort(SortDistances);
                    }
                }
            }

            if (visited.Count < N) return -1;
            int delay = 0;
            foreach (int d in minDelayToNode) delay = Math.Max(delay, d);
            return delay;
        }

        private static int SortDistances((int, int) tup1, (int, int) tup2)
        {
            return tup1.Item2 - tup2.Item2;
        }
    }
}