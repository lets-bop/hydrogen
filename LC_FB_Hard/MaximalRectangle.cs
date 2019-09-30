/*
Given a 2D binary matrix filled with 0's and 1's, find the largest rectangle containing only 1's and return its area.

Example:

Input:
[
  ["1","0","1","0","0"],
  ["1","0","1","1","1"],
  ["1","1","1","1","1"],
  ["1","0","0","1","0"]
]
Output: 6
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class MaximalRectangle
    {
        public static int Execute(char[][] rectangle)
        {
            int rows = rectangle.Length;
            int cols = rectangle[0].Length;

            int[] histogram = new int[cols];
            int maxArea = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if(rectangle[i][j] == '1') histogram[j] += 1;
                    else histogram[j] = 0;
                }
                
                maxArea = Math.Max(maxArea, MaxAreaOfHistogram(histogram));
            }

            return maxArea;
        }

        private static int MaxAreaOfHistogram(int[] histogram)
        {
            return LargestRectangleInHist.Execute(histogram);
        }
    }
}