using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    /*
        Given a 2D board containing 'X' and 'O' (the letter O), capture all regions surrounded by 'X'.
        A region is captured by flipping all 'O's into 'X's in that surrounded region.

        Example:
        X X X X
        X O O X
        X X O X
        X O X X

        After running your function, the board should be:
        X X X X
        X X X X
        X X X X
        X O X X

        Explanation: Surrounded regions shouldn’t be on the border, which means that any 'O' 
        on the border of the board are not flipped to 'X'. Any 'O' that is not on the border 
        and it is not connected to an 'O' on the border will be flipped to 'X'. 
        Two cells are connected if they are adjacent cells connected horizontally or vertically.
    */
    public class SurroundedRegion
    {
        // 1st iteration: From all the border cells that contains 'O', perform a DFS to merged the cells
        // 2nd iteration: For all 'O' that weren't merged post iteration 1 are safe to marked 'X'
        public void Solve(char[][] board) {
            if (board == null || board.Length == 0) return;

            int rows = board.Length, cols = board[0].Length;
            HashSet<int> merged = new HashSet<int>();
            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    if (r == 0 || r == rows - 1 || c == 0 || c == cols - 1) {
                        if (board[r][c] == 'O') this.DFS(board, r, c, rows, cols, merged);
                    }
                }
            }

            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    if (board[r][c] == 'O' && !merged.Contains(r * cols + c)) board[r][c] = 'X';
                }
            }
        }

        private void DFS(char[][] board, int r, int c, int rows, int cols, HashSet<int> merged) {
            if (merged.Contains(r * cols + c)) return;
            merged.Add(r * cols + c);

            int[] dr = new int[] {-1,1,0,0};
            int[] dc = new int[] {0,0,-1,1};

            for(int i = 0; i < 4; i++) {
                int nr = dr[i] + r;
                int nc = dc[i] + c;

                if (nr < 0 || nr >= rows || nc < 0 || nc >= cols || board[nr][nc] != 'O') continue;
                if (!merged.Contains(nr * cols + nc)) {
                    this.DFS(board, nr, nc, rows, cols, merged);
                }
            }
        }
    }
}