using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
     * Suppose you have a random list of people standing in a queue. Each person is described by a pair of integers (h, k), where h is the height of the person and k is the number of people in front of this person who have a height greater than or equal to h. 
     * Write an algorithm to reconstruct the queue. 
     * Note: The number of people is less than 1,100.
     * Example
     * Input: [[7,0], [4,4], [7,1], [5,0], [6,1], [5,2]]
     * Output: [[5,0], [7,0], [5,2], [6,1], [4,4], [7,1]]
     * */
    class QueueReconstruction
    {
        // https://www.programcreek.com/2015/03/leetcode-queue-reconstruction-by-height-java/
        public int[][] ReconstructQueue(int[][] people)
        {
            var n = people.Length;

            var result = new List<int[]>();

            // Sort [[7,0], [4,4], [7,1], [5,0], [6,1], [5,2]]
            // To   [[7,0], [7,1], [6,1], [5,0], [5,2], [4,4]]
            Array.Sort(people, (a, b) => a[0] != b[0] ? b[0] - a[0] : a[1] - b[1]);

            foreach (var person in people)
            {
                result.Insert(person[1], person);
            }

            return result.ToArray();
        }
    }
}
