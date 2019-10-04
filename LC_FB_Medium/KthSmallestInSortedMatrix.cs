using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given a n x n matrix where each of the rows and columns are sorted in ascending order, 
        find the kth smallest element in the matrix.
        Note that it is the kth smallest element in the sorted order, not the kth distinct element.
        Example:
            matrix = [
            [ 1,  5,  9],
            [10, 11, 13],
            [12, 13, 15]
            ],
            k = 8,

            return 13.
    */
    class KthSmallestInSortedMatrix
    {
        public int KthSmallest(int[][] matrix, int k) {
            // add every element from the first row into a minheap
            // extract the min and add the next element in the same col into the min heap
            // continue until you find k.
            // Time complexity is O(k lg (cols))
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            MinHeap minHeap = new MinHeap(cols);
            for (int c = 0; c < cols; c++) minHeap.Add(new Container(matrix[0][c], 0, c));

            int i = 0;
            int kthSmallest = 0;
            
            while (i < k) {
                Container container = minHeap.Poll();
                if (container == null) return kthSmallest;

                kthSmallest = container.val;
                if (container.row < rows - 1) {
                    int nextVal = matrix[container.row + 1][container.col];
                    minHeap.Add(new Container(nextVal, container.row + 1, container.col));
                }

                i++;
            }

            return kthSmallest;
        }

       internal class Container : IComparable {
            internal int val;
            internal int row;
            internal int col;
            internal Container(int v, int r, int c) {
                this.val = v;
                this.row = r;
                this.col = c;
            }

            public int CompareTo(object o) {
                Container other = (Container)o;
                return this.val - other.val;
            }
        }

        internal class MinHeap {
            Container[] pq;
            int currentItemCount;

            internal MinHeap(int size) {
                this.pq = new Container[size];
            }

            internal Container Poll() {
                if (this.currentItemCount == 0) return null;
                Container returnVal = this.pq[0];
                if (this.currentItemCount == 1) { 
                    this.pq[0] = null;
                } else {
                    this.pq[0] = this.pq[this.currentItemCount - 1];
                }

                this.currentItemCount--;
                this.Sink(0);
                return returnVal;
            }

            internal void Add(Container val) {
                if (this.pq.Length == this.currentItemCount) throw new Exception("MinHeap is full");
                this.pq[this.currentItemCount] = val;
                this.Swim(this.currentItemCount);
                this.currentItemCount++;
            }

            internal void Swim(int index) {
                while (index > 0) {
                    int parent = Math.Max(0, (index+1) / 2 - 1);
                    if (this.pq[parent].CompareTo(this.pq[index]) <= 0) return;
                    else {
                        Container temp = this.pq[parent];
                        this.pq[parent] = this.pq[index];
                        this.pq[index] = temp;
                        index = parent;
                    }
                }
            }

            internal void Sink(int index) {
                while (index < this.currentItemCount) {
                    // Find the smallest child
                    int c1 = index * 2 + 1;
                    int c2 = index * 2 + 2;

                    int smallestChild = -1;
                    if (c1 < this.currentItemCount) {
                        if (c2 < this.currentItemCount && this.pq[c2].CompareTo(this.pq[c1]) < 0) smallestChild = c2;
                        else smallestChild = c1;
                    }

                    if (smallestChild == -1) return;
                    if (this.pq[index].CompareTo(this.pq[smallestChild]) <= 0) return;
                    else {
                        Container temp = this.pq[index];
                        this.pq[index] = this.pq[smallestChild];
                        this.pq[smallestChild] = temp;
                        index = smallestChild;
                    }
                }
            }
        }
    }
}