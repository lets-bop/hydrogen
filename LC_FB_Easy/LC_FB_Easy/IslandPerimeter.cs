using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_FB_Easy
{
    /*
     * You are given a map in form of a two-dimensional integer grid where 1 represents land and 0 represents water.
     * Grid cells are connected horizontally/vertically (not diagonally). The grid is completely surrounded by water, and there is exactly one island (i.e., one or more connected land cells).
     * The island doesn't have "lakes" (water inside that isn't connected to the water around the island). One cell is a square with side length 1. 
     * The grid is rectangular, width and height don't exceed 100. Determine the perimeter of the island.
     * Input:
        [[0,1,0,0],
         [1,1,1,0],
         [0,1,0,0],
         [1,1,0,0]]

        Output: 16
     * */
    class IslandPerimeter
    {
        public int CalculateIslandPerimeter(int[][] grid)
        {
            int perimeter = 0;
            int rows = grid.Length;     // rows
            int cols = grid[0].Length;  // cols

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    perimeter += this.GetPerimeterOfCell(grid, r, c, rows, cols);
                }
            }

            return perimeter;
        }

        private int GetPerimeterOfCell(int[][] grid, int cellRow, int cellCol, int rows, int cols)
        {
            int perimeter = 0;
            if (cellRow < 0 || cellCol < 0 || cellRow > rows - 1 || cellCol > cols - 1) return 0;

            if (grid[cellRow][cellCol] == 1)
            {
                // Check cell above
                if (cellRow == 0 || grid[cellRow - 1][cellCol] == 0) ++perimeter;
                // Check cell below
                if (cellRow == rows - 1 || grid[cellRow + 1][cellCol] == 0) ++perimeter;
                // Check cell to left
                if (cellCol == 0 || grid[cellRow][cellCol - 1] == 0) ++perimeter;
                // Check cell to right
                if (cellCol == cols - 1 || grid[cellRow][cellCol + 1] == 0) ++perimeter;
            }

            return perimeter;
        }
    }
}
