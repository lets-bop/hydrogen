/*
Given a string containing digits from 2-9 inclusive, return all possible letter 
combinations that the number could represent.

A mapping of digit to letters (just like on the telephone buttons) is given below. 
Note that 1 does not map to any letters.

Input: "23"
Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class LetterComboOfPhone
    {
        public IList<string> LetterCombinations(string number)
        {
            Dictionary<char, List<string>> numberToLettersMap = this.GetMap();
            List<string> finalList = new List<string>();
            if (string.IsNullOrEmpty(number)) return finalList;
            StringBuilder sb = new StringBuilder();
            this.RecHelper(number, sb, 0, numberToLettersMap, finalList);
            return finalList;
        }

        public void RecHelper(
            string number, 
            StringBuilder sb, 
            int startIndex, 
            Dictionary<char, List<string>> numberToLettersMap, 
            List<string> finalList)
        {
            if (startIndex == number.Length)
            {
                finalList.Add(sb.ToString());
                return;
            }

            char c = number[startIndex];
            if (numberToLettersMap.ContainsKey(c))
            {
                List<string> letterList = numberToLettersMap[c];
                foreach (string letter in letterList)
                {
                    sb.AppendFormat("{0}", letter);
                    RecHelper(number, sb, startIndex + 1, numberToLettersMap, finalList);
                    sb.Remove(sb.Length - 1, 1);
                }
            }
            else 
            {
                sb.AppendFormat("{0}", c);
                RecHelper(number, sb, startIndex + 1, numberToLettersMap, finalList);
            }     
        }

        private Dictionary<char, List<string>> GetMap()
        {
            Dictionary<char, List<string>> numberToLettersMap = new Dictionary<char, List<string>>();
            numberToLettersMap.Add('2', new List<string>() {"a","b","c"});
            numberToLettersMap.Add('3', new List<string>() {"d","e","f"});
            numberToLettersMap.Add('4', new List<string>() {"g","h","i"});
            numberToLettersMap.Add('5', new List<string>() {"j","k","l"});
            numberToLettersMap.Add('6', new List<string>() {"m","n","o"});
            numberToLettersMap.Add('7', new List<string>() {"p","q","r","s"});
            numberToLettersMap.Add('8', new List<string>() {"t","u","v"});
            numberToLettersMap.Add('9', new List<string>() {"w","x","y","z"});
            return numberToLettersMap;
        }        
    }
}