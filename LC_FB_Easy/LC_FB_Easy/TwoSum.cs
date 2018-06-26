/*
Given an array of integers, return indices of the two numbers such that they add up to a specific target.

    Given nums = [2, 7, 11, 15], target = 9,

    Because nums[0] + nums[1] = 2 + 7 = 9,
    return [0, 1].

    Special notes: 
    Make sure logic works with negative #s
        int[] arr = new int[] {-2, 3, -6, 4, -11 };
        TwoSum.Find(arr, 7);
        TwoSum.Find(arr, -7);
        TwoSum.Find(arr, -8);
 */

 using System;
 using System.Collections.Generic;

 namespace LC_FB_Easy
{
    class TwoSum
    {
        public static void Find(int[] arr, int result)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if(!dic.ContainsKey(arr[i]))
                {
                    if (dic.ContainsKey(result - arr[i]))
                    {
                        Console.WriteLine("Found two sum at index[{0}, {1}]", i, dic[result - arr[i]]);
                        return;
                    }
                }

                dic[arr[i]] = i;
            }
        }        
    }
}

