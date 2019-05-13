using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class RangeSumQuery
    {
        int[,] matrix;

        int[,] sumMatrix;

        int rows;
        int cols;

        public RangeSumQuery(int[,] matrix) {
            this.matrix = matrix;
            this.rows = matrix.GetLength(0);
            this.cols = matrix.GetLength(1);
            this.sumMatrix = new int[rows, cols];
            Array.Copy(this.matrix, this.sumMatrix, rows * cols);
            this.CalculateSumMatrix();
        }

        private void CalculateSumMatrix()
        {
            for (int i = 0; i < this.rows; i++){
                int rowSum = 0;
                for (int j = 0; j < this.cols; j++){
                    rowSum += matrix[i,j];
                    if (i == 0) this.sumMatrix[i,j] = rowSum;
                    else sumMatrix[i,j] = rowSum + sumMatrix[i-1, j];
                }
            }
        }

        private void UpdateSumMatrix(int row)
        {
            for (int i = row; i < this.rows; i++){
                int rowSum = 0;
                for (int j = 0; j < this.cols; j++){
                    rowSum += matrix[i,j];
                    if (i == 0) this.sumMatrix[i,j] = rowSum;
                    else sumMatrix[i,j] = rowSum + sumMatrix[i-1, j];
                }                
            }
        }

        public void Update(int row, int col, int val) {
                this.matrix[row, col] = val;
                this.UpdateSumMatrix(row);        
        }

        public void Print(){
            Console.WriteLine("Matrix is ");  
            for (int i = 0; i < this.rows; i++){
                for(int j = 0; j < this.cols; j++) 
                    Console.Write(this.matrix[i,j] + "\t");
                Console.WriteLine();                
            }
            Console.WriteLine("Sum is ");  
            for (int i = 0; i < this.rows; i++){
                for(int j = 0; j < this.cols; j++) 
                    Console.Write(this.sumMatrix[i,j] + "\t");
                Console.WriteLine();                
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2) {
                // row1, col1 = upper left. row2, col2 = lower right
                if (row1 == 0 && col1 == 0) return this.sumMatrix[row2, col2];
                if(row1 == 0) return this.sumMatrix[row2, col2] - this.sumMatrix[row2, col1-1];
                if (col1 == 0)
                    return this.sumMatrix[row2, col2] - this.sumMatrix[row1 - 1, col2];
                return 
                    this.sumMatrix[row2, col2] 
                    - this.sumMatrix[row1 - 1, col2] 
                    - this.sumMatrix[row2, col1 - 1] 
                    + this.sumMatrix[row1-1,col1-1];        
        }
    }
}