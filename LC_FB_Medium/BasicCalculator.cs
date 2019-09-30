/*
Implement a basic calculator to evaluate a simple expression string.

The expression string contains only non-negative integers, +, -, *, / operators 
and empty spaces . The integer division should truncate toward zero.

Example 1:

Input: "3+2*2"
Output: 7
Example 2:

Input: " 3/2 "
Output: 1
Example 3:

Input: " 3+5 / 2 "
Output: 5
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class BasicCalculator
    {
        public int Calculate(string s) {
            Stack<int> operandStack = new Stack<int>();
            Stack<char> operatorStack = new Stack<char>();
            int num = 0, i = 0;
            
            while (i < s.Length) {
                if (s[i] == '+' || s[i] == '-' || s[i] == '*' || s[i] == '/') {
                    while(operatorStack.Count != 0 && this.GetOpPriority(s[i]) <= this.GetOpPriority(operatorStack.Peek())){
                        // evaluate and push result back
                        char op = operatorStack.Pop();
                        int operand2 = operandStack.Pop();
                        int operand1 = operandStack.Pop();
                        int result = this.Evaluate(operand1, operand2, op);
                        operandStack.Push(result);
                    }
                    
                    operatorStack.Push(s[i]);
                    i++;
                } else if (s[i] == ' ') i++;
                else {
                    num = 0;
                    while (i < s.Length && s[i] - '0' >= 0 && s[i] - '0' <= 9) {
                        num = num * 10 + (s[i] - '0');
                        i++;
                    }

                    operandStack.Push(num);
                }
            }

            while(operatorStack.Count != 0){
                // evaluate and push result back
                char op = operatorStack.Pop();
                int operand2 = operandStack.Pop();
                int operand1 = operandStack.Pop();
                int result = this.Evaluate(operand1, operand2, op);
                operandStack.Push(result);
            }

            if (operandStack.Count == 1) return operandStack.Peek();
            else return 0;
        }
        
        private int GetOpPriority(char op) {
            switch(op){
                case '+': return 1;
                case '-': return 1;
                case '*': return 2;
                case '/': return 2;
                default: throw new Exception("Not supported");
            }
        }
        
        private int Evaluate(int operand1, int operand2, char op) {
            switch(op){
                case '+': return operand1 + operand2;
                case '-': return operand1 - operand2;
                case '*': return operand1 * operand2;
                case '/': return operand1 / operand2;
                default: throw new Exception("Not supported");
            }
        }
    }
}