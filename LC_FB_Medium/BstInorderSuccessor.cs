using System;
using System.Collections.Generic;

/*
Given a binary search tree and a node in it, find the in-order successor of that node in the BST.

The successor of a node p is the node with the smallest key greater than p.val.
*/
namespace LC_FB_Medium
{
    class BstInorderSuccessor
    {
        public TreeNode InorderSuccessor(TreeNode node, TreeNode p) {
            if (node == null || p == null) return null;
            
            TreeNode parent = null;
            while (node != null) {
                if (node.val > p.val) {
                    parent = node;
                    node = node.left;
                } else if (node.val < p.val) {
                    node = node.right;
                } else {
                    node = node.right;
                    while (node != null) {
                        parent = node;
                        node = node.left;
                    }
                }
            }

            return parent;
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }  
    }
}