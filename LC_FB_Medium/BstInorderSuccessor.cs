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
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
            // the inorder successor is either the node's parent if the node doesnt have a right subtree
            // or if the node has a right subtree, then its the smallest element of its right subtree
            
            TreeNode parent = null;
            
            // It's guaranteed that the values of the tree are unique.
            while (root != null) {
                if (root.val == p.val) break;
                if (root.val > p.val) {
                    //reassign the parent
                    parent = root;
                    root = root.left;
                }
                else root = root.right;
            }
            
            // check if the node has a right subtree
            if (root != null && root.right != null) {
                root = root.right;
                while (root.left != null) root = root.left;
                return root;
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