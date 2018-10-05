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
        public int NumIslands(char[,] grid)
        {
            int result = 0;
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            for(int i = 0; i < rows; i++){
                for(int j = 0; j < cols; j++){
                    if(grid[i,j] == '0') 
                        continue;

                    result++;
                    this.BFS(grid, i, j, rows, cols);
                }
            }

            return result;
        }

        public void BFS(char[,] grid, int x, int y, int rows , int cols)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(x * cols + y);
            grid[x, y] = '0';

            while(queue.Count > 0){
                int entry = queue.Dequeue();
                int row = entry / cols;
                int col = entry % cols;

                if (this.IsValid(grid, row + 1, col, rows, cols)){
                    grid[row + 1, col] = '0';
                    queue.Enqueue((row + 1) * cols + col);
                }
                if (this.IsValid(grid, row - 1, col, rows, cols)){
                    grid[row - 1, col] = '0';
                    queue.Enqueue((row - 1) * cols + col);
                }
                if (this.IsValid(grid, row, col + 1, rows, cols)){
                    grid[row, col + 1] = '0';
                    queue.Enqueue(row * cols + col + 1);
                }
                if (this.IsValid(grid, row, col - 1, rows, cols)){
                    grid[row, col - 1] = '0';
                    queue.Enqueue(row * cols + col - 1);
                }
            }
        }

        private bool IsValid(char[,] grid, int x, int y, int rows, int cols){
            if(x >= 0 && x < rows &&
                y >= 0 && y < cols && 
                grid[x, y] == '1')
                    return true;
            return false;
        }
    }
}