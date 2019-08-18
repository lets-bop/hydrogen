using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
        Given an array nums of n integers where n > 1,  return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].

        Example:

        Input:  [1,2,3,4]
        Output: [24,12,8,6]
        Note: Please solve it without division and in O(n).

        Follow up:
        Could you solve it with constant space complexity? (The output array does not count as extra space for the purpose of space complexity analysis.)    
    */
    class ProductExceptSelf
    {
        public int[] Calculate(int[] nums) {
            this.GetRightProduct(nums, 0, 1);
            return nums;
        }

        // Solves it with no extra space and O(n) time.
        public int GetRightProduct(int[] nums, int i, int leftProduct) {
            if (i >= nums.Length) return 1;
            int temp = nums[i];
            int rightProduct = GetRightProduct(nums, i + 1, leftProduct * nums[i]);
            nums[i] = leftProduct * rightProduct;
            return rightProduct * temp;
        }
    }
}