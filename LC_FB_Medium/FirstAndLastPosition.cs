using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class FirstAndLastPosition
    {
        public int[] SearchRange(int[] nums, int target) {
            int[] result = new int[] {-1,-1};
            if (nums == null || nums.Length == 0) return result;
            
            // Find left most
            int low = 0, high = nums.Length - 1, mid = 0;
            while(low <= high){
                mid = low + (high - low) / 2;
                if (nums[mid] == target){
                    result[0] = mid;
                    high = mid - 1;
                }
                else if (nums[mid] < target) low = mid + 1;
                else high = mid - 1;
            }
            
            // Find right most
            low = 0; high = nums.Length - 1; mid = 0;
            while(low <= high){
                mid = low + (high - low) / 2;
                if (nums[mid] == target){
                    result[1] = mid;
                    low = mid + 1;
                }
                else if (nums[mid] < target) low = mid + 1;
                else high = mid - 1;
            }
            
            return result;
        }        
    }
}