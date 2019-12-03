using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    class LCAInBinaryTree
    {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        /*
        Algorithm

        1. Start from the root node and traverse the tree.
        2. Until we find p and q both, keep storing the parent pointers in a dictionary.
        3. Once we have found both p and q, we get all the ancestors for p using the parent 
           dictionary and add to a set called ancestors.
        4. Similarly, we traverse through ancestors for node q. If the ancestor is present in the ancestors set for p, 
           this means this is the first ancestor common between p and q (while traversing upwards) and hence this is the LCA node.
        */
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int found = 0;
            
            Dictionary<TreeNode, TreeNode> parent = new Dictionary<TreeNode, TreeNode>();
            parent[root] = null;
            while(queue.Count > 0) {
                TreeNode node = queue.Dequeue();
                if (p == node || q == node) found++;
                if (found == 2) break;
                if (node.left != null) {
                    queue.Enqueue(node.left);
                    parent[node.left] = node;
                }
                
                if (node.right != null) {
                    queue.Enqueue(node.right);
                    parent[node.right] = node;
                }
            }
            
            HashSet<TreeNode> ancestors = new HashSet<TreeNode>();
            while (p != null) {
                ancestors.Add(p);
                p = parent[p];
            }
            
            while (!ancestors.Contains(q)) {
                q = parent[q];
            }
            
            return q;
        }
    }
}