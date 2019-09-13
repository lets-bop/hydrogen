using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
        Given a sorted integer array without duplicates, return the summary of its ranges.

        Example 1:
        Input:  [0,1,2,4,5,7]
        Output: ["0->2","4->5","7"]
        Explanation: 0,1,2 form a continuous range; 4,5 form a continuous range.

        Example 2:
        Input:  [0,2,3,4,6,8,9]
        Output: ["0","2->4","6","8->9"]
        Explanation: 2,3,4 form a continuous range; 8,9 form a continuous range.
    */    
    class SummaryRanges
    {
        public IList<string> FindSummaryRanges(int[] nums) 
        {
            IList<string> result = new List<string>();
            int i = 0;
            int j = 1;

            while (j < nums.Length) {
                if (nums[j] != nums[j - 1] + 1) {
                    if (j - i > 1) result.Add(nums[i].ToString() + "->" + nums[j - 1].ToString());
                    else result.Add(nums[i].ToString());
                    i = j;
                }
                j++;
            }

            if (j - i > 1) result.Add(nums[i].ToString() + "->" + nums[j - 1].ToString());
            else result.Add(nums[i].ToString());

            return result;
        }
    }
}