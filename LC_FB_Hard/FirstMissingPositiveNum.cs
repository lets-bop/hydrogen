using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class FirstMissingPositiveNum
    {
        public int FirstMissingPositive(int[] nums) {
            if (nums == null || nums.Length == 0) return 1;

            // Note 0 is neither positive nor negative. Hence we will write 1 to index 0, 2 to index 1 etc.
            int i = 0;
            while(i < nums.Length){
                if (nums[i] <= 0) i++;
                else if (nums[i] < nums.Length && nums[i] != (i+1)){
                    if (nums[nums[i] - 1] == nums[i]) i++; // Duplicate entry, skip it.
                    else this.Swap(nums, i, nums[i] - 1);
                }
                else i++;
            }

            // Corner case.
            if (nums.Length == 1 && nums[0] == 1) return 2;            
            
            for(i = 0; i < nums.Length; i++){
                if (nums[i] != i+1){
                    return i+1;
                }
            }
            
            return nums.Length + 1;
        }

        private void Swap(int[] nums, int i, int j){
            int temp = nums[j];
            nums[j] = nums[i];
            nums[i] = temp;
        }
    }
}