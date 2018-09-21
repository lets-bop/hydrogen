using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class RecoverBST
    {
        HashSet<BinarySearchTree.TreeNode> nodes = new HashSet<BinarySearchTree.TreeNode>();

        public void RecoverTree(BinarySearchTree.TreeNode root) {
            this.IsBst(root, null, null, null);
            BinarySearchTree.TreeNode minNode = null;
            BinarySearchTree.TreeNode maxNode = null;

            foreach (BinarySearchTree.TreeNode node in this.nodes){
                if (minNode == null && maxNode == null){
                    minNode = maxNode = node;
                }
                if (node.val < minNode.val) minNode = node;
                if (node.val > maxNode.val) maxNode = node;
            }            

            // Swap
            int temp = minNode.val;
            minNode.val = maxNode.val;
            maxNode.val = temp;

            Console.WriteLine("Swapping {0} and {1}", minNode.val, maxNode.val);
        }

        private void IsBst(
            BinarySearchTree.TreeNode node,
            BinarySearchTree.TreeNode parent, 
            BinarySearchTree.TreeNode minNode, 
            BinarySearchTree.TreeNode maxNode)
        {
            if (node == null) return;

            if (minNode != null){
                if (node.val < minNode.val){
                    this.nodes.Add(node);
                    this.nodes.Add(minNode);
                }
            }
            if (maxNode != null){
                if (node.val > maxNode.val){
                    this.nodes.Add(node);
                    this.nodes.Add(maxNode);
                }                 
            }      

            this.IsBst(node.left, node, minNode, node);
            this.IsBst(node.right, node, node, maxNode);
        }
    }
}