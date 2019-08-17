using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class StonesRemoved
    {
        public int RemoveStones(int[][] stones) {
            UnionFind uf = new UnionFind(stones.Length);
            for (int i = 0; i < stones.Length; i++) {
                for (int j = i + 1; j < stones.Length; j++) {
                    if (stones[i][0] == stones[j][0] || stones[i][1] == stones[j][1]) // if the row or col of stones i and j match, union
                        uf.Union(i, j);
                }
            }

            return stones.Length - uf.unConnectedComponents;
        }

        class UnionFind
        {
            int[] parent; // holds the parent of each connected component
            public int unConnectedComponents; // total number of unconnected components
            int[] size; // size of the connected component

            public UnionFind(int N) {
                this.parent = new int[N];
                this.size = new int[N];
                this.unConnectedComponents = N;
                for (int i = 0; i < N; i++) this.parent[i] = i;
            }

            public int Find(int i) {
                if (this.parent[i] != i) {
                    this.parent[i] = this.Find(this.parent[i]); // path compression else it would have just been return this.Find(parent[i])
                }

                return this.parent[i];
            }

            public void Union(int i, int j) {
                int parentI = this.Find(i);
                int parentJ = this.Find(j);
                if (parentI == parentJ) return;

                // parent is not the same. union.
                if (this.size[parentI] <= this.size[parentJ]) {
                    // i has lesser number of components than j. Change i's parent to j.
                    this.parent[parentI] = parentJ;
                    this.size[parentJ]++;
                } else {
                    // j has lesser number of components than i. Change j's parent to i.
                    this.parent[parentJ] = parentI;
                    this.size[parentI]++;
                }

                // reduce the number of unconnected components
                this.unConnectedComponents--;
            }
        }
    }
}