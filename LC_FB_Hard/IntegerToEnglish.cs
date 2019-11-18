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
        string[] tens = new string[] {"","Ten","Twenty","Thirty","Forty","Fifty","Sixty","Seventy","Eighty","Ninety"};
        string[] tens_and_non_zero_in_ones = new string[] {"","Eleven","Twelve","Thirteen","Fourteen","Fifteen","Sixteen","Seventeen","Eighteen","Nineteen"};

        public string NumberToWords(int num) {
            // 2,147,483,647 - max is 2 billion something
            if (num == 0) return "Zero";

            string res = string.Empty;
            string keyword = string.Empty;
            int iter = 0;

            while (num != 0) {
                if (iter == 1) keyword = "Thousand";
                if (iter == 2) keyword = "Million";
                if (iter == 3) keyword = "Billion";
                res = this.NumberToWords3Digits(num % 1000, keyword) + res;
                num /= 1000;
                iter++;
            }

            return res.Trim();
        }

        private string NumberToWords3Digits(int num, string keyword) {
            if (num == 0) return string.Empty;
            string s = string.Empty;
            int ones_d = -1, tens_d = -1, hun_d = -1;

            // Figure out the 1s, 10s and 100s digits
            int iter = 0;
            while (num != 0) {
                if (iter == 0) ones_d = num % 10;
                if (iter == 1) tens_d = num % 10;
                if (iter == 2) hun_d = num %10;
                iter++;
                num /= 10;
            }

            if (hun_d > 0) s = ones[hun_d] + " Hundred ";
            if (tens_d == 1 && ones_d > 0) s += tens_and_non_zero_in_ones[ones_d];
            else if (tens_d > 0 && ones_d == 0) s += tens[tens_d];
            else if (tens_d > 0) s += tens[tens_d] + " " + ones[ones_d];
            else s += ones[ones_d]; // i.e. if tens_d == 0

            s = s.Trim() + " " + keyword + " ";
            return s;
        }
    }
}