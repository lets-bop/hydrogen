using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
        Sometimes people repeat letters to represent extra feeling, such as "hello" -> "heeellooo", "hi" -> "hiiii".  
        In these strings like "heeellooo", we have groups of adjacent letters that are all the same:  "h", "eee", "ll", "ooo".
        For some given string S, a query word is stretchy if it can be made to be equal to S by any number of applications 
        of the following extension operation: choose a group consisting of characters c, and add some number of 
        characters c to the group so that the size of the group is 3 or more.

        For example, starting with "hello", we could do an extension on the group "o" to get "hellooo", 
        but we cannot get "helloo" since the group "oo" has size less than 3. 
        Also, we could do another extension like "ll" -> "lllll" to get "helllllooo".  
        If S = "helllllooo", then the query word "hello" would be stretchy because of these 
        two extension operations: query = "hello" -> "hellooo" -> "helllllooo" = S.
        Given a list of query words, return the number of words that are stretchy.

        Example:
        Input: 
        S = "heeellooo"
        words = ["hello", "hi", "helo"]
        Output: 1
        Explanation: 
        We can extend "e" and "o" in the word "hello" to get "heeellooo".
        We can't extend "helo" to get "heeellooo" because the group "ll" is not size 3 or more.
    */
    public class ExpressiveWords
    {
        public int CountExpressiveWords(string S, string[] words)
        {
            int count = 0;
            List<(string, int)> groupsInS = this.DetermineGroups(S);

            foreach (string word in words) {
                List<(string, int)> groupsInWord = this.DetermineGroups(word);

                if (groupsInS.Count != groupsInWord.Count) continue;
                bool foundExpressiveWord = true;
                for (int i = 0; i < groupsInWord.Count; i++) {
                    if (groupsInS[i].Item1.StartsWith(groupsInWord[i].Item1) &&  
                        (groupsInS[i].Item2 == groupsInWord[i].Item2 ||
                        groupsInS[i].Item2 >= 3 * groupsInWord[i].Item2)) {
                            continue;
                        }

                        foundExpressiveWord = false;
                        break;
                }

                if (foundExpressiveWord) ++count;
            }

            return count;
        }

        private List<(string, int)> DetermineGroups(string s)
        {
            List<(string, int)> groups = new List<(string, int)>();
            if (string.IsNullOrEmpty(s) || s.Length == 0) return groups;

            int i = 0;
            StringBuilder sb = new StringBuilder();
            char prevChar = ' ';
            while (i < s.Length) {
                if (sb.Length == 0 || s[i] == prevChar) {
                    prevChar = s[i];
                    sb.Append(s[i]);
                } else {
                    prevChar = s[i];
                    groups.Add((sb.ToString(), sb.Length));
                    sb.Clear();
                    sb.Append(s[i]);
                }
                
                i++;
            }

            groups.Add((sb.ToString(), sb.Length));
            return groups;
        }
    }
}