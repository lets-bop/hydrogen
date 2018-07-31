using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class ReverseSublist
    {
        public static void Execute(CustomList list, int startIndex, int endIndex)
        {
            int currentIndex = 0;
            CustomList.Node listPtr = list.Head;
            CustomList.Node prevPtr = null;

            while (listPtr != null && currentIndex < startIndex)
            {
                prevPtr = listPtr;
                listPtr = listPtr.Next;
                currentIndex++;
            }

            if (listPtr == null) return;

            // Start the reversal
            CustomList.Node prev = null;
            CustomList.Node next = null;
            CustomList.Node newSubListTail = listPtr;
            while (listPtr != null && currentIndex <= endIndex)
            {
                currentIndex++;
                next = listPtr.Next;
                listPtr.Next = prev;
                prev = listPtr;
                listPtr = next;
            }

            newSubListTail.Next = listPtr;
            if (prevPtr != null) prevPtr.Next = prev;
            else list.Head = prev; // corner case, when the entire list is being reversed.
        }
    }
}