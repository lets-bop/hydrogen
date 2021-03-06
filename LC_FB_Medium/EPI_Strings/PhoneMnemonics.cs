/*
Write a program that takes as input a phone number as a string of digits, 
and returns all possible character sequences that correspond to the phone 
number. The character sequences need not be legal words or phrases.
*/


using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class PhoneMnemonics
    {
        public static List<string> Execute(string number)
        {
            Dictionary<char, List<string>> numberToLettersMap = GetMap();
            List<string> finalList = new List<string>();
            if (string.IsNullOrEmpty(number)) return finalList;
            StringBuilder sb = new StringBuilder();
            RecHelper(number, sb, 0, numberToLettersMap, finalList);
            foreach (string s in finalList) Console.WriteLine(s);
            return finalList;
        }

        public static void RecHelper(string number, StringBuilder sb, int startIndex, Dictionary<char, List<string>> numberToLettersMap, List<string> finalList)
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

        private static Dictionary<char, List<string>> GetMap()
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