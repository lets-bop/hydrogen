using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given a binary tree, determine if it is a valid binary search tree (BST).

        Assume a BST is defined as follows:

        The left subtree of a node contains only nodes with keys less than the node's key.
        The right subtree of a node contains only nodes with keys greater than the node's key.
        Both the left and right subtrees must also be binary search trees.
    */
    class ValidateBST
    {
        public bool IsValidBST(TreeNode root) {
            // (isValid, min, max)
            (bool, int, int) valid = this.IsValid(root);
            return valid.Item1;
        }

        public (bool, int, int) IsValid(TreeNode node) {
            // (isValid, min, max)
            (bool, int, int) nodeValidity = (true, node.val, node.val);
            if (node.left != null) {
                (bool, int, int) left = IsValid(node.left);
                if (!left.Item1 || node.val <= left.Item3) {
                    return (false, node.val, node.val);
                }
                
                nodeValidity = (true, left.Item2, node.val);
            }
            
            if (node.right != null) {
                (bool, int, int) right = IsValid(node.right);
                if (!right.Item1 || node.val >= right.Item2) {
                    return (false, node.val, node.val);
                }
                
                nodeValidity = (true, nodeValidity.Item2, right.Item3);
            }
            
            return nodeValidity;
        }

        internal class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            internal TreeNode(int x) { val = x; }
        }
    }
}