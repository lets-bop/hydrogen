using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class MultiplyArbitraryIntegers
    {
        public static string Execute(int[] num1, int[] num2)
        {
            // Todo: Handle -ve numbers and remove leading zeros
            int len = num1.Length + num2.Length;
            int[] result = new int[len];

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                for (int j = num2.Length - 1; j >= 0; j--)
                {
                    result[i + j + 1] += num1[i] * num2[j];
                    result[i + j] += result[i + j + 1] / 10;
                    result[i + j + 1] %= 10;
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
                sb.AppendFormat("{0}", result[i]);

            return sb.ToString();
        }        
    }    
}