/*
The wild cards can be * and ?

Example:
a*b = ab, aab, aacbdbcdb = true and b, a, ac, abc = False
a?b = aab, abb, acb = True and ab, b, = False

 */

using System;
using System.Collections.Generic;

namespace LC_FB_Easy
{
    class WildCardPatternMatching
    {
        public static bool Match(string pattern, string str)
        {
            DateTime dt = DateTime.UtcNow;
            if (pattern != null && str == null)
                return false;
            if (pattern == null && str == null || pattern == null && str != null)
                return true;

            int patternIndex = 0;
            int strIndex = 0;
            int starIndex = -1;

            while(strIndex < str.Length)
            {
                if (patternIndex < pattern.Length && (pattern[patternIndex] == str[strIndex] || pattern[patternIndex] == '?'))
                {
                    patternIndex++;
                    strIndex++;
                }
                else if (patternIndex < pattern.Length && pattern[patternIndex] == '*')
                {
                    // We just record that a star was seen and continue matching by only advancing the patternIndex.
                    // This is because a * represents 0 or more characters to match. We will use the * only if a match was not seen.
                    starIndex = patternIndex;
                    patternIndex++;
                }
                else
                {
                    // No match, see if * was found and use it for matching
                    if (starIndex == -1)
                        return false;
                    else
                    {
                        patternIndex = starIndex + 1;
                        strIndex++;
                    }
                }
            }

            while (patternIndex < pattern.Length && pattern[patternIndex] == '*')
                patternIndex++;

            Console.WriteLine("{0} {1} {2} ms", pattern.Length, patternIndex, DateTime.UtcNow.Subtract(dt).TotalMilliseconds);
            return pattern.Length == patternIndex;
        }
    }
}