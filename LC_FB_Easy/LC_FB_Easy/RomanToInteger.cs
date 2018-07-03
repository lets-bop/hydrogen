 
 /*

 Symbol       Value
I             1
V             5
X             10
L             50
C             100
D             500
M             1000

Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, 
the number four is written as IV. Because the one is before the five we subtract it making four. 
The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:
    I can be placed before V (5) and X (10) to make 4 and 9. 
    X can be placed before L (50) and C (100) to make 40 and 90. 
    C can be placed before D (500) and M (1000) to make 400 and 900.

Input: "III"
Output: 3

Input: "LVIII"
Output: 58
Explanation: C = 100, L = 50, XXX = 30 and III = 3.

Input: "MCMXCIV"
Output: 1994
Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.

  */
 using System;
 using System.Collections.Generic;

 namespace LC_FB_Easy
{
    class RomanToInteger
    {
        public static int Convert(string roman)
        {
            int sum = 0;
            char[] romanChars = roman.ToCharArray();
            for (int i = 0; i < romanChars.Length; i++)
            {
                // Check for the 6 subtraction cases
                if (i != romanChars.Length - 1 && romanChars[i] == 'I' && romanChars[i + 1] == 'V')
                {
                    sum  += 4;
                    i++;
                }
                else if (i != romanChars.Length - 1 && romanChars[i] == 'I' && romanChars[i + 1] == 'X')
                {
                    sum  += 9;
                    i++;
                }
                else if (i != romanChars.Length - 1 && romanChars[i] == 'X' && romanChars[i + 1] == 'L')
                {
                    sum  += 40;
                    i++;
                }
                else if (i != romanChars.Length - 1 && romanChars[i] == 'X' && romanChars[i + 1] == 'C')
                {
                    sum  += 90;
                    i++;
                }
                else if (i != romanChars.Length - 1 && romanChars[i] == 'C' && romanChars[i + 1] == 'D')
                {
                    sum  += 400;
                    i++;
                }
                else if (i != romanChars.Length - 1 && romanChars[i] == 'C' && romanChars[i + 1] == 'M')
                {
                    sum  += 900;
                    i++;
                }
                else if (romanChars[i] == 'I')
                {
                    sum  += 1;
                }
                else if (romanChars[i] == 'V')
                {
                    sum  += 5;
                }
                else if (romanChars[i] == 'X')
                {
                    sum  += 10;
                }
                else if (romanChars[i] == 'L')
                {
                    sum  += 50;
                }
                else if (romanChars[i] == 'C')
                {
                    sum  += 100;
                }
                else if (romanChars[i] == 'D')
                {
                    sum  += 500;
                }
                else if (romanChars[i] == 'M')
                {
                    sum  += 1000;
                }   
                else
                {
                    Console.WriteLine("Invalid char '{0}'. Exiting!", romanChars[i]);
                    return -1;
                }                                                                                                             
            }

            return sum;
        }
    }
}
