using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    class AboveAverageSubarrays
    {
        internal class Subarray : IComparable
        {
            int start;
            int end;
            internal Subarray(int start, int end) {
                this.start = start;
                this.end = end;
            }

            public int CompareTo(object obj) {
                Subarray other = (Subarray) obj;
                if (other.start != this.start) return this.start - other.start;
                return this.end - other.end;
            }
        }

        public Subarray[] Calculate(int[] A) {
            List<Subarray> output = new List<Subarray>();
            
            double avgSum = 0;
            double avgSumR = 0;

            int totalSum = 0;
            for (int k = 0; k < A.Length; k++) totalSum += A[k];

            for (int i = 0; i < A.Length; i++) {
                int sum = 0;
                for (int j = i; j < A.Length; j++) {
                    sum += A[j];
                    avgSum = (double) sum / (j - i + 1);
                    avgSumR = (double) (totalSum - sum) / Math.Max(1, (A.Length - (j - i + 1)));
                    if (avgSum > avgSumR) {
                        output.Add(new Subarray(i+1, j+1));
                    }
                }
            }

            output.Sort();
            return output.ToArray();
        }
    }
}