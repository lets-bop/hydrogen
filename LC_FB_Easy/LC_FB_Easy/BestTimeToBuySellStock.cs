/*
Say you have an array for which the ith element is the price of a given stock on day i.

If you were only permitted to complete at most one transaction (i.e., buy one and sell one share of the stock), 
design an algorithm to find the maximum profit. Note that you cannot sell a stock before you buy one.

Input: [7,1,5,3,6,4]
Output: 5

Input: [7,6,4,3,1]
Output: 0

 */

using System;
using System.Collections.Generic;

namespace LC_FB_Easy
{
    class BestTimeToBuySellStocks
    {
        public static int FindMax(int[] prices)
        {
            int max = 0;
            int smallestSoFar = int.MaxValue;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < smallestSoFar)
                {
                    smallestSoFar = prices[i];
                    continue;
                }

                int tempMax = prices[i] - smallestSoFar;
                if (tempMax > max)
                    max = tempMax;
            }

            return max;
        }
    }
}