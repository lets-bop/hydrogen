using System;
using System.Collections.Generic;

namespace LC_FB_Hard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // TestRegexMatching();
            // TestMinWindowSubstring();
            // TestMaximalRectangle();
            // TestLRUCache();
            // TestBinarySearchWithTwist();
            // TestMinPQ_FixedSize();
            // TestLargestRectangleInHist();
            // TestWildcardMatching();
            // TestReversePairs();
            // TestWordLadder();
            // TestLongestConsecutiveSequence();
            // TestNumberToEnglish();
            // TestSubstringWithConcat();
            TestAlientDictionary();
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

        private static void TestBinarySearchWithTwist()
        {
            Console.WriteLine("Expected: 8 Actual: ", BinarySearchWithTwist.Find(4, new int[] {1,1,1,1,2,3,4,4,4,4,5,6,7,7,8,8,9}));
            Console.WriteLine("Expected: 0 Actual: ", BinarySearchWithTwist.Find(0, new int[] {1,1,1,1,2,3,4,4,4,4,5,6,7,7,8,8,9}));
            Console.WriteLine("Expected: 10 Actual: ", BinarySearchWithTwist.Find(5, new int[] {1,1,1,1,2,3,4,4,4,4,6,6,7,7,8,8,9}));
            Console.WriteLine("Expected: 0 Actual: ", BinarySearchWithTwist.Find(5, new int[] {}));
            Console.WriteLine("Expected: 1 Actual: ", BinarySearchWithTwist.Find(5, new int[] {1}));
        }

        private static void TestMinPQ_FixedSize()
        {
            MinPQ_FixedSize pq = new MinPQ_FixedSize(20);
            pq.Insert(10);
            pq.Insert(100);
            pq.Insert(5);
            pq.Insert(7);
            pq.Insert(3);
            pq.Insert(1);
            pq.Insert(4);
            pq.Insert(11);
            pq.Print();
            pq.Delete(7); // element at index 7 = 100
            pq.Print();
            pq.Insert(100);
            pq.Print();
            pq.Delete(2);
            pq.Print();
            pq.Insert(3);
            pq.Print();
            pq.Delete(1);
            pq.Print();
        }

        private static void TestLargestRectangleInHist()
        {
            Console.WriteLine("Expected: 10. Actual: " + LargestRectangleInHist.Execute(new int[] {2,1,5,6,2,3}));
        }

        private static void TestWildcardMatching()
        {
            Console.WriteLine("Expected: True. Actual: " + WildcardMatching.IsMatch("hi there", "*"));
            Console.WriteLine("Expected: True. Actual: " + WildcardMatching.IsMatch("hi there", "hi*"));
            Console.WriteLine("Expected: False. Actual: " + WildcardMatching.IsMatch("hi there", "his*"));
            Console.WriteLine("Expected: False. Actual: " + WildcardMatching.IsMatch("hi there", "hi*s*"));
            Console.WriteLine("Expected: True. Actual: " + WildcardMatching.IsMatch("hi there", "hi*t*"));
            Console.WriteLine("Expected: True. Actual: " + WildcardMatching.IsMatch("hi there", "hi?t*"));
            Console.WriteLine("Expected: True. Actual: " + WildcardMatching.IsMatch("adceb", "*a*b"));
            Console.WriteLine("Expected: True. Actual: " + WildcardMatching.IsMatch("", "*"));
        }

        private static void TestReversePairs()
        {
            Console.WriteLine("Expected: 2. Actual: " + ImpReversePairs.Execute(new int[] {1,3,2,3,1}));
            Console.WriteLine("Expected: 3. Actual: " + ImpReversePairs.Execute(new int[] {2,4,3,5,1}));
            Console.WriteLine("Expected: 0. Actual: " + ImpReversePairs.Execute(new int[] {2147483647,2147483647,2147483647,2147483647,2147483647,2147483647}));
            Console.WriteLine("Expected: 40. Actual: " + ImpReversePairs.Execute(new int[] {233,2000000001,234,2000000006,235,2000000003,236,2000000007,237,2000000002,2000000005,233,233,233,233,233,2000000004}));
        }

        private static void TestWordLadder()
        {
            WordLadder wl = new WordLadder();
            IList<IList<string>> ladders = wl.FindLadders("hit", "cog", new List<string>() {"hot","dot","dog","lot","log","cog"});
            foreach (IList<string> ladder in ladders)
            {
                foreach(string s in ladder) Console.Write(s + " ");
                Console.WriteLine();
            }

            wl = new WordLadder();
            ladders = wl.FindLadders("a", "c", new List<string>() {"a","b","c"});
            foreach (IList<string> ladder in ladders)
            {
                foreach(string s in ladder) Console.Write(s + " ");
                Console.WriteLine();
            }   

            wl = new WordLadder();
            ladders = wl.FindLadders("red", "tax", new List<string>() {"ted","tex","red","tax","tad","den","rex","pee"});
            foreach (IList<string> ladder in ladders)
            {
                foreach(string s in ladder) Console.Write(s + " ");
                Console.WriteLine();
            }                       
        }  

        private static void TestLongestConsecutiveSequence()
        {
            LongestConsecutiveSequence lcs = new LongestConsecutiveSequence();
            Console.WriteLine(lcs.LongestConsecutive(new int[] {100, 4, 200, 1, 3, 2}));
        }

        private static void TestNumberToEnglish()
        {
            NumberToEnglish n = new NumberToEnglish();
            n.NumberToWords(99);
        }

        private static void TestSubstringWithConcat()
        {
            SubstringWithConcat sub = new SubstringWithConcat();
            sub.FindSubstring("foosbarfoo", new string[] {"bar", "foo", "foo"});
            sub.FindSubstring("barfoofoo", new string[] {"bar", "foo", "foo"});
            sub.FindSubstring("foofoobar", new string[] {"bar", "foo", "foo"});
            sub.FindSubstring("barfoothefoobarman", new string[] {"foo", "bar"});
            sub.FindSubstring("wordgoodstudentgoodword", new string[] {"word", "student"});
            sub.FindSubstring("barfoofoobarthefoobarman", new string[] {"bar","foo","the"});
            sub.FindSubstring("lingmindraboofooowingdingbarrwingmonkeypoundcake", new string[] {"fooo","barr","wing","ding","wing"});
            sub.FindSubstring("ababaab", new string[] {"ab","ba","ba"});        
            sub.FindSubstring("aaaaaa", new string[] {"aa","aa"});  
        }

        private static void TestAlientDictionary()
        {
            AlienDictionary dic = new AlienDictionary();
            Console.WriteLine(dic.AlienOrder(new string[] {  "wrt", "wrf", "er", "ett", "rftt"}));
        }
    }
}
