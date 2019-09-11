using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    /*
        We have a grid of 1s and 0s; the 1s in a cell represent bricks.  
        A brick will not drop if and only if it is directly connected to the top of the grid, 
        or at least one of its (4-way) adjacent bricks will not drop.

        We will do some erasures sequentially. Each time we want to do the erasure at the location (i, j), 
        the brick (if it exists) on that location will disappear, and then some other bricks may drop because of that erasure.

        Return an array representing the number of bricks that will drop after each erasure in sequence.

        Example 1:
        Input: 
        grid = [[1,0,0,0],[1,1,1,0]]
        hits = [[1,0]]
        Output: [2]
        Explanation: If we erase the brick at (1, 0), the brick at (1, 1) and (1, 2) will drop. So we should return 2.

        Example 2:
        Input: 
        grid = [[1,0,0,0],[1,1,0,0]]
        hits = [[1,1],[1,0]]
        Output: [0,0]
        Explanation: When we erase the brick at (1, 0), the brick at (1, 1) has already disappeared due to the last move. 
        So each erasure will cause no bricks dropping.  Note that the erased brick (1, 0) will not be counted as a dropped brick.
    */
    class BricksFallingWhenHit
    {
        public int[] HitBricks(int[][] grid, int[][] hits) {
            int[] result = new int[hits.Length];

            /*
                1. Mark all the hits on the grid before starting to find the connected component (i.e. the bricks connected to the roof)
                We need to be able to differentiate if the hit had a 1 or 0 in the initial grid. 
                We will use -1 if the hit on the grid had a 0 and 0 if the hit on the grid had a 1.

                2. Find the connected component (i.e. the bricks connected to the roof). For this we only need to do a DFS from every 
                point on the first row of the grid. We will use '2' to indicate the connected component

                3. Going in the reverse order of the hits, we start placing the bricks in the hits back in the grid.
                 If the hit point in the grid had a 0, we have nothing to do.
                 If hit point had a 1, then we need to see if the hit point is connected to the connected component.
                 If it is connected, then removal of this brick will not cause any other bricks to fall.
                 If not, we calculat the size of the connected component again and subtract the initial size of the connected 
                 component from it.
            */

            // Step 1
            for (int h = 0; h < hits.Length; h++) {
                int i = hits[h][0];
                int j = hits[h][1];
                grid[i][j]--;
            }

            // Step 2
            for (int j = 0; j < grid[0].Length; j++) {
                this.DoDFS(grid, 0, j);
            }

            // Step 3
            for (int h = hits.Length - 1; h >= 0; h--) {
                int i = hits[h][0];
                int j = hits[h][1];

                grid[i][j]++; // restore the brick
                if (grid[i][j] == 1 && this.IsConnected(grid, i, j))
                    result[h] = DoDFS(grid, i, j) - 1; // -1 to not count the hit brick
            }

            return result;
        }

        private int DoDFS(int[][] grid, int i, int j) {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] != 1) return 0;
            grid[i][j] = 2;
            int ret = 1;
            ret += this.DoDFS(grid, i - 1, j);
            ret += this.DoDFS(grid, i + 1, j);
            ret += this.DoDFS(grid, i, j - 1);
            ret += this.DoDFS(grid, i, j + 1);
            return ret;
        }

        private bool IsConnected(int[][] grid, int i, int j) {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length) return false;
            if (i == 0) return true;
            if (i - 1 >=0 && grid[i - 1][j] == 2) return true;
            if (i + 1 < grid.Length && grid[i + 1][j] == 2) return true;
            if (j - 1 >= 0 && grid[i][j - 1] == 2) return true;
            if (j + 1 < grid[0].Length && grid[i][j + 1] == 2) return true;
            return false;
        }
    }
}