using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    class ExpressionAddOperators
    {
        public IList<string> AddOperators(string num, int target) {
            List<string> result = new List<string>();
            if (num == null || num.Length == 0) return result;
            
            foreach (KeyValuePair<int, List<string>> pair in this.Add(num, 0, num.Length - 1, target)) {
                if (pair.Key == target) {
                    result.AddRange(pair.Value);
                }
            }
            
            return result;
        }
        
        private Dictionary<int, List<string>> Add(
            string num, 
            int start, 
            int end, 
            int target) {
            if (start > end || end >= num.Length) return null;
            Dictionary<int, List<string>> results = new Dictionary<int, List<string>>();
            
            for (int i = start; i <= end; i++) {
                int num1;
                string numStr = num.Substring(start, i - start + 1);
                if (int.TryParse(numStr, out num1)) {
                    if (numStr.Length > 1 && num1 == 0) continue;
                    Dictionary<int, List<string>> right = this.Add(num, i + 1, end, target);
                    
                    if (right == null || right.Count == 0) {
                        List<string> expressions = new List<string>() { num1.ToString() };
                        if (results.ContainsKey(num1)) results[num1].AddRange(expressions);
                        else results[num1] = expressions;
                    }
                    else {
                        foreach (KeyValuePair<int, List<string>> pair in right) {
                            int num2 = pair.Key;
                            List<string> expressions = pair.Value;
                            this.PerformOperation('+', num1, num2, expressions, results);
                            this.PerformOperation('-', num1, num2, expressions, results);
                            this.PerformOperation('*', num1, num2, expressions, results);
                        }
                    }
                }
            }
            
            return results;
        }

        private void PerformOperation(
            char op, 
            int num1, 
            int num2,
            List<string> expressions,
            Dictionary<int, List<string>> results) {

            int val = 0;
            switch (op) {
                case '+':
                    val = num1 + num2;
                    break;

                case '-':
                    val = num1 - num2;
                    break;

                case '*':
                    val = num1 * num2;
                    break;

            }
            
            List<string> newExpressions = new List<string>();
            foreach (string exp in expressions) {
                string newExp = num1.ToString() + op.ToString() + exp;
                newExpressions.Add(newExp);
            }

            if (results.ContainsKey(val)) results[val].AddRange(newExpressions);
            else results[val] = newExpressions;
        }
    }
}