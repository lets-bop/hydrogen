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