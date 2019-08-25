using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class Test_EPI_Arrays
    {
        public static void Run()
        {
            // TestDutchFlag();
            // TestIncrementArbitraryPrecisionInteger();
            // TestMultiplyArbitraryIntegers();
            // TestBuySellStockTwice(); 
            // TestPermuteArray();
            TestSpiralOrder();
        }

        private static void TestDutchFlag()
        {
            int[] balls = new int[] {2,2,2,0,0,0,1,1,1,0,2,1,1,1,0,2,2,0,1,0,0};
            DutchFlag df = new DutchFlag();

            df.Sort(balls);
            Console.WriteLine("Sorted list is ");
            foreach (int ball in balls) Console.Write(ball + "\t");
            Console.WriteLine();
        }

        private static void TestIncrementArbitraryPrecisionInteger()
        {
            List<int> input = new List<int>() {9, 9};
            IncrementArbitraryPrecisionInteger.Execute(input);
            Console.Write("Input: 99. Output is: ");
            foreach (int i in input) Console.Write(i + "");
            Console.WriteLine();

            input = new List<int>() {1, 9, 9};
            IncrementArbitraryPrecisionInteger.Execute(input);
            Console.Write("Input: 199. Output is: ");
            foreach (int i in input) Console.Write(i + "");
            Console.WriteLine();       
        }

        private static void TestMultiplyArbitraryIntegers()
        {
            string output = MultiplyArbitraryIntegers.Execute(
                new int[] {1,9,3,7,0,7,7,2,1}, 
                new int[] {7,6,1,8,3,8,2,5,7,2,8,7});
            Console.WriteLine("Result is {0}. Expected is 147573952589676412927", output);     
        }

        private static void TestBuySellStockTwice()
        {
            int max = BuySellStockTwice.Execute(new List<int> {310, 315, 275, 295, 260, 270, 290, 230, 255, 250});
            Console.WriteLine("Max profit is {0}. Expected: 55", max);
        }

        private static void TestPermuteArray()
        {
            List<int> input = new List<int>() {1,2,3,4,5};
            PermuteArray.Execute(input, new List<int>() {4, 1, 0, 3, 2});
            foreach (int i in input) Console.Write(i + " "); Console.WriteLine("Expected is 3 2 5 4 1");

            input = new List<int>() {1,2,3,4,5};
            PermuteArray.Execute(input, new List<int>() {1, 4, 2, 0, 3});
            foreach (int i in input) Console.Write(i + " "); Console.WriteLine("Expected is 4 1 3 5 2");
        }

        private static void TestSpiralOrder()
        {
            int[,] input = new int[,] { {1,2,3,4}, {5,6,7,8}, {9,10,11,12}, {13,14,15,16} };
            foreach (int i in input) Console.Write(i + " "); Console.WriteLine();
            List<int> output = SpiralOrder.Execute(input, 4);
            foreach (int i in output) Console.Write(i + " "); Console.WriteLine("Expected 1 2 3 4 8 12 16 15 14 13 9 5 6 7 11 10");
        }
    }    
}