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
        List<int> neighbors = new List<int>();
        HashSet<int> landIds = new HashSet<int>();
        HashSet<int> connectedLandIds = new HashSet<int>();
        
        public IList<int> NumIslands2(int m, int n, int[,] positions) 
        {
            List<int> result = new List<int>();
            UnionFind uf = new UnionFind(m * n);
            List<int> neighbors = new List<int>();

            for (int i = 0; i < positions.GetLength(0); i++)
            {
                int row = positions[i, 0];
                int col = positions[i, 1];

                int elementId = row * n + col;
                this.landIds.Add(elementId);
                int myRoot = uf.Find(elementId);
                this.connectedLandIds.Add(myRoot);

                neighbors.Add((row+1) * n + col);
                neighbors.Add((row-1) * n + col);
                neighbors.Add(row * n + (col+1));
                neighbors.Add(row * n + (col-1));

                foreach(int neighborId in neighbors){
                    if(this.landIds.Contains(neighborId)){
                        myRoot = uf.Find(elementId);
                        int neighborRoot = uf.Find(neighborId);
                        this.connectedLandIds.Add(myRoot);
                        this.connectedLandIds.Add(neighborRoot);
                        uf.Union(elementId, neighborId);

                        if(uf.Find(elementId) != myRoot) this.connectedLandIds.Remove(myRoot);
                        else if(uf.Find(neighborId) != neighborRoot) this.connectedLandIds.Remove(neighborRoot);
                    }
                }

                result.Add(this.connectedLandIds.Count);
                Console.WriteLine("Number of islands = " + this.connectedLandIds.Count);
                neighbors.Clear();
            }

            return result;
        }     
    }    
}