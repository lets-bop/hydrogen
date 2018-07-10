using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Easy
{
    class BST
    {
        public class TreeNode
        {
            public int Value;
            public TreeNode Left;

            public TreeNode Right;

            public TreeNode(int value)
            {
                this.Value = value;
            }
        }

        public static TreeNode Build(string def)
        {
            string[] nodes = def.Split(';');
            TreeNode root = null;
            foreach (string node in nodes)
            {
                int nodeValue, leftValue, rightvalue;
                string[] nodeAndChildren = node.Split('C');
                nodeValue = int.Parse(nodeAndChildren[0]);
                TreeNode tNode;
                if (root == null)
                {
                    root = new TreeNode(nodeValue);
                    tNode = root;
                }
                else
                {
                    tNode = BST.Find(root, nodeValue);
                    if (tNode == null)
                        throw new Exception(string.Format("Tree node {0} not added before.", nodeValue));
                }

                string[] children = nodeAndChildren[1].Split(',');
                TreeNode leftNode = null;
                TreeNode rightNode = null;

                if(children.Length == 2 && children[0] != "-")
                {
                    leftValue = int.Parse(children[0]);
                    // Make sure the right and left node values are not added yet
                    if (BST.Find(root, leftValue) != null)
                        throw new Exception(string.Format("Tree node {0} has been added before.", leftValue));
                    leftNode = new TreeNode(leftValue);
                }

                if(children.Length == 2 && children[1] != "-")
                {
                    rightvalue = int.Parse(children[1]);
                    // Make sure the right and left node values are not added yet
                    if (BST.Find(root, rightvalue) != null)
                        throw new Exception(string.Format("Tree node {0} has been added before.", rightvalue));
                    rightNode = new TreeNode(rightvalue);
                }

                tNode.Left = leftNode;
                tNode.Right = rightNode;
            }

            return root;
        }

        public static TreeNode Find(TreeNode root, int value)
        {
            if (root != null)
            {
                if (root.Value == value)
                    return root;
                else if (root.Value > value)
                    return BST.Find(root.Left, value);
                else
                    return BST.Find(root.Right, value);
            }

            return null;
        }

        public static void PrintInOrder(TreeNode root, StringBuilder sb)
        {
            if (sb == null)
                throw new Exception("StringBuilder expected");

            if (root == null)
                return;

            PrintInOrder(root.Left, sb);
            sb.AppendFormat("{0}\t", root.Value);
            PrintInOrder(root.Right, sb);
        }
    }
}