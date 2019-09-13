/*
Given n non-negative integers representing an elevation map where the width of each bar is 1, 
compute how much water it is able to trap after raining.

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

            while (left < right)
            {
                if (heights[left] < heights[right]) {
                    // means we can definitely trap water between left and right upto a max height restrained by left
                    if (heights[left] > leftWall) leftWall = heights[left];
                    else result += (leftWall - heights[left]);
                    left++;
                }
                else{
                    // means we can definitely trap water between left and right upto a max height restrained by right
                    if (heights[right] > rightWall) rightWall = heights[right];
                    else result += (rightWall - heights[right]);
                    right--;
                }
            }

            return result;
        }
    }
}