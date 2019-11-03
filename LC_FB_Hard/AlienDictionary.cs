/*
There is a new alien language which uses the latin alphabet. However, the order among letters are unknown to you. 
You receive a list of non-empty words from the dictionary, 
where words are sorted lexicographically by the rules of this new language. Derive the order of letters in this language.

Example 1:

Input:
[
  "wrt",
  "wrf",
  "er",
  "ett",
  "rftt"
]

Output: "wertf"
Example 2:

Input:
[
  "z",
  "x"
]

Output: "zx"
Example 3:

Input:
[
  "z",
  "x",
  "z"
] 

Output: "" 

Explanation: The order is invalid, so return "".
Note:

You may assume all letters are in lowercase.
You may assume that if a is a prefix of b, then a must appear before b in the given dictionary.
If the order is invalid, return an empty string.
There may be multiple valid order of letters, return any one of them is fine.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class AlienDictionary
    {
      Dictionary<char, HashSet<char>> graph;
      Dictionary<char, int> inDegree;
        public string AlienOrder(string[] words)
        {
          /*
          A few things to note are:
            1. We need to compare the letters across 2 consecutive words only 
            2. Order of letters in a given word alone doesn't mean anything
            
            We'll proceed by building a graph (Dictionary where key is the letter and value are the neighboring letters).
            We'll also maintain a dictionary called inDegree which holds the number of incoming edges.
            Naturally, the first char will have no letters pointing to it and will have an inDegree of 0.
            Once the graph is built, we'll just use a topological sort to find the right order.
            Topological sort will begin by selecting the letters that have no incoming edges,
            and proceed by reducing the inDegree of its adjacent letters and adding them to the queue if their inDegree = 0.
          */
          if (words!= null && words.Length == 1) return words[0];
          this.BuildGraph(words);
          return this.TopologicalBFS();
        }

        private void BuildGraph(string[] words) {
          graph = new Dictionary<char, HashSet<char>>();
          inDegree = new Dictionary<char, int>();

          for (int i = 0; i < words.Length - 1; i++) {
            int cIndex = 0;
            char c1, c2;
            while (cIndex < words[i].Length && cIndex < words[i+1].Length) {
              c1 = words[i][cIndex];
              c2 = words[i + 1][cIndex];
              if (!inDegree.ContainsKey(c1)) inDegree[c1] = 0;
              if (!inDegree.ContainsKey(c2)) inDegree[c2] = 0;

              if (c1 != c2) {
                if (!graph.ContainsKey(c2)) graph[c2] = new HashSet<char>();
                if (!graph.ContainsKey(c1)) graph[c1] = new HashSet<char>();

                if (!graph[c1].Contains(c2)) {
                  graph[c1].Add(c2);
                  inDegree[c2]++;
                }

                break;
              }

              cIndex++;
            }

            int c1Index = cIndex;
            int c2Index = cIndex;

            // Set the inDegree for the remainder of the characters in words(i) and words(i+1) to 0
            while (c1Index < words[i].Length) {
              c1 = words[i][c1Index];
              if (!inDegree.ContainsKey(c1)) inDegree[c1] = 0;
              c1Index++;
            }

            while (c2Index < words[i + 1].Length) {
              c2 = words[i + 1][c2Index];
              if (!inDegree.ContainsKey(c2)) inDegree[c2] = 0;
              c2Index++;
            }
          }
        }

        private string TopologicalBFS() {
          StringBuilder sb = new StringBuilder();
          Queue<char> queue = new Queue<char>();

          // Find the node with no dependencies (inDegree == 0)
          foreach (var kv in inDegree) if (kv.Value == 0) queue.Enqueue(kv.Key);

          while (queue.Count > 0) {
            char poppedChar = queue.Dequeue();
            sb.Append(poppedChar);
            if (graph.ContainsKey(poppedChar)) {
              foreach (char c in graph[poppedChar]) {
                inDegree[c]--;
                if (inDegree[c] == 0) queue.Enqueue(c);
              }
            }
          }

          // inDegree contains characters present in all words
          if (sb.Length != inDegree.Count) return string.Empty;
          return sb.ToString();
        }
    }
}