/*
Given a 2D board and a list of words from the dictionary, find all words in the board.

Each word must be constructed from letters of sequentially adjacent cell, 
where "adjacent" cells are those horizontally or vertically neighboring. 
The same letter cell may not be used more than once in a word.

Example:

Input: 
words = ["oath","pea","eat","rain"] and board =
[
  ['o','a','a','n'],
  ['e','t','a','e'],
  ['i','h','k','r'],
  ['i','f','l','v']
]

Output: ["eat","oath"]

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class WordSearch2
    {
        Trie trie;
        char[][] board;
        int rows;
        int cols;
        int[] dr = new int[] {-1,1,0,0};
        int[] dc = new int[] {0,0,-1,1};
        public IList<string> FindWords(char[][] board, string[] words) {
            
            this.trie = new Trie();
            this.rows = board.Length;
            this.cols = board[0].Length;
            this.board = board;

            HashSet<string> wordsFound = new HashSet<string>();
            foreach (string word in words) trie.AddWord(word);

            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    char currentChar = board[r][c];
                    if (trie.Root.Children[currentChar - 'a'] != null)
                        this.DoDFS(r, c, trie.Root.Children[currentChar - 'a'], wordsFound, currentChar.ToString());
                }
            }

            List<string> result = new List<string>(wordsFound);
            return result;
        }

        private void DoDFS(
            int r,
            int c,
            Trie.TrieNode node,
            HashSet<string> wordsFound,
            string wordSoFar)
        {
            if (node.IsTerminal) wordsFound.Add(wordSoFar);
            char currentChar = board[r][c];
            board[r][c] = '#';

            for (int k = 0; k < 4; k++) {
                int nr = r + dr[k]; //neighboring row
                int nc = c + dc[k]; //neighboring col
                if (nr < 0 || nc < 0 || nr >= rows || nc >= cols || board[nr][nc] == '#') continue;
                char neighborChar = board[nr][nc];
                if (node.Children[neighborChar - 'a'] == null) continue;
                this.DoDFS(nr, nc, node.Children[neighborChar - 'a'], wordsFound, wordSoFar + neighborChar);
            }

            board[r][c] = currentChar;
        }

        internal class Trie
        {
            internal TrieNode Root = new TrieNode();

            internal class TrieNode
            {
                internal TrieNode[] Children = new TrieNode[26];
                internal bool IsTerminal = false;
            }

            public void AddWord(string s)
            {
                // this.AddWord(s, this.Root, 0);
                if (s == null || s.Length == 0) return;

                TrieNode node = this.Root;
                int idx = 0;
                for (int i = 0; i < s.Length; i++) {
                    idx = s[i] - 'a';
                    if (node.Children[idx] == null) node.Children[idx] = new TrieNode();
                    node = node.Children[idx];
                    if (i == s.Length - 1) node.IsTerminal = true;
                }
            }
        }
    }
}