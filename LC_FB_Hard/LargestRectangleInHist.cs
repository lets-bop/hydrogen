/*
Given n non-negative integers representing the histogram's bar height where the width of each bar is 1, 
find the area of largest rectangle in the histogram.
Above is a histogram where width of each bar is 1, given height = [2,1,5,6,2,3].
The largest rectangle is shown in the shaded area, which has area = 10 unit.

Example:
[2,1,2]. Output: 3
[2,1,3,5,4]. Output: 9

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class LargestRectangleInHist
    {
        public static int Execute(int[] heights) {
            if (heights == null || heights.Length == 0) return 0;
            if (heights.Length == 1) return heights[0];

            Stack<int> stack = new Stack<int>();
            int max = 0;
            int i;
            for (i = 0; i < heights.Length; i++) {
                if (stack.Count == 0 || heights[i] >= heights[stack.Peek()]) stack.Push(i);
                else {
                    while (stack.Count > 0 && heights[stack.Peek()] > heights[i]) {
                        int popIndex = stack.Pop();
                        if (stack.Count == 0) max = Math.Max(max, heights[popIndex] * i);
                        else max = Math.Max(max, heights[popIndex] * (i - stack.Peek() - 1));
                    }
                }
                
                stack.Push(i);
            }

            while (stack.Count > 0) {
                int popIndex = stack.Pop();
                if (stack.Count == 0) max = Math.Max(max, heights[popIndex] * i);
                else max = Math.Max(max, heights[popIndex] * (i - stack.Peek() - 1));
            }

            return max;
        }
    }
}