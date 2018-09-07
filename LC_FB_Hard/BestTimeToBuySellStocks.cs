using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class BestTimeToBuySellStocks
    {
        /*
            Say you have an array for which the ith element is the price of a given stock on day i.
            If you were only permitted to complete at most one transaction (i.e., buy one and sell one share of the stock), design an algorithm to find the maximum profit.
            Note that you cannot sell a stock before you buy one.
            Input: [7,1,5,3,6,4]
            Output: 5
            Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
                        Not 7-1 = 6, as selling price needs to be larger than buying price.
        */
        public int MaxProfit1(int[] prices)
        {
            if(prices == null || prices.Length < 2) return 0;

            int maxProfit = 0;
            int minPrice = prices[0];

            for (int i = 1; i < prices.Length; i++){
                if (prices[i] < minPrice) minPrice = prices[i];
                else maxProfit = Math.Max(maxProfit, prices[i] - minPrice);
            }

            return maxProfit;
        }

        /*
            Say you have an array for which the ith element is the price of a given stock on day i.
            Design an algorithm to find the maximum profit. You may complete as many transactions as you like (i.e., buy one and sell one share of the stock multiple times).
            Note: You may not engage in multiple transactions at the same time (i.e., you must sell the stock before you buy again).
        */
        public int MaxProfit2(int[] prices)
        {
            if (prices == null || prices.Length < 2) return 0;
            int maxProfit = 0;
            for (int i = 1; i < prices.Length; i++){
                if (prices[i] > prices[i - 1]) maxProfit += prices[i] - prices[i - 1];
            }

            return maxProfit;
        }
    }
}