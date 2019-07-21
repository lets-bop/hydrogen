using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class QueueReconstruction
    {

        public int[][] ReconstructQueue(int[][] people)
        {
            var n = people.Length;

            var result = new List<int[]>();

            // Sort [[7,0], [4,4], [7,1], [5,0], [6,1], [5,2]]
            // To   [[7,0], [7,1], [6,1], [5,0], [5,2], [4,4]]
            Array.Sort(people, (a, b) => a[0] != b[0] ? b[0] - a[0] : a[1] - b[1]);

            foreach (var person in people)
            {
                var height = person[0];
                var index = person[1];

                result.Insert(index, person);
            }

            return result.ToArray();
        }
    }
}
