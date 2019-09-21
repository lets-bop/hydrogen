using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Write an efficient algorithm that searches for a value in an m x n matrix. 
        This matrix has the following properties:

        Integers in each row are sorted in ascending from left to right.
        Integers in each column are sorted in ascending from top to bottom.
        Example:

        [
        [1,   4,  7, 11, 15],
        [2,   5,  8, 12, 19],
        [3,   6,  9, 16, 22],
        [10, 13, 14, 17, 24],
        [18, 21, 23, 26, 30]
        ]

        Given target = 5, return true.
        Given target = 20, return false.
    */
    class Search2DMatrix2
    {
        public bool SearchMatrix(int[,] matrix, int target) {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // start from top right corner and eliminate the row or col each time.
            // time complexity is O(m + n)
            int r = 0;
            int c = cols - 1;
            while (r < rows && c >=0) {
                if (matrix[r,c] == target) return true;
                if (matrix[r,c] < target) r++;
                else c--;
            }

            return false;
        }
    }
}