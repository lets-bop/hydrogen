using System;
using System.Collections.Generic;

/*
Given a binary tree, return the zigzag level order traversal of its nodes' values. 
(ie, from left to right, then right to left for the next level and alternate between).

For example:
Given binary tree [3,9,20,null,null,15,7],

    3
   / \
  9  20
    /  \
   15   7
return its zigzag level order traversal as:

[
  [3],
  [20,9],
  [15,7]
]
*/
namespace LC_FB_Medium
{
    class BinaryTreeZigZag
    {
        Stack<TreeNode> rlStack = new Stack<TreeNode>();
        Stack<TreeNode> lrStack = new Stack<TreeNode>();

        public IList<IList<int>> ZigzagLevelOrder1(TreeNode root) {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            rlStack.Push(root);

            int level = 0;
            while (rlStack.Count > 0 || lrStack.Count > 0) {
                result.Add(this.ProcessLevel(level));
                level++;
            }

            return result;
        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            int level = 0;
            Stack<TreeNode> from = new Stack<TreeNode>();
            Stack<TreeNode> to = new Stack<TreeNode>();
            Stack<TreeNode> temp;
            from.Push(root);

            while (from.Count > 0) {
                bool rightFirst = true;
                if (level == 0 || level % 2 == 0) rightFirst = false;
                IList<int> list = new List<int>();
                level++;

                while (from.Count > 0) {
                    TreeNode node = from.Pop();
                    list.Add(node.val);
                    if (rightFirst) {
                        if (node.right != null) to.Push(node.right);
                        if (node.left != null) to.Push(node.left);
                    } else {
                        if (node.left != null) to.Push(node.left);
                        if (node.right != null) to.Push(node.right);
                    }
                }

                result.Add(list);

                // swap from and to
                temp = from;
                from = to;
                to = temp;
            }

            return result;
        }

        private IList<int> ProcessLevel(int level) {
            IList<int> list = new List<int>();

            TreeNode node;
            if (level == 0 || level % 2 == 0) {
                while (rlStack.Count > 0) {
                    node = rlStack.Pop();
                    list.Add(node.val);
                    if(node.left != null) lrStack.Push(node.left);
                    if(node.right != null) lrStack.Push(node.right);
                }
            } else {
                while (lrStack.Count > 0) {
                    node = lrStack.Pop();
                    list.Add(node.val);
                    if(node.right != null) rlStack.Push(node.right);
                    if(node.left != null) rlStack.Push(node.left);
                }
            }

            return list;
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}