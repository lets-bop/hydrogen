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
            // TaskSchedulerTest();
            // ExclusiveTimeFunctionsTest();
            // NumberOfIslandsTest();
            // GenerateParenthesisTest();
            // MinMeetingRoomsTest();
            // MergeIntervalsTest();
            // WordSearchTest();
            // BasicCalculatorTest();
            // PalindromePermutationTest();
            // LetterComboOfPhoneTest();
            // ReorganizeStringTest();
            // PartitionToKEqualSumSubsetsTest();
            // DailyTemperaturesTest();
            // QueueReconstructionTest();
            // WordBreakTest();
            // SpiralOrderTest();
            // SummaryRangesTest();
            // SubArraySumOfKTest();
            BraceExpansionTest();
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

        public static void GenerateParenthesisTest()
        {
            GenerateParenthesis gp = new GenerateParenthesis();
            Console.WriteLine("Generate for 2");
            IList<string> result = gp.Generate(2);
            foreach(string r in result) Console.WriteLine(r);

            Console.WriteLine("Generate for 3");
            result = gp.Generate(3);
            foreach(string r in result) Console.WriteLine(r);

            Console.WriteLine("Generate for 4");
            result = gp.Generate(4);
            foreach(string r in result) Console.WriteLine(r);
        }

        public static void MinMeetingRoomsTest(){
            MinMeetingRooms mr = new MinMeetingRooms();
            MinMeetingRooms.Interval[] intervals = new MinMeetingRooms.Interval[3];
            MinMeetingRooms.Interval int1 = new MinMeetingRooms.Interval(5,10);
            intervals[0] = int1;
            int1 = new MinMeetingRooms.Interval(15,20);
            intervals[1] = int1;
            int1 = new MinMeetingRooms.Interval(0,30);
            intervals[2] = int1;
            Console.WriteLine("Expected: 2. Actual " + mr.FindMinimum(intervals));

            // (1, 10), (2, 7), (3, 19), (8, 12), (10, 20)
            mr = new MinMeetingRooms();
            intervals = new MinMeetingRooms.Interval[6];
            
            int1 = new MinMeetingRooms.Interval(10,20);
            intervals[0] = int1;
            int1 = new MinMeetingRooms.Interval(2,7);
            intervals[1] = int1;
            int1 = new MinMeetingRooms.Interval(11,30);
            intervals[2] = int1;
            int1 = new MinMeetingRooms.Interval(8,12);
            intervals[3] = int1;
            int1 = new MinMeetingRooms.Interval(1,10);
            intervals[4] = int1;
            int1 = new MinMeetingRooms.Interval(3,19);
            intervals[5] = int1;
            Console.WriteLine("Expected: 4. Actual " + mr.FindMinimum(intervals));            
        }

        public static void MergeIntervalsTest(){
            IList<Interval> intervals = new List<Interval>();
            Interval i1 = new Interval(2, 6);
            intervals.Add(i1);
            i1 = new Interval(5, 10);
            intervals.Add(i1);
            i1 = new Interval(1, 4);
            intervals.Add(i1);
            i1 = new Interval(12, 15);
            intervals.Add(i1);
            MergeIntervals merge = new MergeIntervals();
            IList<Interval> merged = merge.Merge(intervals);
            foreach (Interval i in merged)
                Console.Write("[{0}, {1}]\t", i.start, i.end);
            Console.WriteLine();
        }

        public static void WordSearchTest()
        {
            WordSearch wordSearch = new WordSearch();
            char[,] board = new char[,]
                    {{'A','B','C','E'},
                    {'S','F','C','S'},
                    {'A','D','E','E'}};
            Console.WriteLine("Expected: True. Actual: " + wordSearch.Exist(board, "ABCCED"));

            board = new char[,] {{'C','A','A'},{'A','A','A'},{'B','C','D'}};
            Console.WriteLine("Expected: True. Actual: " + wordSearch.Exist(board, "AAB"));

        }

        public static void BasicCalculatorTest()
        {
            BasicCalculator bc = new BasicCalculator();
            Console.WriteLine("Expected: 7. Actual " + bc.Calculate("3 + 2 * 2"));
            Console.WriteLine("Expected: 10. Actual " + bc.Calculate(" 2 + 2 + 2 * 3"));
            Console.WriteLine("Expected: 5. Actual " + bc.Calculate(" 3+5 / 2 "));
            Console.WriteLine("Expected: 28. Actual: " + bc.Calculate("1*2-3/4+5*6-7*8+9/10"));
            Console.WriteLine("Expected: 27. Actual: " + bc.Calculate("100000000/1/2/3/4/5/6/7/8/9/10"));
        }

        public static void PalindromePermutationTest()
        {
            PalindromePermutation pp = new PalindromePermutation();
            pp.GeneratePalindromes("malayyyalam");
            pp.GeneratePalindromes("malayalams");
        }

        public static void LetterComboOfPhoneTest()
        {
            LetterComboOfPhone lcp = new LetterComboOfPhone();
            IList<string> result = lcp.LetterCombinations("23");
            Console.Write("Expected: ad ae af bd be bf cd ce cf. Actual: ");
            foreach (string s in result) Console.Write(s + " ");
            Console.WriteLine();
        }

        public static void ReorganizeStringTest()
        {
            ReorganizeString rs = new ReorganizeString();
            Console.WriteLine("Expected: aba. Actual: " + rs.Reorganize("aab"));
            Console.WriteLine("Expected: ''. Actual: " + rs.Reorganize("aaab"));
            Console.WriteLine("Expected: 'vovlv'. Actual: " + rs.Reorganize("vvvlo"));
            Console.WriteLine("Expected: 'rsrbrxrirararbrxrlrirzryrgrprorsrvrkrhrernrdr'. Actual: " + rs.Reorganize("rvhrlpiesrrryrbrrrrrxrkirranrrrrbdrrzgasoxrrr"));
        }

        public static void PartitionToKEqualSumSubsetsTest()
        {
            int[] input = new int[] {4, 3, 2, 3, 5, 2, 1};
            PartitionToKEqualSumSubsets part = new PartitionToKEqualSumSubsets();
            Console.WriteLine(part.CanPartitionKSubsets(input, 4));
        }
        public static void WordBreakTest()
        {
            WordBreak wordBreak = new WordBreak();
            bool result = wordBreak.Check2("catsanddog", new List<string>(){"cat", "cats", "sand", "and", "dog"});
            Console.WriteLine("Expected: True. Actual: " + result);

            result = wordBreak.Check2(
                "leetcode",
                new List<string>() {"leet","code"});
            Console.WriteLine("Expected: True. Actual: " + result);            

            result = wordBreak.Check2(
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                new List<string>() {"a","aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa"});
            Console.WriteLine("Expected: True. Actual: " + result);

            result = wordBreak.Check2(
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab",
                new List<string>() {"a","aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa"});
            Console.WriteLine("Expected: False. Actual: " + result);            
        }

        public static void DailyTemperaturesTest()
        {
            DailyTemperatures dt = new DailyTemperatures();
            int[] result = dt.CalculateDailyTemperatures(new int[] { 74, 69, 70, 70, 75});
            foreach (int i in result) Console.Write(i + "\t");
            Console.WriteLine();
        }

        public static void QueueReconstructionTest()
        {
            QueueReconstruction qr = new QueueReconstruction();
            int[][] result = qr.ReconstructQueue(new int[][] { new int[] { 7,0 }, new int[] { 4, 4 }, new int[] { 7, 1 }, new int[] { 5, 0 }, new int[] { 6, 1 }, new int[] { 5, 2 } });
            foreach (int[] arr in result)
            {
                foreach (int k in arr) Console.Write(k + "\t");
                Console.WriteLine();
            }
        }

        public static void SpiralOrderTest()
        {
            SpiralOrder_New sp = new SpiralOrder_New();
            IList<int> result = sp.FindSpiralOrder(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } });
            Console.WriteLine("Expected output is 1 2 3 6 9 8 7 4 5");
            foreach (int r in result) Console.Write(r + "\t");
            Console.WriteLine();

            result = sp.FindSpiralOrder(new int[][] { new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8 }, new int[] { 9, 10, 11, 12 } });
            Console.WriteLine("Expected output is 1 2 3 4 8 12 11 10 9 5 6 7");
            foreach (int r in result) Console.Write(r + "\t");
            Console.WriteLine();
        }

        public static void SummaryRangesTest()
        {
            SummaryRanges sr = new SummaryRanges();
            IList<string> result = sr.FindSummaryRanges(new int[] {0,1,2,4,5,7});
            Console.WriteLine("Expected result 0->2, 4->5, 7");
            foreach (string r in result) Console.Write(r + "\t");
            Console.WriteLine();

            result = sr.FindSummaryRanges(new int[] {0,2,3,4,6,8,9});
            Console.WriteLine("Expected result 0, 2->4, 6, 8->9");
            foreach (string r in result) Console.Write(r + "\t");
            Console.WriteLine();
        }

        public static void SubArraySumOfKTest()
        {
            SubArraySumOfK sumK = new SubArraySumOfK();
            int[] num = new int[] {1, 1, 1};
            Console.WriteLine("Expected = 2. Actual = " + sumK.SubarraySum(num, 2));

            num = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            Console.WriteLine("Expected = 55. Actual = " + sumK.SubarraySum(num, 0));
        }

        public static void BraceExpansionTest()
        {
            BraceExpansion br = new BraceExpansion();
            // br.Expand("{a,b,c,d}e{f,g}");
            br.Expand("{a,b}c{d,e}f");
        }
    }    
}