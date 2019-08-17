using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
        Given an unsorted array return whether an increasing subsequence of length 3 exists or not in the array.

        Formally the function should:

        Return true if there exists i, j, k 
        such that arr[i] < arr[j] < arr[k] given 0 ≤ i < j < k ≤ n-1 else return false.
        Note: Your algorithm should run in O(n) time complexity and O(1) space complexity.
    */
    class IncreasingTripletSubsequence
    {
        public bool IncreasingTriplet(int[] nums)
        {
            int firstLb = int.MaxValue;
            int secondLb = int.MaxValue;

            // keep track of the first and second lower bounds
            foreach (int n in nums) {
                if (n <= firstLb) firstLb = n;
                else if (n <= secondLb) secondLb = n;
                else return true;
            }

            return false;
        }
    }
}