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
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        int minCamera;
        HashSet<TreeNode> covered;
        
        public int MinCameraCover(TreeNode root) {
            minCamera = 0;
            covered = new HashSet<TreeNode>();
            this.DoDFS(root, null);
            return minCamera;
        }
        
        private void DoDFS(TreeNode node, TreeNode parent) {
            if (node == null) return;
            if (node.left != null) this.DoDFS(node.left, node);
            if (node.right != null) this.DoDFS(node.right, node);

            bool needCamera = false;
            if (parent == null && !this.covered.Contains(node)) needCamera = true;
            else if (node.left != null && !this.covered.Contains(node.left)) needCamera = true;
            else if (node.right != null && !this.covered.Contains(node.right)) needCamera = true;

            if (needCamera) {
                    if (parent != null) this.covered.Add(parent);
                    this.covered.Add(node);
                    if (node.left != null) this.covered.Add(node.left);
                    if (node.right != null) this.covered.Add(node.right);
                    this.minCamera++;
            }
        }
    }
}