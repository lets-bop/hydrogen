/*
Given nums = [0,0,1,1,1,2,2,3,3,4],
Your function should return length = 5, with the first five elements of nums being modified to 0, 1, 2, 3, and 4 respectively.
It doesn't matter what values are set beyond the returned length.
 */

 using System;
 using System.Collections.Generic;

 namespace LC_FB_Easy
{
    class RemoveDuplicates
    {
        public static int Process(int[] input)
        {
            if (input == null || input.Length == 0)
            {
                return 0;
            }

            int i = 0;
            int j = 0;

            while (j < input.Length)
            {
                if(input[i] != input[j])
                {
                    i++;
                    input[i] = input[j];
                }

                j++;
            }

            foreach(int k in input)
            {
                Console.Write(k + "\t");
            }
            Console.WriteLine();
            return i + 1;
        }
    }
}
