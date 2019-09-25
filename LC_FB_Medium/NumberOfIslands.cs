/*
Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. 
An island is surrounded by water and is formed by connecting adjacent lands 
horizontally or vertically. You may assume all four edges of the grid are 
all surrounded by water.

Example 1:

Input:
11110
11010
11000
00000

Output: 1
Example 2:

Input:
11000
11000
00100
00011

Output: 3
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class NumberOfIslands
    {
        public int NumIslands(char[][] grid) {
            // validate the input
            if (grid == null || grid.Length == 0) return 0;

            int islands = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;

            /*
            Linear scan the 2d grid map, if a node contains a '1', 
            then it is a root node that triggers a Breadth First Search. 
            Put it into a queue and set its value as '0' to mark as visited node. 
            Iteratively search the neighbors of enqueued nodes until the queue becomes empty.
            */
            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    Queue<int> queue = new Queue<int>();
                    if (grid[r][c] == '1') {
                        islands++;
                        queue.Enqueue(r * cols + c);
                        this.BFS(grid, queue, rows, cols);
                    }
                }
            }

            return islands; 
        }

        // time complexity is O(M*N). Space is O(Min(M,N))
        public void BFS(char[][] grid, Queue<int> queue, int rows, int cols)
        {
            int[] dr = new int[] {-1,1,0,0};
            int[] dc = new int[] {0,0,-1,1};

            while(queue.Count > 0){
                int entry = queue.Dequeue();
                int r = entry / cols;
                int c = entry % cols;
                grid[r][c] = '0';

                for (int k = 0; k < 4; k++) {
                    int nr = r + dr[k];
                    int nc = c + dc[k];
                    if (nr >= 0 && nc >=0 && nc < cols && nr < rows && grid[nr][nc] == '1')
                    queue.Enqueue(nr * cols + nc);
                }
            }
        }
    }
}