using System;

namespace LC_FB_Hard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TestRegexMatching();
        }

        public static void TestRegexMatching()
        {
            Console.WriteLine("Str: ad, pattern a*b*c*d. Expected: True. Actual: {0}", RegexMatching.Execute("ad", "a*b*c*d"));
            Console.WriteLine("Str: aaccd, pattern a*b*c*d. Expected: True. Actual: {0}", RegexMatching.Execute("aaccd", "a*b*c*d"));
            Console.WriteLine("Str: aacad, pattern a*b*c*d. Expected: False. Actual: {0}", RegexMatching.Execute("aacad", "a*b*c*d"));
        }
    }
}
