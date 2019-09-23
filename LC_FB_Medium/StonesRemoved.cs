using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
        On a 2D plane, we place stones at some integer coordinate points. 
        Each coordinate point may have at most one stone.
        Now, a move consists of removing a stone that shares a column or row with 
        another stone on the grid. What is the largest possible number of moves we can make?

        Example 1:
        Input: stones = [[0,0],[0,1],[1,0],[1,2],[2,1],[2,2]]
        Output: 5
        Example 2:
        Input: stones = [[0,0],[0,2],[1,1],[2,0],[2,2]]
        Output: 3
        Example 3:
        Input: stones = [[0,0]]
        Output: 0
    */
    class StonesRemoved
    {

        public int RemoveStones(int[][] stones) {
            // Since 0 <= stones[i][j] < 10000, we can use 1 array of size 20000
            // and connect up the to solve the problem in O(N lg N)
            UF uf = new UF(20000);
            for (int i = 0; i < stones.Length; i++) {
                uf.Union(stones[i][0], stones[i][1] + 10000);
            }

            HashSet<int> cc = new HashSet<int>();
            for (int i = 0; i < stones.Length; i++) {
                cc.Add(uf.Root(stones[i][0]));
            }
            
            return stones.Length - cc.Count;
        }

        public int RemoveStones2(int[][] stones) {
            // O(N^2 lg N)
            UF uf = new UF(stones.Length);
            for (int i = 0; i < stones.Length; i++) {
                for (int j = i + 1; j < stones.Length; j++) {
                    // if the row or col of stones i and j match, union
                    if (stones[i][0] == stones[j][0] || stones[i][1] == stones[j][1]) uf.Union(i, j);
                }
            }

            // the number of moves you can make is number of stones - number of connected components
            return stones.Length - uf.cc;
        }
    }
}