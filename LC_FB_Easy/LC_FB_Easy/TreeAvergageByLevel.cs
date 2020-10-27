using System;
using System.Collections.Generic;

public class TreeAverageByLevel
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode (int val)
        {
            this.val = val;
        }
    }

    public List<int> Calculate(TreeNode root)
    {
        List<int> result = new List<int>();
        if (root == null) return result;
        List<TreeNode> nodesInLevel = new List<TreeNode>();
        nodesInLevel.Add(root);
        this.Calculate(result, nodesInLevel);
        return result;
    }

    public void Calculate(List<int> result, List<TreeNode> nodesInCurrentLevel)
    {
        if (nodesInCurrentLevel == null || nodesInCurrentLevel.Count == 0) return;
        int sum = 0;
        List<TreeNode> nodeInNextLevel = new List<TreeNode>();
        
        foreach (TreeNode node in nodesInCurrentLevel)
        {
            sum += node.val;
            if (node.left != null) nodeInNextLevel.Add(node.left);
            if (node.right != null) nodeInNextLevel.Add(node.right);
        }

        result.Add(sum / nodesInCurrentLevel.Count);
        this.Calculate(result, nodeInNextLevel);
    }
}