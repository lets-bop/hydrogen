using System;

namespace LC_FB_Hard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // TestRegexMatching();
            // TestMinWindowSubstring();
            // TestMaximalRectangle();
            TestLRUCache();
        }

        public static void TestRegexMatching()
        {
            // Console.WriteLine("Str: mi, pattern mis* Expected: True. Actual: {0}", RegexMatching.Execute("mi", "mis*"));
            Console.WriteLine("Str: mississippi, pattern mis*is*ip*.. Expected: True. Actual: {0}", RegexMatching.Execute("mississippi", "mis*is*ip*."));
            // Console.WriteLine("Str: ad, pattern a*b*c*d. Expected: True. Actual: {0}", RegexMatching.Execute("ad", "a*b*c*d"));
            // Console.WriteLine("Str: aaccd, pattern a*b*c*d. Expected: True. Actual: {0}", RegexMatching.Execute("aaccd", "a*b*c*d"));
            // Console.WriteLine("Str: aacad, pattern a*b*c*d. Expected: False. Actual: {0}", RegexMatching.Execute("aacad", "a*b*c*d"));
        }

        public static void TestMinWindowSubstring()
        {
            Console.WriteLine("s = dddaaababaca, t = abc. Expected: bac. Actual: {0}", MinWindowSubstring.Execute("dddaaababaca", "abc"));
            Console.WriteLine("s = dddaaababbcac, t = abc. Expected: bca. Actual: {0}", MinWindowSubstring.Execute("dddaaababbcac", "abc"));
            Console.WriteLine("s = dddaaababbcac, t = aabc. Expected: abbca. Actual: {0}", MinWindowSubstring.Execute("dddaaababbcac", "aabc"));
            Console.WriteLine("s = dddaaababbcac, t = aaabc. Expected: aababbc. Actual: {0}", MinWindowSubstring.Execute("dddaaababbcac", "aaabc"));
            Console.WriteLine("s = dddaaababbcac, t = aaaa. Expected: aaaba. Actual: {0}", MinWindowSubstring.Execute("dddaaababbcac", "aaaa"));
            Console.WriteLine("s = ADOBECODEBANC, t = ABC. Expected: BANC. Actual: {0}", MinWindowSubstring.Execute("ADOBECODEBANC", "ABC"));
            Console.WriteLine("s = a, t = b. Expected: ''. Actual: {0}", MinWindowSubstring.Execute("a", "b"));
        }

        public static void TestMaximalRectangle()
        {
            char[,] rectangle = new char[,] {{'1'}};
            Console.WriteLine(MaximalRectangle.Execute(rectangle));

            rectangle = new char[,] {{'1', '0'}};
            Console.WriteLine(MaximalRectangle.Execute(rectangle));            

            rectangle = new char[,] {{'1','0','1','0','0'}, {'1','0','1','1','1'}, {'1','1','1','1','1'}, {'1','0','0','1','0'}};
            Console.WriteLine(MaximalRectangle.Execute(rectangle));

            rectangle = new char[,] {{'1','0','1','0'}, {'1','0','1','1'}, {'1','0','1','1'}, {'1','1','1','1'}};
            Console.WriteLine(MaximalRectangle.Execute(rectangle));

            rectangle = new char[,] {
                {'1','1','1','1','0','0'},
                {'0','1','1','1','0','0'},
                {'0','1','1','1','0','0'},
                {'0','1','1','1','0','0'},
                {'0','1','1','1','0','0'},
                {'0','0','1','1','1','1'},
                {'0','0','0','1','1','1'}};
            Console.WriteLine(MaximalRectangle.Execute(rectangle));

            rectangle = new char[,] {
                {'1','1','1','1','1','1'},
                {'0','1','1','1','1','1'},
                {'0','0','1','1','1','1'},
                {'0','0','0','1','1','1'},
                {'0','0','0','0','1','1'},
                {'0','0','0','0','0','1'},
                {'0','0','0','0','0','0'},};
            Console.WriteLine(MaximalRectangle.Execute(rectangle));                            
        }

        public static void TestLRUCache()
        {
            LRUCache cache = new LRUCache(2);
            // cache.Put(1, 1);
            // cache.Put(2, 2);
            // Console.WriteLine(cache.Get(1));       // returns 1
            // cache.Put(3, 3);    // evicts key 2
            // cache.Print();
            // Console.WriteLine(cache.Get(2));       // returns -1 (not found)
            // cache.Put(4, 4);    // evicts key 1
            // Console.WriteLine(cache.Get(1));       // returns -1 (not found)
            // Console.WriteLine(cache.Get(3));       // returns 3
            // Console.WriteLine(cache.Get(4));       // returns 4

            // Test case 2
            // ["LRUCache","put","put","put","put","get","get"]
            // [[2],[2,1],[1,1],[2,3],[4,1],[1],[2]]
            // cache = new LRUCache(2);
            // cache.Put(2,1);
            // cache.Put(1,1);
            // cache.Put(2,3);
            // cache.Print();
            // cache.Put(4,1);
            // cache.Print();
            // Console.WriteLine(cache.Get(1));
            // Console.WriteLine(cache.Get(2));
            // cache.Print();

            // Test case 3
            // cache = new LRUCache(1);
            // cache.Put(2,1);
            // cache.Get(2);
            // cache.Print();

            // Test case 4
            // ["LRUCache","put","put","get","put","put","get"]
            // [[2],[2,1],[2,2],[2],[1,1],[4,1],[2]]                      
            cache = new LRUCache(2);
            cache.Put(2,1);
            cache.Put(2,2);
            cache.Print();
            Console.WriteLine(cache.Get(2));
            cache.Print();
            cache.Put(1,1);
            cache.Put(4,1);
            cache.Print();
            Console.WriteLine(cache.Get(2));
            cache.Print();           
        }
    }
}
