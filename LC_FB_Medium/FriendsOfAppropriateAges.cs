using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Some people will make friend requests. The list of their ages is given and ages[i] is the age of the ith person. 

        Person A will NOT friend request person B (B != A) if any of the following conditions are true:
        age[B] <= 0.5 * age[A] + 7
        age[B] > age[A]
        age[B] > 100 && age[A] < 100
        Otherwise, A will friend request B.
        Note that if A requests B, B does not necessarily request A.  Also, people will not friend request themselves.
        How many total friend requests are made?

        Example 1:
        Input: [16,16]
        Output: 2
        Explanation: 2 people friend request each other.
        Example 2:
        Input: [16,17,18]
        Output: 2
        Explanation: Friend requests are made 17 -> 16, 18 -> 17.
        Example 3:
        Input: [20,30,100,110,120]
        Output: 
        Explanation: Friend requests are made 110 -> 100, 120 -> 110, 120 -> 100.
    */
    class FriendsOfAppropriateAges
    {
        public int NumFriendRequests(int[] ages) {
            int[] numInAge = new int[121]; // max age is 120
            int[] sumInAge = new int[121]; // prefix sum of numInAge

            foreach (int age in ages) numInAge[age]++;
            for (int i = 1; i < sumInAge.Length; i++) sumInAge[i] = sumInAge[i - 1] + numInAge[i];

            int requests = 0;
            int count;

            for (int i = 15; i <= 120; i++) { // we start at 15 as a person upto the age of 14 cannot friend request anyone
                if(numInAge[i] == 0) continue;
                count = sumInAge[i] - sumInAge[i / 2 + 7];
                requests += (numInAge[i]) * count - numInAge[i];    // subtract to exclude yourself. '- numInAge[i]'
            }

            return requests;
        }
    }
}