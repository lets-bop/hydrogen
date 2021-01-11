using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).

        For example:
        Given binary tree [3,9,20,null,null,15,7],

         3
        / \
        9  20
          /  \
         15   7
        return its level order traversal as:

        [
        [3],
        [9,20],
        [15,7]
        ]
    */
    class BinaryTreeLevelOrderTraversal
    {
        public IList<IList<int>> LevelOrder(TreeNode root) {
            IList<IList<int>> list = new List<IList<int>>();
            
            if (root == null) return list;
            
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            Queue<TreeNode> levelQ = new Queue<TreeNode>();
            List<int> levelList = new List<int>();
            
            while(queue.Count > 0) {
                TreeNode node = queue.Dequeue();
                levelList.Add(node.val);
                if (node.left != null) levelQ.Enqueue(node.left);
                if (node.right != null) levelQ.Enqueue(node.right);
                if (queue.Count == 0) {
                    queue = levelQ;
                    levelQ = new Queue<TreeNode>();
                    list.Add(levelList);
                    levelList = new List<int>();
                }
            }
            
            return list;
        }

        internal class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            internal TreeNode(int x) { val = x; }
        }
    }
}