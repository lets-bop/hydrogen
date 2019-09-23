/*
Given a 2D board and a word, find if the word exists in the grid.

The word can be constructed from letters of sequentially adjacent cell, 
where "adjacent" cells are those horizontally or vertically neighboring. 
The same letter cell may not be used more than once.

Example:

board =
[
  ['A','B','C','E'],
  ['S','F','C','S'],
  ['A','D','E','E']
]

Given word = "ABCCED", return true.
Given word = "SEE", return true.
Given word = "ABCB", return false.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class WordSearch
    {
        public bool Exist(char[][] board, string word) {
            if (string.IsNullOrEmpty(word)) return false;
            int rows = board.Length;
            int cols = board[0].Length;
            for(int i = 0; i < rows; i++){
                for(int j = 0; j < cols; j++){
                    if(board[i][j] == word[0]){
                        if (this.DFS(board, word, 0, i, j, rows, cols))
                            return true;
                    }
                }
            }

            return false;
        }

        private bool DFS(char[][] board, string word, int wIndex, int row, int col, int rows, int cols){
            bool result = false;
            if(wIndex == word.Length) return true;
            if(row < 0 || row >= rows || col < 0 || col >= cols) return false;
            if(board[row][col] == word[wIndex]){
                char temp = board[row][col];
                board[row][col] = '#';
                result =  
                    this.DFS(board, word, wIndex+1, row+1, col, rows, cols) ||
                    this.DFS(board, word, wIndex+1, row-1, col, rows, cols) ||
                    this.DFS(board, word, wIndex+1, row, col+1, rows, cols) ||
                    this.DFS(board, word, wIndex+1, row, col-1, rows, cols);
                board[row][col] = temp;
            }

            return result;
        }
    }
}