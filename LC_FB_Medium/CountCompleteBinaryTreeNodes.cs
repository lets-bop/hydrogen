using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
        Given a complete binary tree, count the number of nodes.
        Note:
        Definition of a complete binary tree from Wikipedia:
        In a complete binary tree every level, except possibly the last, is completely filled, and all nodes in the last level are as far left as possible. It can have between 1 and 2h nodes inclusive at the last level h.

        Example:
        Input: 
          1
        /   \
        2    3
       / \  /
      4  5 6

        Output: 6
    */    
    class CountCompleteBinaryTreeNodes
    {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }        
        public int CountNodes(TreeNode root) 
        {
            if (root == null) return 0;

            // Excluding the last level, the tree will have 2^d - 1 nodes
            int depth = this.FindTreeDepth(root);
            if (depth == 0) return 1;

            // The last level could have upto 2^d nodes.
            // We will use binary search to look for the presence of a node (by index) which will take O(d) time,
            // as we start from the root and depending on the index of the node being searched, decide to go either left or right.
            // Its a complete binary tree and hence the nodes are as far left as possible. 
            // We will not check for the presence of all 2^d nodes, but instead check for log(2^d) = d, because its a binsearch.
            // Therefore, overall time complexity is O(d) * O(log(2^d)) = O(d^2)
            // Last level nodes are enumerated from 0 to 2**d - 1 (left -> right).
            // Perform binary search to check how many nodes exist.
            int totalNodesUptoLastLevel = (int) Math.Pow(2, depth) - 1; // = indexOfMaxNodesPossibleInLastLevel

            // We check the nodes in the last level. last level can have upto 2^d nodes.
            // index of nodes in the last level will be 2^d - 1
            // since we know the left most node will exist (index 0), we start (low) from 1.
            int low = 1; 
            int high = totalNodesUptoLastLevel;
            int mid;
            while (low <= high) {
                mid = low + (high - low) / 2;
                if (this.NodeExists(root, mid, totalNodesUptoLastLevel, depth)) {
                    low = mid + 1;
                } else {
                    high = mid - 1;
                }
            }

            return totalNodesUptoLastLevel + low;
        }

        public bool NodeExists(TreeNode root, int nodeIndex, int iindexOfMaxNodesPossibleInLastLevel, int depth)
        {
            int low = 0;
            int high = iindexOfMaxNodesPossibleInLastLevel;
            int mid;

            for (int i = 0; i < depth; i++) { // its important that we only go upto the last level, not including it.
                mid = low + (high - low) / 2;
                if (nodeIndex <= mid) { // the <= check is important as indices start with 0.
                    root = root.left;
                    high = mid;
                }
                else {
                    root = root.right;
                    low = mid;
                }
            }

            // we are at a node on the last level. If this is not null, then that node exists.
            return root != null;
        }

        private int FindTreeDepth(TreeNode root)
        {
            int depth = 0;
            while (root != null && root.left != null) {
                root = root.left;
                depth++;
            }

            return depth;
        }
    }
}