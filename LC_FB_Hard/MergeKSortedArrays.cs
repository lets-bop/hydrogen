using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    class MergeKSortedArrays
    {
        // This problem can be solved by using a heap. 
        // The time complexity is O(nlog(k)), 
        //where n is the total number of elements and k is the number of arrays.
        public int[] Merge(int[][] arrays) {
            if (arrays == null || arrays.Length == 0) return new int[] {};

            MinHeap minHeap = new MinHeap(arrays.Length);
            
            foreach (int[] array in arrays) {
                minHeap.Add(new Container(array));
            }

            List<int> result = new List<int>();
            Container c = null;
            while((c = minHeap.Poll()) != null) {
                result.Add(c.arr[c.index]);
                if (c.index < c.arr.Length - 1) minHeap.Add(new Container(c.arr, c.index + 1));
            }

            return result.ToArray();
        }

        internal class Container : IComparable {
            internal int[] arr;
            internal int index;
            internal Container(int[] a, int i = 0) {
                this.arr = a;
                this.index = i;
            }

            public int CompareTo(object o) {
                Container other = (Container)o;
                return this.arr[this.index] - other.arr[other.index];
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