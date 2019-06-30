/*
Given an array nums, write a function to move all 0's to the end of it while maintaining the 
relative order of the non-zero elements.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Easy
{
    class MoveZeros
    {
        public static string Process(int[] input)
        {
            if (input == null)
                return null;

            int zeroIndex = -1;
            for(int i = 0; i < input.Length; i++)
            {
                if (input[i] == 0 && zeroIndex == -1)
                    zeroIndex = i;
                else if (zeroIndex != -1 && input[i] != 0)
                    input[zeroIndex++] = input[i];
            }

            if (zeroIndex != -1)
            {
                for(int i = zeroIndex; i < input.Length; i++)
                    input[i] = 0;
            }
            
            StringBuilder sb = new StringBuilder();
            foreach (int i in input)
                sb.AppendFormat("{0}\t", i);

            sb.AppendLine();

            return sb.ToString();
        }
    }
}