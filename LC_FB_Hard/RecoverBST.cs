using System;
using System.Collections.Generic;
using System.Text;

/*
Two elements of a BST are swapped by mistake. Recover the tree without changing its structure.

Example 1:
Input: [1,3,null,null,2]

   1
  /
 3
  \
   2

Output: [3,1,null,null,2]
   3
  /
 1
  \
   2

Example 2:
Input: [3,1,4,null,null,2]
  3
 / \
1   4
   /
  2

Output: [2,1,4,null,null,3]
  2
 / \
1   4
   /
  3

Follow up:
    A solution using O(n) space is pretty straight forward.
    Could you devise a constant space solution?
*/
namespace LC_FB_Hard
{
    public class RecoverBST
    {
        TreeNode first, second, prev;

        public void RecoverTree(TreeNode root) {
            this.Inorder(root);
            
            if (this.first != null && this.second != null) {
                // swap
                int temp = first.val;
                first.val = second.val;
                second.val = temp;
                Console.WriteLine("Swapped: " + first.val + "\t" + second.val);
            }
        }
        
        public void Inorder(TreeNode node) {
            // Inorder traversal will return values in an increasing order. 
            // So if the current element < previous element,the previous element is a swapped node.
            if (node == null) return;
            
            this.Inorder(node.left);
            if (this.prev != null) {
                if (this.prev.val > node.val) {
                    if (this.first == null) this.first = this.prev;
                    this.second = node;
                }
            }
            
            this.prev = node;
            
            Inorder(node.right);
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}