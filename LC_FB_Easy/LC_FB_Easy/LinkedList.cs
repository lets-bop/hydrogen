using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Easy
{
    class LinkedList
    {
        public class ListNode
        {
            public int Value;
            public ListNode Next;
        }

        public static ListNode Reverse(ListNode head)
        {
            ListNode first = head;
            ListNode prev = null;
            ListNode second = null;
            
            while (first != null)
            {
                second = first.Next;
                first.Next = prev;
                prev = first;
                first = second;
            }

            return prev;
        }

        public static ListNode Build(int[] list)
        {
            ListNode prev = null;
            ListNode head = null;

            foreach (int element in list)
            {
                ListNode node = new ListNode();
                node.Value = element;
                if (prev != null)
                    prev.Next = node;
                else
                    head = node;

                prev = node;
            }
            
            return head;
        }

        public static string Print(ListNode head)
        {
            StringBuilder sb = new StringBuilder();
            while (head != null)
            {
                sb.AppendFormat(head.Value + "\t");
                head = head.Next;
            }

            return sb.ToString();
        }
    }
}