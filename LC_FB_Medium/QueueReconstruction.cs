﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
     * Suppose you have a random list of people standing in a queue. Each person is described by a pair of integers (h, k), 
     * where h is the height of the person and k is the number of people in front of this person who have a height greater than or equal to h. 
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

            /* 
            Let's start from the simplest case, when all guys (h, k) in the queue are of the same height h, and differ by their k values only, then 
            the solution is simple: each guy's index is equal to his k value. 
            The guy with zero people in front takes the place number 0, the guy with 1 person in front takes the place number 1, and so on and so forth.
            This strategy could be used even in the case when not all people are of the same height. 
            The smaller persons are "invisible" for the taller ones, and hence one could first arrange the tallest guys as if there was no one else.
            Let's now consider a queue with people of two different heights: 7 and 6. For simplicity, let's have just one 6-height guy. 
            First follow the strategy above and arrange guys of height 7. Now it's time to find a place for the guy of height 6. 
            Since he is "invisible" for the 7-height guys, he could take whatever place without disturbing 7-height guys order. 
            However, for him the others are visible, and hence he should take the position equal to his k-value, in order to have his proper place.
            The following strategy could be continued recursively:
                Sort the tallest guys in the ascending order by k-values and then insert them one by one into output queue at the indexes equal to their k-values.
                Take the next height in the descending order. Sort the guys of that height in the ascending order by k-values and then insert them one by one into output queue at the indexes equal to their k-values.
                And so on and so forth.
            
            The worst case of the algorithm is O(n^2).
             */
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
