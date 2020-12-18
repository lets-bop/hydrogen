using System;
using System.Collections.Generic;

/*
Given the root of a binary tree with N nodes, each node in the tree has node.val coins, 
and there are N coins total. In one move, we may choose two adjacent nodes and move one 
coin from one node to another.  (The move may be from parent to child, or from child to parent.)
Return the number of moves required to make every node have exactly one coin.

           2                        2
          /                       /
         2                       5
        /                       / \
       1                       0   0
      /                       / \  /
     1                       0  0  0
    /
   0
  /
 0

 Moves = 8                  Moves = 8
*/
namespace LC_FB_Medium
{
    class BinaryTreeDistributeCoins
    {
        int moves = 0;

        public int DistributeCoins(TreeNode root) {
            this.moves = 0;
            this.DFS(root);
            return this.moves;
        }

        // The key to the problem is that the tree has only n coins. 
        // Hence if a leaf node doesnt have any coins, it has to receive coins from its parent.
        // Extra coins will be offered up to the parent.
        // Hence the value received by a node's left or right child will be positive (offer up)
        // or negative (request coins) depending on the available coins at the respective child.
        // We just need to do a post-order traversal and keep adding abs(left) + abs(right) to the ans.
        private int DFS(TreeNode node) {
            if (node == null) return 0;
            int left = DFS(node.left);
            int right = DFS(node.right);
            this.moves += Math.Abs(left) + Math.Abs(right);
            return node.val + left + right - 1; // -1 as current node needs to keep a coin for itself
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}