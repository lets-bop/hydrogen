/*
Write a program that takes an array of digits encoding a non negative integer D and 
updates the array to represent D + 1 
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class IncrementArbitraryPrecisionInteger
    {
        public static List<int> Execute(List<int> input)
        {
            if (input == null || input.Count == 0) return input;

            int carry = 0;
            for (int i = input.Count - 1; i >= 0; i--)
            {
                int num = input[i];
                num = num + 1;
                carry = num / 10;
                num = num % 10;
                input[i] = num;

                if (carry == 0)
                    break;
            }

            if (carry != 0)
            {
                input.Insert(0, carry);
            }

            return input;
        }
    }
}