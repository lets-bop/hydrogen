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
            public ListNode(int x = 0) { val = x; }
        }
                
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) 
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            
            int num1 = 0, num2 = 0, sum = 0, carry = 0;
            ListNode head = new ListNode();
            ListNode last = null;
            
            while (l1 != null || l2 != null) {
                num1 = 0; num2 = 0;
                if (l1 != null) {
                    num1 = l1.val;
                    l1 = l1.next;
                }
                if (l2 != null) {
                    num2 = l2.val;
                    l2 = l2.next;
                }
                
                sum = num1 + num2 + carry;
                if (sum >= 10) carry = 1;
                else carry = 0;
                
                if (last == null) {
                    last = head;
                    last.val = sum % 10;
                } else {
                    last.next = new ListNode(sum % 10);
                    last = last.next;
                }
            }
            
            if (carry > 0) last.next = new ListNode(carry);
            return head;
        }
    }
}