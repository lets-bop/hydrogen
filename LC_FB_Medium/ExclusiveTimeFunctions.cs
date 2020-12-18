/*
Given the running logs of n functions that are executed in a nonpreemptive single threaded CPU, 
find the exclusive time of these functions. Each function has a unique id, start from 0 to n-1. 
A function may be called recursively or by another function. A log is a string has this format 
: function_id:start_or_end:timestamp. For example, "0:start:0" means function 0 starts 
from the very beginning of time 0. "0:end:0" means function 0 ends to the very end of time 0.

Exclusive time of a function is defined as the time spent within this function, the time 
spent by calling other functions should not be considered as this function's exclusive time. 
You should return the exclusive time of each function sorted by their function id.

Example 1:
Input:
n = 2
logs = 
["0:start:0",
 "1:start:2",
 "1:end:5",
 "0:end:6"]
Output:[3, 4]
Explanation:
Function 0 starts at time 0, then it executes 2 units of time and reaches the end of time 1. 
Now function 0 calls function 1, function 1 starts at time 2, executes 4 units of time and end at time 5.
Function 0 is running again at time 6, and also end at the time 6, thus executes 1 unit of time. 
So function 0 totally execute 2 + 1 = 3 units of time, and function 1 totally execute 4 units of time.

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class ExclusiveTimeFunctions
    {
        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            // The logs are already sorted by time.
            // We will use a stack to keep track of the functions that we are processing.
            // If we are processing a start log, we update the running for the function  at the top of the stack
            // since that was last running function and it was running until the current function was called
            // and push the current function on to the stack.
            // If we are the processing the end log, then we need to update the time for the current function.
            Stack<int> stack = new Stack<int>();
            int[] result = new int[n];
            int prev = 0;

            foreach(string log in logs) {
                string[] logSplits = log.Split(':'); // "0:start:0"
                if(logSplits.Length != 3) throw new Exception("Incorrect format.");

                int function_id = int.Parse(logSplits[0]);
                int time = int.Parse(logSplits[2]);

                if (logSplits[1] == "start"){
                    if(stack.Count != 0)
                        result[stack.Peek()] += time - prev;

                    stack.Push(function_id);
                    prev = time;
                }
                else {
                    // note that the end time includes the # and hence we need to add 1.
                    result[function_id] += time - prev + 1;
                    prev = time + 1;
                    stack.Pop();
                }
            }

            return result;
        }
    }
}