using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given an array of citations (each citation is a non-negative integer) of a researcher, 
        write a function to compute the researcher's h-index.

        According to the definition of h-index on Wikipedia: 
        "A scientist has index h if h of his/her N papers have at least h citations each, 
        and the other N − h papers have no more than h citations each."

        Example:
        Input: citations = [3,0,6,1,5]
        Output: 3 
        Explanation: [3,0,6,1,5] means the researcher has 5 papers in total and each of them had 
                    received 3, 0, 6, 1, 5 citations respectively. 
                    Since the researcher has 3 papers with at least 3 citations each and the remaining 
                    two with no more than 3 citations each, her h-index is 3.
        Note: If there are several possible values for h, the maximum one is taken as the h-index.
    */
    class HIndex
    {
        public int Find(int[] citations) {
            return this.FindNaive(citations);
            // return this.FindWithBinSearch(citations);
        }

        public int FindWithBinSearch(int[] citations) {
            // Todo: doesn't fully work. 
            if (citations == null || citations.Length == 0) return 0;
            Array.Sort(citations);
            int result = -1;

            int i = 0;
            int j = citations.Length - 1;
            int mid;
            while (i < j) {
                mid = i + (j - i) / 2;
                if (citations.Length - mid >= citations[mid]) {
                    result = citations[mid];
                    i = mid + 1;
                }
                else j = mid;
            }

            if (result != -1) return result;
            if (j == 0 && citations[j] == 0) return 0; 
            return citations.Length - j;
        }

        public int FindNaive(int[] citations) { // O(n)
            Array.Sort(citations);
            int result = 0;
            for(int i = citations.Length - 1; i >= 0; i--) {
                int count = citations.Length - i; // count of citations that have at least citations[i] citations
                if (citations[i] >= count) result = count; // we need to find the maximum count, keep looking
                else return result;
            }

            return result;
        }
    }
}