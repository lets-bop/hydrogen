using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given an integer array of size n, find all elements that appear more than ⌊ n/3 ⌋ times.
        Note: The algorithm should run in linear time and in O(1) space.

        Example 1:
        Input: [3,2,3]
        Output: [3]

        Example 2:
        Input: [1,1,1,3,3,2,2,2]
        Output: [1,2]
    */
    class MajorityElement2
    {
        public IList<int> Find(int[] nums)
        {
            if (nums == null || nums.Length < 2) return nums;

            IList<int> result = new List<int>();

            int n1 = nums[0], n2 = 0, c1 = 1, c2 = 0;
            bool n2Assigned = false;
            for (int i = 1; i < nums.Length; i++) {
                if (n1 == nums[i]) c1++;
                else if (!n2Assigned || n2 == nums[i]) {
                    n2Assigned = true;
                    n2 = nums[i];
                    c2++;
                } else if (c1 == 0) {
                    c1++;
                    n1 = nums[i];
                } else if (c2 == 0) {
                    c2++;
                    n2 = nums[i];
                }
                else {
                    c1--;
                    c2--;
                }
            }

            c1 = c2 = 0;
            foreach (int n in nums) {
                if (n == n1) c1++;
                else if (n2Assigned && n == n2) c2++;
            }

            if (c1 > nums.Length / 3) result.Add(n1);
            if (c2 > nums.Length / 3) result.Add(n2);
            return result;
        }
    }
}