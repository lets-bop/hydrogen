/*
Check if the binary tree is symmetric.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class CheckSymmetric
    {
        public static bool Execute(CustomTree<int> tree)
        {
            if (tree.Root == null) return true;
            return Execute(tree.Root.Left, tree.Root.Right);
        }

        private static bool Execute(CustomTree<int>.Node subTree1, CustomTree<int>.Node subTree2)
        {
            if (subTree1 == null && subTree2 == null) return true;
            if (subTree1 == null || subTree2 == null) return false;
            
            return 
                (subTree1.Data.CompareTo(subTree2.Data) == 0) && 
                Execute(subTree1.Left, subTree2.Right) && 
                Execute(subTree1.Right, subTree2.Left);
        }
    }
}





