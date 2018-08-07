/*
Convert a non-negative integer to its english words representation. Given input is guaranteed to be less than 231 - 1.

Example 1:

Input: 123
Output: "One Hundred Twenty Three"
Example 2:

Input: 12345
Output: "Twelve Thousand Three Hundred Forty Five"
Example 3:

Input: 1234567
Output: "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
Example 4:

Input: 1234567891
Output: "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One"

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class NumberToEnglish
    {
        private string[] tens_digit_Is_1 = new string[] {"ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};
        private string[] tens_digit_Is_Not_1 = new string[] { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private string[] ones_digit = new string[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private string[] hundreds_digit = new string[] { "", "one hundred", "two hundred", "three hundred", "four hundred", "five hundred", "six hundred", "seven hundred", "eight hundred", "nine hundred" };

        public string NumberToWords(int num)
        {

            // Complete this part later, handle one thousand, ten thousand, hundred thousand, 1 million etc.
            // string result = string.Empty;
            // int iteration = 0;

            // while (num > 0)
            // {
            //     if (iteration == 1)
            //     {
            //         num = num / 1000;
            //     }

            //     iteration++;
            //     result += ConvertThreeOrLessDigitNumToEnglish(num / 1000);

            // }
            return null;
        }

        private string ConvertThreeOrLessDigitNumToEnglish(int num)
        {
            string s = string.Empty;

            int ones = num % 10;
            num = num / 10;
            int tens = num % 10;
            num = num / 10;
            int hundreds = num % 10;

            if (hundreds > 0) s = hundreds_digit[hundreds] + " ";

            // Falls in between ten and twenty.
            if (tens > 0 && tens < 2) s += tens_digit_Is_1[ones];
            else
            {
                if (tens > 0) s += tens_digit_Is_Not_1[tens] + " " + ones_digit[ones];
                else s += ones_digit[ones];
            }

            Console.WriteLine(s);

            return s;
        }
    }
}