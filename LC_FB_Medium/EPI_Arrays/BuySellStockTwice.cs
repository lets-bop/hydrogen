/*
Write a program that computes the maximum profit that can be made by buying and selling a stock at most twice
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class BuySellStockTwice
    {
        public static int Execute(List<int> prices)
        {
            if (prices == null || prices.Count == 0) return 0;

            List<int> forwardMax = new List<int>(new int[prices.Count]);
            List<int> backwardMax = new List<int>(new int[prices.Count]);

            foreach (int m in forwardMax) Console.Write(m + " "); Console.WriteLine();            
            foreach (int m in backwardMax) Console.Write(m + " "); Console.WriteLine();            
            
            int maxProfit = 0;
            int min = prices[0];
            for (int i = 0; i < prices.Count; i++)
            {
                if (prices[i] < min) min = prices[i];
                forwardMax[i] = Math.Max(maxProfit, prices[i] - min);
                maxProfit = Math.Max(maxProfit, forwardMax[i]);
            }

            maxProfit = 0;
            int max = prices[prices.Count - 1];
            for (int i = prices.Count - 1; i >=0; i--)
            {
                if (max < prices[i]) max = prices[i];
                backwardMax[i] = Math.Max(maxProfit, max - prices[i]);
                maxProfit = Math.Max(maxProfit, backwardMax[i]);
            }

            foreach (int m in forwardMax) Console.Write(m + " "); Console.WriteLine();            
            foreach (int m in backwardMax) Console.Write(m + " "); Console.WriteLine();

            // Calculate the max
            maxProfit = backwardMax[0];
            for (int i = 1; i < prices.Count; i++)
            {
                maxProfit = Math.Max(maxProfit, forwardMax[i - 1] + backwardMax[i]);
            }

            return maxProfit;
        }
    }
}