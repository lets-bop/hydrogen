/*
Given a non-empty array of digits representing a non-negative integer, plus one to the integer.
The digits are stored such that the most significant digit is at the head of the list, and each element in the array contain a single digit.
You may assume the integer does not contain any leading zero, except the number 0 itself.
Example 1:

Input: [1,2,3]
Output: [1,2,4]
Explanation: The array represents the integer 123.
Example 2:

Input: [4,3,2,1]
Output: [4,3,2,2]
Explanation: The array represents the integer 4321.

 */

using System;
using System.Collections.Generic;

namespace LC_FB_Easy
{
    class PlusOne
    {
        public int[] Execute(int[] digits)
        {
            int currDigitAddResult;
            bool carryBit = true;
            Stack<int> stack = new Stack<int>();

            for (int i = digits.Length - 1; i >= 0; i--) 
            {
                currDigitAddResult = digits[i];
                if (carryBit) currDigitAddResult += 1;

                if (currDigitAddResult == 10) {
                    carryBit = true;
                    stack.Push(0);
                }
                else {
                    stack.Push(currDigitAddResult);
                    carryBit = false;
                }
            }

            if (carryBit) stack.Push(1);
            return stack.ToArray();
        }
    }
} 