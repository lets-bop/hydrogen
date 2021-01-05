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
                A simple approach is for each hit, denote the bricks connected to the 
                top row by performing a DFS from every brick on the top row, and 
                count the bricks that are not connected to the top row. But this exceeds time limit.

                1. Mark all the hits on the grid before starting to find the connected component (i.e. the bricks connected to the roof)
                We need to be able to differentiate if the hit had a 1 or 0 in the initial grid. 
                We will just subtract 1 from each hit in the grid. 
                Hence each hit point in the grid will result in 0 if the grid had 1 and -1 if it had 0.

                2. Find all the bricks connected to the roof. Do a DFS from every 
                point on the first row of the grid == 1. We will use '2' to indicate this connected component

                3. Going in the reverse order of the hits, we start placing the bricks in the hits back in the grid.
                 If the hit point in the grid had a 0, we have nothing to do.
                 If hit point had a 1 is connected to the roof, then we need to find the count of all cells with 1 that can be reached 
                 from this grid and add them to a connected component (mark with 2) just as in step 2.
                 Else, we'll leave that cell as is with 1 and could get cleaned up (hit) by other earlier hits.
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
            // returns true if any of the neighbors has a 2 (connected to the roof)
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

/*
Example:
Input:
    1  0  1  1
    1  1  1  1
    0  1  1  0
    1  1  0  0
Hits: (2,2) (1,2) (1,1) (2,3)

We need to form connected components of all 1's that are connected to the top layer. But before doing that,
we need to exclude the points that are hit. Why? If we connected up all 1's in the grid that are connected 
to the top layer before removing the hit points, and then start processing the hits, then for each of its 
neighbors that's a 1, we need to see if there is path connecting it to top layer after the hit. 
i.e. we need to determine whether the path to the top layer is only via the point getting hit currently, 
or if there were other redundant paths to the top layer. This can very easily become a costly operation.
Hence we first start by removing all the points that are getting hit and then form the conencted comp.
And then begin calculating the points that will drop because of the eaach of the hits.
But we need to process the hit points in the reverse direction. Why?

We need to know if a hit point that is coming later in the order of hit points given was already
hit (lost) because of previous hit. Hence we reinstate the hit points in the reverse order and 
connect them up to the connected component (connected to the top layer) if any of its neighbors
are connected to the top layer. 


    1. Remove all the points that are hit by subtracting 1 from the hits points
    1  0  1  1
    1  0  0  1
    0  1  0 -1
    1  1  0  0

    2. Form connected components of the grid points connected to the top layer. 
    We indicate connected components with a 2 to distinguish from 1's and 0's
    2  0  2  2
    2  0  0  2
    0  1  0 -1
    1  1  0  0

    3. Reinstate the hit points 1 at a time (in reverse order). Why reverse order?
        We could have take the approach of marking 
        a. (2,3) Since it was a 0 (-1 currently) to begin with, convert back to 0 and do nothing
            2  0  2  2
            2  0  0  2
            0  1  0  0
            1  1  0  0
        b. (1,1) Since at least 1 of its neigbhors is part of the connected component 
        (connected to top layer), we will do a DFS to connect the points up and return 
        the # of points that are connected. DoDFS will return 4. i.e. 3 points were hit.
            2  0  2  2
            2  2  0  2
            0  2  0  0
            2  2  0  0
        c. (1,2) Since at least 1 of its neigbhors is part of the connected component 
        (connected to top layer), we will do a DFS to connect the points up and return 
        the # of points that are connected. DoDFS will return 1. i.e. 0 points were hit.
            2  0  2  2
            2  2  2  2
            0  2  0  0
            2  2  0  0
        d. (2,2) Since at least 1 of its neigbhors is part of the connected component 
        (connected to top layer), we will do a DFS to connect the points up and return 
        the # of points that are connected. DoDFS will return 1. i.e. 0 points were hit.
            2  0  2  2
            2  2  2  2
            0  2  2  0
            2  2  0  0

*/