using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    class Program
    {
        static void Main(string[] args)
        {
            // ---- Search in a sorted rotated array ----
            // Console.WriteLine(SearchInRotatedArray.GetIndex(new int[] {6,7,0,1,2,3,4,5}, 0));
            // Console.WriteLine(SearchInRotatedArray.GetIndex(new int[] {4,5,6,7,0,1,2,3}, 0));

            // ---- Group anagrams ----
            // GroupAnagrams.Process(new string[] {"bat","iceman","are","ear","tab","cinema","era"});

            // // ---- Calculate pow(x,n) ----
            // Console.WriteLine("Pow(4,11) = {0}", Pow.Calculate(4, 11));
            // Console.WriteLine("Pow(2.1,3) = {0}", Pow.Calculate((float)2.1, 3));
            // Console.WriteLine("Pow(2,-4) = {0}", Pow.Calculate(2, -2));

            // Calculate PowModM(x,n,m) ----
            // Console.WriteLine("PowModM(3,2,4) = {0}", PowModM.Calculate(3,2,4));
            // Console.WriteLine("PowModM(3,3,4) = {0}", PowModM.Calculate(3,3,4));

            // // ---- Merge intervals ----
            // List<Interval> intervals = new List<Interval>();
            // Interval i1 = new Interval(2, 6);
            // intervals.Add(i1);
            // i1 = new Interval(5, 10);
            // intervals.Add(i1);
            // i1 = new Interval(1, 4);
            // intervals.Add(i1);
            // i1 = new Interval(12, 15);
            // intervals.Add(i1);
            // List<Interval> merged = MergeIntervals.Merge(intervals);
            // foreach (Interval i in merged)
            //     Console.Write("[{0}, {1}]\t", i.Start, i.End);
            // Console.WriteLine();

            // // Arbitrary Precision Integer multiplication
            // Console.WriteLine("Result is {0}. Expected is 147573952589676412927", ArbitraryIntegerMultiplication.Mulitply(new int[] {1,9,3,7,0,7,7,2,1}, new int[] {7,6,1,8,3,8,2,5,7,2,8,7}));

            // Test_EPI_Primitives.Run();

            // Test_EPI_Arrays.Run();

            // Test_EPI_Strings.Run();

            // Test_EPI_Lists.Run();

            Test_EPI_Trees.Run();
        }
    }
}
