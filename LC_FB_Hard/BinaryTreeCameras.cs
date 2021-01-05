using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    /*
        Given a binary tree, we install cameras on the nodes of the tree. 
        Each camera at a node can monitor its parent, itself, and its immediate children.
        Calculate the minimum number of cameras needed to monitor all nodes of the tree.

        Input: [0,0,null,0,0]
                0
               /
              0 (c)
            /  \
           0   0
        Output: 1
        Explanation: One camera is enough to monitor all nodes if placed as shown.

        Input: [0,0,null,0,null,0,null,null,0]
                0
               /
              0 (c)
            /
           0
          /
         0 (c)
          \
           0
        Output: 2
        Explanation: At least two cameras are needed to monitor all nodes of the tree. 
        The above image shows one of the valid configurations of camera placement.
    */
    class BinaryTreeCameras
    {
        int minCamera;

        public int MinCameraCover(TreeNode root) {
            minCamera = 0;
            HashSet<TreeNode> covered = new HashSet<TreeNode>(); // the default implementation of GetHashCode() based on instance is sufficient
            this.DFS(root, null, covered);
            return minCamera;
        }

        private bool DFS(TreeNode node, TreeNode parent, HashSet<TreeNode> covered) {
            // do a post order traversal
            if (node == null) return true;
            bool isLeftCovered = this.DFS(node.left, node, covered);
            bool isRightCovered = this.DFS(node.right, node, covered);

            // we need a camera if the parent is null and we are not yet covered or 
            // if either the left child or the right child is not yet covered.
            if (!isLeftCovered || !isRightCovered || (!covered.Contains(node) && parent == null)) {
                Add(node, covered);
                Add(node.left, covered);
                Add(node.right, covered);
                Add(parent, covered);
                this.minCamera++;
            }

            return covered.Contains(node);
        }

        private static void Add(TreeNode node, HashSet<TreeNode> covered) {
            if (node == null || covered.Contains(node)) return;
            covered.Add(node);
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}