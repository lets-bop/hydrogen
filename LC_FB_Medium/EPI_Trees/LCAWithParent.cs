using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class LCAWithParent
    {
        public static CustomTree<int>.Node Execute(CustomTree<int> tree, CustomTree<int>.Node node1, CustomTree<int>.Node node2)
        {
            CustomTree<int>.Node root = tree.Root;

            // Determine the height of node1
            int node1Height = GetHeight(root, node1);

            // Determine the height of node2
            int node2Height = GetHeight(root, node2);
            
            // Compare the heights and ascend up from the larger of the 2 heights to equate the two
            while (node1Height != node2Height)
            {
                if (node2Height > node1Height) 
                {
                    node2 = node2.Parent;
                    node2Height--;
                }
                
                else
                {
                    node1 = node1.Parent;
                    node1Height--;
                }
            }

            // Ascend up simultaneously from the 2 nodes until you have a common node, which will be the ancestor
            while (node1 != node2)
            {
                node1 = node1.Parent;
                node2 = node2.Parent;
            }

            return node1;
        }

        private static int GetHeight(CustomTree<int>.Node root, CustomTree<int>.Node node)
        {
            int height = 0;
            while (node != root)
            {
                height += 1;
                node = node.Parent;
            }
            return height;
        }
    }
}