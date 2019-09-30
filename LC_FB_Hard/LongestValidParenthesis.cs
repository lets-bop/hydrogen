/*
Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.

Example 1:

Input: "(()"
Output: 2
Explanation: The longest valid parentheses substring is "()"
Example 2:

Input: ")()())"
Output: 4
Explanation: The longest valid parentheses substring is "()()"

*/

using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    public class LongestValidParenthesis
    {
        public int FindWithoutExtraSpace(string s)
        {
            // We need to do 2 passes of the string for this. 
            // In the first pass from left to right, discard extra right parenthesis
            // In the second pass from right to left, discard extra left parenthesis
            if (s == null || s.Length == 0) return 0;

            int longest = 0;
            int left = 0;
            int right = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(') left++;
                else if (s[i] == ')') right++;
                if (left == right) longest = Math.Max(longest, 2 * right);
                if (right > left) left = right = 0;
            }

            left = right = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '(') left++;
                else if (s[i] == ')') right++;
                if (left == right) longest = Math.Max(longest, 2 * left);
                if (left > right) left = right = 0;
            }

            return longest;
        }

        public int Find(string s)
        {
            int longest = 0;
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            for (int i = 0; i < s.Length; i++) 
            {
                if (s[i] == '(') stack.Push(i);
                else 
                {
                    stack.Pop();
                    if (stack.Count == 0) stack.Push(i);
                    else longest = Math.Max(longest, i - stack.Peek());
                }
            }

            return longest;
        }
    }
}