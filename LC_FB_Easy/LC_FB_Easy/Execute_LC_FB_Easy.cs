using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Easy
{
    class Execute_LC_FB_Easy
    {
        public static string GetArrayOfIntAsString(int[] list) {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for(int i = 0; i < list.Length; i++){  
                if (i != 0) sb.Append(","); 
                sb.Append(list[i].ToString());
            }

            sb.Append("]");
            return sb.ToString();
        }

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
            // MoveZeros zeros = new MoveZeros();
            // int[] input = new int[] {0,1,0,3,12};
            // zeros.Move(input);
            // Console.WriteLine("Expected: {1,3,12,0,0}. Actual:" + GetArrayOfIntAsString(input));
            // input = new int[] {4,5,6,0,1,0,3,12};
            // zeros.Move(input);
            // Console.WriteLine("Expected: {4,5,6,1,3,12,0,0}. Actual: " + GetArrayOfIntAsString(input));

            // --- Plus one ---
            //PlusOne plusOne = new PlusOne();
            //int[] result = plusOne.Execute(new int [] {9,9});
            //foreach (int i in result) Console.Write(i + "\t");

            //UniqueEmailAddresses uea = new UniqueEmailAddresses();            
            //Console.WriteLine(uea.NumUniqueEmails(new string[] { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" })); // expected output = 2

            //FirstUniqueCharInString unique = new FirstUniqueCharInString();
            //Console.WriteLine(unique.FirstUniqChar("leetcode"));

            //FlippingAnImage flippingAnImage = new FlippingAnImage();
            //int[][] image = { new int[] { 1, 1, 0 }, new int[] { 1, 0, 1 }, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 } };
            //flippingAnImage.FlipAndInvertImage(image);

            // RobotOrigin robotOrigin = new RobotOrigin();
            // Console.WriteLine(robotOrigin.JudgeCircle("UD"));
            // Console.WriteLine(robotOrigin.JudgeCircle("LL"));

            // BackspaceStringCompare back = new BackspaceStringCompare();
            // Console.WriteLine("Expected: true. Actual: " + back.BackspaceCompare("ab#c", "ad#c"));
            // Console.WriteLine("Expected: true. Actual: " + back.BackspaceCompare("ab##", "c#d#"));
            // Console.WriteLine("Expected: true. Actual: " + back.BackspaceCompare("a##c", "#a#c"));
            // Console.WriteLine("Expected: false. Actual: " + back.BackspaceCompare("a#c", "b"));
            // Console.WriteLine("Expected: true. Actual: " + back.BackspaceCompare("nzp#o#g", "b#nzp#o#g"));

            // BullsAndCows cb = new BullsAndCows();
            // Console.WriteLine("Expected: 1A3B. Actual: " + cb.GetHint("1807", "7810"));
            // Console.WriteLine("Expected: 1A1B. Actual: " + cb.GetHint("1123", "0111"));
            // Console.WriteLine("Expected: 3A0B. Actual: " + cb.GetHint("1122", "1222"));

            // TestSingleRowKeyboard();
            // TestAddStrings();
            // TestIsValidPalindrome();
            // TestRepeatedStringMatch();
            // TestMajorityElememt();
            // TestMeetingRooms();
            // TestInvertBinaryTree();
            // TestClosestBSTValue();
            TestRemoveOuterMostParenthesis();
        }

        public static void TestSingleRowKeyboard()
        {
            SingleRowKeyboard s = new SingleRowKeyboard();
            Console.WriteLine("Expected: 4. Actual: " + s.CalculateTime("abcdefghijklmnopqrstuvwxyz", "cba"));
            Console.WriteLine("Expected: 73. Actual: " + s.CalculateTime("pqrstuvwxyzabcdefghijklmno", "leetcode"));
        }

        public static void TestAddStrings()
        {
            AddStrings a = new AddStrings();
            Console.WriteLine("Expected: 77. Actual: " + a.Add("44", "33"));
            Console.WriteLine("Expected: 1110. Actual: " + a.Add("444", "666"));
            Console.WriteLine("Expected: 670. Actual: " + a.Add("4", "666"));
        }

        public static void TestIsValidPalindrome()
        {
            IsValidPalindrome pal = new IsValidPalindrome();
            Console.WriteLine("Expected: True. Actual: " + pal.IsPalindrome("A man, a plan, a canal: Panama"));
            Console.WriteLine("Expected: False. Actual: " + pal.IsPalindrome("race a car"));
            Console.WriteLine("Expected: False. Actual: " + pal.IsPalindrome("0P"));
        }

        public static void TestRepeatedStringMatch()
        {
            RepeatedStringMatch r = new RepeatedStringMatch();
            Console.WriteLine("Expected: 3. Actual: " + r.Match("abcd", "cdabcdab"));
            Console.WriteLine("Expected: -1. Actual: " + r.Match("abcde", "cdabcdab"));
            Console.WriteLine("Expected: 4. Actual: " + r.Match("abcde", "cdeabcdeabcdea"));
            Console.WriteLine("Expected: 2. Actual: " + r.Match("aaaa", "aaaaa"));
        }

        public static void TestMajorityElememt()
        {
            MajorityElement m = new MajorityElement();
            Console.WriteLine("Expected: 3. Actual: " + m.Find(new int[] {3, 2, 3}));
            Console.WriteLine("Expected: 2. Actual: " + m.Find(new int[] {2,2,1,1,1,2,2}));
        }

        public static void TestMeetingRooms()
        {
            MeetingRooms m = new MeetingRooms();
            int[][] intervals;
            intervals = new int[][] {new int[]{0,30}, new int[]{5,10}, new int[]{15,20}};
            Console.WriteLine("Expected: False. Actual: " + m.CanAttendMeetings(intervals));
            intervals = new int[][] {new int[]{2,4}, new int[]{7,10}};
            Console.WriteLine("Expected: True. Actual: " + m.CanAttendMeetings(intervals));
        }

        public static void TestInvertBinaryTree()
        {
            // placeholder
        }

        public static void TestBinaryTreePathSum() 
        {
            // placeholder
        }

        public static void TestClosestBSTValue()
        {
            ClosestBSTValue bst = new ClosestBSTValue();
            ClosestBSTValue.TreeNode n1 = new ClosestBSTValue.TreeNode(1500000000);
            ClosestBSTValue.TreeNode n2 = new ClosestBSTValue.TreeNode(1400000000);
            n1.left = n2;
            Console.WriteLine(bst.ClosestValue(n1, -1500000000.0));
        }

        public static void TestRemoveOuterMostParenthesis()
        {
            RemoveOuterMostParenthesis r = new RemoveOuterMostParenthesis();
            Console.WriteLine("Expected: ()()(). Actual: " + r.RemoveOuterParentheses("(()())(())"));
            Console.WriteLine("Expected: ()()()()(()). Actual: " + r.RemoveOuterParentheses("(()())(())(()(()))"));
            Console.WriteLine("Expected: . Actual: " + r.RemoveOuterParentheses("()()"));
        }
    }
}