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
            // TestImportantReversePairs();
            // TestWordLadder();
            // TestLongestConsecutiveSequence();
            // TestNumberToEnglish();
            // TestSubstringWithConcat();
            // TestAlientDictionary();
            // TestLongestValidParenthesis();
            // TestMedianOfSortedArrays();
            // TestWordBreak();
            // TestWordSearch();
            // TestInsertInterval();
            // TestDeque();
            // TestSlidingWindowMax();
            // TestRemoveInvalidParentheses();
            // TestTrappingRainWater();
            // TestRecoverBST();
            // TestFrogJump();
            // TestUnionFind();
            // TestNumberOfIslands2();
            // TestSplitArrayWithSameAverage();
            // TestCandyProblem();
            TestFirstMissingPositiveNum();
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

        private static void TestImportantReversePairs()
        {
            Console.WriteLine("Expected: 2. Actual: " + ImpReversePairs.Execute2(new int[] {1,3,2,3,1}));
            Console.WriteLine("Expected: 3. Actual: " + ImpReversePairs.Execute2(new int[] {2,4,3,5,1}));
            Console.WriteLine("Expected: 0. Actual: " + ImpReversePairs.Execute2(new int[] {2147483647,2147483647,2147483647,2147483647,2147483647,2147483647}));
            Console.WriteLine("Expected: 40. Actual: " + ImpReversePairs.Execute2(new int[] {233,2000000001,234,2000000006,235,2000000003,236,2000000007,237,2000000002,2000000005,233,233,233,233,233,2000000004}));
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

            wl = new WordLadder();
            ladders = wl.FindLadders("sand", "acne", new List<string>() {"slit","bunk","wars","ping","viva","wynn","wows","irks","gang","pool","mock","fort","heel","send","ship","cols","alec","foal","nabs","gaze","giza","mays","dogs","karo","cums","jedi","webb","lend","mire","jose","catt","grow","toss","magi","leis","bead","kara","hoof","than","ires","baas","vein","kari","riga","oars","gags","thug","yawn","wive","view","germ","flab","july","tuck","rory","bean","feed","rhee","jeez","gobs","lath","desk","yoko","cute","zeus","thus","dims","link","dirt","mara","disc","limy","lewd","maud","duly","elsa","hart","rays","rues","camp","lack","okra","tome","math","plug","monk","orly","friz","hogs","yoda","poop","tick","plod","cloy","pees","imps","lead","pope","mall","frey","been","plea","poll","male","teak","soho","glob","bell","mary","hail","scan","yips","like","mull","kory","odor","byte","kaye","word","honk","asks","slid","hopi","toke","gore","flew","tins","mown","oise","hall","vega","sing","fool","boat","bobs","lain","soft","hard","rots","sees","apex","chan","told","woos","unit","scow","gilt","beef","jars","tyre","imus","neon","soap","dabs","rein","ovid","hose","husk","loll","asia","cope","tail","hazy","clad","lash","sags","moll","eddy","fuel","lift","flog","land","sigh","saks","sail","hook","visa","tier","maws","roeg","gila","eyes","noah","hypo","tore","eggs","rove","chap","room","wait","lurk","race","host","dada","lola","gabs","sobs","joel","keck","axed","mead","gust","laid","ends","oort","nose","peer","kept","abet","iran","mick","dead","hags","tens","gown","sick","odis","miro","bill","fawn","sumo","kilt","huge","ores","oran","flag","tost","seth","sift","poet","reds","pips","cape","togo","wale","limn","toll","ploy","inns","snag","hoes","jerk","flux","fido","zane","arab","gamy","raze","lank","hurt","rail","hind","hoot","dogy","away","pest","hoed","pose","lose","pole","alva","dino","kind","clan","dips","soup","veto","edna","damp","gush","amen","wits","pubs","fuzz","cash","pine","trod","gunk","nude","lost","rite","cory","walt","mica","cart","avow","wind","book","leon","life","bang","draw","leek","skis","dram","ripe","mine","urea","tiff","over","gale","weir","defy","norm","tull","whiz","gill","ward","crag","when","mill","firs","sans","flue","reid","ekes","jain","mutt","hems","laps","piss","pall","rowe","prey","cull","knew","size","wets","hurl","wont","suva","girt","prys","prow","warn","naps","gong","thru","livy","boar","sade","amok","vice","slat","emir","jade","karl","loyd","cerf","bess","loss","rums","lats","bode","subs","muss","maim","kits","thin","york","punt","gays","alpo","aids","drag","eras","mats","pyre","clot","step","oath","lout","wary","carp","hums","tang","pout","whip","fled","omar","such","kano","jake","stan","loop","fuss","mini","byrd","exit","fizz","lire","emil","prop","noes","awed","gift","soli","sale","gage","orin","slur","limp","saar","arks",
            "mast","gnat","port","into","geed","pave","awls","cent","cunt","full","dint","hank","mate","coin","tars","scud","veer","coax","bops","uris","loom","shod","crib","lids","drys","fish","edit","dick","erna","else","hahs","alga","moho","wire","fora","tums","ruth","bets","duns","mold","mush","swop","ruby","bolt","nave","kite","ahem","brad","tern","nips","whew","bait","ooze","gino","yuck","drum","shoe","lobe","dusk","cult","paws","anew","dado","nook","half","lams","rich","cato","java","kemp","vain","fees","sham","auks","gish","fire","elam","salt","sour","loth","whit","yogi","shes","scam","yous","lucy","inez","geld","whig","thee","kelp","loaf","harm","tomb","ever","airs","page","laud","stun","paid","goop","cobs","judy","grab","doha","crew","item","fogs","tong","blip","vest","bran","wend","bawl","feel","jets","mixt","tell","dire","devi","milo","deng","yews","weak","mark","doug","fare","rigs","poke","hies","sian","suez","quip","kens","lass","zips","elva","brat","cosy","teri","hull","spun","russ","pupa","weed","pulp","main","grim","hone","cord","barf","olav","gaps","rote","wilt","lars","roll","balm","jana","give","eire","faun","suck","kegs","nita","weer","tush","spry","loge","nays","heir","dope","roar","peep","nags","ates","bane","seas","sign","fred","they","lien","kiev","fops","said","lawn","lind","miff","mass","trig","sins","furl","ruin","sent","cray","maya","clog","puns","silk","axis","grog","jots","dyer","mope","rand","vend","keen","chou","dose","rain","eats","sped","maui","evan","time","todd","skit","lief","sops","outs","moot","faze","biro","gook","fill","oval","skew","veil","born","slob","hyde","twin","eloy","beat","ergs","sure","kobe","eggo","hens","jive","flax","mons","dunk","yest","begs","dial","lodz","burp","pile","much","dock","rene","sago","racy","have","yalu","glow","move","peps","hods","kins","salk","hand","cons","dare","myra","sega","type","mari","pelt","hula","gulf","jugs","flay","fest","spat","toms","zeno","taps","deny","swag","afro","baud","jabs","smut","egos","lara","toes","song","fray","luis","brut","olen","mere","ruff","slum","glad","buds","silt","rued","gelt","hive","teem","ides","sink","ands","wisp","omen","lyre","yuks","curb","loam","darn","liar","pugs","pane","carl","sang","scar","zeds","claw","berg","hits","mile","lite","khan","erik","slug","loon","dena","ruse","talk","tusk","gaol","tads","beds","sock","howe","gave","snob","ahab","part","meir","jell","stir","tels","spit","hash","omit","jinx","lyra","puck","laue","beep","eros","owed","cede","brew","slue","mitt","jest","lynx","wads","gena","dank","volt","gray","pony","veld","bask","fens","argo","work","taxi","afar","boon","lube","pass","lazy","mist","blot","mach","poky","rams","sits","rend","dome","pray","duck","hers","lure","keep","gory","chat","runt","jams","lays","posy","bats","hoff","rock","keri","raul","yves","lama","ramp","vote","jody","pock","gist","sass","iago","coos",
            "rank","lowe","vows","koch","taco","jinn","juno","rape","band","aces","goal","huck","lila","tuft","swan","blab","leda","gems","hide","tack","porn","scum","frat","plum","duds","shad","arms","pare","chin","gain","knee","foot","line","dove","vera","jays","fund","reno","skid","boys","corn","gwyn","sash","weld","ruiz","dior","jess","leaf","pars","cote","zing","scat","nice","dart","only","owls","hike","trey","whys","ding","klan","ross","barb","ants","lean","dopy","hock","tour","grip","aldo","whim","prom","rear","dins","duff","dell","loch","lava","sung","yank","thar","curl","venn","blow","pomp","heat","trap","dali","nets","seen","gash","twig","dads","emmy","rhea","navy","haws","mite","bows","alas","ives","play","soon","doll","chum","ajar","foam","call","puke","kris","wily","came","ales","reef","raid","diet","prod","prut","loot","soar","coed","celt","seam","dray","lump","jags","nods","sole","kink","peso","howl","cost","tsar","uric","sore","woes","sewn","sake","cask","caps","burl","tame","bulk","neva","from","meet","webs","spar","fuck","buoy","wept","west","dual","pica","sold","seed","gads","riff","neck","deed","rudy","drop","vale","flit","romp","peak","jape","jews","fain","dens","hugo","elba","mink","town","clam","feud","fern","dung","newt","mime","deem","inti","gigs","sosa","lope","lard","cara","smug","lego","flex","doth","paar","moon","wren","tale","kant","eels","muck","toga","zens","lops","duet","coil","gall","teal","glib","muir","ails","boer","them","rake","conn","neat","frog","trip","coma","must","mono","lira","craw","sled","wear","toby","reel","hips","nate","pump","mont","died","moss","lair","jibe","oils","pied","hobs","cads","haze","muse","cogs","figs","cues","roes","whet","boru","cozy","amos","tans","news","hake","cots","boas","tutu","wavy","pipe","typo","albs","boom","dyke","wail","woke","ware","rita","fail","slab","owes","jane","rack","hell","lags","mend","mask","hume","wane","acne","team","holy","runs","exes","dole","trim","zola","trek","puma","wacs","veep","yaps","sums","lush","tubs","most","witt","bong","rule","hear","awry","sots","nils","bash","gasp","inch","pens","fies","juts","pate","vine","zulu","this","bare","veal","josh","reek","ours","cowl","club","farm","teat","coat","dish","fore","weft","exam","vlad","floe","beak","lane","ella","warp","goth","ming","pits","rent","tito","wish","amps","says","hawk","ways","punk","nark","cagy","east","paul","bose","solo","teed","text","hews","snip","lips","emit","orgy","icon","tuna","soul","kurd","clod","calk","aunt","bake","copy","acid","duse","kiln","spec","fans","bani","irma","pads","batu","logo","pack","oder","atop","funk","gide","bede","bibs","taut","guns","dana","puff","lyme","flat","lake","june","sets","gull","hops","earn","clip","fell","kama","seal","diaz","cite","chew","cuba","bury","yard","bank","byes","apia","cree","nosh","judo","walk","tape","taro","boot","cods","lade","cong","deft",
            "slim","jeri","rile","park","aeon","fact","slow","goff","cane","earp","tart","does","acts","hope","cant","buts","shin","dude","ergo","mode","gene","lept","chen","beta","eden","pang","saab","fang","whir","cove","perk","fads","rugs","herb","putt","nous","vane","corm","stay","bids","vela","roof","isms","sics","gone","swum","wiry","cram","rink","pert","heap","sikh","dais","cell","peel","nuke","buss","rasp","none","slut","bent","dams","serb","dork","bays","kale","cora","wake","welt","rind","trot","sloe","pity","rout","eves","fats","furs","pogo","beth","hued","edam","iamb","glee","lute","keel","airy","easy","tire","rube","bogy","sine","chop","rood","elbe","mike","garb","jill","gaul","chit","dons","bars","ride","beck","toad","make","head","suds","pike","snot","swat","peed","same","gaza","lent","gait","gael","elks","hang","nerf","rosy","shut","glop","pain","dion","deaf","hero","doer","wost","wage","wash","pats","narc","ions","dice","quay","vied","eons","case","pour","urns","reva","rags","aden","bone","rang","aura","iraq","toot","rome","hals","megs","pond","john","yeps","pawl","warm","bird","tint","jowl","gibe","come","hold","pail","wipe","bike","rips","eery","kent","hims","inks","fink","mott","ices","macy","serf","keys","tarp","cops","sods","feet","tear","benz","buys","colo","boil","sews","enos","watt","pull","brag","cork","save","mint","feat","jamb","rubs","roxy","toys","nosy","yowl","tamp","lobs","foul","doom","sown","pigs","hemp","fame","boor","cube","tops","loco","lads","eyre","alta","aged","flop","pram","lesa","sawn","plow","aral","load","lied","pled","boob","bert","rows","zits","rick","hint","dido","fist","marc","wuss","node","smog","nora","shim","glut","bale","perl","what","tort","meek","brie","bind","cake","psst","dour","jove","tree","chip","stud","thou","mobs","sows","opts","diva","perm","wise","cuds","sols","alan","mild","pure","gail","wins","offs","nile","yelp","minn","tors","tran","homy","sadr","erse","nero","scab","finn","mich","turd","then","poem","noun","oxus","brow","door","saws","eben","wart","wand","rosa","left","lina","cabs","rapt","olin","suet","kalb","mans","dawn","riel","temp","chug","peal","drew","null","hath","many","took","fond","gate","sate","leak","zany","vans","mart","hess","home","long","dirk","bile","lace","moog","axes","zone","fork","duct","rico","rife","deep","tiny","hugh","bilk","waft","swig","pans","with","kern","busy","film","lulu","king","lord","veda","tray","legs","soot","ells","wasp","hunt","earl","ouch","diem","yell","pegs","blvd","polk","soda","zorn","liza","slop","week","kill","rusk","eric","sump","haul","rims","crop","blob","face","bins","read","care","pele","ritz","beau","golf","drip","dike","stab","jibs","hove","junk","hoax","tats","fief","quad","peat","ream","hats","root","flak","grit","clap","pugh","bosh","lock","mute","crow","iced","lisa","bela","fems","oxes","vies","gybe","huff","bull","cuss","sunk",
            "pups","fobs","turf","sect","atom","debt","sane","writ","anon","mayo","aria","seer","thor","brim","gawk","jack","jazz","menu","yolk","surf","libs","lets","bans","toil","open","aced","poor","mess","wham","fran","gina","dote","love","mood","pale","reps","ines","shot","alar","twit","site","dill","yoga","sear","vamp","abel","lieu","cuff","orbs","rose","tank","gape","guam","adar","vole","your","dean","dear","hebe","crab","hump","mole","vase","rode","dash","sera","balk","lela","inca","gaea","bush","loud","pies","aide","blew","mien","side","kerr","ring","tess","prep","rant","lugs","hobo","joke","odds","yule","aida","true","pone","lode","nona","weep","coda","elmo","skim","wink","bras","pier","bung","pets","tabs","ryan","jock","body","sofa","joey","zion","mace","kick","vile","leno","bali","fart","that","redo","ills","jogs","pent","drub","slaw","tide","lena","seep","gyps","wave","amid","fear","ties","flan","wimp","kali","shun","crap","sage","rune","logs","cain","digs","abut","obit","paps","rids","fair","hack","huns","road","caws","curt","jute","fisk","fowl","duty","holt","miss","rude","vito","baal","ural","mann","mind","belt","clem","last","musk","roam","abed","days","bore","fuze","fall","pict","dump","dies","fiat","vent","pork","eyed","docs","rive","spas","rope","ariz","tout","game","jump","blur","anti","lisp","turn","sand","food","moos","hoop","saul","arch","fury","rise","diss","hubs","burs","grid","ilks","suns","flea","soil","lung","want","nola","fins","thud","kidd","juan","heps","nape","rash","burt","bump","tots","brit","mums","bole","shah","tees","skip","limb","umps","ache","arcs","raft","halo","luce","bahs","leta","conk","duos","siva","went","peek","sulk","reap","free","dubs","lang","toto","hasp","ball","rats","nair","myst","wang","snug","nash","laos","ante","opal","tina","pore","bite","haas","myth","yugo","foci","dent","bade","pear","mods","auto","shop","etch","lyly","curs","aron","slew","tyro","sack","wade","clio","gyro","butt","icky","char","itch","halt","gals","yang","tend","pact","bees","suit","puny","hows","nina","brno","oops","lick","sons","kilo","bust","nome","mona","dull","join","hour","papa","stag","bern","wove","lull","slip","laze","roil","alto","bath","buck","alma","anus","evil","dumb","oreo","rare","near","cure","isis","hill","kyle","pace","comb","nits","flip","clop","mort","thea","wall","kiel","judd","coop","dave","very","amie","blah","flub","talc","bold","fogy","idea","prof","horn","shoo","aped","pins","helm","wees","beer","womb","clue","alba","aloe","fine","bard","limo","shaw","pint","swim","dust","indy","hale","cats","troy","wens","luke","vern","deli","both","brig","daub","sara","sued","bier","noel","olga","dupe","look","pisa","knox","murk","dame","matt","gold","jame","toge","luck","peck","tass","calf","pill","wore","wadi","thur","parr","maul","tzar","ones","lees","dark","fake","bast","zoom","here","moro","wine","bums","cows",
            "jean","palm","fume","plop","help","tuba","leap","cans","back","avid","lice","lust","polo","dory","stew","kate","rama","coke","bled","mugs","ajax","arts","drug","pena","cody","hole","sean","deck","guts","kong","bate","pitt","como","lyle","siam","rook","baby","jigs","bret","bark","lori","reba","sups","made","buzz","gnaw","alps","clay","post","viol","dina","card","lana","doff","yups","tons","live","kids","pair","yawl","name","oven","sirs","gyms","prig","down","leos","noon","nibs","cook","safe","cobb","raja","awes","sari","nerd","fold","lots","pete","deal","bias","zeal","girl","rage","cool","gout","whey","soak","thaw","bear","wing","nagy","well","oink","sven","kurt","etna","held","wood","high","feta","twee","ford","cave","knot","tory","ibis","yaks","vets","foxy","sank","cone","pius","tall","seem","wool","flap","gird","lore","coot","mewl","sere","real","puts","sell","nuts","foil","lilt","saga","heft","dyed","goat","spew","daze","frye","adds","glen","tojo","pixy","gobi","stop","tile","hiss","shed","hahn","baku","ahas","sill","swap","also","carr","manx","lime","debs","moat","eked","bola","pods","coon","lacy","tube","minx","buff","pres","clew","gaff","flee","burn","whom","cola","fret","purl","wick","wigs","donn","guys","toni","oxen","wite","vial","spam","huts","vats","lima","core","eula","thad","peon","erie","oats","boyd","cued","olaf","tams","secs","urey","wile","penn","bred","rill","vary","sues","mail","feds","aves","code","beam","reed","neil","hark","pols","gris","gods","mesa","test","coup","heed","dora","hied","tune","doze","pews","oaks","bloc","tips","maid","goof","four","woof","silo","bray","zest","kiss","yong","file","hilt","iris","tuns","lily","ears","pant","jury","taft","data","gild","pick","kook","colt","bohr","anal","asps","babe","bach","mash","biko","bowl","huey","jilt","goes","guff","bend","nike","tami","gosh","tike","gees","urge","path","bony","jude","lynn","lois","teas","dunn","elul","bonn","moms","bugs","slay","yeah","loan","hulk","lows","damn","nell","jung","avis","mane","waco","loin","knob","tyke","anna","hire","luau","tidy","nuns","pots","quid","exec","hans","hera","hush","shag","scot","moan","wald","ursa","lorn","hunk","loft","yore","alum","mows","slog","emma","spud","rice","worn","erma","need","bags","lark","kirk","pooh","dyes","area","dime","luvs","foch","refs","cast","alit","tugs","even","role","toed","caph","nigh","sony","bide","robs","folk","daft","past","blue","flaw","sana","fits","barr","riot","dots","lamp","cock","fibs","harp","tent","hate","mali","togs","gear","tues","bass","pros","numb","emus","hare","fate","wife","mean","pink","dune","ares","dine","oily","tony","czar","spay","push","glum","till","moth","glue","dive","scad","pops","woks","andy","leah","cusp","hair","alex","vibe","bulb","boll","firm","joys","tara","cole","levy","owen","chow","rump","jail","lapp","beet","slap","kith","more","maps","bond","hick","opus",
            "rust","wist","shat","phil","snow","lott","lora","cary","mote","rift","oust","klee","goad","pith","heep","lupe","ivan","mimi","bald","fuse","cuts","lens","leer","eyry","know","razz","tare","pals","geek","greg","teen","clef","wags","weal","each","haft","nova","waif","rate","katy","yale","dale","leas","axum","quiz","pawn","fend","capt","laws","city","chad","coal","nail","zaps","sort","loci","less","spur","note","foes","fags","gulp","snap","bogs","wrap","dane","melt","ease","felt","shea","calm","star","swam","aery","year","plan","odin","curd","mira","mops","shit","davy","apes","inky","hues","lome","bits","vila","show","best","mice","gins","next","roan","ymir","mars","oman","wild","heal","plus","erin","rave","robe","fast","hutu","aver","jodi","alms","yams","zero","revs","wean","chic","self","jeep","jobs","waxy","duel","seek","spot","raps","pimp","adan","slam","tool","morn","futz","ewes","errs","knit","rung","kans","muff","huhs","tows","lest","meal","azov","gnus","agar","sips","sway","otis","tone","tate","epic","trio","tics","fade","lear","owns","robt","weds","five","lyon","terr","arno","mama","grey","disk","sept","sire","bart","saps","whoa","turk","stow","pyle","joni","zinc","negs","task","leif","ribs","malt","nine","bunt","grin","dona","nope","hams","some","molt","smit","sacs","joan","slav","lady","base","heck","list","take","herd","will","nubs","burg","hugs","peru","coif","zoos","nick","idol","levi","grub","roth","adam","elma","tags","tote","yaws","cali","mete","lula","cubs","prim","luna","jolt","span","pita","dodo","puss","deer","term","dolt","goon","gary","yarn","aims","just","rena","tine","cyst","meld","loki","wong","were","hung","maze","arid","cars","wolf","marx","faye","eave","raga","flow","neal","lone","anne","cage","tied","tilt","soto","opel","date","buns","dorm","kane","akin","ewer","drab","thai","jeer","grad","berm","rods","saki","grus","vast","late","lint","mule","risk","labs","snit","gala","find","spin","ired","slot","oafs","lies","mews","wino","milk","bout","onus","tram","jaws","peas","cleo","seat","gums","cold","vang","dewy","hood","rush","mack","yuan","odes","boos","jami","mare","plot","swab","borg","hays","form","mesh","mani","fife","good","gram","lion","myna","moor","skin","posh","burr","rime","done","ruts","pays","stem","ting","arty","slag","iron","ayes","stub","oral","gets","chid","yens","snub","ages","wide","bail","verb","lamb","bomb","army","yoke","gels","tits","bork","mils","nary","barn","hype","odom","avon","hewn","rios","cams","tact","boss","oleo","duke","eris","gwen","elms","deon","sims","quit","nest","font","dues","yeas","zeta","bevy","gent","torn","cups","worm","baum","axon","purr","vise","grew","govs","meat","chef","rest","lame"});
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

        private static void TestDeque()
        {
            Deque q = new Deque();
            q.AddFirst(5); 
            q.AddFirst(4);
            Console.WriteLine(q.PeekLast());
            Console.WriteLine(q.PeekFirst());
            Console.WriteLine(q.PollFirst());
            Console.WriteLine(q.PollLast());
            try{
                Console.WriteLine(q.PollFirst());
            }
            catch{
                Console.WriteLine("Expected an exception for Console.WriteLine(q.PollFirst())");
            }     
        }

        private static void TestSlidingWindowMax()
        {
            SlidingWindowMax swm = new SlidingWindowMax();
            int[] result = swm.MaxSlidingWindow(new int[] {1,3,-1,-3,5,3,6,7}, 3);
            foreach (int r in result) Console.Write(r + ",");
            Console.WriteLine();

            result = swm.MaxSlidingWindow(new int[] {7,2,4}, 2);
            foreach (int r in result) Console.Write(r + ",");
            Console.WriteLine();       

            result = swm.MaxSlidingWindow(new int[] {7,10,20,65,-18,7,4,3}, 3);
            foreach (int r in result) Console.Write(r + ",");
            Console.WriteLine();            
        }

        private static void TestRemoveInvalidParentheses()
        {
            string s = "()())()";
            RemoveInvalidParentheses rm = new RemoveInvalidParentheses();
            IList<string> result = rm.Remove(s);
            foreach (string r in result) Console.WriteLine(r);
        }

        private static void TestTrappingRainWater()
        {
            int[] input = new int[] {0,1,0,2,1,0,1,3,2,1,2,1};
            TrappingRainWater t = new TrappingRainWater();
            Console.WriteLine("Expected: 6. Actual: {0}", t.Trap(input));
        }

        private static void TestRecoverBST()
        {
            Console.WriteLine("Q1");
            BinarySearchTree bst = new BinarySearchTree(new string[] {"3","1","4",null,null,"2"});
            RecoverBST recover = new RecoverBST();
            recover.RecoverTree(bst.Root);
            Console.WriteLine("Expected: Swapping 3 and 2");

            Console.WriteLine("Q2");
            bst = new BinarySearchTree(new string[] {"1","3",null,null,"2"});
            recover = new RecoverBST();
            recover.RecoverTree(bst.Root);
            Console.WriteLine("Expected: Swapping 3 and 1");

            Console.WriteLine("Q3");
            bst = new BinarySearchTree(new string[] {"2","3","1"});
            recover = new RecoverBST();
            recover.RecoverTree(bst.Root);
            Console.WriteLine("Expected: Swapping 3 and 1");

            Console.WriteLine("Q4");
            bst = new BinarySearchTree(new string[] {"1","3",null,"2",null,null,null,"4"});
            recover = new RecoverBST();
            recover.RecoverTree(bst.Root);            
            Console.WriteLine("Expected: Swapping 1 and 4");

            Console.WriteLine("Q5");
            bst = new BinarySearchTree(new string[] {"2","3",null,"1",null,null,null,null,"4"});
            recover = new RecoverBST();
            recover.RecoverTree(bst.Root);            
            Console.WriteLine("Expected: Swapping 4 and 2");

            Console.WriteLine("Q6");
            bst = new BinarySearchTree(new string[] {"146","71","-13","55",null,"231","399","321",null,null,null,null,null,"-33"});
            recover = new RecoverBST();
            recover.RecoverTree(bst.Root);
            Console.WriteLine("Expected: Swapping 321 and -33");

            Console.WriteLine("Q7");
            bst = new BinarySearchTree(new string[] {"3","4","1",null,"2"});
            recover = new RecoverBST();
            recover.RecoverTree(bst.Root);
            Console.WriteLine("Expected: Swapping 1 and 4");            
        }

        public static void TestFrogJump()
        {
            FrogJump fj = new FrogJump();
            Console.WriteLine("Expected: True. Actual: {0}", fj.CanCross(new int[]{0,1,3,5,6,8,12,17}));
        }

        public static void TestUnionFind()
        {
            int[] data = new int[30] {10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,3,37,38,39};
            UnionFind uf = new UnionFind(data);
            Console.WriteLine("10's parent element id " + uf.Find(10));
            uf.Union(10,10);
            Console.WriteLine("10's parent element id " + uf.Find(10));
            uf.Union(10,11);
            Console.WriteLine("10's parent element id " + uf.Find(10));
            Console.WriteLine("11's parent element id " + uf.Find(11));
            uf.Union(11,12);
            uf.Union(11,14);
            Console.WriteLine("10's parent element id " + uf.Find(10));
            Console.WriteLine("11's parent element id " + uf.Find(11));
            Console.WriteLine("12's parent element id " + uf.Find(12));
            Console.WriteLine("14's parent element id " + uf.Find(14));

            uf.Union(20,21);
            uf.Union(22,23);
            Console.WriteLine("20's parent element id " + uf.Find(20));
            Console.WriteLine("21's parent element id " + uf.Find(21));            
            Console.WriteLine("22's parent element id " + uf.Find(22));            
            Console.WriteLine("23's parent element id " + uf.Find(23));            
            uf.Union(20,10);
            Console.WriteLine("10's parent element id " + uf.Find(10));
            Console.WriteLine("11's parent element id " + uf.Find(11));
            Console.WriteLine("12's parent element id " + uf.Find(12));
            Console.WriteLine("14's parent element id " + uf.Find(14));            
            Console.WriteLine("20's parent element id " + uf.Find(20));
            Console.WriteLine("21's parent element id " + uf.Find(21));            
            Console.WriteLine("22's parent element id " + uf.Find(22));            
            Console.WriteLine("23's parent element id " + uf.Find(23));                        
        }

        public static void TestNumberOfIslands2()
        {
            Console.WriteLine("Problem 1");
            NumberOfIslands2 islands = new NumberOfIslands2();
            islands.NumIslands2(3,3, new int[,] {{0,0}, {0,1}, {1,2}, {2,1}});
            Console.WriteLine("Problem 2");
            islands = new NumberOfIslands2();
            islands.NumIslands2(3,3, new int[,] {{0,1},{1,2},{2,1},{1,0},{0,2},{0,0},{1,1}});
        }

        public static void TestSplitArrayWithSameAverage()
        {
            SplitArrayWithSameAverage split = new SplitArrayWithSameAverage();
            Console.WriteLine("Expected: True, returned: " + split.SplitArraySameAverage(new int[] {2, 4, 5, 7, 10 ,14}));
            Console.WriteLine("Expected: False, returned: " + split.SplitArraySameAverage(new int[] {18, 10, 5, 3}));
        }

        public static void TestCandyProblem()
        {
            CandyProblem cp = new CandyProblem();
            Console.WriteLine("Expected: 5. Output: " + cp.Candy(new int[]{1,0,2}));
            Console.WriteLine("Expected: 4. Output: " + cp.Candy(new int[]{1,2,2}));
            Console.WriteLine("Expected: 13. Output: " + cp.Candy(new int[]{1,2,87,87,87,2,1}));

        }

        public static void TestFirstMissingPositiveNum()
        {
            FirstMissingPositiveNum missing = new FirstMissingPositiveNum();
            Console.WriteLine("Expected: 3. Actual: " + missing.FirstMissingPositive(new int[] {1,2,0}));
            
            int result = missing.FirstMissingPositive(new int[] {1});
            Console.WriteLine("Expected: 2. Actual: " + result);
            
            result = missing.FirstMissingPositive(new int[] {1,1});
            Console.WriteLine("Expected: 2. Actual: " + result);

            result = missing.FirstMissingPositive(new int[] {3,4,-1,1});
            Console.WriteLine("Expected: 2. Actual: " + result);
            
            result = missing.FirstMissingPositive(new int[] {7,8,9,11,12});
            Console.WriteLine("Expected: 1. Actual: " + result);

            result = missing.FirstMissingPositive(new int[] {2,1});
            Console.WriteLine("Expected: 3. Actual: " + result);                              

        }
    }
}
