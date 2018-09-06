/*
Remove the minimum number of invalid parentheses in order to make the input string valid. Return all possible results.

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
        public IList<string> Remove(string input) {
            IList<string> result = new List<string>();
            Queue<string> q = new Queue<string>();
            HashSet<string> visisted = new HashSet<string>();
            q.Enqueue(input);

            while (q.Count > 0){
                string s = q.Dequeue();
                
                if (this.IsValidParantheses(s)){
                    result.Add(s);
                    continue;
                }

                for (int i = 0; i < s.Length; i++){
                    if (s[i] == '(' || s[i] == ')'){
                        string stringWithoutParenthesis = s.Substring(0, i) + s.Substring(i + 1);
                        if (!visisted.Contains(stringWithoutParenthesis)){
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
            if (s == null || s.Length < 1) return true;

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