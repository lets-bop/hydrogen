using System;
using System.Collections.Generic;
using System.Text;
/*
    Given a matrix of m x n elements (m rows, n columns), return all elements of the matrix in spiral order.

    Example 1:
    Input:
    [
    [ 1, 2, 3 ],
    [ 4, 5, 6 ],
    [ 7, 8, 9 ]
    ]
    Output: [1,2,3,6,9,8,7,4,5]

    Example 2:
    Input:
    [
    [1, 2, 3, 4],
    [5, 6, 7, 8],
    [9,10,11,12]
    ]
    Output: [1,2,3,4,8,12,11,10,9,5,6,7]    
*/
namespace LC_FB_Medium
{
    public class SpiralOrder_New
    {
        public IList<int> FindSpiralOrder(int[][] matrix) {
                List<int> spiralOrder = new List<int>();
                if (matrix.Length == 0) return spiralOrder;
                int rowTop = 0;
                int rowBottom = matrix.Length - 1;
                int colLeft = 0;
                int colRight = matrix[0].Length - 1;

                while(rowTop <= rowBottom && colLeft <= colRight)
                {
                    for (int i = colLeft; i <= colRight; i++) spiralOrder.Add(matrix[rowTop][i]);
                    for (int i = rowTop + 1; i <= rowBottom; i++ ) spiralOrder.Add(matrix[i][colRight]);
                    if (rowTop < rowBottom && colLeft < colRight)
                    {
                        for (int i = colRight - 1; i > colLeft; i--) spiralOrder.Add(matrix[rowBottom][i]);
                        for (int i = rowBottom; i > rowTop; i--) spiralOrder.Add(matrix[i][colLeft]);
                    }

                    rowTop++;
                    rowBottom--;
                    colRight--;
                    colLeft++;
                }

                return spiralOrder;
        }        
    }
}