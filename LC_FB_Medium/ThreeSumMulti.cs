using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given an integer array A, and an integer target, return the number of tuples i, j, k  such that i < j < k 
        and A[i] + A[j] + A[k] == target. 
        As the answer can be very large, return it modulo 10^9 + 7.

        Example 1:
        Input: A = [1,1,2,2,3,3,4,4,5,5], target = 8
        Output: 20
        Explanation: Enumerating by the values (A[i], A[j], A[k]):
        (1, 2, 5) occurs 8 times;
        (1, 3, 4) occurs 8 times;
        (2, 2, 4) occurs 2 times;
        (2, 3, 3) occurs 2 times.

        Example 2:
        Input: A = [1,1,2,2,2,2], target = 5
        Output: 12
        Explanation: A[i] = 1, A[j] = A[k] = 2 occurs 12 times: We choose one 1 from [1,1] in 2 ways,
        and two 2s from [2,2,2,2] in 6 ways.
    */
    class ThreeSumMulti
    {
        public int Calculate(int[] A, int target) {
            if (A == null || A.Length < 3) return 0;
            Array.Sort(A);
            int sum;
            int result = 0;

            for (int i = 0; i < A.Length - 2; i++) {
                int left = i + 1;
                int right = A.Length - 1;

                while (left < right) {
                    sum = A[i] + A[left] + A[right];
                    if (sum == target) {
                        if (A[left] != A[right]) {
                            // count the number of numbers equal to left and right
                            int cLeft = 1;      // keeps count of the duplicates of A[left]
                            int cRight = 1;     // keeps count of the duplicates of A[right]
                            while (left + 1 < A.Length && left < right && A[left + 1] == A[left]) {
                                cLeft++;
                                left++;
                            }
                            while (right - 1 >= 0 && right - 1 > left && A[right - 1] == A[right]) {
                                cRight++;
                                right--;
                            }

                            result += (cLeft * cRight);

                            left++;
                            right--;
                        } else {
                            // M = right - left + 1, and there will be M * (M-1) / 2 pairs.
                            int M = right - left + 1;
                            result += ((M * (M-1)) / 2);
                            break;
                        }
                    } else if (sum < target) left++;
                    else right--;
                }
            }

            return result;
        }
    }
}