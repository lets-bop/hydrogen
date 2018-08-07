/*
Implement a fixed size PQ.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class MinPQ_FixedSize
    {
        private int capacity;
        private int[] pq;
        private int currentItemCount = 0;

        public MinPQ_FixedSize(int capacity)
        {
            if (capacity < 0 || capacity == 0) throw new Exception("Invalid capacity");
            this.capacity = capacity;
            this.pq = new int[capacity];
        }

        public void Insert(int key)
        {
            if (this.currentItemCount > this.capacity)
            {
                // delete the max element in the min pq
            }

            this.pq[this.currentItemCount++] = key;
            this.SwimUp(this.currentItemCount - 1);
        }

        public void Delete(int index)
        {
            if (index > this.currentItemCount - 1) return;

            // Swap it with the last node of the heap and then swim up.
            this.pq[index] = this.pq[this.currentItemCount - 1];
            this.pq[this.currentItemCount - 1] = 0;
            this.currentItemCount--;

            if (index != this.currentItemCount)
            {
                this.SwimUp(index);
                this.Sink(index);
            }
        }

        public void Print()
        {
            for (int i = 0; i < this.currentItemCount; i++) Console.Write(this.pq[i] + " ");
            Console.WriteLine();
        }        

        private void SwimUp(int index)
        {
            int j = index;
            int parent = ((j+1) / 2) - 1;
            while(j > 0 && this.pq[j] < this.pq[parent])
            {
                this.Swap(j, parent);
                j = parent;
                parent = ((j+1) / 2) - 1;
            }
        }

        private void Sink(int index)
        {
            int j = index;
            while (j < this.currentItemCount / 2)
            {
                int child1Index = 2 * j + 1; 
                int child2Index = 2 * j + 2;
                int minChildIndex = child1Index;
                if (child2Index < this.currentItemCount && this.pq[child2Index] < this.pq[child1Index])
                    minChildIndex = child2Index;
                if (minChildIndex < this.currentItemCount && this.pq[j] > this.pq[minChildIndex])
                    this.Swap(j, minChildIndex);
                else break;
            }
        }

        private void Swap(int j, int k)
        {
                int temp = this.pq[j];
                this.pq[j] = this.pq[k];
                this.pq[k] = temp;            
        }
    }    
}