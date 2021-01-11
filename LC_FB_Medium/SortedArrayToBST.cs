using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    class SortedArrayToBST
    {
        public TreeNode GetBST(int[] nums) {
            if (nums == null || nums.Length == 0) return null;
            return BuildTree(nums, 0, nums.Length - 1);
        }
        
        private TreeNode BuildTree(int[] nums, int low, int high) {
            if (low > high) return null;
            int mid = low + (high - low) / 2;
            TreeNode node = new TreeNode(nums[mid]);
            node.left = this.BuildTree(nums, low, mid - 1);
            node.right = this.BuildTree(nums, mid + 1, high);
            return node;
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}