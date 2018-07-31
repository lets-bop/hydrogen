using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class Test_EPI_Primitives
    {
        public static void Run()
        {
            // TestParity();
            // TestReverseBits();
            // TestMultiply();
            // TestDivision();
            TestExponentiation();
        } 

        private static void TestParity()
        {
            List<long> nums = new List<long>();
            nums.Add(0x32FFACFF32321212); // 11001011111111101011001111111100110010001100100001001000010010 (odd parity)
            nums.Add(0x32FFACFF32321213); // 11001011111111101011001111111100110010001100100001001000010011 (even parity)
            Parity.Execute(nums);
        }   

        private static void TestReverseBits()
        {
            List<long> nums = new List<long>();
            nums.Add(0x32FFACFF32321210); // 01001011111111101011001111111100110010001100100001001000010010
            ReverseBits.Execute(nums);
        }     

        public static void TestMultiply()
        {
            Console.WriteLine("{0} * {1} = {2}", 4, 1, Multiply.Execute(4, 1));
            Console.WriteLine("{0} * {1} = {2}", 4, 4, Multiply.Execute(4, 4));
            Console.WriteLine("{0} * {1} = {2}", -4, 20, Multiply.Execute(-4, 20));
            Console.WriteLine("{0} * {1} = {2}", 5, -27, Multiply.Execute(5, -27));
            Console.WriteLine("{0} * {1} = {2}", -4, -5, Multiply.Execute(-4, -5));
        }

        public static void TestDivision()
        {
            Console.WriteLine("{0} / {1} = {2}", 4, 1, Division.Execute(4, 1));
            Console.WriteLine("{0} / {1} = {2}", 4, 2, Division.Execute(4, 2));
            Console.WriteLine("{0} / {1} = {2}", 4, 3, Division.Execute(4, 3));
            Console.WriteLine("{0} / {1} = {2}", 100, -3, Division.Execute(100, -3));
            Console.WriteLine("{0} / {1} = {2}", -25600, 33, Division.Execute(-25600, 33));
        }  

        public static void TestExponentiation()
        {
            Console.WriteLine("{0} ^ {1} = {2}", 4, 1, Exponentiation.Execute(4, 1));
            Console.WriteLine("{0} ^ {1} = {2}", 4, 4, Exponentiation.Execute(4, 4));
            Console.WriteLine("{0} ^ {1} = {2}", 4, -4, Exponentiation.Execute(4, -4));
            Console.WriteLine("{0} ^ {1} = {2}", -4, 4, Exponentiation.Execute(-4, 4));
            Console.WriteLine("{0} ^ {1} = {2}", -4, 5, Exponentiation.Execute(-4, 5));
            Console.WriteLine("{0} ^ {1} = {2}", -4, -5, Exponentiation.Execute(-4, -5));
            Console.WriteLine("{0} ^ {1} = {2}", 4, 0, Exponentiation.Execute(4, 0));
        }      
    }
}