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
        int[] dr = new int[] {-1, 1, 0, 0};
        int[] dc = new int[] {0, 0, -1, 1};
        int maxRows = 0, maxCols = 0;

        public bool Exist(char[][] board, string word) {
            if (string.IsNullOrEmpty(word)) return false;
            maxRows = board.Length;
            maxCols = board[0].Length;
            for(int i = 0; i < maxRows; i++){
                for(int j = 0; j < maxCols; j++){
                    if (this.DFS(board, word, 0, i, j)) return true;
                }
            }

            return false;
        }

        private bool DFS(char[][] board, string word, int index, int r, int c) {
            if (r < 0 || r >= maxRows || c < 0 || c >= maxCols || board[r][c] != word[index]) return false;
            if (index == word.Length - 1) return true;

            char cTemp = board[r][c];
            board[r][c] = '#';
            for (int k = 0; k < 4; k++) {
                if (DFS(board, word, index + 1, r + dr[k], c + dc[k])) {
                    board[r][c] = cTemp;
                    return true;
                }
            }

            board[r][c] = cTemp;
            return false;
        }
    }
}