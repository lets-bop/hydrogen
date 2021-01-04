using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        One simple way to encrypt a string is to "rotate" every alphanumeric character by a certain amount. 
        Rotating a character means replacing it with another character that is a certain number of steps away in normal alphabetic or numerical order.
        For example, if the string "Zebra-493?" is rotated 3 places, the resulting string is "Cheud-726?". 
        Every alphabetic character is replaced with the character 3 letters higher (wrapping around from Z to A), 
        and every numeric character replaced with the character 3 digits higher (wrapping around from 9 to 0). 
        Note that the non-alphanumeric characters remain unchanged. Given a string and a rotation factor, return an encrypted string.

        Input: 1 <= |input| <= 1,000,000; 0 <= rotationFactor <= 1,000,000
        Output: Return the result of rotating input a number of times equal to rotationFactor.
        Example 1: input = Zebra-493?; rotationFactor = 3; output = Cheud-726?
        Example 2: input = abcdefghijklmNOPQRSTUVWXYZ0123456789; rotationFactor = 39; output = nopqrstuvwxyzABCDEFGHIJKLM9012345678
    */

    class RotationalCipher
    {
        public string Rotate(string s, int rotationFactor) {
            if (s == null || s.Length < 1) return s;
            char[] arr = s.ToCharArray();
            for (int i = 0; i < arr.Length; i++) arr[i] = this.GetRotatedChar(arr[i], rotationFactor);
            return new string(arr);
        }

        private char GetRotatedChar(int c, int rf) {
            if (!char.IsLetterOrDigit((char)c)) return (char)c;
            int ret = c;
            if (c >= 'A' && c <= 'Z') {
                rf = rf % 26;
                ret += rf;
                if (ret > 'Z') ret = 'A' + (ret % 'Z' - 1);
            }
            else if (c >= 'a' && c <= 'z') {
                rf = rf % 26;
                ret += rf;
                if (ret > 'z') ret = 'a' + (ret % 'z' - 1);
            }
            else {
                rf = rf % 10;
                ret += rf;
                if (ret > '9') ret = '0' + (ret % '9' - 1);
            }
            
            return (char)ret;
        }
    }
}