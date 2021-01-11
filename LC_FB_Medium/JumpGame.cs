using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given an array of non-negative integers nums, you are initially positioned at the first index of the array.
        Each element in the array represents your maximum jump length at that position.
        Determine if you are able to reach the last index.

        

        Example 1:
            Input: nums = [2,3,1,1,4], Output: true
            Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
        Example 2:
            Input: nums = [3,2,1,0,4]
            Output: false
            Explanation: You will always arrive at index 3 no matter what. 
            Its maximum jump length is 0, which makes it impossible to reach the last index.
        

        Constraints:

        1 <= nums.length <= 3 * 104
        0 <= nums[i] <= 105
    */
    class JumpGame
    {
    public bool CanJump(int[] nums) {
        if (nums.Length == 1 && nums[0] >= 0) return true; // special case
        return this.CanJump(nums, 0, new Dictionary<int, bool>());
    }
    
        public bool CanJump(int[] nums, int i, Dictionary<int, bool> memo) {
            if (i >= nums.Length) return false;
            
            for (int k = nums[i]; k > 0; k--) {
                if (i + k == nums.Length - 1) {
                    memo.Add(i, true);
                    return true;
                }
                
                if (memo.ContainsKey(i + k)) {
                    if (memo[i + k]) {
                        memo.Add(i, true);
                        return true;
                    } else return false;
                } else if (this.CanJump(nums, i + k, memo)) {
                    memo.Add(i, true);
                    return true;
                }
            }
            
            memo.Add(i, false);
            return false;
        }
    }
}