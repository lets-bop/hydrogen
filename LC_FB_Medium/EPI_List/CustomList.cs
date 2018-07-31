using System;

namespace LC_FB_Medium
{
    public class CustomList
    {
        private Node _head = new CustomList.Node();

        // Dummy head
        public Node Head 
        { 
            get { return this._head.Next; } 
            set {this._head.Next = value; }
        }

        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
        }

        public static CustomList Create(int[] input)
        {
            CustomList list = new CustomList();

            if (input == null || input.Length == 0) return list;            
            
            CustomList.Node prevNode = list._head;

            foreach (int i in input)
            {
                CustomList.Node node = new CustomList.Node();
                node.Data = i;
                prevNode.Next = node;
                prevNode = node;  
            }      

            return list;
        }

        public static void Print(CustomList list)
        {
            if (list == null || list.Head == null) return;

            for (CustomList.Node nodePtr = list.Head; nodePtr != null; nodePtr = nodePtr.Next)
                Console.Write(nodePtr.Data + "\t");
            Console.WriteLine();
        }
    }
}