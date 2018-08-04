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
        public static int Execute(char[,] rectangle)
        {
            int rows = rectangle.GetLength(0);
            int cols = rectangle.GetLength(1);

            int[,] histogram = new int[rows,cols];
            int maxArea = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if(rectangle[i,j] == '1') histogram[i,j] = 1;

                    if (i > 0)
                    {
                        if(rectangle[i,j] == '1') histogram[i,j] += histogram[i - 1, j];
                    }
                }
                
                maxArea = Math.Max(maxArea, MaxAreaOfHistogram(histogram, i));
            }

            return maxArea;
        }

        private static int MaxAreaOfHistogram(int[,] histogram, int rowIndex)
        {
            int cols = histogram.GetLength(1);
            Stack<int> stack = new Stack<int>();
            int maxArea = 0;
            for (int i = 0; i < cols; i++)
            {
                if (stack.Count == 0 || histogram[rowIndex, i] >= histogram[rowIndex, stack.Peek()]) stack.Push(i);
                else
                {
                    while(stack.Count != 0 && histogram[rowIndex, stack.Peek()] > histogram[rowIndex, i])
                    {
                        int pop_index = stack.Pop(); 
                        int temp_area = stack.Count == 0 ? 
                            histogram[rowIndex, pop_index] * (i) : 
                            histogram[rowIndex, pop_index] * (i - 1 - stack.Peek());
                        maxArea = Math.Max(maxArea, temp_area);
                    }

                    stack.Push(i);
                }
            }

            while(stack.Count != 0)
            {
                int pop_index = stack.Pop();
                int temp_area = stack.Count == 0 ? 
                    histogram[rowIndex, pop_index] * (cols) : 
                    histogram[rowIndex, pop_index] * (cols - 1 - stack.Peek());
                maxArea = Math.Max(maxArea, temp_area);
            }

            return maxArea;
        }
    }
}