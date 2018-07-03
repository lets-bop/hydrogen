/*
Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:
    Open brackets must be closed by the same type of brackets.
    Open brackets must be closed in the correct order.
    Note that an empty string is also considered valid.

Examples:
Input: "{[]}"
Output: true

Input: "()[]{}"
Output: true

Input: "([)]"
Output: false

 */

using System;
using System.Collections.Generic;

namespace LC_FB_Easy
{
    class ValidParenthesis
    {
        public static bool Validate(string input)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in input.ToCharArray())
            {
                if (c == '{' || c == '[' || c == '(')
                {
                    stack.Push(c);
                }
                else if (c == '}' || c == ']' || c == ')')
                {
                    char top = stack.Pop();
                    if (c == '}' && top != '{')
                    {
                        return false;
                    }
                    if (c == ']' && top != '[')
                    {
                        return false;
                    }
                    if (c == ')' && top != '(')
                    {
                        return false;
                    }                                        
                }
            }

            if (stack.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}