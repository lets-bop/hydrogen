/*
A frog is crossing a river. The river is divided into x units and at each unit there may or may not exist a stone. 
The frog can jump on a stone, but it must not jump into the water. 
Given a list of stones' positions (in units) in sorted ascending order, 
determine if the frog is able to cross the river by landing on the last stone. Initially, 
the frog is on the first stone and assume the first jump must be 1 unit. If the frog's last jump 
was k units, then its next jump must be either k - 1, k, or k + 1 units. 
Note that the frog can only jump in the forward direction.

Note:
The number of stones is ≥ 2 and is < 1,100.
Each stone's position will be a non-negative integer < 231.
The first stone's position is always 0.

Example 1:
[0,1,3,5,6,8,12,17]
There are a total of 8 stones.
The first stone at the 0th unit, second stone at the 1st unit,
third stone at the 3rd unit, and so on...
The last stone at the 17th unit.

Return true. The frog can jump to the last stone by jumping 
1 unit to the 2nd stone, then 2 units to the 3rd stone, then 
2 units to the 4th stone, then 3 units to the 6th stone, 
4 units to the 7th stone, and 5 units to the 8th stone.

Example 2:
[0,1,2,3,4,8,9,11]
Return false. There is no way to jump to the last stone as 
the gap between the 5th and 6th stone is too large.

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
            // This is a classic DFS problem. From every position we are at, 
            // if 'x' is the number of jumps we took took to get to that position,
            // we can take x, x - 1 or x + 1 jumps.

            Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < stones.Length; i++) {
                map.Add(stones[i], new HashSet<int>());
            }

            map[0].Add(0);
            int lastStone = stones[stones.Length - 1];
            for (int i = 0; i < stones.Length; i++) {
                foreach (int k in map[stones[i]]) {
                    for (int step = k - 1; step <= k + 1; step++) {
                        // step size must be greater than 0 and the destination stone (stones[i] + step) must be a valid stone
                        if (step > 0 && stones[i] + step > k  && map.ContainsKey(stones[i] + step)) {
                            map[stones[i] + step].Add(step);
                            if (map[lastStone].Count > 0) return true;
                        }
                    }
                }
            }
            
            return false;
        }
    }
}