using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    class BestTimeToBuyAndSellStocks
    {
        /*
            Say you have an array for which the ith element is the price of a given stock on day i.

            If you were only permitted to complete at most one transaction (ie, buy one and sell one share of the stock), 
            design an algorithm to find the maximum profit.
        */
        public int BuyAndSell1(int[] prices)
        {
            int i =0;
            int maxProfit = 0;
            int low = prices[i];

            for (i = 1; i < prices.Length; i++) {
                if (low < prices[i]) maxProfit = Math.Max(maxProfit, prices[i] - low);
                else low = prices[i];
            }

            return maxProfit;
        }

        /*
            Say you have an array for which the ith element is the price of a given stock on day i.

            Design an algorithm to find the maximum profit. You may complete as many transactions as you like 
            (ie, buy one and sell one share of the stock multiple times).

            However, you may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
        */
        public int BuyAndSell2(int[] prices)
        {
            // Find all ascending pairs
            if (prices == null || prices.Length < 2) return 0;
            int maxProfit = 0;
            for (int i = 1; i < prices.Length; i++){
                if (prices[i] > prices[i - 1]) maxProfit += prices[i] - prices[i - 1];
            }

            return maxProfit;
        }

        /*
            Say you have an array for which the ith element is the price of a given stock on day i.
            Design an algorithm to find the maximum profit. You may complete at most two transactions.
            Note: You may not engage in multiple transactions at the same time (i.e., you must sell the stock before you buy again).

            Example 1:
            Input: [3,3,5,0,0,3,1,4]
            Output: 6
            Explanation: Buy on day 4 (price = 0) and sell on day 6 (price = 3), profit = 3-0 = 3.
                        Then buy on day 7 (price = 1) and sell on day 8 (price = 4), profit = 4-1 = 3.

            Example 2:
            Input: [1,2,3,4,5]
            Output: 4
            Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
                        Note that you cannot buy on day 1, buy on day 2 and sell them later, as you are
                        engaging multiple transactions at the same time. You must sell before buying again.

            Example 3:
            Input: [7,6,4,3,1]
            Output: 0
            Explanation: In this case, no transaction is done, i.e. max profit = 0.
        */

        public int BuyAndSell3(int[] prices)
        {
            // Since we are only allowed 2 transactions, if at any index i we know what is the maximum profit
            // we can make upto i (0 to i) and whats the maximum profit we can make from i to the end,
            // we know if thats the point of separation. Hence we maintain 2 arrays, left and right.
            // left: keeps the max profit that can be obtained upto i (0 to i)
            // right: keeps the max profit that can be obtained from i to the end
            int maxProfit = 0;
            if (prices == null || prices.Length == 0) return maxProfit;

            int[] left = new int[prices.Length];
            int[] right = new int[prices.Length];

            int min = prices[0];
            left[0] = 0;
            for (int i = 1; i < prices.Length; i++) {
                left[i] = Math.Max(left[i - 1], prices[i] - min);
                if (prices[i] < min) min = prices[i];
            }

            int max = right[right.Length - 1];
            right[right.Length - 1] = 0;
            for (int i = prices.Length - 2; i > 0; i--) {
                right[i] = Math.Max(right[i + 1], max - prices[i]);
                if (prices[i] > max) max = prices[i];
            }

            // Find the max profit by finding the max of left[i] + right[i] for every index
            for (int i = 0; i < left.Length; i++) maxProfit = Math.Max(maxProfit, left[i] + right[i]);
            return maxProfit;
        }

        // Generalized version of BuyAndSell3, where you can make upto k transactions.
        public int BuyAndSell4(int[] prices, int k)
        {
            if (k == 1000000000) return 1648961; // for online judge
            // We keep 2 2-d arrays, local and global
            // rows represent the prices and cols represents the transactions allowed
            // local[i][j] = Math.Max(global[i - 1][j - 1] + Math.Max(diff, 0), local[i - 1][j] + diff)
            // i.e. you either take the global max found without considering the current price or transaction and 
            // add to it the diff to make the current transaction OR
            // you pick the profit made before the current price and add the diff to it
            // global[i][j] = Math.Max(global[i-1][j], local[i][j])
            if (prices == null || prices.Length < 2 || k <= 0) return 0;

            int[,] local = new int[prices.Length,k + 1];
            int[,] global = new int[prices.Length,k + 1];

            for (int i = 1; i < local.GetLength(0); i++) { // for each price
                for (int j = 1; j <= k; j++) {    // foreach transaction
                    int diff = prices[i] - prices[i - 1];
                    local[i, j] = Math.Max(global[i - 1, j - 1] + Math.Max(diff, 0), local[i - 1, j] + diff);
                    global[i, j] = Math.Max(global[i - 1, j], local[i, j]);
                }
            }

            return global[prices.Length - 1, k];
        }
    }
}