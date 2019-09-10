using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    class BinaryTreeCameras
    {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        int minCamera = 0;
        
        public int MinCameraCover(TreeNode root) {
            
            // corner case
            if (root != null && root.left == null && root.right == null) return 1;
            this.DoDFS(root);
            return minCamera;
            
        }
        
        private bool DoDFS(TreeNode node) {
            if (node == null) return false;
            
            if (node.left == null && node.right == null) return false; // leaf node delegate to parent

            bool leftHasCamera = this.DoDFS(node.left);
            bool rightHasCamera = this.DoDFS(node.right);
            
            if (!leftHasCamera && !rightHasCamera) {
                this.minCamera++;
                return true;
            }
            
            // only 1 of the children has a camera.
            // Since leaf nodes delegate to the parent, we need to check if either of the children are leaf nodes.
            // if so, we need to have a camera.
            if (!leftHasCamera) {
                if (node.left != null && node.left.left == null && node.left.right == null) {
                    // left child is a leaf node
                    this.minCamera++;
                    return true;
                }
            }

            if (!rightHasCamera) {
                if (node.right != null && node.right.left == null && node.right.right == null) {
                    // right child is a leaf node
                    this.minCamera++;
                    return true;
                }
            }

            return false;
        }
    }
}