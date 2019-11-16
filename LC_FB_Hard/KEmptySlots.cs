namespace LC_FB_Hard
{
    /*
        You have N bulbs in a row numbered from 1 to N. Initially, all the bulbs are turned off. 
        We turn on exactly one bulb everyday until all bulbs are on after N days.
        You are given an array bulbs of length N where bulbs[i] = x means that on the (i+1)th day, 
        we will turn on the bulb at position x where i is 0-indexed and x is 1-indexed.
        Given an integer K, find out the minimum day number such that there exists two turned on bulbs 
        that have exactly K bulbs between them that are all turned off. If there isn't such day, return -1.

        Example 1:
            Input: 
            bulbs: [1,3,2]
            K: 1
            Output: 2
            Explanation:
            On the first day: bulbs[0] = 1, first bulb is turned on: [1,0,0]
            On the second day: bulbs[1] = 3, third bulb is turned on: [1,0,1]
            On the third day: bulbs[2] = 2, second bulb is turned on: [1,1,1]
            We return 2 because on the second day, there were two on bulbs with one off bulb between them.

        Example 2:
            Input: 
            bulbs: [1,2,3]
            K: 1
            Output: -1
    */
    class KEmptySlots
    {
        // The optimal way to solve this is to use some sorted data structure which also supports finding the floor and ceiling
        // Whenever we activate a bulb, we look for its neighboring bulbs. If the distance between the current bulb
        // and either of its neighbors is k, we can return it

        // Since C# doesn't have a TreeSet equivalent, here is the Java version
        // public int kEmptySlots(int[] bulbs, int K) {
            
        //     TreeSet<Integer> set = new TreeSet<>();

        //     for (int i = 0; i < bulbs.length; i++) {
        //         Integer higher = set.higher(bulbs[i]);
        //         Integer lower = set.lower(bulbs[i]);

        //         if (lower != null && bulbs[i] - K - 1 == lower) {
        //             return i + 1;
        //         }

        //         if (higher != null && bulbs[i] + K + 1 == higher) {
        //             return i + 1;
        //         }

        //         set.add(bulbs[i]);
        //     }

        //     return -1;
        // }
    }
}