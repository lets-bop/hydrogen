using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Imagine a length-N array of booleans, initially all false. Over time, some values are set to true, 
        and at various points in time you would like to find the location of the nearest true to the right of given indices.
        You will receive Q queries, each of which has a type and a value. SET queries have type = 1 and GET queries have type = 2.
        When you receive a SET query, the value of the query denotes an index in the array that is set to true. 
        Note that these indices start at 1. When you receive a GET query, you must return the smallest index that 
        contains a true value that is greater than or equal to the given index, or -1 if no such index exists.
        Input: A list of Q queries, formatted as [type, index] where type is either 1 or 2, and index is < N
        1 <= N <= 1,000,000,000
        1 <= Q <= 500,000
        Output: Return an array containing the results of all GET queries. 
        The result of queries[i] is the smallest index that contains a true value that is 
        greater than or equal to i, or -1 if no index satisfies those conditions.

        Example: 
        N = 5, Q = 5
        queries = [[2, 3], [1, 2], [2, 1], [2, 3], [2, 2]]
        output = [-1, 2, -1, 2]
        The initial state of the array is [false, false, false, false, false].
        The first query is GET 3, but no values in the array are true, so the answer is -1.
        The second query is SET 2, so the value at index 2 is set to true.
        The new state of the array is [false, true, false, false, false].
        The third query is GET 1, and the index of the true value nearest to 1 (to the right) is 2.
        The fourth query is GET 3, but no values to the right of index 3 are true.
        The fifth query is GET 2, and the value at index 2 is true.
    */
    class AnswerQuery
    {
        public int[] Answer(int[][] queries) {
            List<int> values = new List<int>();
            List<int> output = new List<int>();
            bool isSet = false;
            for(int i = 0; i < queries.Length; i++) {
                if (queries[i][0] == 1) {
                    // set query
                    values.Add(queries[i][1]);
                    isSet = true;
                } else {
                    // If 's' is the total # of set operations, worst case is s log s
                    if (isSet) values.Sort();
                    isSet = false;
                    int index = this.Search(values, queries[i][1]);
                    output.Add(index);
                }
            }

            return output.ToArray();
        }

        private int Search(List<int> values, int numToSearch) {
            int low = 0;
            int high = values.Count - 1;
            int mid;

            int index = -1;
            while (low <= high) {
                mid = low + (high - low) / 2;
                if (values[mid] == numToSearch) return numToSearch;
                if (values[mid] < numToSearch) low = mid + 1;
                else {
                    high = mid - 1;
                    index = values[mid];
                }
            }

            return index;
        }
    }
}