using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Write an efficient algorithm that searches for a value in an m x n matrix. 
        This matrix has the following properties: 
        Integers in each row are sorted from left to right.
        The first integer of each row is greater than the last integer of the previous row.
        
        Example 1:
        Input:
            matrix = [
            [1,   3,  5,  7],
            [10, 11, 16, 20],
            [23, 30, 34, 50]
            ]
            target = 3
            Output: true

        Example 2:
            Input:
            matrix = [
            [1,   3,  5,  7],
            [10, 11, 16, 20],
            [23, 30, 34, 50]
            ]
            target = 13
            Output: false
    */
    class Search2DMatrix
    {
        public bool SearchMatrix(int[][] matrix, int target) {
            // validate the input
            if (matrix == null || matrix.Length == 0) return false;
            
            int r = matrix.Length;
            int c = matrix[0].Length;
            
            int start = 0;
            int end = r * c - 1;

            // normal binary search. time complexity is O(log (r*c))
            while (start <= end) {
                int mid = start + (end - start) / 2;
                int mid_r = mid / c;
                int mid_c = mid % c;
                if (matrix[mid_r][mid_c] == target) return true;
                if (matrix[mid_r][mid_c] < target) start = mid + 1;
                else end = mid - 1;
            }
            
            return false;
        }
    }
}