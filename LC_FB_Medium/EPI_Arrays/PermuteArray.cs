/*
Given an array and a permutation order, permute the elements of the array according to the permutation order
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class PermuteArray
    {
        public static void Execute(List<int> input, List<int> permutationOrder)
        {
            // Perform appropriate safety checks

            // A permutation consists of disjoint cycles. Identify the cycles and order the elements accordingly.
            for(int i = 0; i < permutationOrder.Count; i++)
            {
                int currentIndex = i;
                int currentValueToMove = input[currentIndex];

                while (permutationOrder[currentIndex] != currentIndex && permutationOrder[currentIndex] >= 0)
                {
                    // This cycle has not been processed yet.
                    int nextValueToMove = input[permutationOrder[currentIndex]];
                    input[permutationOrder[currentIndex]] = currentValueToMove;
                    int nextIndex = permutationOrder[currentIndex];
                    permutationOrder[currentIndex] -= permutationOrder.Count;
                    currentIndex = nextIndex;
                    currentValueToMove = nextValueToMove;
                }
            }
        }
    }
}