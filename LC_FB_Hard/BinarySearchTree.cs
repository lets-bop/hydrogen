using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class BinarySearchTree
    {
        public TreeNode Root = null;
        Dictionary<int, TreeNode> nodeMap = new Dictionary<int, TreeNode>();

        public class TreeNode
        {
            public TreeNode left;
            public TreeNode right;
            public int val;

            public TreeNode(int value)
            {
                this.val = value;
            }
        }

        /*
        The input values will be of the form of a heap.
        Input: [3,1,4,null,null,2]

                3
                / \
                1  4
                   /
                   2

                Output: [2,1,4,null,null,3]

                2
                / \
               1   4
                   /
                  3
        */

        public BinarySearchTree(string[] values)

        {
            for (int i = 0; i < values.Length; i++){
                if (values[i] == null) continue;

                TreeNode current = null;
                if (this.nodeMap.ContainsKey(i)){
                    current = this.nodeMap[i];
                }
                else{
                    current = new TreeNode(int.Parse(values[i]));
                    if (this.Root == null) this.Root = current;
                }

                if (2 * i + 1 < values.Length){
                    TreeNode child = values[2*i + 1] == null ? null : new TreeNode(int.Parse(values[2*i + 1]));
                    current.left = child;
                    this.nodeMap[2 * i + 1] = child;
                }
                    
                if (2 * i + 2 < values.Length)
                {
                    TreeNode child = values[2*i + 2] == null ? null : new TreeNode(int.Parse(values[2*i + 2]));
                    current.right = child;
                    this.nodeMap[2 * i + 2] = child;                                                
                }                
            }
        }

        public List<string> TraverseInorder(){
            List<string> result = new List<string>();
            this.TraverseInorderRec(this.Root, result);
            return result;
        }

        private void TraverseInorderRec(TreeNode node, List<string> result){
            if (node == null){
                result.Add("null");
                return;
            }

            if (node.left == null && node.right == null){
                result.Add(node.val.ToString());
                return;
            }

            this.TraverseInorderRec(node.left, result);
            result.Add(node.val.ToString());
            this.TraverseInorderRec(node.right, result);

        }

        public List<string> TraverseHeapOrder(){
            List<string> result = new List<string>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(this.Root);

            while (q.Count > 0){
                TreeNode node = q.Dequeue();
                
                if (node == null){
                    result.Add("null");
                    continue;
                }
                else 
                    result.Add(node.val.ToString());

                // if (node.Left == null && node.Right == null) continue;
                q.Enqueue(node.left);
                q.Enqueue(node.right);
            }

            return result;
        }     
    }
}