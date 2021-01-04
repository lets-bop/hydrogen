using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
        A string S represents a list of words.
        Each letter in the word has 1 or more options.  If there is one option, 
        the letter is represented as is. 
        If there is more than one option, then curly braces delimit the options. 
        For example, "{a,b,c}" represents options ["a", "b", "c"].
        For example, "{a,b,c}d{e,f}" represents the list ["ade", "adf", "bde", "bdf", "cde", "cdf"].
        Return all words that can be formed in this manner, in lexicographical order.     

        Example 1:
        Input: "{a,b}c{d,e}f"
        Output: ["acdf","acef","bcdf","bcef"]

        Example 2:
        Input: "abcd"
        Output: ["abcd"]
    */

    class BraceExpansion
    {
        public string[] Expand(string s)
        {
            List<List<char>> parsedString = this.ParseString(s);
            List<string> result = new List<string>();
            if (parsedString == null) return result.ToArray();
            // this.Expand1(parsedString, 0, string.Empty, result);
            result = this.ExpandParsedString(parsedString, 0);
            return result.ToArray();
        }

        private List<string> ExpandParsedString(List<List<char>> parsedString, int index) {
            if (index >= parsedString.Count) return new List<string>() {""};
            List<string> tokens = this.ExpandParsedString(parsedString, index + 1);
            List<string> ret = new List<string>();

            foreach (char c in parsedString[index]) {
                foreach (string s in tokens) ret.Add(s + c);
            }

            return ret;
        }
        
        private void Expand1(List<List<char>> parsedString, int index, string strSoFar, List<string> res) {
            if (index >= parsedString.Count) return;

            foreach (char s in parsedString[index]) {
                if (index == parsedString.Count - 1) res.Add(strSoFar + s);
                else this.Expand1(parsedString, index + 1, strSoFar + s, res);
            }
        }

        private List<List<char>> ParseString(string s)
        {
            List<List<char>> parsedString = new List<List<char>>();
            if (string.IsNullOrEmpty(s)) return parsedString;
            
            List<char> list = new List<char>();
            bool multiCharList = false;

            foreach (char c in s) {
                if (c == '{') {
                    multiCharList = true;
                    list = new List<char>();
                } else if (c == '}') {
                    multiCharList = false;
                    list.Sort(); // only needed to satisfy leetcode's test validation
                    parsedString.Add(list);
                } else if (char.IsLetter(c)) {
                    if (multiCharList) list.Add(c);
                    else {
                        list = new List<char> {c};
                        parsedString.Add(list);
                    }
                }
            }

            return parsedString;
        }
    }
}