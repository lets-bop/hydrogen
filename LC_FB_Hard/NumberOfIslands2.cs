/*
A 2d grid map of m rows and n columns is initially filled with water. 
We may perform an addLand operation which turns the water at position (row, col) into a land. 
Given a list of positions to operate, count the number of islands after each addLand operation. 
An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. 
You may assume all four edges of the grid are all surrounded by water.

Example:

Input: m = 3, n = 3, positions = [[0,0], [0,1], [1,2], [2,1]]
Output: [1,1,2,3]
Explanation:

Initially, the 2d grid grid is filled with water. (Assume 0 represents water and 1 represents land).

0 0 0
0 0 0
0 0 0
Operation #1: addLand(0, 0) turns the water at grid[0][0] into a land.

1 0 0
0 0 0   Number of islands = 1
0 0 0
Operation #2: addLand(0, 1) turns the water at grid[0][1] into a land.

1 1 0
0 0 0   Number of islands = 1
0 0 0
Operation #3: addLand(1, 2) turns the water at grid[1][2] into a land.

1 1 0
0 0 1   Number of islands = 2
0 0 0
Operation #4: addLand(2, 1) turns the water at grid[2][1] into a land.

1 1 0
0 0 1   Number of islands = 3
0 1 0
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class NumberOfIslands2
    {
        public IList<int> NumIslands2(int m, int n, int[][] positions) 
        {
            HashSet<int> landIds = new HashSet<int>();
            List<int> result = new List<int>();
            UF uf = new UF(m * n);
            int[] dr = new int[] {-1, 1, 0, 0};
            int[] dc = new int[] {0, 0, -1, 1};
            int count = 0;

            foreach (int[] position in positions)
            {
                int row = position[0];
                int col = position[1];
                int id = row * n + col;
                if (!landIds.Contains(id)) count++;
                landIds.Add(id);

                for(int k = 0; k < 4; k++) {
                    int r =  dr[k] + row;
                    int c =  dc[k] + col;
                    int neighbor_id = r * n + c;
                    if (r >= 0 && c >=0 && r < m && c < n && landIds.Contains(neighbor_id)) {
                        if (uf.Root(id) != uf.Root(neighbor_id)) {
                            count--;
                            uf.Union(id, neighbor_id);
                        }
                    }
                }

                result.Add(count);
            }

            return result;
        }
    }    
}