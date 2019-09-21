using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    class MaxSumOfRectangleNoLargerThanK
    {
        // Since C# doesn't have a good implementation of 
        // TreeSet.ceiling operation, here's the java equivalent.
        /*
            public int maxSumSubmatrix(int[][] matrix, int k) {
                if(matrix==null||matrix.length==0||matrix[0].length==0)
                    return 0;

                int rows=matrix.length;
                int cols=matrix[0].length;

                int result = Integer.MIN_VALUE;

                for(int c1=0; c1<cols; c1++){
                    int[] each = new int[rows];
                    for(int c2=c1; c2>=0; c2--){

                        for(int r=0; r<rows; r++){
                            each[r]+=matrix[r][c2];   
                        }

                        result = Math.max(result, getLargestSumCloseToK(each, k));
                    }
                }

                return result;
            }

            public int getLargestSumCloseToK(int[] arr, int k) {
                // this part is exactly the same as finding the subarray sum <= k 
                int sum=0;
                TreeSet<Integer> set = new TreeSet<Integer>();
                int result=Integer.MIN_VALUE;
                set.add(0);

                for(int i=0; i<arr.length; i++){
                    sum=sum+arr[i];

                    Integer ceiling = set.ceiling(sum-k);
                    if(ceiling!=null){
                        result = Math.max(result, sum-ceiling);        
                    }

                    set.add(sum);
                }

                return result;
            }
        */
    }
}