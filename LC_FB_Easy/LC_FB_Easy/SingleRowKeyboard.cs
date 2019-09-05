using System;
using System.Collections.Generic;

namespace LC_FB_Easy
{
    class SingleRowKeyboard
    {
        public int CalculateTime(string keyboard, string word) {
            int distance = 0;
            int[] asciiKeyboardPosition = new int[26];
            for (int i = 0; i < keyboard.Length; i++) {
                asciiKeyboardPosition[keyboard[i] - 97] = i;
            }
            
            for (int i = 0; i < word.Length; i++) {
                if (i == 0) distance = asciiKeyboardPosition[word[i] - 97];
                else distance += Math.Abs(asciiKeyboardPosition[word[i] - 97] - asciiKeyboardPosition[word[i - 1] - 97]);
            }
            
            return distance;
        }
    }
}