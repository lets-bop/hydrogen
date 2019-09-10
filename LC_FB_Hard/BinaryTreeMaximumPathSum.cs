using System;
using System.Collections.Generic;

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
            int sum = node.val + left + right;
            if (sum < node.val) sum = node.val;
            if (sum < node.val + left) sum = node.val + left;
            if (sum < node.val + right) sum = node.val + right;
            this.maxSum = Math.Max(sum, this.maxSum);

            // But we will return only the max of node.val, node.val + left, node.val + right
            return Math.Max(Math.Max(node.val, node.val + left), node.val + right); // this is the key!!
        }
    }
}