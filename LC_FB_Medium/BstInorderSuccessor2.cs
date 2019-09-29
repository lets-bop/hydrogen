using System;
using System.Collections.Generic;

/*
Given a binary search tree and a node in it, find the in-order successor of that node in the BST.

The successor of a node p is the node with the smallest key greater than p.val.

You will have direct access to the node but not to the root of the tree. 
Each node will have a reference to its parent node.
*/
namespace LC_FB_Medium
{
    class BstInorderSuccessor2
    {
        public TreeNode InorderSuccessor(TreeNode x) {
            if (x.right != null) {
                x = x.right;
                while (x.left != null) x = x.left;
                return x;
            }
            
            // the right subtree is null. see if x is on the left subtree of some node
            TreeNode parent = x.parent;
            while (parent != null) {
                if (parent.left == x) return parent;
                x = parent;
                parent = x.parent;
            }
            
            return null;
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode parent;
            public TreeNode(int x) { val = x; }
        }
    }
}