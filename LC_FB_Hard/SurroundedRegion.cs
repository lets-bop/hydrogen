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
            char[,] board1 = new char[rows, cols];
            Array.Copy(board, board1, rows * cols);

            for (int i = 0; i < rows; i++){
                for (int j = 0; j < cols; j++){
                    if (i == 0 || i == rows - 1 || j == 0 || j == cols - 1){
                        if (board[i,j] == 'O') board[i,j] = '?';
                    }

                    if (board[i,j] == 'O' && (this.Check(board, rows, cols, i-1, j) || this.Check(board, rows, cols, i, j-1))) board[i,j] = '?';
                }
            }         

            for (int i = 0; i < rows; i++){
                for (int j = 0; j < cols; j++)
                if (!processed.Contains(i * cols + j) && board[i,j] == 'O')
                    this.Rec(board, rows, cols, i, j);
            }

            for (int i = 0; i < rows; i++){
                for (int j = 0; j < cols; j++){
                    if (board[i,j] == '?') board[i,j] = board1[i,j];
                }
            }              
        }

        private bool Check(char[,] board, int rows, int cols, int row, int col){
            if (row < 0 || row >= rows || col < 0 || col >= cols || board[row, col] != '?') return false;
            return true;
        }
        
        private bool Rec(char[,] board, int rows, int cols, int row, int col){
            this.processed.Add(row * cols + col);
            if (row >= 0 && row < rows && col >= 0 && col < cols){
                if (board[row, col] == 'X') return true;
                if (board[row, col] == '?') return false;
                bool check = true;
                if (!this.processed.Contains((row+1) * cols + col)) check = this.Rec(board, rows, cols, row + 1, col);
                if (!check) return false;
                if (!this.processed.Contains((row-1) * cols + col)) check = this.Rec(board, rows, cols, row - 1, col);
                if (!check) return false;
                if (!this.processed.Contains(row * cols + col + 1)) check = this.Rec(board, rows, cols, row, col + 1);
                if (!check) return false;
                if (!this.processed.Contains(row * cols + col - 1)) check = this.Rec(board, rows, cols, row, col - 1);
                if (!check) return false;
                board[row, col] = 'X';
            }

            return false;
        }
    }
}