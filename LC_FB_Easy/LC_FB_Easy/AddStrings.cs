using System;
using System.Collections.Generic;

namespace LC_FB_Easy
{
    /*
        Given two non-negative integers num1 and num2 represented as string, return the sum of num1 and num2.

        Note:

        The length of both num1 and num2 is < 5100.
        Both num1 and num2 contains only digits 0-9.
        Both num1 and num2 does not contain any leading zero.
        You must not use any built-in BigInteger library or convert the inputs to integer directly.
    */
    class AddStrings
    {
        public string Add(string num1, string num2) {
            if (num1 == null || num1.Length == 0) return num2;
            if (num2 == null || num2.Length == 0) return num1;
            
            int i = num1.Length - 1, j = num2.Length - 1;
            int carry = 0;
            int sum = 0;
            int current = 0;
            int d1, d2;
            string result = string.Empty;
            while (i >= 0 || j >= 0) {
                if (i >= 0) d1 = num1[i] - 48;
                else d1 = 0;
                if (j >= 0) d2 = num2[j] - 48;
                else d2 = 0;
                
                sum = d1 + d2 + carry;
                
                carry = sum / 10;
                current = sum % 10;
                
                result = current.ToString() + result;
                i--; j--;
            }
            
            if (carry != 0) result = carry.ToString() + result;
            return result;
        }
    }
}