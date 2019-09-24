using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class RunTests
    {
        public static void Run()
        {
            DateTime startTime = DateTime.Now;

            // MinSizeSubarraySumTest(); // 1
            // TaskSchedulerTest(); // 2
            // ExclusiveTimeFunctionsTest(); // 3
            // NumberOfIslandsTest(); // 4
            // GenerateParenthesisTest(); // 5
            // MinMeetingRoomsTest(); // 6
            // MergeIntervalsTest(); // 7
            // WordSearchTest(); // 8
            // BasicCalculatorTest(); // 9
            // PalindromePermutationTest(); // 10
            // LetterComboOfPhoneTest(); // 11
            // ReorganizeStringTest(); // 12
            // PartitionToKEqualSumSubsetsTest(); // 13
            // DailyTemperaturesTest(); // 14
            // QueueReconstructionTest(); // 15
            // WordBreakTest(); // 16
            // SpiralOrderTest(); // 17
            // SummaryRangesTest(); // 18
            // SubArraySumOfKTest(); // 19
            // BraceExpansionTest(); // 20
            // ThreeSumTest(); // 21
            // TestCountCompleteBinaryTreeNodes(); // 22
            // TestFruitIntoBasket(); // 23
            // TestNetworkDelayTime(); // 24
            // TestLongestWordInDicThroughDeleting(); // 25
            // TestExpressiveWords(); // 26
            // TestTimeBasedKeyValueStore(); // 27
            // TestShipCapacity(); // 28
            // TestDifferentWaysToAddParenthesis(); // 29
            // TestMinDominoRotations(); // 30
            // TestDecodeString(); // 31
            // TestMissingRanges(); // 32
            // TestIncreasingTripletSubsequence(); // 33
            // TestShortestWayToFormString(); // 34
            // TestStonesRemoved(); // 35
            // TestIntervalListInterections(); // 36
            // TestKClosestToOrigin(); // 37
            // TestProductExceptSelf(); // 38
            // TestBSTDoublyList(); // 39
            // TestContinuousSubarraySum(); // 40
            // TestOneEditDistance(); // 41
            // TestNextPermutation(); // 42
            // TestKthLargest(); // 43
            // TestTopKFrequent(); // 44
            // TestBinaryTreeRightSideView(); // 45
            // TestAccountsMerge(); // 46
            // TestLongestSubstringKDistinctChars(); // 47
            // TestLongestRepeatingChar(); // 48
            // TestLongestWithoutRepeatingChars(); //49
            // TestMaxOnes(); // 50
            // TestDuctchFlag(); // 51
            // TestThreeSumClosest(); // 52
            // TestSortedSquares(); // 53
            // TestThreeSumSmaller(); // 54
            // TestThreeSumMulti(); // 55
            // TestSubArrayProductLessThanK(); // 56
            // TestSubarraySubDivisibleByK(); // 57
            // TestLinkedListCycle(); //58
            // TestHappyNumber(); //59
            // TestNonoverlappingIntervals(); // 60
            // TestDuplicateNumber(); // 61
            // TestReverseLinkedList2(); // 62
            // TestSearchInRotatedArray(); // 63
            // TestContainerWithMostWater(); // 64
            // TestFriendsOfAppropriateAges(); //65
            // TestLongestRepeatedSubstring(); // 66
            // TestRestoreIpAddress(); // 67
            // TestLongestArithmeticSequence(); // 68
            // TestArithmeticSlices(); // 69
            // TestPartitionLabels(); // 70
            // TestSentenceScreenFitting(); // 71
            // TestFindMinimumInSortedArray(); // 72
            // TestLongestIncreasingSubsequence(); // 73
            // TestHIndex(); // 74
            // TestIsomorphicStrings(); // 75
            // TestMaximumSizeSubarraySumK(); // 76
            // TestMajorityElement2(); // 77
            // TestWordLadder(); // 78
            // TestRangeAddition(); // 79
            // TestConcordance(); // 80
            // TestUglyNumber2(); // 81
            // TestSearch2DMatrix(); // 82
            // TestKthSmallestInSortedMatrix(); // 83
            // TestNumberOfConnectedComponentsUG(); // 84
            TestWallsAndGates(); // 85

            Console.WriteLine("Time taken (ms): " + (DateTime.Now - startTime).TotalMilliseconds);
        }

        public static string GetListOfIntAsString(IList<int> list) {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for(int i = 0; i < list.Count; i++){  
                if (i != 0) sb.Append(","); 
                sb.Append(list[i].ToString());
            }

            sb.Append("]");
            return sb.ToString();
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
            char[][] board = new char[][]
                    {new char[]{'A','B','C','E'},
                    new char[]{'S','F','C','S'},
                    new char[]{'A','D','E','E'}};
            Console.WriteLine("Expected: True. Actual: " + wordSearch.Exist(board, "ABCCED"));

            board = new char[][] {new char[]{'C','A','A'},new char[]{'A','A','A'},new char[]{'B','C','D'}};
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

        public static void ThreeSumTest()
        {
            ThreeSum sum = new ThreeSum();
            IList<IList<int>> result = sum.Calculate(new int[] {-1, 0, 1, 2, -1, -4});
            foreach (IList<int> r in result){
                foreach (int n in r){
                    Console.Write(n + ",");
                }
                Console.WriteLine();
            }
        }

        public static void TestCountCompleteBinaryTreeNodes()
        {
            /*
                Input: 
                      1
                    /   \
                    2    3
                    / \  /
                    4  5 6

                Output: 6             
            */
            CountCompleteBinaryTreeNodes.TreeNode t1 = new CountCompleteBinaryTreeNodes.TreeNode(1);
            t1.left = new CountCompleteBinaryTreeNodes.TreeNode(2);
            t1.left.left = new CountCompleteBinaryTreeNodes.TreeNode(4);
            t1.left.right = new CountCompleteBinaryTreeNodes.TreeNode(5);
            t1.right = new CountCompleteBinaryTreeNodes.TreeNode(3);
            t1.right.left = new CountCompleteBinaryTreeNodes.TreeNode(6);

            CountCompleteBinaryTreeNodes c = new CountCompleteBinaryTreeNodes();
            Console.WriteLine(c.CountNodes(t1));
        }

        public static void TestFruitIntoBasket()
        {
            FruitIntoBaskets fib = new FruitIntoBaskets();
            Console.WriteLine("Expected: 3. Output: " + fib.TotalFruit(new int[] {1,2,1}));
            Console.WriteLine("Expected: 3. Output: " +fib.TotalFruit(new int[] {0,1,2,2}));
            Console.WriteLine("Expected: 4. Output: " +fib.TotalFruit(new int[] {1,2,3,2,2}));
            Console.WriteLine("Expected: 19. Output: " +fib.TotalFruit(new int[] {1,2,1,2,1,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3}));
            Console.WriteLine("Expected: 5. Output: " +fib.TotalFruit(new int[] {1,1,1,1,1}));
            Console.WriteLine("Expected: 6. Output: " +fib.TotalFruit(new int[] {1,1,1,1,1,2}));            
            Console.WriteLine("Expected: 7. Output: " +fib.TotalFruit(new int[] {1,1,1,1,1,2,2}));
            Console.WriteLine("Expected: 12. Output: " +fib.TotalFruit(new int[] {1,0,29,29,29,29,29,29,0,0,29,8,8,29,8,29,8,8,15,8,8,15,15,8,15,15,8,8,7,5}));
            Console.WriteLine("Expected: 3. Output: " + fib.TotalFruit(new int[] {6,2,1,1,3,6,6}));
        }

        public static void TestNetworkDelayTime()
        {
            NetworkDelayTime ndt = new NetworkDelayTime();
            Console.WriteLine("Expected: 2. Output: " + ndt.CalculateDelay(new int[][] {new int[] {2,1,1}, new int[] {2,3,1}, new int[] {3,4,1}}, 4, 2));

            ndt = new NetworkDelayTime();
            Console.WriteLine("Expected: 2. Output: " + ndt.CalculateDelay(new int[][] {new int[] {1,2,1}, new int[] {1,3,3}, new int[] {2,3,1}}, 3, 1));

            ndt = new NetworkDelayTime();
            Console.WriteLine("Expected: 4. Output: " + ndt.CalculateDelay(new int[][] {new int[] {1,2,1}, new int[] {1,3,5}, new int[] {2,3,4}, new int[] {2,4,1}, new int[] {4,3,3}, new int[] {4,5,1}, new int[] {5,3,1}}, 5, 1));
        }

        public static void TestLongestWordInDicThroughDeleting()
        {
            LongestWordInDicThroughDeleting lwid = new LongestWordInDicThroughDeleting();
            Console.WriteLine("Expected: apple, output: " + lwid.FindLongestWord("abpcplea", new List<string>() {"ale","apple","monkey","plea"}));
            Console.WriteLine("Expected: a, output: " + lwid.FindLongestWord("abpcplea", new List<string>() {"a","b","c"}));
            Console.WriteLine("Expected: ab, output: " + lwid.FindLongestWord("bab", new List<string>() {"ba","ab","a","b"}));
        }

        public static void TestExpressiveWords()
        {
            ExpressiveWords ew = new ExpressiveWords();
            // Console.WriteLine("Expected: 2. Output: " + ew.CountExpressiveWords("hellllllooo", new string[] {"hello", "helo", "hi"}));
            // Console.WriteLine("Expected: 1. Output: " + ew.CountExpressiveWords("hiiiii", new string[] {"hi", "hii", ""}));
            // Console.WriteLine("Expected: 1. Output: " + ew.CountExpressiveWords("heeellooo", new string[] {"hello", "helo", "hi"}));
            Console.WriteLine("Expected: 3. Output: " + ew.CountExpressiveWords("zzzzzzyyyyyy", new string[] {"zzyy", "zy", "zyy"}));

        }

        public static void TestTimeBasedKeyValueStore()
        {
            TimeBasedKeyValueStore time = new TimeBasedKeyValueStore();
            time.Set("foo", "bar1", 1);
            time.Set("foo", "bar21", 21);
            time.Set("foo", "bar31", 31);
            time.Set("foo", "bar41", 41);
            time.Set("foo", "bar61", 61);
            time.Set("foo", "bar71", 71);
            time.Set("foo", "bar81", 81);
            time.Set("foo", "bar91", 91);
            time.Set("foo", "bar101", 101);
            time.Set("foo", "bar111", 111);

            Console.WriteLine("Expected: . Actual: " + time.Get("foo", 0));
            Console.WriteLine("Expected: bar1. Actual: " + time.Get("foo", 11));
            Console.WriteLine("Expected: bar21. Actual: " + time.Get("foo", 25));
            Console.WriteLine("Expected: bar41. Actual: " + time.Get("foo", 45));
            Console.WriteLine("Expected: bar71. Actual: " + time.Get("foo", 75));
        }

        public static void TestShipCapacity()
        {
            ShipCapacity sc = new ShipCapacity();
            Console.WriteLine("Expected: 15. Actual: " + sc.ShipWithinDays(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, 5));
            Console.WriteLine("Expected: 3. Actual: " + sc.ShipWithinDays(new int[] {1, 2, 3, 1, 1}, 4));
        }

        public static void TestDifferentWaysToAddParenthesis()
        {
            DifferentWaysToAddParenthesis dp = new DifferentWaysToAddParenthesis();
            dp.DiffWaysToCompute("2*3-4*5");
            dp.DiffWaysToCompute("21*20-3");
        }

        public static void TestMinDominoRotations()
        {
            MinDominoRotations minDominoRotations = new MinDominoRotations();
            Console.WriteLine("Expected: 2. Actual: " + 
                minDominoRotations.CalcMinDominoRotations(new int[] {2,1,2,4,2,2}, new int[] {5,2,6,2,3,2}));
            Console.WriteLine("Expected: 2. Actual: " + 
                minDominoRotations.CalcMinDominoRotations(new int[] {5,2,6,2,3,2}, new int[] {2,1,2,4,2,2}));
            Console.WriteLine("Expected: -1. Actual: " + 
                minDominoRotations.CalcMinDominoRotations(new int[] {3,5,1,2,3}, new int[] {3,6,3,3,4}));
            Console.WriteLine("Expected: 0. Actual: " + 
                minDominoRotations.CalcMinDominoRotations(new int[] {2}, new int[] {2}));
            Console.WriteLine("Expected: 1. Actual: " + 
                minDominoRotations.CalcMinDominoRotations(new int[] {1,2,3,4,5,6}, new int[] {6,6,6,6,6,5}));
            Console.WriteLine("Expected: 1. Actual: " + 
                minDominoRotations.CalcMinDominoRotations(new int[] {1,2,1,1,1,2,2,2}, new int[] {2,1,2,2,2,2,2,2}));
        }

        public static void TestDecodeString()
        {
            DecodeString decode = new DecodeString();
            Console.WriteLine("Expected: ababaaaa. Actual: " + decode.Decode("2[ab]4[a]"));
            Console.WriteLine("Expected: ababayzyzayzyz. Actual: " + decode.Decode("2[ab]2[a2[yz]]"));
            Console.WriteLine("Expected: aaabcbc. Actual: " + decode.Decode("3[a]2[bc]"));
            Console.WriteLine("Expected: accaccacc. Actual: " + decode.Decode("3[a2[c]]"));
            Console.WriteLine("Expected: abcabccdcdcdef. Actual: " + decode.Decode("2[abc]3[cd]ef"));
            Console.WriteLine("Expected: sdfeegfeegi. Actual: " + decode.Decode("sd2[f2[e]g]i"));
        }

        public static void TestMissingRanges()
        {
            MissingRanges missingRanges = new MissingRanges();
            IList<string> result;
            Console.WriteLine("Expected: " + "2, 4->49, 51->74, 76->99.");
            result = missingRanges.FindMissingRanges(new int[] {0, 1, 3, 50, 75}, 0, 99);
            Console.Write("Actual: ");
            foreach (string r in result) Console.Write(r + "\t"); Console.WriteLine();

            Console.WriteLine("Expected: " + "0->22, 24->99.");
            result = missingRanges.FindMissingRanges(new int[] {23}, 0, 99);
            Console.Write("Actual: ");
            foreach (string r in result) Console.Write(r + "\t"); Console.WriteLine();

            Console.WriteLine("Expected: " + "0->2147483646");
            result = missingRanges.FindMissingRanges(new int[] {2147483647}, 0, 2147483647);
            Console.Write("Actual: ");
            foreach (string r in result) Console.Write(r + "\t"); Console.WriteLine();

            Console.WriteLine("Expected: " + "");
            result = missingRanges.FindMissingRanges(new int[] {-1}, -1, -1);
            Console.Write("Actual: ");
            foreach (string r in result) Console.Write(r + "\t"); Console.WriteLine();

            Console.WriteLine("Expected: " + "-2147483647->-1, 1->2147483646");
            result = missingRanges.FindMissingRanges(new int[] {-2147483648,-2147483648,0,2147483647,2147483647}, -2147483648, 2147483647);
            Console.Write("Actual: ");
            foreach (string r in result) Console.Write(r + "\t"); Console.WriteLine();

            Console.WriteLine("Expected: " + "-2147483647->2147483647");
            result = missingRanges.FindMissingRanges(new int[] {-2147483648}, -2147483648, 2147483647);
            Console.Write("Actual: ");
            foreach (string r in result) Console.Write(r + "\t"); Console.WriteLine();
        }

        public static void TestIncreasingTripletSubsequence() {
            IncreasingTripletSubsequence trip = new IncreasingTripletSubsequence();
            Console.WriteLine("Expected: True. Actual: " + trip.IncreasingTriplet(new int[] {1,2,3,4,5}));
            Console.WriteLine("Expected: True. Actual: " + trip.IncreasingTriplet(new int[] {1,2,-1,2,1}));
            Console.WriteLine("Expected: False. Actual: " + trip.IncreasingTriplet(new int[] {1,2,-1,2,-1}));
        }

        public static void TestShortestWayToFormString()
        {
            ShortestWayToFormString shortestWayToFormString = new ShortestWayToFormString();
            Console.WriteLine("Expected: 2. Actual: " + shortestWayToFormString.ShortestWay("abc", "abcbc"));
            Console.WriteLine("Expected: -1. Actual: " + shortestWayToFormString.ShortestWay("abc", "acdbc"));
            Console.WriteLine("Expected: 3. Actual: " + shortestWayToFormString.ShortestWay("xyz", "xzyxz"));
            Console.WriteLine("Expected: 7. Actual: " + shortestWayToFormString.ShortestWay("xyz", "xxxxxxx"));
            Console.WriteLine("Expected: 4. Actual: " + shortestWayToFormString.ShortestWay("xyz", "xzzyzz"));
        }

        public static void TestStonesRemoved()
        {
            StonesRemoved stonesRemoved = new StonesRemoved();
            int[][] stones = new int[][]{new int[] {0,0}, new int[] {0,1}, new int[] {1,0}, new int[] {1,2}, new int[] {2,1}, new int[] {2,2}};
            Console.WriteLine("Expected 5. Actual: " + stonesRemoved.RemoveStones(stones));
            stones = new int[][]{new int[] {0,0}, new int[] {0,2}, new int[] {1,1}, new int[] {2,0}, new int[] {2,2}};
            Console.WriteLine("Expected 3. Actual: " + stonesRemoved.RemoveStones(stones));
            stones = new int[][]{new int[] {0,0}};
            Console.WriteLine("Expected 0. Actual: " + stonesRemoved.RemoveStones(stones));
        }

        public static void TestIntervalListInterections()
        {
            IntervalListIntersection intervalListIntersection = new IntervalListIntersection();
            int[][] A = new int[] []{new int[] {0,2}, new int[] {5,10}, new int[] {13,23}, new int[] {24,25}};
            int[][] B = new int[] []{new int[] {1,5}, new int[] {8,12}, new int[] {15,24}, new int[] {25,26}};
            Console.WriteLine("Expected output: [[1,2],[5,5],[8,10],[15,23],[24,24],[25,25]]");
            Console.WriteLine("Actual: ");
            int[][] result = intervalListIntersection.IntervalIntersection(A, B);
            for (int i = 0; i < result.Length; i++) Console.Write("[{0},{1}],", result[i][0], result[i][1]);
            Console.WriteLine();
        }

        public static void TestKClosestToOrigin()
        {
            KClosestToOrigin kClosest;
            int[][] input;
            int[][] result;
            // input = new int[][] {new int[] {1,3}, new int[] {-2, 2}};
            // Console.WriteLine("Expected: [-2, 2]");
            // Console.Write("Actual: ");
            // kClosest = new KClosestToOrigin();
            // result = kClosest.KClosest(input, 1);
            // foreach (int[] r in result) Console.Write("[{0}, {1}],", r[0], r[1]);
            // Console.WriteLine();

            // input = new int[][] {new int[] {3,3}, new int[] {5, -1}, new int[] {-2, 4}};
            // Console.WriteLine("Expected: [3, 3], [-2, 4]");
            // Console.Write("Actual");
            // kClosest = new KClosestToOrigin();
            // result = kClosest.KClosest(input, 2);
            // foreach (int[] r in result) Console.Write("[{0}, {1}],", r[0], r[1]);
            // Console.WriteLine();

            // input = new int[][] {new int[] {-2, 10}, new int[] {-4, -8}, new int[] {10, 7}, new int[] {-4, -7}};
            // Console.WriteLine("Expected: [-4, -7], [-4, -8], [-2, 10]");
            // Console.Write("Actual");
            // kClosest = new KClosestToOrigin();
            // result = kClosest.KClosest(input, 3);
            // foreach (int[] r in result) Console.Write("[{0}, {1}],", r[0], r[1]);
            // Console.WriteLine();

            // input = new int[][] {new int[] {2, 2}, new int[] {2, 2}, new int[] {2, 2}, new int[] {2, 2}, new int[] {2, 2}, new int[] {2, 2}, new int[] {1, 1}};
            // Console.WriteLine("Expected: [1, 1]");
            // Console.Write("Actual");
            // kClosest = new KClosestToOrigin();
            // result = kClosest.KClosest(input, 1);
            // foreach (int[] r in result) Console.Write("[{0}, {1}],", r[0], r[1]);
            
            input = new int[][] {new int[] {89,6}, new int[] {-39,-4}, new int[] {-13,91}, new int[] {97,-61}, new int[] {1,7}, new int[] {-66,69}, new int[] {-51,68}, new int[] {82,-6}, new int[] {-21,44}, new int[] {-58,-83}, new int[] {-40,73}, new int[] {-88,-24}};
            Console.WriteLine("Expected: [1,7],[-39,-4],[-21,44],[82,-6],[-40,73],[-51,68],[89,6],[-88,-24]");
            Console.Write("Actual");
            kClosest = new KClosestToOrigin();
            result = kClosest.KClosest(input, 8);
            foreach (int[] r in result) Console.Write("[{0}, {1}],", r[0], r[1]);            
        }

        public static void TestProductExceptSelf()
        {
            ProductExceptSelf product = new ProductExceptSelf();
            int[] nums = product.Calculate(new int[] {1,2,3,4});
            foreach (int n in nums) Console.Write(n + "\t");
            Console.WriteLine();
        }

        public static void TestBSTDoublyList()
        {
            // do nothing
        }

        public static void TestContinuousSubarraySum()
        {
            ContinuousSubarraySum c = new ContinuousSubarraySum();
            Console.WriteLine("Expected: True. Actual: " + c.CheckSubarraySum2(new int[] {23, 2, 4, 6, 7}, 6));
            Console.WriteLine("Expected: True. Actual: " + c.CheckSubarraySum2(new int[] {23, 2, 4, 6, 8}, 6));
            Console.WriteLine("Expected: True. Actual: " + c.CheckSubarraySum2(new int[] {22, 2, 5, 5, 9}, 6));
            Console.WriteLine("Expected: False. Actual: " + c.CheckSubarraySum2(new int[] {20, 2, 5, 4, 10}, 6));
            Console.WriteLine("Expected: True. Actual: " + c.CheckSubarraySum2(new int[] {20, 2, 5, 4, 11}, 6));
            Console.WriteLine("Expected: True. Actual: " + c.CheckSubarraySum2(new int[] {20, 2, 5, 4, 10, 0, 8, 0, 0}, 6));
            Console.WriteLine("Expected: True. Actual: " + c.CheckSubarraySum2(new int[] {0, 0}, 0));

            // Console.WriteLine("Expected: True. Actual: " + c.CheckSubarraySum(new int[] {23, 2, 4, 6, 7}, 6));
            // Console.WriteLine("Expected: True. Actual: " + c.CheckSubarraySum(new int[] {23, 2, 4, 6, 8}, 6));
            // Console.WriteLine("Expected: True. Actual: " + c.CheckSubarraySum(new int[] {22, 2, 5, 5, 9}, 6));
            // Console.WriteLine("Expected: False. Actual: " + c.CheckSubarraySum(new int[] {20, 2, 5, 4, 10}, 6));
            // Console.WriteLine("Expected: True. Actual: " + c.CheckSubarraySum(new int[] {20, 2, 5, 4, 11}, 6));
            // Console.WriteLine("Expected: True. Actual: " + c.CheckSubarraySum(new int[] {20, 2, 5, 4, 10, 0, 8, 0, 0}, 6));
            // Console.WriteLine("Expected: True. Actual: " + c.CheckSubarraySum(new int[] {0, 0}, 0));
        }

        public static void TestOneEditDistance()
        {
            OneEditDistance one = new OneEditDistance();
            Console.WriteLine("Expected: True. Actual: " + one.IsOneEditDistance(null, "s"));
            Console.WriteLine("Expected: True. Actual: " + one.IsOneEditDistance("t", null));
            Console.WriteLine("Expected: True. Actual: " + one.IsOneEditDistance("ta", "ts"));
            Console.WriteLine("Expected: True. Actual: " + one.IsOneEditDistance("taa", "ta"));
            Console.WriteLine("Expected: True. Actual: " + one.IsOneEditDistance("tat", "tst"));
            Console.WriteLine("Expected: False. Actual: " + one.IsOneEditDistance("taa", "tst"));
            Console.WriteLine("Expected: False. Actual: " + one.IsOneEditDistance("taa", "t"));
            Console.WriteLine("Expected: False. Actual: " + one.IsOneEditDistance("taa", "taa"));
            Console.WriteLine("Expected: False. Actual: " + one.IsOneEditDistance("", ""));
            Console.WriteLine("Expected: True. Actual: " + one.IsOneEditDistance("ca", "c"));
            Console.WriteLine("Expected: True. Actual: " + one.IsOneEditDistance("", "c"));
        }

        public static void TestNextPermutation()
        {
            NextPermutation nextPermutation = new NextPermutation();
            Console.WriteLine("Expected: 1 3 2 4. Actual: ");
            int[] nums = new int[] {1, 2, 4, 3};
            nextPermutation.Next(nums);
            foreach (int n in nums) Console.Write(n + " "); Console.WriteLine();

            Console.WriteLine("Expected: 1 2 3 4. Actual: ");
            nums = new int[] {4, 3, 2, 1};
            nextPermutation.Next(nums);
            foreach (int n in nums) Console.Write(n + " "); Console.WriteLine();            
        }

        public static void TestKthLargest()
        {
            KthLargetst kthLargetst = new KthLargetst();
            Console.WriteLine("Expected: 5. Actual: " + kthLargetst.FindKthLargest(new int[] {3,2,1,5,6,4}, 2));
            Console.WriteLine("Expected: 4. Actual: " + kthLargetst.FindKthLargest(new int[] {3,2,3,1,2,4,5,5,6}, 4));
            Console.WriteLine("Expected: 3. Actual: " + kthLargetst.FindKthLargest(new int[] {3,3,3,3,3,3,3,3,3}, 1));
        }

        public static void TestTopKFrequent()
        {
            // placeholder.
        }

        public static void TestBinaryTreeRightSideView() {
            // placeholder
        }

        public static void TestAccountsMerge() {
            // IList<IList<string>> accounts = new List<IList<string>>();
            // accounts.Add(new List<string> {"John", "johnsmith@mail.com", "john00@mail.com"});
            // accounts.Add(new List<string>() {"John", "johnnybravo@mail.com"});
            // accounts.Add(new List<string>() {"John", "johnsmith@mail.com", "john_newyork@mail.com"});
            // accounts.Add(new List<string>() {"Mary", "mary@mail.com"});
            // AccountsMerge acc = new AccountsMerge();
            // IList<IList<string>> result = acc.Merge(accounts);
            // foreach (List<string> r in result) {
            //     foreach (string s in r) {
            //         Console.Write(s + ", ");
            //     }
            //     Console.WriteLine();
            // }

            List<string> k = new List<string>();
            k.Add("n00");
            k.Add("n_0");
            k.Add("n11");
            k.Add("n_1");
            k.Sort();
            foreach (string s in k) Console.WriteLine(s);

        }

        public static void TestLongestSubstringKDistinctChars()
        {
            LongestSubstringKDistinctChars l = new LongestSubstringKDistinctChars();
            Console.WriteLine("Expected 16. Actual: " + l.LengthOfLongestSubstringKDistinct("aaaaabbbbbbaaaaacccccaa", 2));
            Console.WriteLine("Expected 12. Actual: " + l.LengthOfLongestSubstringKDistinct("aaaaabaaaaacccccaa", 2));
            Console.WriteLine("Expected 11. Actual: " + l.LengthOfLongestSubstringKDistinct("aaaaabaaaaacccccbb", 2));
            Console.WriteLine("Expected 18. Actual: " + l.LengthOfLongestSubstringKDistinct("aaaaabaaaaacccccbb", 3));
            Console.WriteLine("Expected 12. Actual: " + l.LengthOfLongestSubstringKDistinct("aaaaaaaaaaaab", 1));
            Console.WriteLine("Expected 12. Actual: " + l.LengthOfLongestSubstringKDistinct("baaaaaaaaaaaab", 1));
        }

        public static void TestLongestRepeatingChar()
        {
            LongestRepeatingChar l = new LongestRepeatingChar();
            Console.WriteLine("Expected: 7. Actual: " + l.CharacterReplacement("aabbabcccbcc", 2));
            Console.WriteLine("Expected: 7. Actual: " + l.CharacterReplacement("aabaaaab", 1));
            Console.WriteLine("Expected: 2. Actual: " + l.CharacterReplacement("abcdefghijklmnopqrstuvwxyz", 1));
            Console.WriteLine("Expected: 8. Actual: " + l.CharacterReplacement("aaaaaaaabbb", 0));
            Console.WriteLine("Expected: 4. Actual: " + l.CharacterReplacement("abab", 2));
            Console.WriteLine("Expected: 4. Actual: " + l.CharacterReplacement("AABABBA", 1));
            Console.WriteLine("Expected: 2. Actual: " + l.CharacterReplacement("ABAA", 0));
            Console.WriteLine("Expected: 4. Actual: " + l.CharacterReplacement("ABBB", 2)); // important test case
            Console.WriteLine("Expected: 5. Actual: " + l.CharacterReplacement("BAAAB", 2)); // important test case
        }

        public static void TestLongestWithoutRepeatingChars()
        {
            LongestWithoutRepeatingChars l = new LongestWithoutRepeatingChars();
            Console.WriteLine("Expected: 3. Actual: " + l.LengthOfLongestSubstring("abcabcbb"));
            Console.WriteLine("Expected: 1. Actual: " + l.LengthOfLongestSubstring("bbbbbbbbb"));
            Console.WriteLine("Expected: 3. Actual: " + l.LengthOfLongestSubstring("pwwkew"));
            Console.WriteLine("Expected: 5. Actual: " + l.LengthOfLongestSubstring("tmmzuxt"));
        }

        public static void TestMaxOnes()
        {
            MaxOnes max = new MaxOnes();
            Console.WriteLine("Expected: 6. Actual: " + max.LongestOnes(new int[] {1,1,1,0,0,0,1,1,1,1,0}, 2));
            Console.WriteLine("Expected: 10. Actual: " + max.LongestOnes(new int[] {0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1}, 3));
        }

        public static void TestDuctchFlag()
        {
            DutchFlag df = new DutchFlag();
            int[] result;
            result = df.Sort(new int[] {2,2,2,0,0,0,1,1});
            foreach (int r in result) Console.Write(r + " "); Console.WriteLine();
            result = df.Sort(new int[] {0,2,1,0,0,0,2,1});
            foreach (int r in result) Console.Write(r + " "); Console.WriteLine();
            result = df.Sort(new int[] {2,2,2,0,0,0,1,1,1,0,2,1,1,1,0,2,2,0,1,0,0});
            foreach (int r in result) Console.Write(r + " "); Console.WriteLine();
        }

        public static void TestThreeSumClosest()
        {
            ThreeSumClosest closest = new ThreeSumClosest();
            Console.WriteLine("Expected: 2. Actual: " + closest.Closest(new int[] {-1, 2, 1, -4}, 1));
            Console.WriteLine("Expected: -1. Actual: " + closest.Closest(new int[] {-1, -5, -10, 4, -20, 10, 4}, 1));
            Console.WriteLine("Expected: -2. Actual: " + closest.Closest(new int[] {-1, -5, -10, 4, -20, 10, 4}, -3));
            Console.WriteLine("Expected: -1. Actual: " + closest.Closest(new int[] {1,1,-1,-1,3}, -3));
        }

        public static void TestSortedSquares()
        {
            SortedSquares s = new SortedSquares();
            int[] result = s.Calculate(new int[] {-20, -5, -4, 0, 1, 2, 3 ,4 ,5, 6, 10});
            foreach (int r in result) Console.Write(r + " "); Console.WriteLine();
            result = s.Calculate(new int[] {-20});
            foreach (int r in result) Console.Write(r + " "); Console.WriteLine();            
        }

        public static void TestThreeSumSmaller()
        {
            ThreeSumSmaller closest = new ThreeSumSmaller();
            Console.WriteLine("Expected: 2. Actual: " + closest.Smaller(new int[] {-2,0,1,3}, 2));
            Console.WriteLine("Expected: 25. Actual: " + closest.Smaller(new int[] {-1, -5, -10, 4, -20, 10, 4}, 3));
        }

        public static void TestThreeSumMulti()
        {
            ThreeSumMulti multi = new ThreeSumMulti();
            Console.WriteLine("Expected: 10. Actual: " + multi.Calculate(new int[] {0,0,0,0,0}, 0));
            Console.WriteLine("Expected: 12. Actual: " + multi.Calculate(new int[] {1,1,2,2,2,2}, 5));
            Console.WriteLine("Expected: 20. Actual: " + multi.Calculate(new int[] {1,1,2,2,3,3,4,4,5,5}, 8));
            Console.WriteLine("Expected: 495500972. Actual: " + multi.Calculate(new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, 0));
        }

        public static void TestSubArrayProductLessThanK()
        {
            SubArrayProductLessThanK s = new SubArrayProductLessThanK();
            Console.WriteLine("Expected: 0. Actual: " + s.Calculate(new int[] {1, 2, 3}, 0));
            Console.WriteLine("Expected: 8. Actual: " + s.Calculate(new int[] {10, 5, 2, 6}, 100));
        }

        public static void TestSubarraySubDivisibleByK()
        {
            SubarraySumDivisibleByK div = new SubarraySumDivisibleByK();
            Console.WriteLine("Expected: 7. Actual: " + div.Calculate(new int[] {4,5,0,-2,-3,1}, 5));
        }

        public static void TestLinkedListCycle()
        {
            // dummy, but passed online judge
            LinkedListCycle cycle = new LinkedListCycle();
            cycle.HasCycle(null);
        }

        public static void TestHappyNumber()
        {
            // dummy, but passed online judge
            HappyNumber h = new HappyNumber();
            Console.WriteLine("Expected: True. Actual: " + h.IsHappy(19));
            Console.WriteLine("Expected: False. Actual: " + h.IsHappy(24));
        }

        public static void TestNonoverlappingIntervals() {
            NonoverlappingIntervals n = new NonoverlappingIntervals();
            int[][] input;
            input = new int[][] {new int[] {1,2}, new int[] {3,4}, new int[] {2,3}, new int[] {1,3}};
            Console.WriteLine("Expected: 1. Actual: " + n.EraseOverlapIntervals(input));
            input = new int[][] {new int[] {1,2}, new int[] {1,2}, new int[] {1,2}, new int[] {1,2}};
            Console.WriteLine("Expected: 3. Actual: " + n.EraseOverlapIntervals(input));
            input = new int[][] {new int[] {1,2}, new int[] {3,4}};
            Console.WriteLine("Expected: 0. Actual: " + n.EraseOverlapIntervals(input));
        }

        public static void TestDuplicateNumber()
        {
            DuplicateNumber d = new DuplicateNumber();
            Console.WriteLine("Expected: 2. Actual: " + d.FindDuplicate(new int[] {2, 2, 2, 2, 2 ,2}));
            Console.WriteLine("Expected: 2. Actual: " + d.FindDuplicate(new int[] {1, 3, 2, 4, 5, 2}));
        }

        public static void TestReverseLinkedList2()
        {
            ReverseLinkedList2 rev = new ReverseLinkedList2();
            rev.ReverseBetween(null, 0, 0);
        }

        public static void TestSearchInRotatedArray()
        {
            Console.WriteLine("Expected: 2. Actual: " + SearchInRotatedArray.GetIndex(new int[] {6,7,0,1,2,3,4,5}, 0));
            Console.WriteLine("Expected: 4. Actual: " + SearchInRotatedArray.GetIndex(new int[] {4,5,6,7,0,1,2,3}, 0));
            Console.WriteLine("Expected: 1. Actual: " + SearchInRotatedArray.GetIndex(new int[] {4,1}, 1));
            Console.WriteLine("Expected: 1. Actual: " + SearchInRotatedArray.GetIndex(new int[] {4,1}, 4));
            Console.WriteLine("Expected: 1. Actual: " + SearchInRotatedArray.GetIndex(new int[] {1,3}, 1));
            Console.WriteLine("Expected: 1. Actual: " + SearchInRotatedArray.GetIndex(new int[] {1,3}, 3));
            Console.WriteLine("Expected: 1. Actual: " + SearchInRotatedArray.GetIndex(new int[] {4,1,3}, 4));
            Console.WriteLine("Expected: 1. Actual: " + SearchInRotatedArray.GetIndex(new int[] {8,9,2,3,4}, 9));
        }

        public static void TestContainerWithMostWater(){
            ContainerWithMostWater water = new ContainerWithMostWater();
            Console.WriteLine("Expected: 1. Actual: " + water.MaxArea(new int[] {1,2}));
            Console.WriteLine("Expected: 2. Actual: " + water.MaxArea(new int[] {1,2,1}));
            Console.WriteLine("Expected: 49. Actual: " + water.MaxArea(new int[] {1,8,6,2,5,4,8,3,7}));
            Console.WriteLine("Expected: 20. Actual: " + water.MaxArea(new int[] {10,8,7,6,5,3}));
            Console.WriteLine("Expected: 45. Actual: " + water.MaxArea(new int[] {10,6,8,5,4,9,6,5,3}));
            Console.WriteLine("Expected: 72. Actual: " + water.MaxArea(new int[] {10,6,8,5,4,7,6,5,9}));
        }

        public static void TestFriendsOfAppropriateAges()
        {
            FriendsOfAppropriateAges friends = new FriendsOfAppropriateAges();
            Console.WriteLine("Expected: 2. Actual: " + friends.NumFriendRequests(new int[] {16,16}));
            Console.WriteLine("Expected: 2. Actual: " + friends.NumFriendRequests(new int[] {16,17,18}));
            Console.WriteLine("Expected: 3. Actual: " + friends.NumFriendRequests(new int[] {20,30,100,110,120}));
        }

        public static void TestLongestRepeatedSubstring()
        {
            LongestRepeatedSubstring lrs = new LongestRepeatedSubstring();
            Console.WriteLine("Expected: 3. Actual: " + lrs.LongestRepeatingSubstring("aabcaabdaab"));
            Console.WriteLine("Expected: 2. Actual: " + lrs.LongestRepeatingSubstring("abbaba"));
            Console.WriteLine("Expected: 4. Actual: " + lrs.LongestRepeatingSubstring("aaaaa"));
        }

        public static void TestRestoreIpAddress()
        {
            RestoreIpAddress restore = new RestoreIpAddress();
            IList<string> restored;
            restored = restore.RestoreIpAddresses("25525511135"); // Expected ["255.255.11.135","255.255.111.35"]
            foreach (string r in restored) Console.Write(r + " ");
            Console.WriteLine();

            restored = restore.RestoreIpAddresses("13112"); // expected ["1.3.1.12", "1.3.11.2", "1.31.1.2", "13.1.1.2"]
            foreach (string r in restored) Console.Write(r + " ");
            Console.WriteLine();

            restored = restore.RestoreIpAddresses("010010"); //expected: ["0.10.0.10", "0.100.1.0"]
            foreach (string r in restored) Console.Write(r + " ");
            Console.WriteLine();
        }

        public static void TestLongestArithmeticSequence()
        {
            LongestArithmeticSequence las = new LongestArithmeticSequence();
            Console.WriteLine("Expected: 4. Actual: " + las.LongestArithmeticSequenceLen(new int[] {3,6,9,12}));
            Console.WriteLine("Expected: 3. Actual: " + las.LongestArithmeticSequenceLen(new int[] {9,4,7,2,10}));
            Console.WriteLine("Expected: 4. Actual: " + las.LongestArithmeticSequenceLen(new int[] {20,1,15,3,10,5,8}));
            Console.WriteLine("Expected: 4. Actual: " + las.LongestArithmeticSequenceLen(new int[] {12,28,13,6,34,36,53,24,29,2,23,0,22,25,53,34,23,50,35,43,53,11,48,56,44,53,31,6,31,57,46,6,17,42,48,28,5,24,0,14,43,12,21,6,30,37,16,56,19,45,51,10,22,38,39,23,8,29,60,18}));
        }

        public static void TestArithmeticSlices()
        {
            ArithmeticSlices ar = new ArithmeticSlices();
            Console.WriteLine("Expected: 3. Actual: " + ar.CountSlices(new int[] {3,6,9,12}));
            Console.WriteLine("Expected: 10. Actual: " + ar.CountSlices(new int[] {1,2,3,4,5,6}));
        }

        public static void TestPartitionLabels()
        {
            PartitionLabels p = new PartitionLabels();
            IList<int> result;
            StringBuilder sb = new StringBuilder();
            result = p.Partition("ababfeefhijkh");
            foreach (int r in result) sb.Append(r + " ");
            Console.WriteLine("Expected: 4 4 5. Actual: " + sb.ToString());
            sb.Clear();

            result = p.Partition("ababcbacadefegdehijhklij");
            foreach (int r in result) sb.Append(r + " ");
            Console.WriteLine("Expected: 9 7 8. Actual: " + sb.ToString());
            sb.Clear();
        }

        public static void TestSentenceScreenFitting()
        {
            SentenceScreenFitting s = new SentenceScreenFitting();
            Console.WriteLine("Expected: 1. Actual: " + s.WordsTyping(new string[] {"hello", "world"}, 2, 8));
            Console.WriteLine("Expected: 2. Actual: " + s.WordsTyping(new string[] {"a", "bcd", "e"}, 3, 6));
            Console.WriteLine("Expected: 1. Actual: " + s.WordsTyping(new string[] {"I", "had", "apple", "pie"}, 4, 5));
            Console.WriteLine("Expected: 80000000. Actual: " + s.WordsTyping(new string[] {"a", "bc"}, 20000, 20000));
            Console.WriteLine("Expected: 848587. Actual: " + s.WordsTyping(new string[] {"abcdef","ghijkl","mnop","qrs","tuv","wxyz","asdf","ogfd","df","r","abcdef","ghijkl","mnop","qrs","tuv","wxyz","asdf","ogfd","df","r","abcdef","ghijkl","mnop","qrs","tuv","wxyz","asdf","ogfd","df","r","abcdef","ghijkl","mnop","qrs","tuv","wxyz","asdf","ogfd","df","r","abcdef","ghijkl","mnop","qrs","tuv","wxyz","asdf","ogfd","df","r","abcdef","ghijkl","mnop","qrs","tuv","wxyz","asdf","ogfd","df","r","abcdef","ghijkl","mnop","qrs","tuv","wxyz","asdf","ogfd","df","r","abcdef","ghijkl","mnop","qrs","tuv","wxyz","asdf","ogfd","df","r","abcdef","ghijkl","mnop","qrs","tuv","wxyz","asdf","ogfd","df","r","abcdef","ghijkl","mnop","qrs","tuv","wxyz","asdf","ogfd","df","r"}, 19948, 19994));
            Console.WriteLine("Expected: 363600. Actual: " + s.WordsTyping(new string[] {"aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa","aaaaaaaaaa"}, 20000, 20000));
            Console.WriteLine("Expected: 10. Actual: " + s.WordsTyping(new string[] {"f", "p", "a"}, 8, 7));
        }

        public static void TestFindMinimumInSortedArray()
        {
            FindMinimumInSortedRotatedArray f = new FindMinimumInSortedRotatedArray();
            Console.WriteLine("Expected: 0. Actual: "+ f.Find(new int[] {0,1,2,3,4,5,6}));
            Console.WriteLine("Expected: 0. Actual: "+ f.Find(new int[] {6,0,1,2,3,4,5}));
            Console.WriteLine("Expected: 0. Actual: "+ f.Find(new int[] {5,6,0,1,2,3,4}));
            Console.WriteLine("Expected: 0. Actual: "+ f.Find(new int[] {4,5,6,0,1,2,3}));
            Console.WriteLine("Expected: 0. Actual: "+ f.Find(new int[] {3,4,5,6,0,1,2}));
            Console.WriteLine("Expected: 0. Actual: "+ f.Find(new int[] {2,3,4,5,6,0,1}));
            Console.WriteLine("Expected: 0. Actual: "+ f.Find(new int[] {1,2,3,4,5,6,0}));
            // with duplicates
            Console.WriteLine("Expected: 1. Actual: "+ f.Find(new int[] {1,2,3,3,3,3,3}));
            Console.WriteLine("Expected: 1. Actual: "+ f.Find(new int[] {3,1,2,3,3,3,3}));
            Console.WriteLine("Expected: 1. Actual: "+ f.Find(new int[] {3,3,1,2,3,3,3}));
            Console.WriteLine("Expected: 1. Actual: "+ f.Find(new int[] {3,3,3,1,2,3,3}));
            Console.WriteLine("Expected: 1. Actual: "+ f.Find(new int[] {3,3,3,3,1,2,3}));
            Console.WriteLine("Expected: 1. Actual: "+ f.Find(new int[] {3,3,3,3,3,1,2}));
            Console.WriteLine("Expected: 1. Actual: "+ f.Find(new int[] {2,3,3,3,3,3,1}));
        }

        public static void TestLongestIncreasingSubsequence()
        {
            LongestIncreasingSubsequence lis = new LongestIncreasingSubsequence();
            Console.WriteLine("Expected: 5. Actual: " + lis.LengthOfLIS(new int[] {9,1,5,8,9,3,4,5,6}));
            Console.WriteLine("Expected: 5. Actual: " + lis.LengthOfLIS(new int[] {9,1,5,1,8,9,3,3,3,4,5,6}));
        }

        public static void TestHIndex() {
            HIndex h = new HIndex();
            Console.WriteLine("Expected: 3. Actual: " + h.Find(new int[] {3,0,6,1,5}));
            Console.WriteLine("Expected: 5. Actual: " + h.Find(new int[] {2,2,4,4,4,4,5,6,7,8,9}));
            Console.WriteLine("Expected: 2. Actual: " + h.Find(new int[] {3,3}));
            Console.WriteLine("Expected: 0. Actual: " + h.Find(new int[] {}));
            Console.WriteLine("Expected: 0. Actual: " + h.Find(new int[] {0}));
            Console.WriteLine("Expected: 1. Actual: " + h.Find(new int[] {0,1}));
            Console.WriteLine("Expected: 5. Actual: " + h.Find(new int[] {2,2,4,4,4,4,5,6,7,8,9}));
        }

        public static void TestIsomorphicStrings()
        {
            IsomorphicStrings iso = new IsomorphicStrings();
            Console.WriteLine("Expected: True. Actual: " + iso.IsIsomorphic("egg", "ebb"));
            Console.WriteLine("Expected: True. Actual: " + iso.IsIsomorphic("egg", "taa"));
            Console.WriteLine("Expected: False. Actual: " + iso.IsIsomorphic("ebb", "ego"));
            Console.WriteLine("Expected: False. Actual: " + iso.IsIsomorphic("foo", "bar"));
            Console.WriteLine("Expected: True. Actual: " + iso.IsIsomorphic("paper", "title"));
            Console.WriteLine("Expected: False. Actual: " + iso.IsIsomorphic("ab", "aa"));
            Console.WriteLine("Expected: True. Actual: " + iso.IsIsomorphic("ab", "ca"));
        }

        public static void TestMaximumSizeSubarraySumK()
        {
            MaximumSizeSubarraySumK max = new MaximumSizeSubarraySumK();
            Console.WriteLine("Expected: 4. Actual: " + max.MaxSubArrayLen(new int[] {-1, 1, 1, 1, 0, 3, 8}, 3));
            Console.WriteLine("Expected: 4. Actual: " + max.MaxSubArrayLen(new int[] {1, -1, 5, -2, 3}, 3));
            Console.WriteLine("Expected: 2. Actual: " + max.MaxSubArrayLen(new int[] {-2, -1, 2, 1}, 1));
        }

        public static void TestMajorityElement2()
        {
            MajorityElement2 m = new MajorityElement2();
            Console.WriteLine("Expected: [3]. Actual: " + GetListOfIntAsString(m.Find(new int[] {3,2,3})));
            Console.WriteLine("Expected: [2,3]. Actual: " + GetListOfIntAsString(m.Find(new int[] {2,2,2,1,1,3,3,3})));
            Console.WriteLine("Expected: []. Actual: " + GetListOfIntAsString(m.Find(new int[] {2,2,2,1,1,1,3,3,3})));
            Console.WriteLine("Expected: [3]. Actual: " + GetListOfIntAsString(m.Find(new int[] {2,2,2,1,1,1,3,3,3,3})));
            Console.WriteLine("Expected: [2]. Actual: " + GetListOfIntAsString(m.Find(new int[] {2,2})));
            Console.WriteLine("Expected: [2,1]. Actual: " + GetListOfIntAsString(m.Find(new int[] {1,2,2,3,2,1,1,3})));
        }

        public static void TestWordLadder()
        {
            WordLadder w = new WordLadder();
            Console.WriteLine("Expected: 5. Actual: " + w.LadderLength("hit", "cog", new List<string>() {"hot","dot","dog","lot","log","cog"}));
            Console.WriteLine("Expected: 0. Actual: " + w.LadderLength("hit", "cog", new List<string>() {"hot","dot","dog","lot","log"}));
            Console.WriteLine("Expected: 0. Actual: " + w.LadderLength("hot", "dog", new List<string>() {"hot","dog"}));
            Console.WriteLine("Expected: 2. Actual: " + w.LadderLength("hot", "hog", new List<string>() {"hot","hog"}));
        }

        public static void TestRangeAddition()
        {
            RangeAddition r = new RangeAddition();
            int[][] input;
            input = new int[][] {new int[] {1,3,2}, new int[] {2,4,3}, new int[] {0,2,-2}};
            Console.WriteLine("Expected: [-2,0,3,5,3]. Actual: " + GetListOfIntAsString(r.GetModifiedArray(5, input)));
        }

        public static void TestConcordance()
        {
            List<string> inputLines = new List<string>();
            // inputLines.Add("Wait a minute. Wait a minute, Doc.");
            // inputLines.Add("Are you telling me that you built");
            // inputLines.Add("a time machine out of a DeLorean?");
            // Concordance.GenerateAndPrintConcordance(inputLines);

            inputLines.Add("Given an arbitrary text document written in English, write a program that will generate a");
            inputLines.Add("concordance, i.e. an alphabetical list of all word occurrences, labeled with word ");
            inputLines.Add("frequencies.");
            inputLines.Add("Bonus: label each word with the sentence numbers in which each occurrence appeared.");
            Concordance.GenerateAndPrintConcordance(inputLines);
        }

        public static void TestUglyNumber2()
        {
            UglyNumber2 ugly = new UglyNumber2();
            Console.WriteLine("Expected: 6. Actual: " + ugly.NthUglyNumber(6));
            Console.WriteLine("Expected: 9. Actual: " + ugly.NthUglyNumber(8));
            Console.WriteLine("Expected: 12. Actual: " + ugly.NthUglyNumber(10));
        }

        public static void TestSearch2DMatrix()
        {
            Search2DMatrix s = new Search2DMatrix();
            int[][] matrix;
            matrix = new int[][] {new int[] {1,3,5,7}, new int[] {10,11,16,20}, new int[] {23,30,34,50}};
            Console.WriteLine("Expected: True. Actual: " + s.SearchMatrix(matrix, 3));
            Console.WriteLine("Expected: False. Actual: " + s.SearchMatrix(matrix, 13));
        }

        public static void TestKthSmallestInSortedMatrix()
        {
            KthSmallestInSortedMatrix s = new KthSmallestInSortedMatrix();
            int[][] matrix;
            matrix = new int[][] {new int[] {1,8,21}, new int[] {4,8,23}, new int[] {6,13,25}};
            Console.WriteLine("Expected: 6. Actual: " + s.KthSmallest(matrix, 3));
            Console.WriteLine("Expected: 8. Actual: " + s.KthSmallest(matrix, 5));
            Console.WriteLine("Expected: 13. Actual: " + s.KthSmallest(matrix, 6));
            Console.WriteLine("Expected: 23. Actual: " + s.KthSmallest(matrix, 8));
        }
        
        public static void TestNumberOfConnectedComponentsUG()
        {
            NumberOfConnectedComponentsUG n = new NumberOfConnectedComponentsUG();
            int[][] input = new int[][] {new int[]{0,1},new int[]{1,2},new int[]{3,4}};
            Console.WriteLine("Expected: 2. Actual: " + n.CountComponents(5, input));
            input = new int[][] {new int[]{0,1},new int[]{1,2},new int[]{2,3},new int[]{3,4}};
            Console.WriteLine("Expected: 1. Actual: " +n.CountComponents(5, input));
        }

        public static void TestWallsAndGates()
        {
            WallsAndGates wallsAndGates = new WallsAndGates();
            int inf = int.MaxValue;
            int[][] rooms = new int[][] {
                new int[]{inf,-1,0,inf},
                new int[]{inf,inf,inf,-1},
                new int[]{inf,-1,inf,-1},
                new int[]{0,-1,inf,inf}};
            wallsAndGates.Find(rooms);
        }
    }
}