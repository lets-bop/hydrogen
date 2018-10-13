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
                    if (i == 0){
                        rowSum += matrix[i,j];
                        this.sumMatrix[i,j] = rowSum;
                    }
                    else{
                        rowSum += matrix[i,j];
                        sumMatrix[i,j] = rowSum + sumMatrix[i-1, j];
                    }
                }
            }
        }

        private void UpdateSumMatrix(int row)
        {
            for (int i = row; i <= row + 1; i++){
                if (i >= this.rows) continue;
                int rowSum = 0;
                for (int j = 0; j < this.cols; j++){
                    if (i == 0){
                        rowSum += matrix[i,j];
                        this.sumMatrix[i,j] = rowSum;
                    }
                    else{
                        rowSum += matrix[i,j];
                        sumMatrix[i,j] = rowSum + sumMatrix[i-1, j];
                    }
                }                
            }
        }

        public void Update(int row, int col, int val) {
            this.matrix[row, col] = val;
        }

        public void Print(){
            for (int i = 0; i < this.rows; i++){
                for(int j = 0; j < this.cols; j++) 
                    Console.Write(this.sumMatrix[i,j] + "\t");
                Console.WriteLine();                
            }
        }

        // public int SumRegion(int row1, int col1, int row2, int col2) {
            
        // }        
    }
}