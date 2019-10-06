using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
        Given an array nums of n integers where n > 1,  return an array output such 
        that output[i] is equal to the product of all the elements of nums except nums[i].

        Example:
        Input:  [1,2,3,4]
        Output: [24,12,8,6]
        Note: Please solve it without division and in O(n).

        Follow up:
        Could you solve it with constant space complexity? 
        (The output array does not count as extra space for the purpose of space complexity analysis.)    
    */
    class ProductExceptSelf
    {
        public int[] Calculate(int[] nums) {
            
            int[] result = new int[nums.Length];
            result[result.Length - 1] = 1;

            for (int i = nums.Length - 2; i >= 0; i--) {
                result[i] = result[i + 1] * nums[i + 1]; // i.e. value at i = product of elements to its right
            }

            int left = 1;
            for (int i = 0; i < nums.Length; i++) {
                result[i] *= left; 
                left *= nums[i];
            }

            return result;

            // this.GetRightProduct(nums, 0, 1);
            // return nums;
        }

        // Solves it with no extra space and O(n) time.
        public int GetRightProduct(int[] nums, int i, int leftProduct) {
            if (i >= nums.Length) return 1;
            int temp = nums[i];
            int rightProduct = GetRightProduct(nums, i + 1, leftProduct * nums[i]);
            nums[i] = leftProduct * rightProduct;
            return rightProduct * temp;
        }

        public int[] Product(int[] nums) {
            int[] result = new int[nums.Length];
            result[result.Length - 1] = 1;

            for (int i = nums.Length - 2; i >= 0; i--) {
                result[i] = result[i + 1] * nums[i + 1]; // i.e. value at i = product of elements to its right
            }

            int left = 1;
            for (int i = 0; i < nums.Length; i++) {
                result[i] *= left; 
                left *= nums[i];
            }

            return result;
        }
    }
}