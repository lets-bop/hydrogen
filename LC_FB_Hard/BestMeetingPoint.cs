using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    /*
        A group of two or more people wants to meet and minimize the total travel distance. 
        You are given a 2D grid of values 0 or 1, where each 1 marks the home of someone in the group. 
        The distance is calculated using Manhattan Distance, where distance(p1, p2) = |p2.x - p1.x| + |p2.y - p1.y|.

        Example:
        Input: 
        1 - 0 - 0 - 0 - 1
        |   |   |   |   |
        0 - 0 - 0 - 0 - 0
        |   |   |   |   |
        0 - 0 - 1 - 0 - 0

        Output: 6 
        Explanation: Given three people living at (0,0), (0,4), and (2,2):
                    The point (0,2) is an ideal meeting point, as the total travel distance 
                    of 2+2+2=6 is minimal. So return 6.
    */
    class BestMeetingPoint
    {
        /*
            The best meeting point is the median of the x and y coordinates of all the points.
            Hence we'll collect the x and y coordinates of the all the points in 2 separate lists
            and then determine the median point.

            Since manhattan distance (total) = |TotalX| + |TotalY|
            where TotalX += |point.X - median.X| and TotalY += |point.Y - median.Y| for each point
        */
        public int MinTotalDistance(int[][] grid) {
            int m = grid.Length;
            int n = grid[0].Length;
        
            List<int> cols = new List<int>();
            List<int> rows = new List<int>();

            // record the row and col for each 1 in the grid
            for(int i = 0; i < m; i++){
                for(int j = 0; j < n; j++){
                    if(grid[i][j]==1){
                        cols.Add(j);
                        rows.Add(i);
                    }
                }
            }
        
            int sum=0;
        
            foreach(int i in rows){
                // for each 1 in the row, calculate how far it is from the median
                sum += Math.Abs(i - rows[rows.Count/2]);
            }
        
            cols.Sort();
        
            foreach (int i in cols){
                // for each 1 in the col, calculate how far it is from the median
                // we only need to sort the cols, as we are scanning the matrix by the row
                // and 1 can appear in any col and hence not ordered. 
                // So we need to find the median by ordering the cols across all rows
                sum += Math.Abs(i - cols[cols.Count/2]);
            }
        
            return sum;
        }
    }
}