using System;
using System.Collections.Generic;

namespace LC_FB_Easy
{
    class Execute_LC_FB_Easy
    {
        public static void Execute()
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
            // int[] arr1 = new int[13];
            // arr1[0] = 4; arr1[1] = 4; arr1[2] = 8; arr1[3] = 10; arr1[4] = 14; arr1[5] = 15; arr1[6] = 16; arr1[7] = 22;
            // MergeSortedArrays.Merge(arr1, new int[] {1, 2, 5, 7, 20}, 8, 5);

            // ---- BestTimeToBuySellStocks.cs ----
            // Console.WriteLine(
            //     "{0}. Actual:{1}, Expected:5", "Input 7,1,5,3,6,4", 
            //     BestTimeToBuySellStocks.FindMax(new int[] {7,1,5,3,6,4}));
            // Console.WriteLine(
            //     "{0}. Actual:{1}, Expected:0", "Input 7,6,5,4,3,2,1", 
            //     BestTimeToBuySellStocks.FindMax(new int[] {7,6,5,4,3,2,1}));

            // ---- Reverse a linked list ----
            // LinkedList.ListNode head = LinkedList.Build(new int[] {1,2,3,4,5});
            // Console.WriteLine("Input is \t {0}", LinkedList.Print(head));
            // head = LinkedList.Reverse(head);
            // Console.WriteLine("Reversed list is {0}", LinkedList.Print(head));
            // head = LinkedList.Reverse(head);
            // Console.WriteLine("Reversed list is {0}", LinkedList.Print(head));

            // ---- Lowest common ancestor for a BST ----
            // BST.TreeNode root = BST.Build("6C2,8;2C0,4;8C7,9;4C3,5");
            // Console.WriteLine("LCA of 2, 8 is {0}", LCAInBST.Find(root, 2, 8));
            // Console.WriteLine("LCA of 2, 4 is {0}", LCAInBST.Find(root, 2, 4));

            // ---- Missing number ----
            // Console.WriteLine("Missing number in 3,0,1 is {0}", MissingNumber.Find(new int[] {3,0,1}));
            // Console.WriteLine("Missing number in 9,6,4,2,3,5,7,0,1 is {0}", MissingNumber.Find(new int[] {9,6,4,2,3,5,7,0,1}));

            // ---- Move zeros ----
            Console.WriteLine("Input 0,1,0,3,12. Output is {0}", MoveZeros.Process(new int[] {0,1,0,3,12}));
            Console.WriteLine("Input 4,5,6,0,1,0,3,12. Output is {0}", MoveZeros.Process(new int[] {4,5,6,0,1,0,3,12}));            
        }
    }
}