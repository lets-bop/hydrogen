using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Reverse a linked list from position m to n. Do it in one-pass.

        Note: 1 ≤ m ≤ n ≤ length of list.

        Example:

        Input: 1->2->3->4->5->NULL, m = 2, n = 4
        Output: 1->4->3->2->5->NULL
    */
    class ReverseLinkedList2
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode ReverseBetween(ListNode head, int m, int n) {
            ListNode inputHead = head;
            ListNode prevRevStart = null;
            int start = 1;
            
            while (start < m) {
                start++;
                prevRevStart = head;
                head = head.next;
            }

            ListNode prev = null;
            ListNode curr = head;
            ListNode next = null;
            ListNode revStart = head;

            while (start <= n && curr != null) {
                start++;
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            if (prevRevStart != null) prevRevStart.next = prev;
            if (revStart != null) revStart.next = curr;

            if (prevRevStart == null) return prev; // prev is the new head
            return inputHead;
        }
    }
}