using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
        Given a sorted integer array nums, where the range of elements are in the inclusive range [lower, upper], return its missing ranges.
        Example:
        Input: nums = [0, 1, 3, 50, 75], lower = 0 and upper = 99,
        Output: ["2", "4->49", "51->74", "76->99"]
    */
    class MissingRanges
    {
        public IList<string> FindMissingRanges(int[] nums, int lower, int upper)
        {
            IList<string> result = new List<string>();
            int rangeStart, rangeEnd;
            if (nums == null || nums.Length == 0) {
                rangeStart = lower;
                rangeEnd = upper;                
                if (rangeStart != rangeEnd) result.Add(lower.ToString() + "->" + upper.ToString());
                else result.Add(lower.ToString());
                return result;
            }

            int i = 0;
            if (nums[i] > lower) {
                rangeStart = lower;
                rangeEnd = nums[i] - 1;
                if (rangeStart != rangeEnd) result.Add(lower.ToString() + "->" + (nums[i] - 1).ToString());
                else result.Add(lower.ToString());
            }

            while (++i < nums.Length) {
                if (nums[i] != nums[i - 1] && nums[i] != nums[i - 1] + 1) {
                    rangeStart = nums[i - 1] + 1;
                    rangeEnd = nums[i] - 1;
                    if (rangeStart != rangeEnd) result.Add((nums[i - 1] + 1).ToString() + "->" + (nums[i] - 1).ToString());
                    else result.Add((nums[i - 1] + 1).ToString());
                }
            }

            
            if (nums[i - 1] != upper) {
                rangeStart = nums[i - 1] + 1;
                rangeEnd = upper;
                if (rangeStart != rangeEnd) result.Add((nums[i - 1] + 1).ToString() + "->" + upper.ToString());
                else result.Add(upper.ToString());
            }

            return result;
        }
    }
}