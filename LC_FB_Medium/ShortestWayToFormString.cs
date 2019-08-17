using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
        From any string, we can form a subsequence of that string by deleting some number of characters (possibly no deletions).
        Given two strings source and target, return the minimum number of subsequences of source such that their 
        concatenation equals target. If the task is impossible, return -1.

        Example 1:
        Input: source = "abc", target = "abcbc"
        Output: 2
        Explanation: The target "abcbc" can be formed by "abc" and "bc", which are subsequences of source "abc".

        Example 2:
        Input: source = "abc", target = "acdbc"
        Output: -1
        Explanation: The target string cannot be constructed from the subsequences of source string due to the character "d" in target string.

        Example 3:
        Input: source = "xyz", target = "xzyxz"
        Output: 3
        Explanation: The target string can be constructed as follows "xz" + "y" + "xz".
    */
    class ShortestWayToFormString
    {
        public int ShortestWay(string source, string target) {
            if (source == null || (source.Length == 0 && target.Length != 0)) return -1;

            int targetIndex = 0;
            int sourceIndex = 0;
            bool foundMatchInSourceIteration = false;
            int count = 0;

            while (targetIndex < target.Length) {
                if (sourceIndex == 0) count++;

                if (target[targetIndex] == source[sourceIndex]) {
                    foundMatchInSourceIteration = true;
                    targetIndex++;
                }
                
                sourceIndex++;
                if (sourceIndex >= source.Length && !foundMatchInSourceIteration) return -1;
                else if (sourceIndex >= source.Length) {
                    sourceIndex = 0;
                    foundMatchInSourceIteration = false;
                }
            }

            return count;
        }
    }
}