using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    /*
        Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.

        Example:

        Input:
        [
        1->4->5,
        1->3->4,
        2->6
        ]
        Output: 1->1->2->3->4->4->5->6
    */
    public class MergeKSortedLists
    {
        // This problem can be solved by using a heap. 
        // The time complexity is O(nlog(k)), where n is the total number of elements and k is the number of arrays.
        public ListNode MergeKLists(ListNode[] lists) {
            if (lists == null || lists.Length == 0) return null;

            MinHeap minHeap = new MinHeap(lists.Length);
            
            foreach (ListNode node in lists) {
                minHeap.Add(node);
            }

            ListNode head = null;
            ListNode curr = null;
            ListNode n = null;
            while((n = minHeap.Poll()) != null) {
                if (head == null) {
                    head = new ListNode(n.val);
                    curr = head;
                } else {
                    curr.next = new ListNode(n.val);
                    curr = curr.next;
                }

                minHeap.Add(n.next);
            }

            return head;
        }

        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        internal class MinHeap {
            ListNode[] pq;
            int currentItemCount;

            internal MinHeap(int size) {
                this.pq = new ListNode[size];
            }

            internal ListNode Poll() {
                if (this.currentItemCount == 0) return null;
                ListNode returnVal = this.pq[0];
                if (this.currentItemCount == 1) { 
                    this.pq[0] = null;
                } else {
                    this.pq[0] = this.pq[this.currentItemCount - 1];
                }

                this.currentItemCount--;
                this.Sink(0);
                return returnVal;
            }

            internal void Add(ListNode val) {
                if (val == null) return;
                if (this.pq.Length == this.currentItemCount) throw new Exception("MinHeap is full");
                this.pq[this.currentItemCount] = val;
                this.Swim(this.currentItemCount);
                this.currentItemCount++;
            }

            internal void Swim(int index) {
                while (index > 0) {
                    int parent = Math.Max(0, (index+1) / 2 - 1);
                    if (this.pq[parent].val <= this.pq[index].val) return;
                    else {
                        ListNode temp = this.pq[parent];
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
                        if (c2 < this.currentItemCount && this.pq[c2].val < this.pq[c1].val) smallestChild = c2;
                        else smallestChild = c1;
                    }

                    if (smallestChild == -1) return;
                    if (this.pq[index].val <= this.pq[smallestChild].val) return;
                    else {
                        ListNode temp = this.pq[index];
                        this.pq[index] = this.pq[smallestChild];
                        this.pq[smallestChild] = temp;
                        index = smallestChild;
                    }
                }
            }
        }
    }
}