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
        int[] dr = new int[] {-1, 1, 0, 0};
        int[] dc = new int[] {0, 0, -1, 1};
        Dictionary<int, int> indexToMaxPathLengthMap = new Dictionary<int, int>();
        
        public int LongestIncreasingPath(int[][] matrix) {
            // validate input
            if (matrix == null || matrix.Length == 0) return 0;
            
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int result = 1;
            indexToMaxPathLengthMap.Clear();
            
            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    result = Math.Max(result, this.DFS(matrix, r, c, rows, cols));
                }
            }
            
            return result;
        }
        
        private int DFS(int[][] matrix, int r, int c, int maxR, int maxC) {
            if (r < 0 || c < 0 || r >= maxR || c >= maxC) return 0;
            
            int result = 1;
            for (int k = 0; k < 4; k++) {
                int nr = r + dr[k]; // neighbor row
                int nc = c + dc[k]; // neighbor col
                
                if (nr >= 0 && nc >= 0 && nr < maxR && nc < maxC && matrix[nr][nc] > matrix[r][c]) {
                    if (!this.indexToMaxPathLengthMap.ContainsKey(r * maxC + c))
                        result = Math.Max(this.DFS(matrix, nr, nc, maxR, maxC) + 1, result);
                    else result = Math.Max(this.indexToMaxPathLengthMap[r * maxC + c], result);
                }
            }
            
            this.indexToMaxPathLengthMap[r * maxC + c] = result;
            return result;
        }
    }
}