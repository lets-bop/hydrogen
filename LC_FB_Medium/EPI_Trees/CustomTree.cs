/*
Custom tree class
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class CustomTree<T> where T : IComparable<T>
    {
        public Node Root;

        public class Node
        {
            public T Data;
            public Node Left;

            public Node Right;

            public Node Parent;

            public Node(T data)
            {
                this.Data = data;
            }
        }

        public static CustomTree<T> Build(List<T> inOrder, List<T> preOrder)
        {
            int preOrderIndex = 0;
            CustomTree<T> tree = new CustomTree<T>();
            CustomTree<T>.Node root = tree.Build(null, inOrder, preOrder, 0, inOrder.Count, ref preOrderIndex);
            tree.Root = root;
            return tree;
        }

        public static CustomTree<T>.Node GetNode(CustomTree<T>.Node root, T dataToFind)
        {
            if (root == null) return null;
            if (root.Data.CompareTo(dataToFind) == 0) return root;
            CustomTree<T>.Node node = GetNode(root.Left, dataToFind);
            if (node != null) return node;
            return GetNode(root.Right, dataToFind);
        }

        public void Print()
        {
            Console.WriteLine("In-order traversal order is ");
            this.PrintInorder(this.Root);
            Console.WriteLine();
            Console.WriteLine("Pre-order traversal order is ");
            this.PrintPreOrder(this.Root);
            Console.WriteLine();
        }

        private void PrintInorder(Node node)
        {
            if (node == null) return;
            PrintInorder(node.Left);
            Console.Write(node.Data + " ");
            PrintInorder(node.Right);
        }

        private void PrintPreOrder(Node node)
        {
            if (node == null) return;
            Console.Write(node.Data + " ");
            PrintInorder(node.Left);
            PrintInorder(node.Right);            
        }

        private CustomTree<T>.Node Build(
            CustomTree<T>.Node parent,
            List<T> inOrder, 
            List<T> preOrder, 
            int inOrderStartIndex, 
            int inOrderEndIndex, 
            ref int preOrderIndex)
            {
                if (preOrderIndex >= preOrder.Count) return null;
                CustomTree<T>.Node node = new CustomTree<T>.Node(preOrder[preOrderIndex]);
                node.Parent = parent;
                int inOrderElementIndex = CustomTree<T>.FindElementIndex(inOrder, node.Data, inOrderStartIndex, inOrderEndIndex);

                if (inOrderStartIndex <= inOrderElementIndex - 1)
                {
                    ++preOrderIndex;
                    node.Left = Build(node, inOrder, preOrder, inOrderStartIndex, inOrderElementIndex - 1, ref preOrderIndex);
                }
                    
                if (inOrderEndIndex >= inOrderElementIndex + 1)
                {
                    ++preOrderIndex;
                    node.Right = Build(node, inOrder, preOrder, inOrderElementIndex + 1, inOrderEndIndex, ref preOrderIndex);
                }

                return node;

            }
        private static int FindElementIndex(List<T> list, T data, int startIndex, int endIndex)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (list[i].CompareTo(data) == 0) return i;
            }

            return -1;
        }   
    }
}





