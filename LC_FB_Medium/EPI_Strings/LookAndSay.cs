/*
The first 8 numbers of the look-and-say problem look like
<1, 11, 21, 1211, 111221, 312211, 13112221, 111321321>
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class LookAndSay
    {
        public static void Execute(int n)
        {
            RecursivePrint(n, "1");
        }

        private static void RecursivePrint(int n, string str)
        {
            if (n <= 0 || string.IsNullOrEmpty(str)) return;

            StringBuilder sb = new StringBuilder();
            int count = 0;
            char prevChar = ' ';
            foreach (char c in str.ToCharArray())
            {
                count++;
                if (prevChar == ' ')
                {
                    prevChar = c;
                    continue;
                }

                if (prevChar != c)
                {
                    sb.AppendFormat("{0}{1}", (count - 1).ToString(), prevChar);
                    count = 1;
                    prevChar = c;
                }
            }

            // Need to append the last char to the string builder
            sb.AppendFormat("{0}{1}", (count).ToString(), prevChar);
            Console.WriteLine(sb.ToString());
            RecursivePrint(n-1, sb.ToString());
        }
    }
}