using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class SurroundedRegion
    {    
        HashSet<int> processed = new HashSet<int>();
        public void Solve(char[,] board) {
            processed.Clear();
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            for (int i = 0; i < rows; i++){
                for (int j = 0; j < cols; j++){
                    if (i == 0 || i == rows - 1 || j == 0 || j == cols - 1){
                        if (board[i,j] == 'O') board[i,j] = '#';
                    }
                }
            }

            for (int i = 0; i < rows; i++){
                for (int j = 0; j < cols; j++){
                    if (board[i,j] == '#'){
                        this.Merge(board, rows, cols, i, j);
                    }
                }
            }       

            for (int i = 0; i < rows; i++){
                for (int j = 0; j < cols; j++){
                    if (board[i,j] == 'O') board[i,j] = 'X';
                }
            }
            

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