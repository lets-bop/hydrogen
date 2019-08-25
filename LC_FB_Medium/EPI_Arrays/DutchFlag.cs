/*
Given a randomly ordered array containing balls of 3 colors, Red (0), Green(1) and Blue(2).
Order the items as groups of Red Green Blue.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
        For this problem, your goal is to sort an array of 0, 1 and 2's but you must do this in place, 
        in linear time and without any extra space (such as creating an extra array). 
        This is called the Dutch national flag sorting problem. 
        For example, if the input array is [2,0,0,1,2,1] then your program should output 
        [0,0,1,1,2,2] and the algorithm should run in O(n) time.
    */
    class DutchFlag
    {
        public int[] Sort(int[] input) {
            if (input == null || input.Length == 0) return input;
            int low = 0;
            int mid = 0;
            int high = input.Length - 1;

            while (mid <= high) {
                if (input[mid] == 0) this.Swap(input, low++, mid++);
                else if (input[mid] == 2) this.Swap(input, high--, mid);
                else mid++;
            }

            return input;
        }

        private void Swap(int[] input, int i, int j) {
            int temp = input[i];
            input[i] = input[j];
            input[j] = temp;
        }
    } 
}