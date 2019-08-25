using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given an array of integers A sorted in non-decreasing order, return an array of the squares of each number, also in sorted non-decreasing order.

        Example 1:
        Input: [-4,-1,0,3,10]
        Output: [0,1,9,16,100]

        Example 2:
        Input: [-7,-3,2,3,11]
        Output: [4,9,9,49,121]
    */
    class SortedSquares
    {
        public int[] Calculate(int[] input) {
            // The straight forward way is to simply square the numbers and sort the array thereafter.
            // This would take O(nlogn) time.
            // What if we can walk the numbers according to their magnitude?
            // Walk the negative numbers from right to left and positve numbers from left to right,
            // each time picking the smaller of the numbers (by magnitude) for squaring.
            if (input == null || input.Length == 0) return new int[] {};
            int[] result = new int[input.Length];

            // Find the first non-negative #
            int i = 0; // will keep track of the positive numbers and will move forward
            int j = 0; // will keep track of the negative numbers and will back backward
            int r = 0;
            while (i < input.Length && input[i] < 0) i++;
            j = i - 1;
            while (j >= 0 || i < input.Length) {
                if (j >= 0 && i < input.Length) {
                    // pick the number with the smaller magnitude
                    if (Math.Abs(input[j]) < Math.Abs(input[i])) {
                        result[r++] = input[j] * input[j];
                        j--;
                    }
                    else {
                        result[r++] = input[i] * input[i];
                        i++;
                    }
                }
                else if (i < input.Length) {
                    result[r++] = input[i] * input[i];
                    i++;
                }
                else {
                    result[r++] = input[j] * input[j];
                    j--;
                }
            }

            return result;
        }
    }
}