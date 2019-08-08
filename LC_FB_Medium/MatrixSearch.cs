using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
        Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:

        Integers in each row are sorted in ascending from left to right.
        Integers in each column are sorted in ascending from top to bottom.
        Example:

        Consider the following matrix:

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
     public class MatrixSearch
     {
         public bool SearchUsingBinSearch(int[,] matrix, int target)
         {
             if (matrix == null || matrix.Length == 0) return false;
             int minDim = Math.Min(matrix.GetLength(0), matrix.GetLength(1));

             // Now we are binary searching diagonally
             // 0th row and 0th col, then 1st row and 1 col, then 2nd row and 2 col
             /*
             Complexity analysis - 
                In each iteration we spend O (lg(n - i) + lg(m - i)) time.
                Worst case is when n == m. We spend O(2 * lg (n - i)) = O(lg (n - i))
                For i = 0 to n, we get O(lg (n)) + O(lg (n - 1)) + O(lg (n - 2)) + .. + O(lg (1))
                Following log a + log b = log (a * b), the above equation becomes O (lg (n * (n-1) * (n - 2) ... * 1) = O (lg (n!))
                = O(n lg n)
              */
             // Hence the algorithm is dominated by the size of of the smallest dimension
             for (int i = 0; i < minDim; i++)
             {
                 if (BinSearch(matrix, i, true, target) || BinSearch(matrix, i, false, target)) return true;
             }

             return false;
         }

         private bool BinSearch(int[,] matrix, int start, bool vertical, int target)
         {
             int low = start;
             int high = vertical ? matrix.GetLength(1) - 1 : matrix.GetLength(0) - 1;

             while (low <= high)
             {
                 int mid = low + (high - low) / 2;
                 if (vertical)
                 {
                     // we are searching the cols and hence the row must be a constant.
                     if (target > matrix[start, mid]) low = mid + 1;
                     else if (target < matrix[start, mid]) high = mid -1;
                     else return true;
                 }
                 else
                 {
                     // we are searching rows and hence the col will be a constant
                     if (target > matrix[mid, start]) low = mid + 1;
                     else if (target < matrix[mid, start]) high = mid - 1;
                     else return true;
                 }
             }

             return false;
         }

         // Start from the bottom left of the matrix and use elimination.
         // O (n + m) - worst case move from bottom left to top right
         public bool Search(int[,] matrix, int target)
         {
             if (matrix == null || matrix.Length == 0) return false;

             int rows = matrix.GetLength(0);
             int cols = matrix.GetLength(1);
             int r = rows - 1;
             int c = 0;
             while (r >= 0 && c >= 0 && r <= rows - 1 && c <= cols -1)
             {
                 if (matrix[r, c] > target) r--;
                 else if (matrix[r, c] < target) c++;
                 else return true;
             }

             return false;
         }
     }
    
}