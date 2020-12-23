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

            List<List<string>> letterList = new List<List<string>>();
            foreach (char c in number) letterList.Add(numberToLettersMap[c]);
            List<string> combo = this.FindCombo(letterList, 0);
            return combo;
        }

        List<string> FindCombo(List<List<string>> letterList, int listIndex) {
            if (listIndex >= letterList.Count) return new List<string>();
            if (listIndex == letterList.Count - 1) return letterList[listIndex];

            List<string> retList = new List<string>();
            List<string> list = FindCombo(letterList, listIndex + 1);
            
            foreach (string l in letterList[listIndex]) {
                foreach (string s in list) retList.Add(l + s);
            }

            return retList;
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