using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Write an algorithm to determine if a number is "happy".

        A happy number is a number defined by the following process: Starting with any positive integer, replace the number by the sum of the squares of its digits, and repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1. Those numbers for which this process ends in 1 are happy numbers.

        Example: 

        Input: 19
        Output: true
        Explanation: 
        12 + 92 = 82
        82 + 22 = 68
        62 + 82 = 100
        12 + 02 + 02 = 1
    */
    class HappyNumber
    {
        public bool IsHappy(int n) {
            // similar to the floyd cycle detection algorithm used in linked list
            int slow = n;
            int fast = n;
            do {
                slow = this.DigitSquareSum(slow);
                fast = this.DigitSquareSum(fast);
                fast = this.DigitSquareSum(fast);
            } while (slow != fast);

            if (slow == 1) return true;
            else return false;
        }

        private int DigitSquareSum(int num) {
            if (num == 1) return 1;
            int digit;
            int sum = 0;
            while (num != 0) {
                digit = num % 10;
                sum += (digit * digit);
                num /= 10;
            }

            return sum;
        }
    }
}