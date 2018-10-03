using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class RunTests
    {
        public static void Run()
        {
            // MinSizeSubarraySumTest();
            //TaskSchedulerTest();
            ExclusiveTimeFunctionsTest();
            NumberOfIslandsTest();
        }

        public static void MinSizeSubarraySumTest()
        {
            
            int[] arr = new int[] {2,3,1,2,4,3};
            Console.WriteLine("Expected: 2. Actual: " + MinSizeSubarraySum.Find(arr, 7));

            arr = new int[] {1,2,3,4,5};
            Console.WriteLine("Expected: 3. Actual: " + MinSizeSubarraySum.Find(arr, 11));        

            arr = new int[] {0,0,0,0,0};
            Console.WriteLine("Expected: 1. Actual: " + MinSizeSubarraySum.Find(arr, 0));

            arr = new int[] {0,2,1,9,0};
            Console.WriteLine("Expected: 1. Actual: " + MinSizeSubarraySum.Find(arr, 0));

            arr = new int[] {0,2,2,4,3};
            Console.WriteLine("Expected: 1. Actual: " + MinSizeSubarraySum.Find(arr, 4));

            arr = new int[] {0,2,2,4,3};
            Console.WriteLine("Expected: 2. Actual: " + MinSizeSubarraySum.Find(arr, 6));
        }

        public static void TaskSchedulerTest()
        {
            char[] tasks = new char[] {'A','A','A','B','B','B'};
            TaskScheduler ts = new TaskScheduler();
            Console.WriteLine(ts.LeastInterval(tasks, 2));
        }

        public static void ExclusiveTimeFunctionsTest()
        {
            ExclusiveTimeFunctions etf = new ExclusiveTimeFunctions();
            int[] result = etf.ExclusiveTime(2, new List<string>() {"0:start:0","1:start:2","1:end:5","0:end:6"});
            Console.WriteLine("Expected [3,4]. Actual is ");

            foreach(int r in result) Console.Write("{0} ", r);
            Console.WriteLine();
        }

        public static void NumberOfIslandsTest()
        {
            NumberOfIslands n = new NumberOfIslands();
            /*
                11110
                11010
                11000
                00000            
            */
            char[,] grid = new char[,] {
                {'1','1','1','1','0'},
                {'1','1','0','1','0'},
                {'1','1','0','0','0'},
                {'0','0','0','0','0'}};

                Console.WriteLine("Expected: 1. Actual: " + n.NumIslands(grid));

            /*
                11000
                11000
                00100
                00011     
            */
            grid = new char[,] {
                {'1','1','0','0','0'},
                {'1','1','0','0','0'},
                {'0','0','1','0','0'},
                {'0','0','0','1','1'}};

            Console.WriteLine("Expected: 3. Actual: " + n.NumIslands(grid));

            grid = new char[,] {
                {'1','1','1','1','1','0','1','1','1','1','1','1','1','1','1','0','1','0','1','1'},
                {'0','1','1','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','1','0'},
                {'1','0','1','1','1','0','0','1','1','0','1','1','1','1','1','1','1','1','1','1'},
                {'1','1','1','1','0','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
                {'1','0','0','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
                {'1','0','1','1','1','1','1','1','0','1','1','1','0','1','1','1','0','1','1','1'},
                {'0','1','1','1','1','1','1','1','1','1','1','1','0','1','1','0','1','1','1','1'},
                {'1','1','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','0','1','1'},
                {'1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','1','1','1','1','1'},
                {'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
                {'0','1','1','1','1','1','1','1','0','1','1','1','1','1','1','1','1','1','1','1'},
                {'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
                {'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
                {'1','1','1','1','1','0','1','1','1','1','1','1','1','0','1','1','1','1','1','1'},
                {'1','0','1','1','1','1','1','0','1','1','1','0','1','1','1','1','0','1','1','1'},
                {'1','1','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','1','1','0'},
                {'1','1','1','1','1','1','1','1','1','1','1','1','1','0','1','1','1','1','0','0'},
                {'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
                {'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'},
                {'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'}};

            Console.WriteLine("Expected: 3. Actual: " + n.NumIslands(grid));




        }
    }    
}