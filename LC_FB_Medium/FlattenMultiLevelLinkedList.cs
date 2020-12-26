using System;

namespace LC_FB_Medium
{
    /*

        You are given a doubly linked list which in addition to the next and previous pointers, 
        it could have a child pointer, which may or may not point to a separate doubly linked list. 
        These child lists may have one or more children of their own, and so on, 
        to produce a multilevel data structure, as shown in the example below.
        Flatten the list so that all the nodes appear in a single-level, doubly linked list. 
        You are given the head of the first level of the list.

        Example:

        Input:
        1---2---3---4---5---6--NULL
                |
                7---8---9---10--NULL
                    |
                    11--12--NULL

        Output:
        1-2-3-7-8-11-12-9-10-4-5-6-NULL
    */
    class FlattenMultiLevelLinkedList
    {
        // Its like doing a DFS when a node has child. So use recursion. Or use a stack.
        public Node Flatten(Node head) {
            this.FlattenList(head);
            return head;
        }

        private Node FlattenList(Node curr) {
            Node prev = null;
            Node next = null;
            while (curr != null) {
                if (curr.child != null) {
                    next = curr.next;
                    curr.next = curr.child;
                    curr.child.prev = curr;
                    curr.child = null;
                    Node endOfFlattenedList = this.FlattenList(curr.next);
                    endOfFlattenedList.next = next;
                    if (next != null) next.prev = endOfFlattenedList;
                    curr = endOfFlattenedList;
                }
                
                prev = curr;
                curr = curr.next;
            }
            
            return prev;
        }

        public class Node {
            public int val;
            public Node prev;
            public Node next;
            public Node child;

            public Node(){}
            public Node(int _val,Node _prev,Node _next,Node _child) {
                val = _val;
                prev = _prev;
                next = _next;
                child = _child;
            }
        }
    }
}