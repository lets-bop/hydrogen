using System;
using System.Collections.Generic;

/* 
Your previous Plain Text content is preserved below:

Given a list of .csv strings containing an integer timestamp, stock name, and stock
price on the previous trading day, examine the list and provide the optimal time to
have bought and sold exactly one share of a specified stock, along with the profit.
 - Can only buy a single share, one time (or zero times if there is no profit)
 - Can only sell a single share, one time (or zero times if there is no profit)
 - Must buy before selling
 - Find maximum profit and report the stock, buy time, sell time, and profit
 - each line has 3 fields, separated by a comma:
      <integer timestamp>,<stock name>,<price>

Example output for the sample data below for "GOOG" might be:
    GOOG: buytime=1559990007, selltime=1559990010, profit=4.0

price_lines = [
    "1559990001,GOOG,104.25",
    "1559990001,FB,100.00",
    "1559990002,AAPL,100.00",
    "1559990003,GOOG,105.00",
    "1559990004,FB,99.00",
    "1559990007,GOOG,99.50",
    "1559990008,GOOG,102.75",
    "1559990010,AAPL,101.00",
    "1559990010,GOOG,103.50",
    "1559990011,GOOG,99.00",
    "1559990013,AAPL,102.00",
    "1559990013,GOOG,102.50",
    "1559990014,GOOG,102.50",
    "1559990014,FB,97.00",
    "1559990017,GOOG,102.75",
    "1559990018,GOOG,102.00",
    "1559990019,FB,95.00",
]

 */

namespace LC_FB_Hard
{
    class BuyAndSellStocks
    {
        public void CalculateMaxProfit(string[] pricelines)
        {
            if (pricelines == null || pricelines.Length == 0) return;
            Dictionary<string, List<(string, double)>> symToPrice = new Dictionary<string, List<(string, double)>>();

            foreach (string line in pricelines) {
                // (ts, sym, price)
                string[] splits = line.Split(',');
                string time = splits[0];
                string stockName = splits[1];
                double price = double.Parse(splits[2]);
                if (!symToPrice.ContainsKey(stockName)) symToPrice[stockName] = new List<(string, double)>();
                symToPrice[stockName].Add((time, price));
            }

            (string, string, string, double) max = (string.Empty, string.Empty, string.Empty, 0.0);
            foreach (string key in symToPrice.Keys) {
                (string, string, double) currMax = this.GetMaxProfit(symToPrice[key]);
                if (currMax.Item3 > max.Item4) {
                    max.Item1 = key;
                    max.Item2 = currMax.Item1;
                    max.Item3 = currMax.Item2;
                    max.Item4 = currMax.Item3;
                }
            }
            
            if (!string.IsNullOrEmpty(max.Item1)) {
                Console.WriteLine("{0}: buytime={1}, selltime={2}, profit={3}", 
                                max.Item1,
                                max.Item2,
                                max.Item3,
                                max.Item4);
            }
        }

        private (string, string, double) GetMaxProfit(List<(string, double)> prices) {
            double max = double.MinValue;
            double profit = double.MinValue;
            string sellTime = string.Empty;
            string buyTime = string.Empty;

            for (int i = prices.Count - 1; i >= 0; i--) {
                if (max <= prices[i].Item2) {
                    sellTime = prices[i].Item1;
                    max = prices[i].Item2;
                } else {
                    buyTime = prices[i].Item1;
                    profit = Math.Max(profit, max - prices[i].Item2);
                }
            }

            return (buyTime, sellTime, profit);
        }
    }
}