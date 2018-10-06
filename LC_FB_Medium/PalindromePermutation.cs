/*
Given a string s, return all the palindromic permutations (without duplicates) of it. Return an empty list if no palindromic permutation could be form.

Example 1:

Input: "aabb"
Output: ["abba", "baab"]
Example 2:

Input: "abc"
Output: []
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class PalindromePermutation
    {
        public IList<string> GeneratePalindromes(string s) {
            IList<string> result = new List<string>();

            // Check if palidrome is even possible.
            // At most one character can have odd # of occurrence.
            Dictionary<char, int> charCounts = this.CountChars(s);
            if(this.IsPalidromePossible(charCounts)){
                // Let 'st' be the string containing half of the even chars. 
                // We need to permute st and then for each permutation,
                // attach its reversed-self to get the palindrome.
                // In case 's' is of odd length, there will be char that has odd char count.
                // For the char with odd # of occurrence, split it into odd and even part.
                // The odd part will be 1, and the even part will be a multiple of 2.

                StringBuilder sb = new StringBuilder();
                char oddChar = '#';
                foreach(char key in charCounts.Keys){
                    if(charCounts[key] % 2 != 0){
                        oddChar = key;
                    }
                    for(int i = 0; i < charCounts[key] / 2; i++){
                        sb.Append(key);
                    }
                }

                HashSet<string> perms = new HashSet<string>();
                this.Permute(sb.ToString().ToCharArray(), 0, perms);
                foreach(string p in perms){
                    char[] reversed = p.ToCharArray();
                    Array.Reverse(reversed);
                    if (oddChar != '#')
                        result.Add(p + oddChar + new string(reversed));
                    else result.Add(p + new string(reversed));
                }
            }

            foreach (string r in result) Console.WriteLine(r);

            return result;          
        }

        private void Permute(char[] s, int start, HashSet<string> perms){
            if (start == s.Length) perms.Add(new string(s));
            for(int i = start; i < s.Length; i++){
                if(s[i] == s[start] && i != start) {
                    // no need to swap, duplicate chars
                    continue;
                }
                this.Swap(s, start, i);
                Permute(s, start + 1, perms);
                this.Swap(s, start, i);
            }
        }

        private void Swap(char[] c, int i, int j){
            char temp = c[i];
            c[i] = c[j];
            c[j] = temp;
        }

        private Dictionary<char, int> CountChars(string s){
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++){
                if (map.ContainsKey(s[i])) map[s[i]]++;
                else map[s[i]] = 1;
            }

            return map;
        }

        private bool IsPalidromePossible(Dictionary<char, int> charCounts){
            bool oneOdd = false;
            foreach (var key in charCounts.Keys){
                if (charCounts[key] % 2 != 0){
                    if (oneOdd) return false;
                    oneOdd = true;
                }
            }

            return true;
        }
    }
}