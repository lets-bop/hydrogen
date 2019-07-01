using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_FB_Easy
{
    /*
     * Write a function that takes a string as input and reverse only the vowels of a string.

        Example 1:
        Input: "hello"
        Output: "holle"

        Example 2:
        Input: "leetcode"
        Output: "leotcede"

     * */
    class ReverseVowels
    {
        public string Reverse(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            int i = 0;
            int j = s.Length - 1;
            bool iVowel = false;
            bool jVowel = false;
            StringBuilder sb = new StringBuilder(s);

            while (i < j)
            {
                while (i < j)
                {
                    if (this.IsVowel(sb[i]))
                    {
                        iVowel = true;
                        break;
                    }

                    i++;
                }
                while (j > i)
                {
                    if (this.IsVowel(sb[j]))
                    {
                        jVowel = true;
                        break;
                    }

                    j--;
                }

                if (iVowel && jVowel)
                {
                    // swap
                    char temp = sb[i];
                    sb[i] = sb[j];
                    sb[j] = temp;

                    iVowel = false;
                    jVowel = false;
                    i++;
                    j--;
                }
            }

            return sb.ToString();
        }

        public bool IsVowel(char c)
        {
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
            {
                return true;
            }

            return false;
        }
    }
}
