using System;
using System.Collections.Generic;

/*
Given a binary tree and a sum, find all root-to-leaf paths where each path's sum equals the given sum.

Note: A leaf is a node with no children.

Example:

Given the below binary tree and sum = 22,

      5
     / \
    4   8
   /   / \
  11  13  4
 /  \    / \
7    2  5   1
Return:

[
   [5,4,11,2],
   [5,8,4,5]
]
*/
namespace LC_FB_Medium
{
    class BinaryTreePathSum2
    {
        IList<IList<int>> result;

        public IList<IList<int>> PathSum(TreeNode root, int sum) {
            result = new List<IList<int>>();
            this.PathSum(root, sum, 0, new List<int>());
            return result;
        }

        private void PathSum(TreeNode node, int sum, int parentSum, List<int> parentList) {
            if (node == null) return;
            int currSum = node.val + parentSum;
            if (currSum == sum && node.left == null && node.right == null) {
                //create a new list
                List<int> list = new List<int>(parentList);
                list.Add(node.val);
                result.Add(list);
                return;
            }
            
            parentList.Add(node.val);
            this.PathSum(node.left, sum, currSum, parentList);
            this.PathSum(node.right, sum, currSum, parentList);
            parentList.RemoveAt(parentList.Count - 1); // remove current value when returning back from recursion
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}