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
    /*
        Given an array of integers, return indices of the two numbers such that they add up to a specific target.
        You may assume that each input would have exactly one solution, and you may not use the same element twice.

        Example:
        Given nums = [2, 7, 11, 15], target = 9,
        Because nums[0] + nums[1] = 2 + 7 = 9,
        return [0, 1].    
     */
    class TwoSum
    {
        public static int[] Find(int[] nums, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int numToSearch;
            for (int i = 0; i < nums.Length; i++)
            {
                numToSearch = target - nums[i];
                if (dic.ContainsKey(numToSearch))
                {
                    return new int[] {i, dic[numToSearch]};
                }
                
                dic[nums[i]] = i;
            }

            return new int[] {};
        }        
    }
}

