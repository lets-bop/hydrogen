using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class LongestIncreasingSubsequence
    {
        public int LIS(int[] nums)
        {
            // return LISNaive(nums);

            return LISWithBinSearch(nums);
        }

        private int LISNaive(int[] nums)
        {
            if (nums == null || nums.Length < 1) return 0;

            int[] lis = new int[nums.Length];
            int maxLength = 1;

            // O(n^2) time and O(n) extra space
            for(int i = 0; i < nums.Length; i++){
                lis[i] = 1;
                for (int j = 0; j < i; j++){
                    if (nums[i] > nums[j]){
                        lis[i] = Math.Max(lis[i], lis[j] + 1);
                    }
                }

                maxLength = Math.Max(maxLength, lis[i]);
            }

            return maxLength;
        }

        private int LISWithBinSearch(int[] nums)
        {
            if (nums == null || nums.Length < 1) return 0;

            List<int> lis = new List<int>();
            for(int i = 0; i < nums.Length; i++){
                if(lis.Count == 0 || lis[lis.Count - 1] < nums[i]) lis.Add(nums[i]);
                else{
                    // binary search and remove the smallest num larger than nums[i]
                    int low = 0, high = lis.Count - 1, mid = 0;
                    while(low < high){
                        mid = low + (high - low)/2;

                        if(lis[mid] < nums[i]) low = mid + 1;                        
                        else high = mid;
                    }

                    lis[high] = nums[i];
                }
            }

            return lis.Count;
        }
    }
}