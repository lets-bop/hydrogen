using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
        Given an encoded string, return its decoded string.

        The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets 
        is being repeated exactly k times. Note that k is guaranteed to be a positive integer.

        You may assume that the input string is always valid; No extra white spaces, square brackets are well-formed, etc.

        Furthermore, you may assume that the original data does not contain any digits and that 
        digits are only for those repeat numbers, k. For example, there won't be input like 3a or 2[4].

        Examples:
        s = "3[a]2[bc]", return "aaabcbc".
        s = "3[a2[c]]", return "accaccacc".
        s = "2[abc]3[cd]ef", return "abcabccdcdcdef".
    */
    class DecodeString
    {
        public string Decode(string s) 
        {
            Stack<string> exp = new Stack<string>();
            StringBuilder sb = new StringBuilder();
            StringBuilder result = new StringBuilder();

            int n = 0;
            string tempStr = string.Empty;
            string popStr = string.Empty;
            for (int i = 0; i < s.Length; i++) {
                if (char.IsDigit(s[i])) {
                    n = (n * 10) + (int)char.GetNumericValue(s[i]);
                    continue;
                }

                if (n != 0) {
                    exp.Push(n.ToString());
                    n = 0;
                }

                if (s[i] == ']') {
                    popStr = exp.Pop();
                    while (popStr != "[") {
                        tempStr = popStr + tempStr;
                        popStr = exp.Pop();
                    }

                    // There must be an associated num along with the expression in []
                    sb.Clear();
                    int expCount = int.Parse(exp.Pop());
                    for(int j = 0; j < expCount; j++) {
                        sb.Append(tempStr);
                    }

                    if (exp.Count == 0) result.Append(sb);
                    else exp.Push(sb.ToString());
                    tempStr = string.Empty;
                    popStr = string.Empty;
                } else exp.Push(s[i].ToString());
            }

            // there could be plain text remaining in the stack.
            while (exp.Count > 0) {
                tempStr = exp.Pop() + tempStr;
            }

            result.Append(tempStr);
            return result.ToString();
        }
    }
}