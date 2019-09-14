using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    class SentenceScreenFitting
    {
        public int WordsTyping(string[] sentence, int rows, int cols) {
            int result = 0;

            int r = 0;
            int c = cols;
            int w = 0;
            int charsNeededForAllWordsWithSpaces = 0;

            while (r < rows) {
                if (sentence[w].Length > cols) return 0;
                if (c >= sentence[w].Length) {
                    charsNeededForAllWordsWithSpaces += sentence[w].Length + 1;
                    c = c - sentence[w++].Length - 1; // 1 for additional space between words
                } else {
                    c = cols;
                    r++;
                    if (w == 0) {
                        // optimization for faster processing
                        if (rows % r == 0) return result * rows / r;
                        else {
                            int remainder = rows % r;
                            return (result * rows / r) + (remainder * cols / charsNeededForAllWordsWithSpaces);
                        }
                    }
                }

                if (w == sentence.Length) {
                    result++;
                    w = 0;
                }
            }

            return result;
        }
    }
}