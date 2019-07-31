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

            if (nums == null || nums.Length < 1) return result;
            if (nums.Length == 1) {
                result.Add(nums[0].ToString());
                return result;
            }

            int startIndexOfRange = -1; // -1 indicates no range has started yet.

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1] + 1) {
                    // This is a range - either its a continuation of a range or the start of a range.
                    if (startIndexOfRange == -1)
                    {
                        // Start of a range
                        startIndexOfRange = i - 1;
                    }
                }
                else {
                    // Either the range just ended or there was no range and hence this number will be added as is
                    if (startIndexOfRange != -1) {
                        // the range just ended
                        result.Add(nums[startIndexOfRange].ToString() + "->" + nums[i-1].ToString());
                        startIndexOfRange = -1;
                    }
                    else {
                        result.Add(nums[i - 1].ToString());
                    }
                }
            }

            // We've handled all but the last element.
            if (startIndexOfRange == -1) {
                result.Add(nums[nums.Length - 1].ToString());
            } 
            else {
                // the range ends with the last element
                result.Add(nums[startIndexOfRange].ToString() + "->" + nums[nums.Length - 1].ToString());
            }

            return result;
        }
    }
}