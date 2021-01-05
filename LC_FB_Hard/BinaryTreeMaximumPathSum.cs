using System;
using System.Collections.Generic;

/*
    Given a non-empty binary tree, find the maximum path sum.
    For this problem, a path is defined as any sequence of nodes from some starting node 
    to any node in the tree along the parent-child connections. The path must contain 
    at least one node and does not need to go through the root.

Example 1:
Input: [1,2,3]

       1
      / \
     2   3

Output: 6

Example 2:
Input: [-10,9,20,null,null,15,7]
   -10
   / \
  9  20
    /  \
   15   7

Output: 42 (15+20+7)
*/
namespace LC_FB_Hard
{
    class BinaryTreeMaximumPathSum
    {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        int maxSum = int.MinValue;

        public int MaxPathSum(TreeNode root) {
            this.DoDFS(root);
            return this.maxSum;
        }

        public int DoDFS(TreeNode node) {
            if (node == null) return 0;

            int left = 0, right = 0;
            if (node.left != null) left = this.DoDFS(node.left);
            if (node.right != null) right = this.DoDFS(node.right);
            
            // At the node, take the max of node.val, node.val + left, node.val + right, node.val + left + right
            int totalSum = node.val + left + right;
            int leftSum = node.val + left;
            int rightSum = node.val + right;
            int max = Math.Max(Math.Max(left, right), totalSum);
            this.maxSum = Math.Max(this.maxSum, max);

            // But we will return only the max of node.val, node.val + left, node.val + right
            return Math.Max(Math.Max(node.val, leftSum), rightSum); // this is the key!!
        }
    }
}