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
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

    public bool IsValidBST(TreeNode root) {
            BSTInfo info = this.Validate(root);
            if (info == null) return true;
            return info.valid;
        }
    
        class BSTInfo
        {
            public int min;
            public int max;
            public bool valid;

            public BSTInfo(int min, int max, bool valid) {
                this.min = min;
                this.max = max;
                this.valid = valid;
            }
        }    

        private BSTInfo Validate(TreeNode node) {
            if (node == null) return null;

            BSTInfo left = this.Validate(node.left);
            if (left == null || (left.valid && node.val > left.max)) {
                BSTInfo right = this.Validate(node.right);
                int leftMin = left == null ? node.val : left.min;
                if (right == null || (right.valid && node.val < right.min)){
                    int rightMax = right == null ? node.val : right.max;
                    return new BSTInfo(leftMin, rightMax, true);
                }
            }

            return new BSTInfo(int.MinValue, int.MaxValue, false);
        }
    }
}