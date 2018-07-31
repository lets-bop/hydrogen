/*
Rearrange the list such that elements less than the pivot are to its left and elements 
greater than the pivot element are to its right.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class PivotList
    {
        public static void Execute(CustomList list, int pivot)
        {
            if (list == null) return;
            CustomList.Node lessHead = new CustomList.Node();
            CustomList.Node equalHead = new CustomList.Node();
            CustomList.Node greaterHead = new CustomList.Node();
            CustomList.Node listIter = list.Head;
            CustomList.Node lessIter = lessHead, equalIter = equalHead, greaterIter = greaterHead;

            while (listIter != null)
            {
                if (listIter.Data < pivot)
                {
                    lessIter.Next = listIter;
                    lessIter = lessIter.Next;
                }
                else if (listIter.Data > pivot)
                {
                    greaterIter.Next = listIter;
                    greaterIter = greaterIter.Next;
                }
                else
                {
                    equalIter.Next = listIter;
                    equalIter = equalIter.Next;
                }

                listIter = listIter.Next;
            }

            if (lessHead.Next != null)
            {
                list.Head = lessHead.Next;
                if (equalHead.Next != null) 
                {
                    lessIter.Next = equalHead.Next;
                    equalIter.Next = greaterHead.Next;
                }
                else lessIter.Next = greaterHead.Next;
            }
            else if (equalHead.Next != null)
            {
                list.Head = equalHead.Next;
                equalIter.Next = greaterHead.Next;
            }
            else if (greaterHead.Next != null) list.Head = greaterHead.Next;
        }
    }
}





