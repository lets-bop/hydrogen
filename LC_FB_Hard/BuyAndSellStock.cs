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
        internal class Stock
        {
            internal string sym;
            internal long ts;
            internal double price;
            
            internal Stock(string sym, long ts, double price) {
                this.sym = sym;
                this.ts = ts;
                this.price = price;
            }
        }
        
        
        public void CalculateMaxProfit(string[] pricelines)
        {
            if (pricelines == null || pricelines.Length == 0) return;
            
            // 
            Dictionary<string, Stock> symToMinPrice = new Dictionary<string, Stock>();
            
            // buyts, sellts, sym, maxprofit
            (long, long, string, double) bestStock = (long.MinValue, long.MinValue, null, double.MinValue);

            foreach (string line in pricelines) {
                // (ts, sym, price)
                Stock stock = this.ExtractValue(line);
                
                if (!symToMinPrice.ContainsKey(stock.sym)) {
                    // insert the value
                    symToMinPrice[stock.sym] = stock;
                } else {
                    if (symToMinPrice[stock.sym].price < stock.price) {
                        // calculate profit
                        double profit = stock.price - symToMinPrice[stock.sym].price;
                        
                        // check if this profit is the best
                        if (bestStock.Item3 == null || (bestStock.Item3 != null && profit > bestStock.Item4)) {
                            // replace best stock values
                            bestStock = (symToMinPrice[stock.sym].ts, // min price ts
                                        stock.ts, // current ts, sell time
                                        stock.sym, // current stock sym
                                        profit); // profit
                        }
                    } else if (symToMinPrice[stock.sym].price > stock.price) {
                        // found a new min
                        symToMinPrice[stock.sym] = stock;
                    }
                }
            }
            
            if (bestStock.Item3 != null) {
                Console.WriteLine("{0}: buytime={1}, selltime={2}, profit={3}", 
                                bestStock.Item3,
                                bestStock.Item1,
                                bestStock.Item2,
                                bestStock.Item4);
            }
        }
        
        private Stock ExtractValue(string line)
        {
            if (line == null) throw new Exception("Invalid input");
            
            string[] values = line.Split(",");
            if (values.Length != 3) throw new Exception("Invalid input");
            
            long ts = long.Parse(values[0]);
            string sym = values[1];
            double price = double.Parse(values[2]);
            return new Stock(sym, ts, price);
        }
    }
}