/*
Check if the binary tree is height balanced.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class CheckHeightBalanaced
    {
        private class Status
        {
            public int Height;
            public bool IsBalanced;

            public Status(int height, bool isBalanced)
            {
                this.Height = height;
                this.IsBalanced = isBalanced;
            }
        }

        public static bool Execute(CustomTree<int> tree)
        {
            Status status = ExecuteWithStatus(tree.Root);
            return status.IsBalanced;
        }

        private static Status ExecuteWithStatus(CustomTree<int>.Node node)
        {
            if (node == null) return new Status(-1, true);

            Status leftStatus = ExecuteWithStatus(node.Left);
            if (!leftStatus.IsBalanced) return leftStatus;
            
            Status rightStatus = ExecuteWithStatus(node.Right);
            if (!rightStatus.IsBalanced) return rightStatus;

            int height = Math.Abs(leftStatus.Height - rightStatus.Height);
            if(height > 1) return new Status(height, false);

            return new Status(Math.Max(leftStatus.Height, rightStatus.Height) + 1, true);
        }
    }
}





