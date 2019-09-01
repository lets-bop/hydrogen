using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    class BinaryTreeZigZag
    {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        Stack<TreeNode> rlStack = new Stack<TreeNode>();
        Stack<TreeNode> lrStack = new Stack<TreeNode>();

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
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
    }
}