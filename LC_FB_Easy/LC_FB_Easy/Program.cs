﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_FB_Easy
{
    class Program
    {
        static void Main(string[] args)
        {
            // ---- TwoSum.cs ----
            // int[] arr = new int[] {-2, 3, -6, 4, -11 };
            // TwoSum.Find(arr, 7);

            // ---- RomanToInteger.cs ----
            // Console.WriteLine("Roman III in integer is {0}", RomanToInteger.Convert("III"));
            // Console.WriteLine("Roman IV in integer is {0}", RomanToInteger.Convert("IV"));
            // Console.WriteLine("Roman IX in integer is {0}", RomanToInteger.Convert("IX"));
            // Console.WriteLine("Roman LVIII in integer is {0}", RomanToInteger.Convert("LVIII"));
            // Console.WriteLine("Roman MCMXCIV in integer is {0}", RomanToInteger.Convert("MCMXCIV"));

            // ---- Valid parenthesis ----
            // Console.WriteLine("{0}{1}", "Is '()' valid?: ", ValidParenthesis.Validate("()"));
            // Console.WriteLine("{0}{1}", "Is '()[]{}' valid?: ", ValidParenthesis.Validate("()[]{}"));
            // Console.WriteLine("{0}{1}", "Is '(]' valid?: ", ValidParenthesis.Validate("(]"));
            // Console.WriteLine("{0}{1}", "Is '([{' valid?: ", ValidParenthesis.Validate("([{"));
            // Console.WriteLine("{0}{1}", "Is '([)] valid?: ", ValidParenthesis.Validate("([)]"));
            // Console.WriteLine("{0}{1}", "Is '{[]}' valid?: ", ValidParenthesis.Validate("{[]}"));

            // ---- Remove duplicates ----
            // Console.WriteLine("{0} {1}", "The length after removing duplicates from Input array is ", RemoveDuplicates.Process(new int[] {1,1,1,3,4,5,5,5,5}));
            // Console.WriteLine("{0} {1}", "The length after removing duplicates from Input array is ", RemoveDuplicates.Process(new int[] {44,55,66,66,66,66,67,68,68}));

            // ---- WildCardPatterMatching.cs ----
            // Console.WriteLine("{0}{1}{2}", "Wild card matching run for Pattern 'a*b', Str 'abbbbbasdb'. Actual: ", WildCardPatternMatching.Match("a*b", "abbbbbasdb"), " Expected: True");
            // Console.WriteLine("{0}{1}{2}", "Wild card matching run for Pattern 'a*b', Str 'abbbbasdbc'. Actual: ", WildCardPatternMatching.Match("a*b", "abbbbasdbc"), " Expected: False");
            // Console.WriteLine("{0}{1}{2}", "Wild card matching run for Pattern 'a?b', Str 'acb'. Actual: ", WildCardPatternMatching.Match("a?b", "acb"), " Expected: True");
            // Console.WriteLine("{0}{1}{2}", "Wild card matching run for Pattern 'a?b', Str 'ab'. Actual: ", WildCardPatternMatching.Match("a?b", "ab"), " Expected: False");

            // ---- MergeSortedArrays.cs ----
            int[] arr1 = new int[13];
            arr1[0] = 4; arr1[1] = 4; arr1[2] = 8; arr1[3] = 10; arr1[4] = 14; arr1[5] = 15; arr1[6] = 16; arr1[7] = 22;
            MergeSortedArrays.Merge(arr1, new int[] {1, 2, 5, 7, 20}, 8, 5);
        }
    }
}
