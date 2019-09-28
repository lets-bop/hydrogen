/*
The lowest common ancestor is defined between two nodes p and q as the lowest node in T 
that has both p and q as descendants (where we allow a node to be a descendant of itself).
        _______6______
       /              \
    ___2__          ___8__
   /      \        /      \
   0      _4       7       9
         /  \
         3   5
Input: root, p = 2, q = 8
Output: 6

Input: root p = 2, q = 4
Output: 2

 */

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Easy
{
    class LCAInBST
    {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            // All of the nodes' values will be unique.
            // p and q are different and both values will exist in the BST.
            if (p.val < q.val) return this.Find(root, p.val, q.val);
            return this.Find(root, q.val, p.val);
        }
        
        private TreeNode Find(TreeNode node, int small, int big) {
            if (node == null) return null;
            if (node.val > small && node.val < big) return node;
            if (node.val == small || node.val == big) return node;
            if (node.val < small) return this.Find(node.right, small, big);
            return this.Find(node.left, small, big);
        }

        public static int Find(BST.TreeNode root, int p, int q)
        {
            if(root == null)
                throw new Exception("Root cant be null");
            
            if (root.Value >= p && root.Value <= q || root.Value >=q && root.Value <= p)
                return root.Value;
            else if (root.Value <= p && root.Value <=q)
                return LCAInBST.Find(root.Right, p, q);
            else return LCAInBST.Find(root.Left, p, q);
        }
    }
}