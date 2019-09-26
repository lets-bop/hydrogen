using System;
using System.Collections.Generic;

/*
Given a binary tree, flatten it to a linked list in-place.

For example, given the following tree:

    1
   / \
  2   5
 / \   \
3   4   6
The flattened tree should look like:

1
 \
  2
   \
    3
     \
      4
       \
        5
         \
          6
*/
namespace LC_FB_Medium
{
    class FlattenBinaryTree
    {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public void Flatten(TreeNode root) {
            
            if (root == null) return;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode head = root;
            
            while (root != null || stack.Count > 0) {
                if (root.right != null) stack.Push(root.right);
                if (root.left != null) {
                    root.right = root.left;
                    root.left = null;
                }
                else if (stack.Count > 0) {
                    TreeNode qnode = stack.Pop();
                    root.right = qnode;
                }
                
                root = root.right;
            }
        }
    }
}