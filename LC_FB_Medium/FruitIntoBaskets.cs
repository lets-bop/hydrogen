using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
        In a row of trees, the i-th tree produces fruit with type tree[i].
        You have two baskets, and each basket can carry any quantity of fruit, 
        but you want each basket to only carry one type of fruit each.

        You can start at any tree of your choice, then repeatedly perform the following steps ONLY:
            1. Add one piece of fruit from this tree to your baskets.  If you cannot, stop.
            2. Move to the next tree to the right of the current tree.  If there is no tree to the right, stop.
        you must perform step 1, then step 2, then back to step 1, then step 2, and so on until you stop.

        What is the maximum amount of fruit you can collect with this procedure?
        Example 1:
        Input: [1,2,1]
        Output: 3
        Explanation: We can collect [1,2,1].
        
        Example 2:
        Input: [0,1,2,2]
        Output: 3
        Explanation: We can collect [1,2,2]. If we started at the first tree, we would only collect [0, 1].
        
        Example 3:
        Input: [1,2,3,2,2]
        Output: 4
        Explanation: We can collect [2,3,2,2]. If we started at the first tree, we would only collect [1, 2].        
    */
    class FruitIntoBaskets
    {
        public int TotalFruit(int[] tree) 
        {
            // Let a hold the first seen value and b the second.
            // We need to keep track of the lastSeen value and its count
            // to be able to account of repeating values but out of order like (1,2,1,1,3,3,3,3)
            // In the example, though 1 appears 3 times when paired with 2, but when paired with 3, 
            // we can only count 2.
            if (tree == null || tree.Length == 0) return 0;
            if (tree.Length <= 2) return tree.Length;

            int a = tree[0], aCt = 1, b = -1, bCt = 0, lastSeen = a, lastSeenCt = 1, count = 0;
            for (int i = 1; i < tree.Length; i++) {
                if (tree[i] == a) aCt++;
                else if (b == -1) { b = tree[i]; bCt = 1;}
                else if (tree[i] == b) bCt++;
                else {
                    count = Math.Max(count, aCt + bCt);
                    a = lastSeen; aCt = lastSeenCt;
                    b = tree[i]; bCt = 1;
                    lastSeen = b; lastSeenCt = 1;
                    continue;
                }

                if (tree[i] == lastSeen) lastSeenCt++;
                else { lastSeen = tree[i]; lastSeenCt = 1; }
                count = Math.Max(count, aCt + bCt);
            }

            return count;
        }
    }
}