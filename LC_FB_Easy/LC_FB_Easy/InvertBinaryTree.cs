using System;
using System.Collections.Generic;

/*
Invert a binary tree.

Example:

Input:

     4
   /   \
  2     7
 / \   / \
1   3 6   9
Output:

     4
   /   \
  7     2
 / \   / \
9   6 3   1
Trivia:
This problem was inspired by this original tweet by Max Howell:

Google: 90% of our engineers use the software you wrote (Homebrew), 
but you can’t invert a binary tree on a whiteboard so f*** off.
*/
namespace LC_FB_Easy
{
    class InvertBinaryTree
    {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        
        public TreeNode InvertTree(TreeNode root) {
            if (root == null) return null;
            TreeNode left = root.left;
            root.left = root.right;
            root.right = left;
            InvertTree(root.left);
            InvertTree(root.right);
            return root;
        }
    }
}