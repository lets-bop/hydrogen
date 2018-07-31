using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class Test_EPI_Strings
    {
        public static void Run()
        {
            TestLookAndSay();
            TestPhoneMnemonics();
        }

        private static void TestLookAndSay()
        {
            LookAndSay.Execute(8);
        }

        private static void TestPhoneMnemonics()
        {
            PhoneMnemonics.Execute("23");
        }
    }
}





