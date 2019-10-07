using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        You are given a m x n 2D grid initialized with these three possible values.

        -1 - A wall or an obstacle.
        0 - A gate.
        INF - Infinity means an empty room. We use the value 231 - 1 = 2147483647 to represent INF as you may assume that the distance to a gate is less than 2147483647.
        
        Fill each empty room with the distance to its nearest gate. 
        If it is impossible to reach a gate, it should be filled with INF.

        Example: Given the 2D grid
        INF  -1  0  INF
        INF INF INF  -1
        INF  -1 INF  -1
        0  -1 INF INF

        After running your function, the 2D grid should be:
        3  -1   0   1
        2   2   1  -1
        1  -1   2  -1
        0  -1   3   4
    */
    class WallsAndGates
    {
    
        int[] dr = new int[] {-1,1,0,0};
        int[] dc = new int[] {0,0,-1,1};
        
        public void Find(int[][] rooms) {
            // validate input
            if (rooms == null || rooms.Length == 0) return;
            int rows = rooms.Length;
            int cols = rooms[0].Length;
            
            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    if (rooms[r][c] == 0) this.DFS(rooms, r, c, rows, cols, 0);
                }
            }
        }
        
        private void DFS(int[][] rooms, int r, int c, int rows, int cols, int distance) {
            rooms[r][c] = distance;
            for (int k = 0; k < 4; k++) {
                int nr = this.dr[k] + r; //neighboring row
                int nc = this.dc[k] + c; //neighboring col
                
                if (nr >=0 && nc >= 0 && nr < rows && nc < cols && rooms[nr][nc] > rooms[r][c] + 1) {
                    this.DFS(rooms, nr, nc, rows, cols, distance + 1);
                }
            }
        }
    }
}