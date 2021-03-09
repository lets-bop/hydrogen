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
            int start = 0, end = 0;
            
            for (int i = 1; i < nums.Length; i++) {
                if (nums[i] - nums[end] > 1) {
                    if (start == end) result.Add(nums[start].ToString());
                    else result.Add(nums[start] + "->" + nums[end]);
                    start = i;
                }

                end = i;
            }

            if (start == end) result.Add(nums[start].ToString());
            else result.Add(nums[start] + "->" + nums[end]);
            return result;
        }
    }
}