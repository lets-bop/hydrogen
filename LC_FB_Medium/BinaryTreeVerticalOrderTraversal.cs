using System;
using System.Collections.Generic;
/*
Given a binary tree, return the vertical order traversal of its nodes values.
For each node at position (X, Y), its left and right children respectively will be at positions (X-1, Y-1) and (X+1, Y-1).
Running a vertical line from X = -infinity to X = +infinity, whenever the vertical line touches some nodes, 
we report the values of the nodes in order from top to bottom (decreasing Y coordinates).
If two nodes have the same position, then the value of the node that is reported first is the value that is smaller.
Return an list of non-empty reports in order of X coordinate.  Every report will have a list of values of nodes.

Input: [3,9,20,null,null,15,7]
Output: [[9],[3,15],[20],[7]]
Explanation: 
Without loss of generality, we can assume the root node is at position (0, 0):
Then, the node with value 9 occurs at position (-1, -1);
The nodes with values 3 and 15 occur at positions (0, 0) and (0, -2);
The node with value 20 occurs at position (1, -1);
The node with value 7 occurs at position (2, -2).
*/
namespace LC_FB_Medium
{
    class BinaryTreeVerticalOrderTraversal
    {
        /*
        It's evident that there are two steps in a straightforward solution: 
        first, find the location of every node, then report their locations.

        Algorithm
        To find the location of every node, we can use a depth-first search. 
        During the search, we will maintain the location (x, y) of the node. 
        As we move from parent to child, the location changes to (x-1, y+1) or (x+1, y+1) 
        depending on if it is a left child or right child. 
        [We use y+1 to make our sorting by decreasing y easier.]
        To report the locations, we sort them by x coordinate, then y coordinate, 
        so that they are in the correct order to be added to our answer.
        */
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        internal class Location : IComparable
        {
            internal int x;
            internal int y;
            internal TreeNode node;

            internal Location(int x, int y, TreeNode node) {
                this.x = x;
                this.y = y;
                this.node = node;
            }

            public int CompareTo(object obj) {
                Location other = (Location)obj;
                if (other.x != this.x) return this.x - other.x;
                if (other.y != this.y) return this.y - other.y;
                return this.node.val - other.node.val;
            }
        }

        public IList<IList<int>> VerticalTraversal(TreeNode root) {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            List<Location> locs = new List<Location>();
            this.Dfs(root, 0, 0, locs);

            locs.Sort();
            List<int> list = new List<int>();
            list.Add(locs[0].node.val);

            for (int i = 1; i < locs.Count; i++) {
                if (locs[i].x != locs[i - 1].x) {
                    result.Add(list);
                    list = new List<int>();
                }
                list.Add(locs[i].node.val);
            }

            result.Add(list);
            return result;
        }

        private void Dfs(TreeNode node, int x, int y, IList<Location> loc) {
            if (node == null) return;
            if (node.left != null) Dfs(node.left, x - 1, y + 1, loc);
            if (node.right != null) Dfs(node.right, x + 1, y + 1, loc);            
            loc.Add(new Location(x, y, node));
        }
    }
}