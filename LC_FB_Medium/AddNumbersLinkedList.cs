using System;
using System.Collections;
using System.Text;

namespace LC_FB_Medium
{
    /*
        You are given two non-empty linked lists representing two non-negative integers. 
        The digits are stored in reverse order and each of their nodes contain a single digit. 
        Add the two numbers and return it as a linked list.
        You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        Example:

        Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
        Output: 7 -> 0 -> 8
        Explanation: 342 + 465 = 807.    
    */
    class AddNumbersLinkedList
    {

        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
                
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) 
        {
            int sum;
            int carry = 0;
            ListNode head = null;
            ListNode last = null;
            while (l1 != null && l2 != null) {
                sum = l1.val + l2.val + carry;
                ListNode node = new ListNode(sum % 10);
                carry = sum / 10;
                if (last != null) {
                    last.next = node;
                    last = last.next;
                }
                else {
                    last = node;
                    head = node;
                }

                l1 = l1.next;
                l2 = l2.next;
            }

            ListNode iter = l1 == null ? l2 : l1;
            while (carry != 0 && iter != null) {
                last.next = new ListNode((iter.val + carry) % 10);
                carry = (iter.val + carry) / 10;
                last = last.next;
                iter = iter.next;
            }

            if (carry == 0 && iter != null) last.next = iter;
            else if (carry == 1 && iter == null) { // iter should always be null here
                last.next = new ListNode(carry);
            }

            return head;
        }        
    }
}