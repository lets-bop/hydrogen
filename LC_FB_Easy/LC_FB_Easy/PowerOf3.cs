using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_FB_Easy
{
    /*
     * Given an integer, write a function to determine if it is a power of three.
            Example 1:
            Input: 27
            Output: true

            Example 2:
            Input: 0
            Output: false

            Example 3:
            Input: 9
            Output: true

            Example 4:
            Input: 45
            Output: false
     * */
    class PowerOf3
    {
        public bool IsPowerOfThree(int n)
        {
            // n = 3 ^ i
            // i = log3 (n)
            // i = log10(n) / log10(3)
            // n is a power of 3 only if i is an integer. We can do this by checking the result of the division has it's decimal part = 0
            return (Math.Log10(n) / Math.Log10(3)) % 1 == 0;
        }
    }
}
