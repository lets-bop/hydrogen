using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class UF
    {
        private int[] id;
        private int[] sz;   // holds the number of nodes in the tree. i.e. size of each connected component
        public int cc = 0;     // holds the number of connected components

        // Constructor that takes in the number of objects.
        public UF(int size)
        {
            this.id = new int[size];
            this.sz = new int[size];
            this.cc = size;

            // initially all the objects are independent and 
            // in their own connected component.
            // id[i] points to the parent of i. 
            // For now, every element point to iself and its size is 1.
            for(int i = 0; i < size; i++){
                this.id[i] = i;
                this.sz[i] = 1;
            }
        }

        public int Root(int i) {
            while (id[i] != i) {
                id[i] = id[id[i]]; // path compression. make every node point to its grandparent, thereby halving the path length
                i = id[i];
            }
            return i;
        }

        public bool Connected(int p, int q) {
            return this.Root(p) == this.Root(q);
        }

        public void Union(int p, int q)
        {
            // make the root of p point to the root of q.
            int rootp = this.Root(p);
            int rootq = this.Root(q);
            if (rootp == rootq) return;
            this.cc--;

            // get the size of the 2 trees and link the root of the
            // smaller tree to the root of the larger tree.
            // the depth of any node is at most lg N
            // because the depth is at most lg N, find takes O(lg N)
            if (this.sz[rootp] < this.sz[rootq]) {
                this.id[rootp] = rootq;
                this.sz[rootq] += this.sz[rootp];
            }
            else {
                this.id[rootq] = rootp;
                this.sz[rootq] += this.sz[rootp];
            }
        }
    }
}