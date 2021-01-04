using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Reverse Operations
        You are given a singly-linked list that contains N integers. 
        A subpart of the list is a contiguous set of even elements, 
        bordered either by either end of the list or an odd element. 
        For example, if the list is [1, 2, 8, 9, 12, 16], the subparts of the list are [2, 8] and [12, 16].
        Then, for each subpart, the order of the elements is reversed. In the example, this would result in the new list, [1, 8, 2, 9, 16, 12].
        The goal of this question is: given a resulting list, determine the original order of the elements.
        Implementation detail:
        You must use the following definition for elements in the linked list:
        class Node {
            int data;
            Node next;
        }
        Signature
        Node reverse(Node head)
        Constraints
        1 <= N <= 1000, where N is the size of the list
        1 <= Li <= 10^9, where Li is the ith element of the list
        Example
        Input:
        N = 6
        list = [1, 2, 8, 9, 12, 16]
        Output:
        [1, 8, 2, 9, 16, 12]
    */

    class ReverseEvenList
    {
        internal class Node {
            internal int data;
            internal Node next;

            internal Node(int data) {
                this.data = data;
            }
        }

        public Node Reverse(Node head){
            Node prev = null, curr = head;
            Node newHead, newTail;

            while (curr != null) {
                if (curr.data % 2 == 0) {
                    this.RevSubList(curr, out newHead, out newTail);
                    if (prev != null) prev.next = newHead;
                    else head = newHead;
                    curr = newTail;
                }

                prev = curr;
                curr = curr.next;
            }

            return head;
        }

        private void RevSubList(Node currNode, out Node newHead, out Node newTail) {
            newTail = currNode;
            Node prev = null, next = null;

            while (currNode != null && currNode.data % 2 == 0) {
                next = currNode.next;
                currNode.next = prev;
                prev = currNode;
                currNode = next;
            }

            newHead = prev;
            newTail.next = currNode;
        }

        public Node CreateList(int[] nums) {
            Node head = null, prev = null;
            foreach (int num in nums) {
                Node node = new Node(num);
                if (head == null) {
                    head = node;
                    prev = node;
                } else {
                    prev.next = node;
                    prev = prev.next;
                }
            }

            return head;
        }

        public List<int> ConvertToList(Node node) {
            List<int> list = new List<int>();
            while (node != null) {
                list.Add(node.data);
                node = node.next;
            }

            return list;
        }
    }
}