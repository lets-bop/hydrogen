using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    class RotateArray
    {
        public void Rotate(int[] nums, int k) {
            // There are multiple ways of doing this. The below does it in place with O(n) time.
            if (nums == null || nums.Length < 2 || k == 0) return;
            k = k % nums.Length; // in case k is bigger than length of the input
            
            int count = 0;
            for (int i = 0; count < nums.Length; i++) {
                int current = i;
                int prev = nums[current];
                
                do {
                    int next = (current + k) % nums.Length;
                    int temp = nums[next];
                    nums[next] = prev;
                    current = next;
                    prev = temp;
                    count++;
                } while (current != i);
            }
        }
    }
}