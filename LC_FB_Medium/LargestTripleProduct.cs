using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        You're given a list of n integers arr[0..(n-1)]. You must compute a list output[0..(n-1)] such that, 
        for each index i (between 0 and n-1, inclusive), output[i] is equal to the product of the three largest elements 
        out of arr[0..i] (or equal to -1 if i < 2, as arr[0..i] then includes fewer than three elements).
        Note that the three largest elements used to form any product may have the same values as one another, 
        but they must be at different indices in arr.

        Input: n is in the range [1, 100,000]. Each value arr[i] is in the range [1, 1,000].
        Output: Return a list of n integers output[0..(n-1)], as described above.
        Example 1: 
            arr = [1, 2, 3, 4, 5], output = [-1, -1, 6, 24, 60]
            The 3rd element of output is 3*2*1 = 6, the 4th is 4*3*2 = 24, and the 5th is 5*4*3 = 60.
        
        Example 2:
            arr = [2, 1, 2, 1, 2], output = [-1, -1, 4, 4, 8]
            The 3rd element of output is 2*2*1 = 4, the 4th is 2*2*1 = 4, and the 5th is 2*2*2 = 8.
    */
    public class LargestTripleProduct
    {
        public int[] FindMaxProduct(int[] arr) {
            // We could use a minHeap or just 3 variables to solve this problem.
            // We'll use a minHeap. Remove the min element from the heap everytime you have 4 items in the heap
            // and divide product so far with the value of the element removed.
            if (arr == null || arr.Length == 0) return null;
            if (arr.Length == 1) return new int[1] { -1 };
            if (arr.Length < 3) return new int[2] { -1, -1 };

            MinHeap heap = new MinHeap(4); // the heap need hold a max of 4 elements only
            heap.Add(arr[0]);
            heap.Add(arr[1]);
            heap.Add(arr[2]);

            int product = arr[0] * arr[1] * arr[2];
            int[] result = new int[arr.Length];
            result[0] = result[1] = -1; result[2] = product;
            
            for (int i = 3; i < arr.Length; i++) {
                product *= arr[i];
                heap.Add(arr[i]);
                product /= heap.RemoveMin();
                result[i] = product;
            }

            return result;
        }

        internal class MinHeap
        {
            internal int[] pq;
            int maxSize = 0;
            int currentSize = 0;
            internal MinHeap(int size) {
                this.pq = new int[size];
                this.maxSize = size;
            }

            internal void Add(int data) {
                if (currentSize == maxSize) throw new Exception("Full heap");

                this.pq[currentSize] = data;
                int k = currentSize;
                while (k > 0 && this.pq[k] < this.pq[k/2]) {
                    this.Swap(k, k/2);
                    k /= 2;
                }
                currentSize++;
            }

            internal int RemoveMin() {
                if (currentSize == 0) throw new Exception("Empty heap");

                int data = this.pq[0];
                currentSize--;
                if (currentSize != 1) {
                    this.pq[0] = this.pq[currentSize];
                    currentSize--;
                    this.Sink();
                }

                return data;
            }

            internal void Sink() {
                int k = 0;
                int child1 = k * 2 + 1;
                int child2 = k * 2 + 2;
                int minChild = 0;
                while (child1 < currentSize) {
                    if (child2 < currentSize) minChild = this.pq[child1] < this.pq[child2] ? child1 : child2;
                    else minChild = child1;
                    if (this.pq[k] <= this.pq[minChild]) return;
                    this.Swap(k, minChild);
                    k = minChild;
                    child1 = k * 2 + 1;
                    child2 = k * 2 + 2;
                }
            }

            internal void Swap(int i, int j) {
                int temp = this.pq[i];
                this.pq[i] = this.pq[j];
                this.pq[j] = temp;
            }
        }
    }
}