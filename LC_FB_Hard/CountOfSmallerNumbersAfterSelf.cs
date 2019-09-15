using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    /*
        You are given an integer array nums and you have to return a new counts array. 
        The counts array has the property where counts[i] is the number of smaller elements to the right of nums[i].

        Example:
        Input: [5,2,6,1]
        Output: [2,1,1,0]

        Explanation:
        To the right of 5 there are 2 smaller elements (2 and 1).
        To the right of 2 there is only 1 smaller element (1).
        To the right of 6 there is 1 smaller element (1).
        To the right of 1 there is 0 smaller element.
    */
    class CountOfSmallerNumbersAfterSelf
    {
        public IList<int> CountSmaller(int[] nums) {
            if (nums == null || nums.Length == 0) return nums;
            // return this.CountNaive(nums);
            return CountWithBST(nums);
        }

        private IList<int> CountNaive(int[] nums) { // O(n^2) time
            IList<int> list = new List<int>();
            for(int i = 0; i < nums.Length; i++) list.Add(0);
            for (int i = nums.Length - 1; i >= 0; i--) {
                int count = 0;
                for (int j = nums.Length - 1; j >= i + 1; j--) {
                    if (nums[i] > nums[j]) count++;
                }

                list[i] = count;
            }

            return list;
        }

        private IList<int> CountWithBST(int[] nums) {
            List<int> result = new List<int>();
            if (nums == null || nums.Length == 0) return nums;

            // We are just going to iterate the nums array from right to left and build a BST.
            // The worst case will still be O(n^2) as we are not building a balanced BST. But avg case is O(nlgn)
            // The root is the right most element in the array. 
            // We need to keep track of duplicates as well as the number of nodes to the left of self
            // Hence every node will have count (track duplicate values), leftCount and val
            Node node = null;
            for (int i = nums.Length - 1; i >= 0; i--) {
                node = this.InsertNode(node, nums[i], 0, result);
            }

            result.Reverse();
            return result;
        }

        public class Node {
            public int Val;
            public int Count; // track duplicates, will increment if node to be inserted has same val as self
            public int LeftCount; // number of nodes to the left of self
            public Node Left;
            public Node Right;

            public Node(int v, int c, int snc) {
                this.Val = v; this.Count = c; this.LeftCount = snc;
            }
        }

        private Node InsertNode(Node node,int val, int smallerNodeCount, IList<int> result) {
            if (node == null) {
                result.Add(smallerNodeCount);
                return new Node(val, 1, 0);
            }

            if (node.Val == val) {
                node.Count++;
                result.Add(smallerNodeCount + node.LeftCount);
                return node;
            }

            if (node.Val > val) {
                node.LeftCount++;
                node.Left = this.InsertNode(node.Left, val, smallerNodeCount, result);
            }

            else node.Right = this.InsertNode(node.Right, val, smallerNodeCount + node.Count + node.LeftCount, result);
            return node;
        }
    }
}