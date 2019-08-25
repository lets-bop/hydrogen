using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
/*
    Given a binary tree, imagine yourself standing on the right side of it, 
    return the values of the nodes you can see ordered from top to bottom.

    Example:
    Input: [1,2,3,null,5,null,4]
    Output: [1, 3, 4]
*/
}
    class BinaryTreeRightSideView
    {

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        IList<int> list;
        int levelSeen;
 
        public IList<int> RightSideView(TreeNode root) {
            this.list = new List<int>();
            this.levelSeen = -1;
            this.Traverse(root, 0);
            return this.list;
        }

        private void Traverse(TreeNode node, int level) {
            if (node == null) return;
            
            // We are seeing the first node in this level. Add it to the list.
            if (this.levelSeen < level) {
                this.levelSeen = level;
                this.list.Add(node.val);
            }

            // Since we need all right nodes first, we traverse right child before left.
            this.Traverse(node.right, level + 1);
            this.Traverse(node.left, level + 1);
        }
    }