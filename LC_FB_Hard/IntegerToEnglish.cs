using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
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
    class IntegerToEnglish
    {
        string[] ones = new string[] {"","One","Two","Three","Four","Five","Six","Seven","Eight","Nine"};
        string[] tens_zero_in_ones = new string[] {"","Ten","Twenty","Thirty","Forty","Fifty","Sixty","Seventy","Eighty","Ninety"};
        string[] tens_non_zero_in_ones = new string[] {"","Eleven","Twelve","Thirteen","Fourteen","Fifteen","Sixteen","Seventeen","Eighteen","Nineteen"};

        public string NumberToWords(int num) {
            // 2,147,483,647 - max is 2 billion something
            if (num == 0) return "Zero";

            string s = string.Empty;
            string keyword;
            int iter = 0;
            do {
                switch (iter) {
                    case 0: keyword = string.Empty; break;
                    case 1: keyword = "Thousand"; break;
                    case 2: keyword = "Million"; break;
                    case 3: keyword = "Billion"; break;
                    default: keyword = string.Empty; break;
                }

                s = this.NumberToWords3Digits(num % 1000, keyword) + " " + s;
                iter++;
                num /= 1000;
                s = s.Trim(); // for online judge as spacing matters
            } while (num != 0);

            return s.Trim();
        }

        private string NumberToWords3Digits(int num, string keyword) {
            if (num == 0) return string.Empty;
            string s = string.Empty;
            int ones_digit = -1, tens_digit = -1, hundreds_digit = -1;
            ones_digit = num % 10;
            num /= 10;
            if (num != 0) {
                tens_digit = num % 10;
                num /= 10;
                if (num != 0) hundreds_digit = num % 10;
            }

            if (hundreds_digit != -1) s += ones[hundreds_digit] + " Hundred ";
            if (tens_digit != -1) {
                if (tens_digit == 0 && ones_digit != 0) s += ones[ones_digit] + " "; // important case (like 101, 304 etc)
                else if (tens_digit != 0) {
                    if (ones_digit == 0) s += tens_zero_in_ones[tens_digit] + " ";
                    else {
                        if (tens_digit == 1) s += tens_non_zero_in_ones[ones_digit] + " ";
                        else s += tens_zero_in_ones[tens_digit] + " " + ones[ones_digit] + " ";
                    }
                }
            }
            if (hundreds_digit == -1 && tens_digit == -1) s += ones[ones_digit] + " ";
            s += keyword;
            return s;
        }
    }
}