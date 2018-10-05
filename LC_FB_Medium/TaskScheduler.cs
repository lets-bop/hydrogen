/*
Given a char array representing tasks CPU need to do. It contains capital letters 
A to Z where different letters represent different tasks.Tasks could be done 
without original order. Each task could be done in one interval. 
For each interval, CPU could finish one task or just be idle.

However, there is a non-negative cooling interval n that means between two same 
tasks, there must be at least n intervals that CPU are doing different tasks or 
just be idle.

You need to return the least number of intervals the CPU will take to finish all 
the given tasks.

Example 1:
Input: tasks = ["A","A","A","B","B","B"], n = 2
Output: 8
Explanation: A -> B -> idle -> A -> B -> idle -> A -> B.
Note:
The number of tasks is in the range [1, 10000].
The integer n is in the range [0, 100].
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class TaskScheduler
    {
        public int LeastInterval(char[] tasks, int n) 
        {
            int[] taskMap = new int[26];

            foreach (char c in tasks){
                taskMap[c - 'A']++;
            }

            Array.Sort(taskMap);

            int time = 0;
            while(taskMap[25] > 0){
                int i = 0;
                while(i <= n){
                    if (taskMap[25] <= 0) break;
                    if (i < 26 && taskMap[25 - i] > 0) taskMap[25 - i]--;
                    time++;
                    i++;
                }

                Array.Sort(taskMap);
            }

            return time;
        }        
    }
}