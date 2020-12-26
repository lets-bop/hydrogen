using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given a string of numbers and operators, return all possible results from computing all the 
        different possible ways to group numbers and operators. The valid operators are +, - and *.

        Example 1:
        Input: "2-1-1"
        Output: [0, 2]
        Explanation: 
        ((2-1)-1) = 0 
        (2-(1-1)) = 2

        Example 2:
        Input: "2*3-4*5"
        Output: [-34, -14, -10, -10, 10]
        Explanation: 
        (2*(3-(4*5))) = -34 
        ((2*3)-(4*5)) = -14 
        ((2*(3-4))*5) = -10 
        (2*((3-4)*5)) = -10 
        (((2*3)-4)*5) = 10
    */
    class DifferentWaysToAddParenthesis
    {
        public IList<int> DiffWaysToCompute(string input) 
        {
            IList<int> result = this.Compute(input, 0, input.Length - 1);
            foreach (int r in result) Console.Write(r + "\t"); Console.WriteLine();
            return result;
        }

        private IList<int> Compute(string input, int low, int high) {
            if (input == null || high < low) return new List<int>();
            if (low == high) return new List<int>() {(int) char.GetNumericValue(input[low])};
            bool foundOps = false;
            IList<int> result = new List<int>();

            // for i = low .. high, split at the operator and recurse.
            for (int i = low; i <= high; i++) {
                if (input[i] == '+' || input[i] == '-' || input[i] == '*') {
                    foundOps = true;
                    IList<int> left = this.Compute(input, low, i - 1);
                    IList<int> right = this.Compute(input, i + 1, high);
                    foreach (int r in this.Calculate(left, right, input[i])) result.Add(r);
                }
            }

            // Handle numbers with multiple digits and cases where there are no operators
            if (!foundOps) result.Add(int.Parse(input.Substring(low, high - low + 1)));
            return result;
        }

        private IList<int> Calculate(IList<int> left, IList<int> right, char op) {
            IList<int> result = new List<int>();
            foreach (int l in left) {
                foreach (int r in right) {
                    switch(op) {
                        case '+':
                        result.Add(l + r);
                        break;
                        case '-':
                        result.Add(l - r);
                        break;
                        case '*':
                        result.Add(l * r);
                        break;
                    }
                }
            }

            return result;
        }
    }
}