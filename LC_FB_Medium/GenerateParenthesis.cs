/*Given n pairs of parentheses, write a function to generate all combinations of 
well-formed parentheses.

For example, given n = 3, a solution set is:

[
  "((()))",
  "(()())",
  "(())()",
  "()(())",
  "()()()"
]

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class GenerateParenthesis
    {
        public IList<string> Generate(int n) {
            IList<string> list = new List<string>();
            HashSet<string> check = new HashSet<string>();
            IList<string> result = new List<string>();
            list.Add("()");
            result.Add("()");

            for(int i = 1; i < n; i++){
                check.Clear();
                result.Clear();

                foreach(string pattern in list){
                    for(int j = 2; j <= pattern.Length; j = j + 2){
                        string s1 = null, s2 = null;
                        s1 = pattern.Substring(0, j);
                        if(this.IsValid(s1)){
                            if(j < pattern.Length) s2 = pattern.Substring(j);
                            string rs = "()" + s1 + (s2 == null ? "" : s2);
                            if(!check.Contains(rs)){
                                check.Add(rs);
                                result.Add(rs);
                            }

                            rs = s1 + "()" + (s2 == null ? "" : s2);
                            if(!check.Contains(rs)){
                                check.Add(rs);
                                result.Add(rs);
                            }

                            rs = s1 + (s2 == null ? "" : s2) + "()";
                            if(!check.Contains(rs)){
                                check.Add(rs);
                                result.Add(rs);
                            }

                            rs = "(" + s1 + ")" + (s2 == null ? "" : s2);
                            if(!check.Contains(rs)){
                                check.Add(rs);
                                result.Add(rs);
                            }

                            rs = s1 + "(" +  (s2 == null ? "" : s2) + ")";
                            if(!check.Contains(rs)){
                                check.Add(rs);
                                result.Add(rs);
                            }

                            rs = "(" + s1 +  (s2 == null ? "" : s2) + ")";
                            if(!check.Contains(rs)){
                                check.Add(rs);
                                result.Add(rs);
                            }                          
                        }
                    }
                }

                list = new List<string>(result);
            }

            return result;            
        }

        private bool IsValid(string s){
            int check = 0;
            for(int i = 0; i < s.Length; i++){
                if(s[i] == '(') check++;
                if(s[i] == ')'){
                    if (check <= 0) return false;
                    check--;
                }
            }

            if(check == 0) return true;
            return false;
        }        
    }
}