/*
Given n non-negative integers representing the histogram's bar height where the width of each bar is 1, find the area of largest rectangle in the histogram.
Above is a histogram where width of each bar is 1, given height = [2,1,5,6,2,3].
The largest rectangle is shown in the shaded area, which has area = 10 unit.

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class LargestRectangleInHist
    {
        public static int Execute(int[] input)
        {
            if (input == null || input.Length == 0) return 0;
            if (input.Length == 1) return input[0];

            Stack<int> stack = new Stack<int>();
            int max = 0;
            int i;
            for (i = 0; i < input.Length; i++)
            {
                if (stack.Count == 0 || input[i] >= input[stack.Peek()]) stack.Push(i);
                else
                {
                    while (stack.Count != 0 && input[stack.Peek()] > input[i])
                    {
                        int popIndex = stack.Pop();
                        if (stack.Count == 0) max = Math.Max(max, input[popIndex] * i);
                        else max = Math.Max(max, input[popIndex] * (i - stack.Peek() - 1));
                    }
                }
                
                stack.Push(i);
            }

            while (stack.Count > 0)
            {                                
                int popIndex = stack.Pop();
                if (stack.Count == 0) max = Math.Max(max, input[popIndex] * i);
                else max = Math.Max(max, input[popIndex] * (i - stack.Peek() - 1));
            }

            return max;
        }
    }
}