using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
     * 
     * Given a list of daily temperatures T, return a list such that, for each day in the input, 
     * tells you how many days you would have to wait until a warmer temperature. 
     * If there is no future day for which this is possible, put 0 instead. For example, given the list of temperatures 
     * T = [73, 74, 75, 71, 69, 72, 76, 73], your output should be [1, 1, 4, 2, 1, 1, 0, 0].
     * Note: The length of temperatures will be in the range [1, 30000]. 
     * Each temperature will be an integer in the range [30, 100].
     * 
     * */
    class DailyTemperatures
    {
        public int[] CalculateDailyTemperatures(int[] T)
        {
            if (T == null || T.Length == 0) return new int[0];

            Stack<int> stack = new Stack<int>();
            int[] result = new int[T.Length];

            for (int i = T.Length - 1; i >= 0; i--)
            {
                // We've found a smaller index which has a warmer temperature that current index.
                while(stack.Count > 0 && T[stack.Peek()] <= T[i]) stack.Pop();
                if (stack.Count > 0) result[i] = stack.Peek() - i;
                stack.Push(i);
            }

            return result;
        }
    }
}
