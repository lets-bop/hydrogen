/*
Given a 2D board and a list of words from the dictionary, find all words in the board.

Each word must be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. The same letter cell may not be used more than once in a word.

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
    public class WordSearch
    {
        public IList<string> FindWords(char[,] board, string[] words) {
            
            Trie trie = new Trie();
            List<string> wordsFound = new List<string>();
            foreach (string word in words) trie.AddWord(word);

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    wordsFound.AddRange(trie.DoDFS(board, board.GetLength(0), board.GetLength(1), i, j));
                }
            }

            return wordsFound;
        }

        public class Trie
        {
            internal TrieNode Root = new TrieNode();

            internal class TrieNode
            {
                internal TrieNode[] Children = new TrieNode[128];
                internal bool IsTerminal = false;
            }

            public void AddWord(string s)
            {
                this.AddWord(s, this.Root, 0);
            }

            private void AddWord(string s, TrieNode root, int index)
            {
                if (s == null || index > s.Length) return;                
                if (index == s.Length){ 
                    root.IsTerminal = true;
                    return;
                }

                char currentChar = s[index];
                int ascii = currentChar;
                if (root.Children[ascii] == null) root.Children[ascii] = new TrieNode();
                this.AddWord(s, root.Children[ascii], index + 1);
            }

            public IList<string> DoDFS(char[,] board, int rows, int cols, int rowIndex, int colIndex)
            {
                List<string> wordsFound = new List<string>();
                this.DoDFS(board, rows, cols, rowIndex, colIndex, this.Root, wordsFound, new StringBuilder());
                return wordsFound;
            }

            private void DoDFS(char[,] board, int rows, int cols, int rowIndex, int colIndex, TrieNode node, List<string> wordsFound, StringBuilder wordSoFar)
            {
                if (!this.IsIndexValid(board, rows, cols, rowIndex, colIndex)) return;

                char currentChar = board[rowIndex, colIndex];
                int ascii = board[rowIndex, colIndex];

                if (node.Children[ascii] == null) return;

                wordSoFar.Append(currentChar);
                if (node.Children[ascii].IsTerminal) wordsFound.Add(wordSoFar.ToString());
                
                board[rowIndex, colIndex] = '#';                
                this.DoDFS(board, rows, cols, rowIndex, colIndex + 1, node.Children[ascii], wordsFound, wordSoFar);
                this.DoDFS(board, rows, cols, rowIndex + 1, colIndex, node.Children[ascii], wordsFound, wordSoFar);
                this.DoDFS(board, rows, cols, rowIndex, colIndex - 1, node.Children[ascii], wordsFound, wordSoFar);
                this.DoDFS(board, rows, cols, rowIndex - 1, colIndex, node.Children[ascii], wordsFound, wordSoFar);
                board[rowIndex, colIndex] = currentChar;
            }

            private bool IsIndexValid(char[,] board, int rows, int cols, int rowIndex, int colIndex)         
            {
                if (rowIndex < 0 || colIndex < 0 || rowIndex >= rows || colIndex >= cols || board[rowIndex, colIndex] == '#') return false;
                return true;
            }            
        }
    }
}