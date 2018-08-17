using System;
using System.Collections.Generic;
using System.Text;

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
            // TestAlientDictionary();
            // TestLongestValidParenthesis();
            // TestMedianOfSortedArrays();
            // TestWordBreak();
            // TestWordSearch();
            TestInsertInterval();
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

        private static void TestLongestValidParenthesis()
        {
            LongestValidParenthesis valid = new LongestValidParenthesis();
            // Console.WriteLine("Expected: 2. Actual: " + valid.Find("(((()"));
            // Console.WriteLine("Expected: 4. Actual: " + valid.Find(")()())"));
            // Console.WriteLine("Expected: 4. Actual: " + valid.Find("())((())"));
            // Console.WriteLine("Expected: 2. Actual: " + valid.Find("()(()"));

            Console.WriteLine("Expected: 2. Actual: " + valid.FindWithoutExtraSpace("(()"));
            Console.WriteLine("Expected: 4. Actual: " + valid.FindWithoutExtraSpace(")()())"));
            Console.WriteLine("Expected: 4. Actual: " + valid.FindWithoutExtraSpace("())((())"));
            Console.WriteLine("Expected: 2. Actual: " + valid.FindWithoutExtraSpace("()(()"));
        }

        private static void TestMedianOfSortedArrays()
        {
            MedianOfTwoSortedArrays median = new MedianOfTwoSortedArrays();
            // Console.WriteLine("Expected: 3. Actual: " + median.Find(new int[] {}, new int[] {1,2,3,4,5}));
            // Console.WriteLine("Expected 3. Actual: " + median.Find(new int[] {1,2,3,4,5}, new int[] {}));
            // Console.WriteLine("Expected: 3.5. Actual: " + median.Find(new int[] {}, new int[] {1,2,3,4,5,6}));
            // Console.WriteLine("Expected 3.5. Actual: " + median.Find(new int[] {1,2,3,4,5,6}, new int[] {})); 
            Console.WriteLine("Expected: 2. Actual: " + median.Find(new int[] {1,3}, new int[] {2}));
            Console.WriteLine("Expected: 4. Actual: " + median.Find(new int[] {1,3}, new int[] {2,4,5,6,7}));
            Console.WriteLine("Expected: 9. Actual: " + median.Find(new int[] {1,3}, new int[] {2,4,5,6,7,8,9,10,11,12,13,14,15,16,17}));
            Console.WriteLine("Expected: 9. Actual: " + median.Find(new int[] {1}, new int[] {2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17}));
            Console.WriteLine("Expected: 4. Actual: " + median.Find(new int[] {1,3,4,6}, new int[] {2,5,7}));
            Console.WriteLine("Expected: 4. Actual: " + median.Find(new int[] {2,5,7}, new int[] {1,3,4,6}));
            // Console.WriteLine("Expected: 3.5. Actual: " + median.Find(new int[] {1,4,5}, new int[] {2,3,6}));
        }

        private static void TestWordBreak()
        {
            WordBreak wb = new WordBreak();
            IList<string> list = wb.Execute("catsanddog", new List<string>() {"cat", "sand", "dog", "and", "cats"});
            foreach (string s in list) Console.WriteLine(s);

            wb = new WordBreak();
            list = wb.Execute("pineapplepenapple", new List<string>() {"apple","pen","applepen","pine","pineapple"});
            foreach (string s in list) Console.WriteLine(s);             

            wb = new WordBreak();
            list = wb.Execute("catsandog", new List<string>() {"cat", "sand", "dog", "and", "cats"});
            foreach (string s in list) Console.WriteLine(s);

            wb = new WordBreak();
            list = wb.Execute("cofjdnfdnjbejdhbkhechoeindgmkeloaibeffoacbieekebbfimhdehmncdcajhknidl", new List<string>() {"khjhhagijlickgjob","ajhknidl","khech","kjigndmcl","mbmodglgbahcmdcdoea","lnllaflae","enhakibofef","gjhegnfhlibiog","ajlfkmccbahbbggn","inbanhdomnnghdj","ghigcndibhmeojchbbogkgb","cdebhjjifcnmmmccoj","majcemhhdg","ccfhclceoh","ljfjlaghjehk","mljn","anifljijkdhociken","fogabkbbd","cjahcbienajcgakjjig","kkfffg","jchelakgio","mkkaklj","obehecobkolile","eejne","ndoeic","fbfnkehm","e","mam","hdbibbfijcnlomabemombog","lo","egbklbihgangemjb","jmckjbkbodfknffbchfgie","hldlkfclidhfalmlonfj","diabnkcbadjfmncenihfhk","lamnnbhbaak","cgjmekgfkogclha","nifaifhkbl","eimgallmelmi","mchglmn","fladoo","admmdklfogkafedhnkikell","nfceebenebjgffillm","bacnnmhilkfkffflhdjkhb","fdmbgmckefhenhn","cofjdnfdnjbej","lcmooada","iikimdf","aoloadmajamljdcbfeo","jhoebchekagjlellllm","dh","agk","nlgb","ldihehjafnkcakofebgloam","cbgkafkljdaea","jillnbnglddhdjaf","bjnhobhaalaanijcblhfjfj","difdoaj","mfmcgmaekia","dofkioedciimljhdeehd","kegnobengjbbiko","aamlocelnmib","oeemgcnfamlmdljfdmflfjj","eff","klblolckacndmangjm","kieec","ldljcjchn","blbeg","minibhaoegameolbchfdmd","aahofmcngcdle","lgihd","mmmkj","eoajcgncdafj","ehgkknkefkgkmfbnkfgn","jnniindkohgjdnbjj","mjgkooiklknbnohbn","cddhoglffhikhf","hkojnkclkfjdkno","bhamagfa","cclfechbhkkbikjnfiam","caihcen","ddo","cndgo","mmecggd","k","cnccdoiflnincgacakdoffkdg","eadblmgaioccedaabjfli","jielegjn","kmcnckacoifjamh","ljladkigjjcklnfjagdbbm","na","nblkbmcmmlible","aobkbkeljbhm","jinalibnjhghkdegejfkhojmb","eahacl","chefiggjndcnmlhfelbffea","nbekmjcgjhbnm","hkgabejjogecnlnollhdmc","kc","lhifcackehclg","c","fcna","docgijgankik","b","kfmnoenngjhbkjdbbdb","fmajfjg","imaalcbeibmondaen","loaibeffoacbieekebhmncdc","mchdeedmhmimjeg","oebgcilngjfalebeonbgjmhb","igaieibkhklncikm","lkmhimcj","ahfehlfbimgbgc","hemaimhfnigmfnabco","l","jahkbcdonia","i","bfimhde","ciekchnoolgkjnijekjehcagl","iob","gjldfmnaldnclofg","bbghhfbmknflddiabgj","gholddmbmnhii","iodn","cckkmijgcdjkglfd","njmdahlgbloimibfdco","cjdekg","oeindgmke","mbdcgebgdk","jlddkmoe","oegbiannddkmhibjokkm","loaejecbcondlgaeenbjlokjg","dlchahdimcdjobkfoce","haamgab","fkbj","aggodojjglicnf","gahadoafofdbeieihklfg","aembllfaiggee","ljnjfhknfjf","lhkobdkmnkmaf","ilgcde","nghclbilaiombcidj","igamidcjibblokkmjkhnha","ceiikahhicgbdlhlo","hdcfnig","fbbignkajdjgn","ogjkbcccdldmea","ihnoenlokk","blk","aifhjmimhnggogajflkgc","jfoiif"});
            foreach (string s in list) Console.WriteLine(s);

            wb = new WordBreak();
            list = wb.Execute("aaaaaaa", new List<string>() {"aaaa","aaa"});
            foreach (string s in list) Console.WriteLine(s);

            wb = new WordBreak();
            list = wb.Execute("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaab", new List<string>() {"a", "aa", "aaa", "aaaa", "aaaaa"});
            foreach (string s in list) Console.WriteLine(s);

            wb = new WordBreak();
            list = wb.Execute("abcd", new List<string>() {"a", "abc", "b", "cd"});
            foreach (string s in list) Console.WriteLine(s);            

            // wb = new WordBreak();
            // list = wb.Execute("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new List<string>() {"a","aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa"});
            // foreach (string s in list) Console.WriteLine(s);

            wb = new WordBreak();
            list = wb.Execute("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", new List<string>() {"a","aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa"});
            foreach (string s in list) Console.WriteLine(s);

            StringBuilder sb = new StringBuilder();
            sb.Append('k');
            sb.Append('a');
            sb.Append('r');
            sb.Append('t');
            sb.Remove(sb.Length - 1, 1);
            Console.WriteLine(sb.ToString());
        }

        private static void TestWordSearch()
        {
            string[] words = new string[] {"oath","pea","eat","rain"};
            char[,] board = new char[,] {
                {'o','a','a','n'},
                {'e','t','a','e'},
                {'i','h','k','r'},
                {'i','f','l','v'}
            };

            WordSearch ws = new WordSearch();
            foreach (string s in ws.FindWords(board, words))
            {
                Console.WriteLine(s);
            }

            board = new char[,] {{'s','e','e','n','e','w'},{'t','m','r','i','v','a'},{'o','b','s','i','b','d'},{'w','m','y','s','e','n'},{'l','t','s','n','s','a'},{'i','e','z','l','g','n'}};
            words = new string[] {"pluma","holm","lippen","trag","milla","bietle","upbind","waxy","knead","nickle","reem","skice","unde","hain","savant","tryt","ribose","niton","lysis","bedad","sindry","themis","blushy","cocket","tube","craps","clavel","towhee","ogeed","gloss","goes","bena","mayhap","shor","grief","agria","debosh","rimmed","unlent","whenas","planky","dormer","yati","rang","duer","yigh","deasil","diwata","indic","puerer","levers","fusser","verre","rutile","erical","batata","swager","pudgy","sputa","alite","bummer","velum","infamy","ngai","unfed","bulger","wharve","dipole","sorter","pily","chatty","yapok","womble","liana","parch","speltz","cyan","limose","noggin","proker","crayer","ration","tivy","moyite","beany","fils","riper","jixie","sink","quit","tupuna","jetton","genua","stanno","apace","busine","havers","bedrip","behorn","uncake","cystid","grinch","hexene","fratch","agama","relift","tillot","plaint","ropp","anna","chaos","cytoma","coost","fitted","kegler","twin","rimple","armory","uniced","tubig","trull","glumly","tutrix","rhamn","knelt","astely","colin","clawk","alar","tower","vealy","yearn","roter","prase","undub","toozoo","liter","omelet","taler","curium","bullet","yday","codol","elute","slight","boopis","lotto","nagara","riffle","bustic","shrug","gunk","syrma","wrocht","depose","tramal","tidley","prof","lacmus","copse","flosh","whelky","fifer","needy","wealth","joyant","uroxin","carlet","snarly","lunged","acetal","kibosh","unburn","slimer","elysia","teagle","chymic","erept","quince","shin","knoppy","picudo","chider","gaspy","stope","drawly","pigful","unwarp","sate","nautch","uphasp","fluted","pecht","torpid","childe","inclip","faints","stela","kuskus","arcked","repic","kojang","bigha","lipoid","owerby","anadem","lench","ortiga","astart","slinky","rubify","wootz","recure","natch","tiring","skimp","seck","decay","atria","borax","leeky","auncel","soary","loir","twinge","pinto","bemat","bepuff","odum","uptorn","frowy","fother","witful","erenow","cooker","maddle","okee","leek","hasky","owght","cnicin","togate","screve","abac","hustle","packly","tilt","oscule","nonary","uranic","sulka","urheen","rouncy","gaze","aril","dint","steep","samp","ferule","cakey","unlead","drummy","kelpy","adati","pawn","cyanic","corn","caudle","geyan","danaid","ayless","acre","secos","yeld","obole","finely","avowed","tetard","inflex","sloke","trice","chaise","nursle","aldime","whist","waggly","pilula","loppy","rignum","groff","rigsby","istoke","roughy","bardo","bijoux","junker","progne","ninny","wyss","unhook","lieve","tibey","rethaw","corke","stelar","tirade","earlet","dried","corach","caroli","decern","congee","stog","arake","braid","plasma","unwept","maund","kamahi","pool","local","region","sequa","cuneus","faster","tung","warly","bosket","museum","rule","basion","iodate","pommet","shat","cappy","trail","darbha","scroop","jarfly","sirdar","kulah","ziffs","thump","galee","melter","padder","odist","comber","apodia","widdy","priest","manuma","flob","biaxal","corbel","sodden","begash","duress","tenues","bayman","stases","claro","savage","korero","hurler","routh","civic","flaser","scurvy","lather","amla","male","tiara","salted","restir","soap","exhume","embole","keelie","tera","census","tete","folium","dade","quell","grower","phare","bullan","adrop","athrob","blurry","cerous","rosily","heed","finish","anguis","pizza","mesad","lief","bebait","matchy","impoor","needs","prana","tabret","hoga","gowk","potash","sileni","cumene","kahili","thigh","vortex","fogy","kuruma","teeny","naid","unface","linha","aizle","yender","wolf","deism","bousy","dink","unboy","toshly","hebete","ahura","bowed","porger","gaol","chasmy","karree","isopag","bloody","avail","pinax","slimy","gamba","arghel","strung","simmer","smiler","outlet","gangly","sialic","hemine","trophy","excite","tined","bandar","sprang","kiwi","winner","unsack","rupial","swum","censer","borg","retold","ovular","paal","sware","posh","evade","buffle","plagal","bottom","amend","swipy","siss","fixing","anuran","tinty","weapon","fogged","sampan","enring","suade","causey","ferri","upbrow","jing","rewove","shield","undaub","cingle","rebute","dodd","gaub","scry","cipo","mantra","huller","boller","baud","diem","rammer","ruiner","bardic","ethyl","pleion","path","burrow","nutlet","dital","saxten","assail","minute","berley","labefy","salema","praxis","entone","ipecac","holmic","shita","litas","bemoil","future","defuse","glom","tilpah","bisti","skater","typist","carene","nidget","amply","alveus","salty","crinet","gourde","saluki","sextic","xyrid","likin","refeed","couper","smaik","vestee","lactic","croche","figgle","thunge","tunner","hill","cooba","tucuma","casco","copus","beldam","johnin","soiled","framea","prose","yeard","sobeit","nanism","purply","helper","appeal","mitten","layery","salon","mitra","rusine","verser","beluga","moosa","orate","piemag","attune","rucker","purfly","freet","simmon","affine","mardy","stroam","chia","gynic","saple","serif","bocce","froze","pilot","arenae","laney","locum","casbah","awave","armil","escrow","tetra","unbelt","mehari","patten","mome","muscid","wrang","tundun","sepad","acetic","afresh","vealer","raglin","aloud","pickle","minuet","retort","murium","arched","punjum","baylet","brew","holder","slunk","killas","pomato","penta","hunger","epocha","damie","scrod","cannel","belly","monny","gaum","joker","portly","biurea","eosin","pint","bumper","koft","hyrax","sequin","turn","pilus","fant","advert","unorn","trolly","minded","toom","wander","unglad","tweest","elenge","magpie","agon","boatly","propyl","swelly","know","myal","pika","bewept","karamu","hemal","pigdom","averil","parker","mids","awash","cornea","icing","falsie","necked","darner","shrend","rondo","exequy","adlet","craze","sign","angry","salpa","stoper","percha","kartel","garsil","unfill","gunge","behind","revet","garava","faker","corded","sauf","poemet","whew","tolsey","sluer","trichi","devout","lung","skip","boreal","razzly","athing","atavus","moutan","steepy","whir","sucuri","sinful","turp","ramper","bassan","wheaty","vidry","upturn","gipon","ashlar","facund","liber","warful","geoid","palay","jammy","uptide","mural","gashes","silty","nunlet","tergum","form","soggy","aide","upwrap","fabled","kosin","claval","quail","rummy","junket","vility","treat","sniper","graham","cestus","koruna","corban","clerid","aimer","alada","wedge","trainy","eyedot","banker","plumb","xoanon","wankly","chello","cheet","uncalk","cutely","aurar","bilsh","unram","hart","beday","raser","babloh","ticken","troy","canto","bodhi","pavior","depone","pore","argosy","hanker","sexern","millet","pelean","resign","chaya","furred","tiling","titler","ionone","tinman","induce","forged","hamfat","incur","hammam","sannup","loungy","glib","fikie","evovae","fusure","modern","dinkey","lyric","hawer","sawney","wabeno","calx","troco","sexly","tosh","byhand","meek","unflat","amli","vocate","chamal","askant","fleche","repour","myitis","thwite","merism","pent","enolic","nomina","curney","rother","cooser","depas","thread","riden","pyosis","uparch","elding","cotoro","akpek","quern","rami","daggy","flawn","puller","colove","cage","exode","nignay","brooky","rocket","glar","quota","wiser","atony","nodi","utrubi","amass","yachan","patao","quag","slag","douser","arear","recut","corky","estre","thief","gloat","redia","pricky","ligas","chisel","defier","shower","repen","nakong","indane","tetric","action","redux","gally","suffer","sutler","croupe","metage","terap","bemud","smog","draggy","plyer","dolor","daggly","wiss","isopod","puzzle","deair","anole","bever","goyle","odored","duro","seity","abkari","kersey","spurry","ungaro","idiom","yercum","pugman","astern","ouabe","taenia","eneugh","doze","doily","mixy","floury","sadic","plummy","miter","zebra","rushen","photon","bespot","agnate","kados","tinner","outsin","aloid","dime","labba","arista","cuffy","synema","gainer","reader","skybal","dairi","cavort","wrote","blowth","vacoua","serum","gapo","spunk","melody","hymner","append","alacha","wreat","crenel","cawney","uncoy","soul","bidri","eigne","heaps","plodge","toper","aerugo","ungirt","ablach","domnei","cowl","sold","anneal","cruels","udell","necker","broch","clips","cern","rani","sory","neiper","adead","cashew","spanky","salep","prexy","togue","tedge","motion","troche","unlean","babu","rizzom","craber","tonga","hyssop","jessur","whealy","tashie","badian","refine","bondar","adept","runnet","jumby","latish","strone","topcap","ovarin","rerent","mustee","begin","oblong","lapon","vowed","downy","sept","tabled","racily","quench","shauri","monad","reword","stude","keup","tiding","boyla","blende","rusot","unwind","flioma","ductor","stealy","pedant","silane","swaggy","pulu","uneven","choky","eloge","earcap","descry","tyken","cubica","dregs","scye","chiton","murine","hinge","quatch","giller","screwy","clamb","flask","avijja","amobyr","sant","glossy","outgo","partly","wekeen","tiffle","lith","fulgid","knar","mucket","pundum","doucin","neurin","cost","hatred","alee","submit","uncite","shekel","seme","pyrex","scog","emery","dolose","skrike","fizzer","cephid","curtal","bunce","linden","dorser","valgus","ahem","ricker","wingle","morne","kmet","swinge","razoo","floey","tuik","reif","cohol","patrol","seek","berger","youd","ransom","chrism","coram","impel","glisk","phene","midge","palpi","leban","tactic","jotter","dasher","rouge","rough","owler","pinnet","cetene","noop","eyrir","griffe","murra","whone","caza","hoop","inrun","jerry","cowboy","swanny","deevey","scoke","feck","telfer","pinna","boglet","unrule","pipery","malati","poked","cyclar","shive","acrawl","brotan","linty","infare","bevel","ilia","gelada","skeet","jojoba","sposhy","angary","ghetto","inness","chitak","aint","natron","navew","adular","steri","altho","thyrse","palmy","notum","lift","arsis","insect","nifle","venner","flap","poleax","sarwan","halter","lily","seizer","ectal","bhikku","ahmadi","enure","mingle","shrewd","whilk","dodder","buaze","helmed","bilify","muscly","ungum","sophy","pilau","starky"};

            foreach (string s in ws.FindWords(board, words))
            {
                Console.WriteLine(s);
            }            
        }

        private static void TestInsertInterval()
        {
            InsertInterval interval = new InsertInterval();
            IList<InsertInterval.Interval> intervals = interval.Insert(new List<InsertInterval.Interval>() { new InsertInterval.Interval(1,3), new InsertInterval.Interval(6,9)}, new InsertInterval.Interval(2,5));
            foreach (InsertInterval.Interval inter in intervals){
                Console.WriteLine("[{0}, {1}]", inter.Start, inter.End);
            }
        }
    }
}
