using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    public class MergeSortedLists
    {
        public static CustomList Merge(CustomList list1, CustomList list2)
        {
            CustomList newList = null;

            if (list1 == null || list1.Head == null) newList = list2;
            else if (list2 == null || list2.Head == null) newList = list1;
            else
            {
                CustomList.Node list1Ptr = list1.Head;
                CustomList.Node list2Ptr = list2.Head;
                
                CustomList.Node prevNode = null;
                while (list1Ptr != null && list2Ptr != null)
                {
                    if (list1Ptr.Data <= list2Ptr.Data)
                    {
                        if (newList == null) newList = list1;
                        else prevNode.Next = list1Ptr;
                        prevNode = list1Ptr;
                        list1Ptr = list1Ptr.Next;
                    }
                    else
                    {
                        if (newList == null) newList = list2;
                        else  prevNode.Next = list2Ptr;
                        prevNode = list2Ptr;
                        list2Ptr = list2Ptr.Next;                     
                    }
                }

                if (list1Ptr == null) prevNode.Next = list2Ptr;
                else prevNode.Next = list1Ptr;
            }

            return newList;
        }
    }
}