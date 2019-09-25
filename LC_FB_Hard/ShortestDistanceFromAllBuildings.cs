using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    /*
        You want to build a house on an empty land which reaches all buildings in the shortest amount of distance. 
        You can only move up, down, left and right. You are given a 2D grid of values 0, 1 or 2, where:

        Each 0 marks an empty land which you can pass by freely.
        Each 1 marks a building which you cannot pass through.
        Each 2 marks an obstacle which you cannot pass through.
        Example: Input: [[1,0,2,0,1],[0,0,0,0,0],[0,0,1,0,0]]

        1 - 0 - 2 - 0 - 1
        |   |   |   |   |
        0 - 0 - 0 - 0 - 0
        |   |   |   |   |
        0 - 0 - 1 - 0 - 0

        Output: 7 
        Explanation: Given three buildings at (0,0), (0,4), (2,2), and an obstacle at (0,2),
                    the point (1,2) is an ideal empty land to build a house, as the total 
                    travel distance of 3+3+1=7 is minimal. So return 7.
        Note:
        There will be at least one building. If it is not possible to build such house according to the above rules, return -1.
    */
    class ShortestDistanceFromAllBuildings
    {
        int[][] distance;
        int[][] reach;

        public int ShortestDistance(int[][] grid) {
            // validate the input
            if (grid == null || grid.Length == 0) return -1;

            int rows = grid.Length;
            int cols = grid[0].Length;
            this.distance = new int[rows][];
            this.reach = new int[rows][];

            int shortest = int.MaxValue;
            for (int i = 0; i < this.distance.Length; i++){
                distance[i] = new int[cols];
                reach[i] = new int[cols];
            }

            // Calculate the distance to every empty from every building by doing a BFS
            // from every building.
            // Along with keeping track of the distance, 
            // we'll also need to keep track of how many building were reachable from every grid,
            // which will be done during BFS.
            int numOfBuildings = 0;
            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    if (grid[r][c] == 1) {
                        numOfBuildings++;
                        Queue<(int,int)> queue = new Queue<(int, int)>();
                        queue.Enqueue((r * cols + c, 0));
                        this.BFS(queue, rows, cols, grid);
                    }
                }
            }

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    if (reach[r][c] == numOfBuildings) shortest = Math.Min(shortest, this.distance[r][c]);

            return shortest < int.MaxValue ? shortest : -1;
        }

        private void BFS(Queue<(int,int)> queue, int rows, int cols, int[][] grid) {
            int[] dr = new int[] {-1,1,0,0};
            int[] dc = new int[] {0,0,-1,1};

            while (queue.Count > 0) {
                (int,int) item = queue.Dequeue();
                int idx = item.Item1;
                int dist = item.Item2;
                int r = idx / cols;
                int c = idx % cols;

                for (int k = 0; k < 4; k++) {
                    int nr = r + dr[k];
                    int nc = c + dc[k];
                    if (nr >=0 && nc >=0 && nr < rows && nc < cols && grid[nr][nc] == 0) {
                        grid[nr][nc] = -1;
                        queue.Enqueue((nr * cols + nc, dist + 1));
                        this.reach[nr][nc]++;
                        this.distance[nr][nc] += dist + 1;
                    }
                }
            }

            // restore the grid where 0's where converted to -1 earlier
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (grid[i][j] == -1) grid[i][j] = 0;
        }
    }
}