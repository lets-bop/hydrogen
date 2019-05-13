/*
Given an array nums, we call (i, j) an important reverse pair if i < j and nums[i] > 2*nums[j].
You need to return the number of important reverse pairs in the given array.
Input: [1,3,2,3,1]
Output: 2 (Reason 3 > 1, 3 > 1)

Example2:
Input: [2,4,3,5,1]
Output: 3 (Reason: 4 > 1, 3 > 1, 5 > 1)

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

        public static int Execute2(int[] nums)
        {
            if (nums == null || nums.Length <= 1) return 0;
            return MergeSortForReversePairs(nums, 0, nums.Length - 1);
        }

        private static int MergeSortForReversePairs(int[] nums, int lo, int hi)
        {
            if (lo == hi) return 0;
            int mid = lo + (hi - lo) / 2;
            int left = MergeSortForReversePairs(nums, lo, mid);
            int right = MergeSortForReversePairs(nums, mid + 1, hi);
            int count = left + right;
            
            // Add up the inversions before merge sorting
            for (int i = lo; i <= mid; i++){
                int j = mid + 1;
                while(j <= hi){
                    if ((long)nums[i] > (long)2 * nums[j]) j++;   
                    else break;              
                }

                count += (j - mid - 1);
            }

            Merge(nums, lo, mid, hi);
            return count;
        }

        private static void Merge(int[] nums, int lo, int mid, int hi)
        {
            // create left and right sub arrays
            int[] left = new int[mid - lo + 1];
            int[] right = new int[hi - mid];
            for (int i = lo, k = 0; i <= mid; i++, k++) left[k] = nums[i];
            for (int i = mid + 1, k = 0; i <= hi; i++, k++) right[k] = nums[i];

            // merge left and right
            int p = 0;
            int q = 0;
            int r = lo;
            while (p < left.Length && q < right.Length){
                if (left[p] < right[q]) nums[r++] = left[p++];
                else nums[r++] = right[q++];
            }

            while (p < left.Length) nums[r++] = left[p++];
            while (q < right.Length) nums[r++] = right[q++];
        }
    }
}