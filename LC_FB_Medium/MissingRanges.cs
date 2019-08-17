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
            if (nums == null || nums.Length == 0) {
                if (lower == upper) return new List<string>() {lower.ToString()};
                return new List<string>() {lower.ToString() + "->" + upper.ToString()};
            }

            int missingRangeStart = -1;
            int missingRangeEnd = -1;
            int i = lower;
            int numsIndex = 0;
            List<string> result = new List<string>();

            while (i <= upper && numsIndex < nums.Length) {
                if (numsIndex < nums.Length - 1 && nums[numsIndex] == nums[numsIndex + 1]) {
                    // handle duplicates in the input
                    numsIndex++;
                    continue;
                }

                if (nums[numsIndex] != i) {
                    if (missingRangeStart == -1) missingRangeStart = i;
                    missingRangeEnd = nums[numsIndex] - 1;
                    if (missingRangeStart == missingRangeEnd) result.Add(missingRangeEnd.ToString());
                    else result.Add(missingRangeStart.ToString() + "->" + missingRangeEnd.ToString());
                    missingRangeStart = missingRangeEnd = -1;
                }

                i = nums[numsIndex] + 1; // can cause integer overflow and will become negative
                numsIndex++;
            }

            if (i < nums[nums.Length - 1]) {
                // this ideally would not be the case. Will happen only when there is an overflow
                return result;
            }

            if (i <= upper) { // not using i as i might have overflown
                missingRangeStart = nums[nums.Length - 1] + 1;
                missingRangeEnd = upper;
                if (missingRangeStart == missingRangeEnd) result.Add(missingRangeEnd.ToString());
                else result.Add(missingRangeStart.ToString() + "->" + missingRangeEnd.ToString());
            }

            return result;
        }
    }
}