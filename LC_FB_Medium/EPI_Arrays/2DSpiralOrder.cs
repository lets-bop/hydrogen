/*
List the elements of a 2D array in spiral order.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class SpiralOrder
    {
        public static List<int> Execute(int[,] input, int size)
        {
            // Do appropriate safety checks

            int rowTop = 0;
            int rowBottom = size - 1;
            int colLeft = 0;
            int colRight = size - 1;

            List<int> spiralOrder = new List<int>();

            while(rowTop < rowBottom && colLeft < colRight)
            {
                for (int i = colLeft; i <= colRight; i++) spiralOrder.Add(input[rowTop, i]);
                rowTop++;
                for (int i = rowTop; i <= rowBottom; i++ ) spiralOrder.Add(input[i, colRight]);
                colRight--;
                for (int i = colRight; i >= colLeft; i--) spiralOrder.Add(input[rowBottom, i]);
                rowBottom--;
                for (int i = rowBottom; i >= rowTop; i--) spiralOrder.Add(input[i, colLeft]);
                colLeft++;
            }

            return spiralOrder;
        }
    }
}