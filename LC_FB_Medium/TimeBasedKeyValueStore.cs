using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Create a timebased key-value store class TimeMap, that supports two operations.
        1. set(string key, string value, int timestamp) - Stores the key and value, along with the given timestamp.
        2. get(string key, int timestamp) - Returns a value such that set(key, value, timestamp_prev) was called previously, 
        with timestamp_prev <= timestamp. If there are multiple such values, it returns the one with the largest timestamp_prev.
        If there are no values, it returns the empty string ("").

        Example 1:
        Input: inputs = ["TimeMap","set","get","get","set","get","get"], inputs = [[],["foo","bar",1],["foo",1],["foo",3],["foo","bar2",4],["foo",4],["foo",5]]
        Output: [null,null,"bar","bar",null,"bar2","bar2"]
        Explanation: TimeMap kv;   
        kv.set("foo", "bar", 1); // store the key "foo" and value "bar" along with timestamp = 1   
        kv.get("foo", 1);  // output "bar"   
        kv.get("foo", 3); // output "bar" since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 ie "bar"   
        kv.set("foo", "bar2", 4);   
        kv.get("foo", 4); // output "bar2"   
        kv.get("foo", 5); //output "bar2"   

        Example 2:
        Input: inputs = ["TimeMap","set","set","get","get","get","get","get"], 
        inputs = [[],["love","high",10],["love","low",20],["love",5],["love",10],["love",15],["love",20],["love",25]]
        Output: [null,null,null,"","high","high","low","low"]
        
        Note:
        All key/value strings are lowercase.
        All key/value strings have length in the range [1, 100]
        The timestamps for all TimeMap.set operations are strictly increasing.
        1 <= timestamp <= 10^7
        TimeMap.set and TimeMap.get functions will be called a total of 120000 times (combined) per test case.    
    */
    class TimeBasedKeyValueStore
    {
        // We will use a dictionary + binary search approach to solve the problem.
        // The value of the dictionary for a key will be a list.
        // Since we are guaranteed that the set operations are always increasing in time,
        // we are guaranteed that the list will be sorted, hence applying binary search is straight-forward.

        class TimeValue 
        {
            public string value;
            public int timestamp;

            public TimeValue(string value, int timestamp) {
                this.value = value;
                this.timestamp = timestamp;
            }
        }

        Dictionary<string, List<TimeValue>> store;
        public TimeBasedKeyValueStore() {
            this.store = new Dictionary<string, List<TimeValue>>();
        }
        
        public void Set(string key, string value, int timestamp)
        {
            if (!this.store.ContainsKey(key)) this.store[key] = new List<TimeValue>(); 
            this.store[key].Add(new TimeValue(value, timestamp));
        }
        
        public string Get(string key, int timestamp)
        {
            if(!this.store.ContainsKey(key)) return string.Empty;
            if (this.store.ContainsKey(key) && timestamp < this.store[key][0].timestamp) return string.Empty;

            // need to do a binary search
            List<TimeValue> list = this.store[key];
            int low = 0;
            int high = list.Count - 1;
            int mid;
            int index = -1;
            while (low <= high) {
                mid = low + (high - low) / 2;
                if (list[mid].timestamp <= timestamp) {
                    index = mid;
                    low = mid + 1;
                } else high = mid - 1;
            }

            if (index != -1) return list[index].value;
            return string.Empty;
        }
    }
}