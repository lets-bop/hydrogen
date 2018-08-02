/*
List the elements of a 2D array in spiral order.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class LCA
    {
        private class Status
        {
            public int TargetCount;
            public CustomTree<int>.Node Ancestor;

            public Status(int targetCount, CustomTree<int>.Node ancestor)
            {
                this.TargetCount = targetCount;
                this.Ancestor = ancestor;
            }
        }
        public static CustomTree<int>.Node Execute(CustomTree<int> tree, CustomTree<int>.Node node1, CustomTree<int>.Node node2)
        {
            Status status = ExecuteWithStatus(tree.Root, node1, node2); 
            return status.Ancestor;
        }

        private static Status ExecuteWithStatus(CustomTree<int>.Node root, CustomTree<int>.Node node1, CustomTree<int>.Node node2)
        {
            if (root == null) return new Status(0, null);

            Status leftStatus = ExecuteWithStatus(root.Left, node1, node2);
            if (leftStatus.TargetCount == 2) return leftStatus;

            Status rightStatus = ExecuteWithStatus(root.Right, node1, node2);
            if (rightStatus.TargetCount == 2) return rightStatus;            
            
            int targetCount = 
                leftStatus.TargetCount + rightStatus.TargetCount + 
                (root == node1 ? 1 : 0) +  (root == node2 ? 1 : 0);

            if (targetCount == 2) return new Status(2, root);
            return new Status(targetCount, null);
        }
    }
}