using System;
using System.Collections.Generic;

/*
Given a non-empty binary search tree and a target value, find k values in the BST that are closest to the target.

Note:

Given target value is a floating point.
You may assume k is always valid, that is: k ≤ total nodes.
You are guaranteed to have only one unique set of k values in the BST that are closest to the target.
Example:

Input: root = [4,2,5,1,3], target = 3.714286, and k = 2

    4
   / \
  2   5
 / \
1   3

Output: [4,3]
Follow up:
Assume that the BST is balanced, could you solve it in less than O(n) runtime (where n = total nodes)?

Hint 1: Consider implement these two helper functions:
    getPredecessor(N), which returns the next smaller node to N.
    getSuccessor(N), which returns the next larger node to N.
Hint 2: Try to assume that each node has a parent pointer, it makes the problem much easier.
HInt 3: Without parent pointer we just need to keep track of the path from the root to the current node using a stack.
Hint 4: You would need two stacks to track the path in finding predecessor and successor node separately.

*/
namespace LC_FB_Hard
{
    class KClosestBstValues
    {
        public IList<int> ClosestKValues(TreeNode root, double target, int k) {
            Stack<TreeNode> pred = new Stack<TreeNode>();
            Stack<TreeNode> succ = new Stack<TreeNode>();

            this.GetPredecessors(root, target, pred);
            this.GetSuccessors(root, target, succ);

            IList<int> result = new List<int>();
            while (result.Count < k) {
                if (pred.Count == 0 || (succ.Count > 0 && succ.Peek().val - target < target - pred.Peek().val)) {
                    TreeNode node = succ.Pop();
                    result.Add(node.val);
                    this.GetSuccessors(node.right, target, succ);
                } else {
                    TreeNode node = pred.Pop();
                    result.Add(node.val);
                    this.GetPredecessors(node.left, target, pred);
                }
            }

            return result;
        }

        private void GetPredecessors(TreeNode node, double target, Stack<TreeNode> s)
        {
            if (node == null) return;
            if (target > node.val) {
                s.Push(node);
                GetPredecessors(node.right, target, s);
            } else GetPredecessors(node.left, target, s);
        }

        private void GetSuccessors(TreeNode node, double target, Stack<TreeNode> s)
        {
            if (node == null) return;
            if (target <= node.val) {
                s.Push(node);
                GetSuccessors(node.left, target, s);
            } else GetSuccessors(node.right, target, s);
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}