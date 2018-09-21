/*

Given a sorted stone array containing the positions at which there are stones in a river. 
We need to determine whether it is possible or not for a frog to cross the river by 
stepping over these stones, provided that the frog starts at position 0, 
and at every step the frog can make a jump of size k-1, k or k+1 if the previous jump 
is of size k.

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class FrogJump
    {
        public bool CanCross(int[] stones)
        {
            Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < stones.Length; i++) {
                map.Add(stones[i], new HashSet<int>());
            }

            map[0].Add(0);
            for (int i = 0; i < stones.Length; i++) {
                foreach (int k in map[stones[i]]) {
                    for (int step = k - 1; step <= k + 1; step++) {
                        if (step > 0 && stones[i] + step > k  && map.ContainsKey(stones[i] + step)) {
                            map[stones[i] + step].Add(step);
                        }
                    }
                }
            }

            return map[stones[stones.Length - 1]].Count > 0;            
        }        
    }
}