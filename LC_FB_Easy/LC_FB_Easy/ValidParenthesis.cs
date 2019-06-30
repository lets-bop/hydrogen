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
            
            foreach (char currChar in input.ToCharArray())
            {
                if (currChar == '{' || currChar == '[' || currChar == '(')
                {
                    stack.Push(currChar);
                }
                else if (currChar == '}' || currChar == ']' || currChar == ')')
                {
                    if (stack.Count == 0) {
                        return false;
                    }

                    char prevChar = stack.Pop();

                    if (currChar == '}' && prevChar != '{')
                    {
                        return false;
                    }
                    if (currChar == ']' && prevChar != '[')
                    {
                        return false;
                    }
                    if (currChar == ')' && prevChar != '(')
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