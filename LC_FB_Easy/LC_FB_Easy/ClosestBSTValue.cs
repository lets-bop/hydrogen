using System;
using System.Collections.Generic;

/*
Given a non-empty binary search tree and a target value, find the value in the BST that is closest to the target.
Note: Given target value is a floating point. You are guaranteed to have only one unique value in the BST that is closest to the target.

Example:
Input: root = [4,2,5,1,3], target = 3.714286

    4
   / \
  2   5
 / \
1   3

Output: 4
*/
namespace LC_FB_Easy
{
    class ClosestBSTValue
    {
        public int ClosestValue(TreeNode root, double target) {
            return BSTSearch(root, target);
        }
        
        private int BSTSearch(TreeNode node, double target) {
            
            double delta = double.MaxValue;
            int ret = -1;
            
            while (node != null) {
                double tempDelta = Math.Abs(target - node.val);
                if (delta > tempDelta) {
                    delta = tempDelta;
                    ret = node.val;
                }
                
                if (target < node.val) node = node.left;
                else if (target > node.val) node = node.right;
                else break;
            }
            
            return ret;
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}