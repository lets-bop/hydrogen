using System;
using System.Collections.Generic;

/*
Given a binary tree and a sum, determine if the tree has a root-to-leaf path 
such that adding up all the values along the path equals the given sum.

Note: A leaf is a node with no children.
Example:
Given the below binary tree and sum = 22,

      5
     / \
    4   8
   /   / \
  11  13  4
 /  \      \
7    2      1
return true, as there exist a root-to-leaf path 5->4->11->2 which sum is 22.
*/
namespace LC_FB_Easy
{
    class BinaryTreePathSum
    {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public bool HasPathSum(TreeNode root, int sum) {
            return this.FindSum(root, sum, 0);
        }
        
        private bool FindSum(TreeNode node, int sum, int parentSum) {
            if (node == null) return false;
            int currSum = node.val + parentSum;
            if (currSum == sum && node.left == null && node.right == null) return true;
            return FindSum(node.left, sum, currSum) || FindSum(node.right, sum, currSum);
        }
    }
}