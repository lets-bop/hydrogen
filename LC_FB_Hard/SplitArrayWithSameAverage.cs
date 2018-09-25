/*
In a given integer array A, we must move every element of A to either list B or list C. (B and C initially start empty.)

Return true if and only if after such a move, it is possible that the average value of B is equal to the average value of C, 
and B and C are both non-empty.

Example :
Input: 
[1,2,3,4,5,6,7,8]
Output: true
Explanation: We can split the array into [1,4,5,8] and [2,3,6,7], and both of them have the average of 4.5.

Example: 
Input: 
[2, 4, 5, 7, 10, 14]
Output: true
[7] and [2, 4, 5, 10, 14] or [4, 10] and [2, 5, 7, 14]

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class SplitArrayWithSameAverage
    {
        public bool SplitArraySameAverage(int[] A) {
            int sum = 0;

            foreach (int a in A){
                sum += a;
            }

            if (Prune(A, sum)){
                // The first row represents all the sums possible with 0 elements
                // The second row represents all the sums possible with 1 element
                // The third row represents all the sums possible with 2 elements and so on.
                // For an input A[] = {2,4,5,7,10,14}, the subset sum will look like
                // 0
                // 2       4       5       7       10      14
                // 6       7       9       11      12      14      15      17      16      18      19      21      24
                // 11      13      14      16      17      19      21      22      20      23      25      26      28      29      31                                                
                List<HashSet<int>> subSetSum = new List<HashSet<int>>();

                // Prepoulate first row
                HashSet<int> set = new HashSet<int>();
                set.Add(0);
                subSetSum.Add(set);

                // The smaller of the 2 subsets will have at most n/2 elements.
                // Hence we will only find the subset with at most n/2 elements (instead of n).
                for(int i = 0; i < A.Length; i++){
                    for (int j = Math.Min(i+1, A.Length / 2); j > 0; j--){
                        if (j >= subSetSum.Count) subSetSum.Add(new HashSet<int>());
                        foreach (int element in subSetSum[j - 1]){
                            if (subSetSum[j] == null) subSetSum[j] = new HashSet<int>();
                            subSetSum[j].Add(element + A[i]);
                        }
                    }
                }

                for(int i = 1; i < subSetSum.Count; i++){
                    if ((sum * i) % A.Length == 0 && subSetSum[i].Contains((sum * i) / A.Length)) return true;
                    // foreach (int e in subSetSum[i]) Console.Write(e + "\t");
                    // Console.WriteLine();
                }
            }
            
            return false;            
        }

        private bool Prune(int[] a, int sum)
        {
            for (int i = 1; i < a.Length; i++){
                if (i * sum % a.Length == 0) return true;
            }

            return false;
        }        
    }
}