/*
Given an array nums, we call (i, j) an important reverse pair if i < j and nums[i] > 2*nums[j].
You need to return the number of important reverse pairs in the given array.
Input: [1,3,2,3,1]
Output: 2

Example2:
Input: [2,4,3,5,1]
Output: 3

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class ImpReversePairs
    {
        public static BSTNode Root = null;

        public class BSTNode
        {
            public int Data;
            public int SubTreeSizeWithEqualOrHigherValue;
            public BSTNode Left;
            public BSTNode Right;

            public BSTNode(int data)
            {
                this.Data = data;
                this.SubTreeSizeWithEqualOrHigherValue = 1;
            }
        }

        private static void Insert(int data)
        {
            ImpReversePairs.Root = ImpReversePairs.Insert(ImpReversePairs.Root, data);
        }

        private static BSTNode Insert(BSTNode node, int data)
        {
            if (node == null) return new BSTNode(data);
            if (data < node.Data) node.Left = ImpReversePairs.Insert(node.Left, data);
            else
            {
                node.SubTreeSizeWithEqualOrHigherValue++;
                node.Right = ImpReversePairs.Insert(node.Right, data);   
            }
            
            return node;
        }

        private static int Search(BSTNode node, long data)
        {
            if (node == null) return 0;
            if (node.Data >= data) return ImpReversePairs.Size(node) + ImpReversePairs.Search(node.Left, data);
            else return ImpReversePairs.Search(node.Right, data);
        }

        private static int Size(BSTNode node)
        {
            if (node == null) return 0;
            return node.SubTreeSizeWithEqualOrHigherValue;
        }

        public static int Execute(int[] nums)
        {
            ImpReversePairs.Root = null;
            if (nums == null) return 0;
            int total = 0;

            foreach (int num in nums)
            {
                total += ImpReversePairs.Search(ImpReversePairs.Root, ((long) num) * 2 + 1);
                ImpReversePairs.Insert(num);
            }

            return total;
        }
    }
}