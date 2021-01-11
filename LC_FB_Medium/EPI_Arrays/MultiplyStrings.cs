using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class MultiplyStrings {
        public string Multiply(string num1, string num2) {
            if (num1.Length == 1 && int.Parse(num1) == 0) return "0";
            if (num2.Length == 1 && int.Parse(num2) == 0) return "0";
            
            int len = num1.Length + num2.Length;
            int[] result = new int[len];

            for (int i = num1.Length - 1; i >= 0; i--) {
                for (int j = num2.Length - 1; j >= 0; j--) {
                    int n1 = (int) char.GetNumericValue(num1[i]);
                    int n2 = (int) char.GetNumericValue(num2[j]);
                    result[i + j + 1] += n1 * n2;
                    result[i + j] += result[i + j + 1] / 10; // carry
                    result[i + j + 1] %= 10; // current
                }
            }

            StringBuilder sb = new StringBuilder();
            bool seenNonZero = false;
            for (int i = 0; i < result.Length; i++)
                if (result[i] != 0 || seenNonZero) {
                    seenNonZero = true;
                    sb.AppendFormat("{0}", result[i]);
                }

            return sb.ToString();
        }
    }
}