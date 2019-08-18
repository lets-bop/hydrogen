using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    class BSTDoublyList
    {
        public class Node {
            public int val;
            public Node left;
            public Node right;
            public Node(int _val,Node _left,Node _right) {
                val = _val;
                left = _left;
                right = _right;
            }
        }

    public Node TreeToDoublyList(Node root) {
            this.Inorder(root);
            if (this.firstSeen != null)
                this.firstSeen.left = this.lastSeen;
            if (this.lastSeen != null)
                this.lastSeen.right = this.firstSeen;
            return this.firstSeen;
        }

        Node firstSeen;
        Node lastSeen;

        private void Inorder(Node root) {
            if (root == null) return;

            this.Inorder(root.left);

            if (this.lastSeen != null) {
                this.lastSeen.right = root;
                root.left = this.lastSeen;
            } else {
                this.firstSeen = root;
            }
            
            this.lastSeen = root;
            this.Inorder(root.right);
        }
    }
}