/*
Given an integer matrix, find the length of the longest increasing path.

From each cell, you can either move to four directions: left, right, up or down. 
You may NOT move diagonally or move outside of the boundary (i.e. wrap-around is not allowed).

Example 1:

Input: nums = 
[
  [9,9,4],
  [6,6,8],
  [2,1,1]
] 
Output: 4 
Explanation: The longest increasing path is [1, 2, 6, 9].
Example 2:

Input: nums = 
[
  [3,4,5],
  [3,2,6],
  [2,2,1]
] 
Output: 4 
Explanation: The longest increasing path is [3, 4, 5, 6]. Moving diagonally is not allowed.

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class LongestIncreasingPathMatrix
    {
        Dictionary<int, int> mem = new Dictionary<int, int>();

        public int LongestIncreasingPath(int[,] matrix)
        {
            int longest = 0;

            if(matrix == null) return longest;
            
            int rowSize = matrix.GetLength(0);
            int colSize = matrix.GetLength(1);            

            for(int i = 0; i < rowSize; i++){
                for (int j = 0; j < colSize; j++){
                    if(!this.mem.ContainsKey(i * colSize + j))
                        longest = Math.Max(longest, this.DFS(matrix, i, j, 1));
                    else longest = Math.Max(longest, this.mem[i * colSize + j]);
                }
            }

            return longest;           
        }

        private int DFS(int[,] matrix, int row, int col, int currentLength)
        {
            int rowSize = matrix.GetLength(0);
            int colSize = matrix.GetLength(1);

            if(this.mem.ContainsKey(row * colSize + col)) 
                return this.mem[row * colSize + col];
                
            int maxLength = currentLength;
            List<Tuple<int, int>> list = new List<Tuple<int, int>>();
            list.Add(new Tuple<int, int>(row + 1, col));
            list.Add(new Tuple<int, int>(row - 1, col));
            list.Add(new Tuple<int, int>(row, col + 1));
            list.Add(new Tuple<int, int>(row, col - 1));

            foreach (Tuple<int, int> t in list){
                if(this.IsRowColValid(matrix, t.Item1, t.Item2, rowSize, colSize) && matrix[row, col] < matrix[t.Item1, t.Item2]){
                    int length;
                    if(this.mem.ContainsKey(t.Item1 * colSize + t.Item2))
                        length = mem[t.Item1 * colSize + t.Item2];
                    else 
                        length = this.DFS(matrix, t.Item1, t.Item2, 1);

                    maxLength = Math.Max(maxLength, currentLength + length);
                }
            }

            this.mem[row * matrix.GetLength(1) + col] = maxLength;
            return maxLength;
        }

        private bool IsRowColValid(int[,] matrix, int row, int col, int rowSize, int colSize){
            if(row < 0 || col < 0 ||row >= rowSize || col >= colSize) return false;
            return true;
        }
    }
}