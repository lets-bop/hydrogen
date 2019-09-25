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
        HashSet<int> processed = new HashSet<int>();
        public void Solve(char[,] board) {
            processed.Clear();
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            // mark all the 'O' in the borders with '#' (processed) as they cannot be surrounded by 'X'
            for (int i = 0; i < rows; i++){
                for (int j = 0; j < cols; j++){
                    if (i == 0 || i == rows - 1 || j == 0 || j == cols - 1){
                        if (board[i,j] == 'O') board[i,j] = '#';
                    }
                }
            }

            // Any 0 connected to a 0 on the border cannot be surrounded either.
            // So we merge all the 0 connected to a 0 on the border
            for (int i = 0; i < rows; i++){
                for (int j = 0; j < cols; j++){
                    if (board[i,j] == '#'){
                        this.Merge(board, rows, cols, i, j);
                    }
                }
            }

            // The remainder of all 0 can be marked as surrounded
            for (int i = 0; i < rows; i++){
                for (int j = 0; j < cols; j++){
                    if (board[i,j] == 'O') board[i,j] = 'X';
                }
            }
            
            // Remark 0s on borders and connected 0's with 0
            for (int i = 0; i < rows; i++){
                for (int j = 0; j < cols; j++){
                    if (board[i,j] == '#') board[i,j] = 'O';
                }
            }
        }
        
        private void Merge(char[,] board, int rows, int cols, int row, int col){
            if (row >= 0 && row < rows && col >= 0 && col < cols){
                if (this.processed.Contains(row * cols + col)) 
                    return;

                this.processed.Add(row * cols + col);
                if (board[row, col] == 'X') 
                    return;

                board[row, col] = '#';
                this.Merge(board, rows, cols, row + 1, col);
                this.Merge(board, rows, cols, row - 1, col);
                this.Merge(board, rows, cols, row, col + 1);
                this.Merge(board, rows, cols, row, col - 1);
            }
        }        
    }
}