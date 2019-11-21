/*
Remove the minimum number of invalid parentheses in order to make the input string valid. 
Return all possible results.
Note: The input string may contain letters other than the parentheses ( and ).

Example 1:
Input: "()())()"
Output: ["()()()", "(())()"]

Example 2:
Input: "(a)())()"
Output: ["(a)()()", "(a())()"]

Example 3:
Input: ")("
Output: [""]

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class RemoveInvalidParentheses
    {
        int maxLengthSoFar = -1;

        public IList<string> Remove(string input) {
            // BFS based approach. 
            // Beginning with the string given to us, if the string is not valid,
            // we drop a parenthesis at each index of the string and add it to a queue.
            // For a string of length n, we generate n - 1 strings.
            // And repeat the process until we find the first valid string. 
            // Any succeeding string will be considered for further processing only if its length is
            // at least as long as the first valid string.
            IList<string> result = new List<string>();
            Queue<string> q = new Queue<string>();
            HashSet<string> visisted = new HashSet<string>();
            q.Enqueue(input);

            while (q.Count > 0){
                string s = q.Dequeue();
                if (s.Length < maxLengthSoFar) continue;
                
                if (this.IsValidParantheses(s)){
                    maxLengthSoFar = s.Length;
                    result.Add(s);
                    continue;
                }

                // Parenthesis is not valid here.
                for (int i = 0; i < s.Length; i++) {
                    if (s[i] == '(' || s[i] == ')') {
                        // drop char at i which is a parenthesis
                        string stringWithoutParenthesis = s.Substring(0, i) + s.Substring(i + 1);
                        if (stringWithoutParenthesis.Length < maxLengthSoFar) continue;
                        if (!visisted.Contains(stringWithoutParenthesis)) {
                            visisted.Add(stringWithoutParenthesis);
                            q.Enqueue(stringWithoutParenthesis);
                        }
                    }
                }
            }

            return result;
        }   

        private bool IsValidParantheses(string s)
        {
            if (s == null || s.Length == 0) return true;

            int cnt = 0;
            for (int i = 0; i < s.Length; i++){
                if (s[i] == '(') cnt++;
                if (s[i] == ')') cnt--;
                if (cnt < 0) return false;
            }

            return cnt == 0 ? true : false;
        }
    }
}