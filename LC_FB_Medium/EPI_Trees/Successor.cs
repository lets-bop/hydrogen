/*
Find the inorder successor of a node.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class Successor
    {
        public static CustomTree<int>.Node GetNext(CustomTree<int>.Node node)
        {
            if (node == null) return null;
            
            // If the node has a right subtree, find the left most node of its right subtree
            if (node.Right != null)
            {
                node = node.Right;
                while (node.Left != null) node = node.Left;
                return node;
            }

            // Else, we need to ascend up from the node until the node we ascend up from is the left child of its parent.
            while (node != null && node.Parent != null && node.Parent.Left != node) node = node.Parent;
            return node.Parent;
        }
    }
}