using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        It takes you 1 minute to eat all of the pieces of candy in a bag (irrespective of how many pieces of candy are inside), 
        and as soon as you finish, the bag mysteriously refills. If there were x pieces of candy in the bag at 
        the beginning of the minute, then after you've finished you'll find that floor(x/2) pieces are now inside.
        You have k minutes to eat as much candy as possible. How many pieces of candy can you eat?

        Input: 1 ≤ N ≤ 10,000; 1 ≤ k ≤ 10,000; 1 ≤ arr[i] ≤ 1,000,000,000
        Output: A single integer, the maximum number of candies you can eat in k minutes.
        Example 1: 
            k = 3, arr = [2, 1, 7, 4, 2]
            Output = 14

            In the first minute you can eat 7 pieces of candy. That bag will refill with floor(7/2) = 3 pieces.
            In the second minute you can eat 4 pieces of candy from another bag. That bag will refill with floor(4/2) = 2 pieces.
            In the third minute you can eat the 3 pieces of candy that have appeared in the first bag that you ate.
            In total you can eat 7 + 4 + 3 = 14 pieces of candy.
    */
    public class MagicalCandyBags
    {
        // We could use a maxHeap solve this problem.
        public int MaxCandies(int[] arr, int k) {
            if (arr == null || arr.Length == 0) return 0;

            MaxHeap heap = new MaxHeap(arr.Length);
            int result = 0;
            
            for (int i = 0; i < arr.Length; i++) heap.Add(arr[i]);

            int candies = 0;
            while (k > 0) {
                k--;

                candies = heap.RemoveMax();
                result += candies;
                candies /= 2;
                if (candies != 0) heap.Add(candies);
            }

            return result;
        }

        internal class MaxHeap
        {
            internal int[] pq;
            int maxSize = 0;
            int currentSize = 0;
            internal MaxHeap(int size) {
                this.pq = new int[size];
                this.maxSize = size;
            }

            internal void Add(int data) {
                if (currentSize == maxSize) throw new Exception("Full heap");

                this.pq[currentSize] = data;
                int k = currentSize;
                while (k > 0 && this.pq[k] > this.pq[k/2]) {
                    this.Swap(k, k/2);
                    k /= 2;
                }
                currentSize++;
            }

            internal int RemoveMax() {
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
                int maxChild = 0;
                while (child1 < currentSize) {
                    if (child2 < currentSize) maxChild = this.pq[child1] > this.pq[child2] ? child1 : child2;
                    else maxChild = child1;
                    if (this.pq[k] >= this.pq[maxChild]) return;
                    this.Swap(k, maxChild);
                    k = maxChild;
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