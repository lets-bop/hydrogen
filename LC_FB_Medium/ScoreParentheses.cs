using System;
using System.Collections.Generic;
using System.Text;

/*
Given a balanced parentheses string S, compute the score of the string based on the following rule:

() has score 1
AB has score A + B, where A and B are balanced parentheses strings.
(A) has score 2 * A, where A is a balanced parentheses string.
 

Example 1:
Input: "()"
Output: 1

Example 2:
Input: "(())"
Output: 2

Example 3:
Input: "()()"
Output: 2

Example 4:
Input: "(()(()))"
Output: 6
*/
namespace LC_FB_Medium
{
    class ScoreParentheses
    {
        public int ScoreOfParentheses(string S) {
            // return this.ScoreWithStack(S);
            // return this.ScoreWithCount(S);
            return this.ScoreWithStack2(S);
        }

        // Keep track of the open parenthesis of the string. 
        // For every ) that immediately follows a (, the answer is 1 << count of open parenthesis
        //  as count of open parenthesis is the number of exterior set of parentheses that contains this core.
        private int ScoreWithCount(string s) {
            int result = 0;
            int parenthesisOpenCount = 0;
            if (s == null || s.Length == 0) return result;
            
            for (int i = 0; i < s.Length; i++) {
                if (s[i] == '(') parenthesisOpenCount++;
                else {
                    parenthesisOpenCount--;
                    if (s[i - 1] == '(') result += 1 << parenthesisOpenCount;
                }
            }
            
            return result;
        }

        private int ScoreWithStack2(string s) {
            if (s == null || s.Length == 0) return 0;

            int sum;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < s.Length; i++) {
                if (s[i] == '(') stack.Push(s[i]);
                else {
                    sum = 0;
                    while (stack.Peek() != '(') sum += stack.Pop();
                    stack.Pop(); // pop '('
                    if (sum == 0) stack.Push(1);
                    else stack.Push(sum * 2);
                }
            }
            
            sum = 0;
            while (stack.Count > 0) sum += stack.Pop();
            return sum;
        }

        private int ScoreWithStack(string s) {
            int result = 0;
            if (s == null || s.Length == 0) return result;

            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            for (int i = 0; i < s.Length; i++) {
                if (s[i] == '(') stack.Push(0);
                else {
                    int pop1 = stack.Pop();
                    int pop2 = stack.Pop();
                    stack.Push(pop2 + Math.Max(pop1 * 2, 1));
                }
            }

            if (stack.Count > 0) return stack.Pop();
            return 0;
        }
    }
}