using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    class BasicCalculator
    {
        public int Calculate(string s)
        {
            Stack<int> numStack = new Stack<int>();
            Stack<char> opStack = new Stack<char>();

            int num = 0;
            bool processedNumber = false;
            foreach (char c in s.ToCharArray()){
                if(c - '0' >= 0 && c - '0' <= 9){
                    // number
                    processedNumber = true;
                    int digit = c - '0';
                    num = (num*10) + digit;
                }
                else{
                    if(processedNumber){
                        processedNumber = false;
                        numStack.Push(num);
                        num = 0;
                    }

                    if(c == ' ') continue;
                    else if (c == '(') opStack.Push(c);
                    else if (c == ')'){
                        char popC;
                        while((popC = opStack.Pop()) != '('){
                            int num2 = numStack.Pop();
                            int num1 = numStack.Pop();
                            numStack.Push(this.ApplyOperator(num1, num2, popC));
                        }
                    }
                    else{
                        if (this.IsValidOp(c)){
                            if(opStack.Count > 0 && opStack.Peek() == '(') opStack.Push(c);
                            else{
                                while(opStack.Count > 0 && this.GetOpRank(opStack.Peek()) >= this.GetOpRank(c)){
                                    char popC = opStack.Pop();
                                    int num2 = numStack.Pop();
                                    int num1 = numStack.Pop();
                                    numStack.Push(this.ApplyOperator(num1, num2, popC));                                  
                                }

                                opStack.Push(c);
                            }
                        }
                    }
                }
            }

            if(processedNumber){
                numStack.Push(num);
            }     

            while(opStack.Count != 0){
                // Assuming that the given expression is always valid.
                char popC = opStack.Pop();
                int num2 = numStack.Pop();
                int num1 = numStack.Pop();
                numStack.Push(this.ApplyOperator(num1, num2, popC));                   
            }

            if (numStack.Count != 1) Console.WriteLine("!!!!!!!!!Something has gone wrong!!!!!!!. Stack count is " + numStack.Count);
            
            return numStack.Peek();
        }

        private int ApplyOperator(int n1, int n2, char op){
            if(!this.IsValidOp(op)){
                throw new Exception("Not a valid operator");
            }

            switch(op){
                case '+':
                    return n1 + n2;
                case '-':
                    return n1 - n2;
                case '*':
                    return n1 * n2;
                case '/':
                    return n1 / n2;
                default:
                    return 0;
            }
        }

        private bool IsValidOp(char c){
            if (c == '+' || c == '-' || c == '*' || c == '/') return true;
            return false;
        }

        private int GetOpRank(char op)
        {
            switch(op){
                case '+':
                    return 1;
                case '-':
                    return 1;
                case '*':
                    return 2;
                case '/':
                    return 2;
                default:
                    return 0;
            }                        
        }
    }
}