using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    class BestMeetingPoint
    {
    public int MinTotalDistance(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
    
        List<int> cols = new List<int>();
        List<int> rows = new List<int>();
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
            // and 1 can appear only any col. So we need to find the median by ordering the cols
            // across all rows
            sum += Math.Abs(i - cols[cols.Count/2]);
        }
    
        return sum;
    }
    }
}