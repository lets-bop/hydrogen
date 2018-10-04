using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class  MinMeetingRooms
    {
        public class Interval {
            public int start;
            public int end;
            public Interval() { start = 0; end = 0; }
            public Interval(int s, int e) { start = s; end = e; }
        }

        internal class MinPQ
        {
            int[] pq;
            internal int currentItemCount;
            int size;

            internal MinPQ(int size){
                this.size = size;
                this.pq = new int[size];
                this.currentItemCount = 0;
            }

            internal int GetMin(){
                return this.pq[0];
            }

            internal void Add(int val){
                this.pq[this.currentItemCount++] = val;
                this.Swim();
            }

            internal void UpdateMin(int val){
                this.pq[0] = val;
                this.Sink();
            }

            internal void Swim(){
                int index = this.currentItemCount - 1;
                int parentIndex = (index + 1) / 2 - 1;
                while(parentIndex >= 0 && this.pq[parentIndex] > this.pq[index]){
                    int temp = this.pq[index];
                    this.pq[index] = this.pq[parentIndex];
                    this.pq[parentIndex] = temp;
                    index = parentIndex;
                    parentIndex = (parentIndex + 1) / 2 - 1;
                }
            }

            internal void Sink(){
                int index = 0;

                while(2 * index < this.currentItemCount){
                    int childIndex = -1;
                    int child1 = index * 2 + 1;
                    int child2 = index * 2 + 2;

                    if(child1 < this.currentItemCount){
                        childIndex = child1;

                        if(child2< this.currentItemCount && this.pq[child1] > this.pq[child2]){
                            childIndex = child2;
                        }
                    }

                    if(childIndex != -1 && this.pq[childIndex] < this.pq[index]){
                        int temp = this.pq[index];
                        this.pq[index] = this.pq[childIndex];
                        this.pq[childIndex] = temp;
                        index = childIndex;                
                    }
                    else break;
                }              
            }
        }

        public int FindMinimum(Interval[] intervals)
        {
            Array.Sort(intervals, CompareInts);
            MinPQ pq = new MinPQ(intervals.Length);

            foreach(Interval interval in intervals){
                if(pq.currentItemCount == 0 || interval.start < pq.GetMin())
                    pq.Add(interval.end);
                else 
                    pq.UpdateMin(interval.end);
            }

            return pq.currentItemCount;
        }

        public static int CompareInts(Interval s1, Interval s2)
        {
            return s1.start - s2.start;
        }        
    }
}