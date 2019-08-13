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
            // Let a represent the start index of the most recently seen element
            // Let b represent the start index of the 2nd most recently seen element
            // If the element being read != element at a or b, then we need to reset the max fruit count
            // to being that of only a + 1 (count of the element being read currently). We shift a to b.
            // And a becomes the index of the element being read.
            // Else if the element being read == either a or b, we continue adding 1 to max fruit count
            // and adjust a and b accordingly such that a corresponds to the index of the most recently
            // read element
            // If a's and b's come alternating, though their total counts respectively can be incremented,
            // we also need to keep track of the continuous counts of a.
            if (tree == null || tree.Length == 0) return 0;
            if (tree.Length <= 2) return tree.Length;

            int b = 0; // Let b represent the start index of the 2nd most recently seen element
            int b_count = 1;

            for (int i = 1; i < tree.Length && tree[i] == tree[b]; i++) {
                ++b_count;
            }

            if (b_count == tree.Length) return b_count;

            int a = b_count; // Let a represent the start index of the most recently seen element
            int a_count = 1;
            int countinuous_a_count = 1;
            
            int maxFruitCount = a_count + b_count;

            for (int i = a + 1; i < tree.Length; i++) {
                if (tree[i] != tree[a] && tree[i] != tree[b]) {
                    maxFruitCount = Math.Max(maxFruitCount, a_count + b_count);
                    b = a;
                    b_count = countinuous_a_count;
                    countinuous_a_count = 1;
                    a_count = 1;
                    a = i;
                }
                else if (tree[i] == tree[a]) {
                    // no need to reset anything. just increment count
                    ++a_count;
                    ++countinuous_a_count;
                }
                else {
                    // swap a and b
                    int temp = a;
                    a = b;
                    b = temp;
                    
                    // swap the counts
                    temp = a_count;
                    a_count = b_count;
                    b_count = temp;
                    countinuous_a_count = 1;
                    ++a_count;
                }
            }

            return Math.Max(maxFruitCount, a_count + b_count);
        }
    }
}