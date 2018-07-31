/*
Given a randomly ordered array containing balls of 3 colors, Red (0), Green(1) and Blue(2).
Order the items as groups of Red Green Blue.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class DutchFlag
    {
        public static void Sort(List<int> balls)
        {
            if (balls == null || balls.Count == 0) return;
            int startOfGreen = -1;
            int startOfUnread = 0;
            int endOfUnread = balls.Count;

            while (startOfUnread < endOfUnread)
            {
                if (balls[startOfUnread] == 0) // Red
                {
                    if (startOfGreen != -1)
                    {
                        int temp = balls[startOfGreen];
                        balls[startOfGreen] = balls[startOfUnread];
                        balls[startOfUnread] = temp;
                        startOfGreen = startOfGreen + 1;
                    }

                    startOfUnread++;
                }
                else if (balls[startOfUnread] == 1) // green
                {
                    if (startOfGreen == -1) startOfGreen = startOfUnread;
                    startOfUnread++;
                }
                else if (balls[startOfUnread] == 2) // blue
                {
                    endOfUnread--;
                    int temp = balls[endOfUnread];
                    balls[endOfUnread] = balls[startOfUnread];
                    balls[startOfUnread] = temp;
                }
                else throw new Exception("Unexpected entry");
            }
        }
    } 
}