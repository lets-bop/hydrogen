/*
    Given n non-negative integers representing an elevation map where the width of each bar is 1, 
    compute how much water it is able to trap after raining.

    Example 1:
        Input: height = [0,1,0,2,1,0,1,3,2,1,2,1], Output: 6
        Explanation: The above elevation map (black section) is represented by array 
        [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped.

    Example 2:
        Input: height = [4,2,0,3,2,5], Output: 9

    Constraints:
        n == height.length
        0 <= n <= 3 * 104
        0 <= height[i] <= 105

*/
using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class TrappingRainWater
    {
        public int Trap(int[] heights)
        {
            int result = 0;

            int left = 0;
            int right = heights.Length - 1;
            int leftWall = 0;
            int rightWall = 0;

            while (left < right) {
                if (heights[left] < heights[right]) {
                    leftWall = Math.Max(leftWall, heights[left]);
                    result += (leftWall - heights[left]);
                    left++;
                } else {
                    rightWall = Math.Max(rightWall, heights[right]);
                    result += (rightWall - heights[right]);
                    right--;
                }
            }

            return result;
        }
    }
}