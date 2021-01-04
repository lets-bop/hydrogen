using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        You likely know that different currencies have coins and bills of different denominations. 
        In some currencies, it's actually impossible to receive change for a given amount of money. 
        For example, Canada has given up the 1-cent penny. If you're owed 94 cents in Canada, 
        a shopkeeper will graciously supply you with 95 cents instead since there exists a 5-cent coin.
        Given a list of the available denominations, determine if it's possible to receive exact change 
        for an amount of money targetMoney. Both the denominations and target amount will be given in 
        generic units of that currency.
        Input: 1 ≤ |denominations| ≤ 100; 1 ≤ denominations[i] ≤ 10,000; 1 ≤ targetMoney ≤ 1,000,000
        Output: Return true if it's possible to receive exactly targetMoney given the available denominations, and false if not.
        Example 1: 
        denominations = [5, 10, 25, 100, 200], targetMoney = 94, output = false
        Every denomination is a multiple of 5, so you can't receive exactly 94 units of money in this currency.
        Example 2: 
        denominations = [4, 17, 29], targetMoney = 75, output = true
        You can make 75 units with the denominations [17, 29, 29].
    */

    class ForeignCurrencyChange
    {
        public bool CanMakeExactChange(int amount, int[] denominations) {
            if (this.MinNumberOfCoinsDp(amount, denominations) != int.MaxValue) return true;
            return false;
        }

        private int MinNumberOfCoinsDp(int amount, int[] denominations) {
            int[] dp = new int[amount + 1];
            for (int i = 1; i < dp.Length; i++) dp[i] = int.MaxValue;
            for (int i = 1; i < dp.Length; i++) {
                for (int j = 0; j < denominations.Length; j++) {
                    if (i >= denominations[j] && dp[i - denominations[j]] != int.MaxValue) {
                        dp[i] = Math.Min(dp[i], dp[i - denominations[j]] + 1);
                    }
                }
            }

            return dp[amount];
        }
    }
}