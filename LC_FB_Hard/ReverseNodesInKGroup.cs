using System;
using System.Collections.Generic;

/*
Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.

k is a positive integer and is less than or equal to the length of the linked list. 
If the number of nodes is not a multiple of k then left-out nodes in the end should remain as it is.

Example:
Given this linked list: 1->2->3->4->5
For k = 2, you should return: 2->1->4->3->5
For k = 3, you should return: 3->2->1->4->5

Note:
Only constant extra memory is allowed. You may not alter the values in the list's nodes, only nodes itself may be changed.
*/
namespace LC_FB_Hard
{
    class ReverseNodesInKGroup
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode ReverseKGroup(ListNode head, int k) {
            if (head == null || k <= 1) return head;

            int i = 0;
            // ListNode prevTail = null, currTail = null, prev = null, curr = head, next = curr.next;
            ListNode prevTail = null, start = head, end = null, currTail = null, curr = head;
            ListNode newHead = null;
            while (curr != null) {
                while (curr != null && i < k) {
                    i++;
                    if (start == null) start = curr;
                    curr = curr.next;
                    end = curr;
                }
                if (i == k) {
                    var rev = this.Reverse(start, end, currTail);
                    ListNode h = rev.Item1;
                    currTail = rev.Item2;
                    if (prevTail != null) prevTail.next = h;
                    if (newHead == null) newHead = h;
                    prevTail = currTail;
                    currTail = null;

                    // re-initialize for next iteration
                    i= 0;
                    start = null;
                    end = null;
                } else {
                    if (prevTail != null) prevTail.next = start;
                }
            }

            if (newHead == null) return head;
            return newHead;
        }

        public (ListNode,ListNode) Reverse(ListNode start, ListNode end, ListNode currTail) {
            ListNode prev, curr, next;
            prev = null;
            curr = start;
            next = start.next;
            while (next != end) { // we need to reverse element up until end, not including end.
                if (currTail == null) currTail = curr;
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            
            return (prev, currTail);
        }
    }
}