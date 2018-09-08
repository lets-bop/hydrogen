using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class RecoverBST
    {
        BinarySearchTree.TreeNode node1 = null;
        BinarySearchTree.TreeNode node1Pair = null;

        BinarySearchTree.TreeNode node2 = null;
        BinarySearchTree.TreeNode node2Pair = null;        

        public void RecoverTree(BinarySearchTree.TreeNode root) {
            this.IsBst(root, null, null, null);

            if (node1 != null && node2 != null){
                // Swap the min and max nodes
                BinarySearchTree.TreeNode minNode = node1;
                BinarySearchTree.TreeNode maxNode = node1;
                if (node1Pair != null && node1Pair.val < minNode.val) minNode = node1Pair;
                if (node2.val < minNode.val) minNode = node2;
                if (node2Pair != null && node2Pair.val < minNode.val) minNode = node2Pair;

                if (node1Pair != null && node1Pair.val > maxNode.val) maxNode = node1Pair;
                if (node2.val > maxNode.val) maxNode = node2;
                if (node2Pair != null && node2Pair.val > maxNode.val) maxNode = node2Pair;

                node1 = minNode;
                node2 = maxNode;                
            }
            else{
                node2 = node1Pair;
            }

            // Swap
            int temp = node1.val;
            node1.val = node2.val;
            node2.val = temp;

            Console.WriteLine("Swapping {0} and {1}", node1.val, node2.val);
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
                    if (this.node1 == null){
                        this.node1Pair = minNode;
                        this.node1 = node;
                    }
                    else if (this.node2 == null){
                        this.node2Pair = minNode;
                        this.node2 = node;
                    }
                }
            }
            if (maxNode != null){
                if (node.val > maxNode.val){
                    if (this.node1 == null){
                        this.node1Pair = maxNode;
                        this.node1 = node;
                    }
                    else if (this.node2 == null){
                        this.node2Pair = maxNode;
                        this.node2 = node;
                    }
                }                 
            }      

            this.IsBst(node.left, node, minNode, node);
            this.IsBst(node.right, node, node, maxNode);
        }
    }
}