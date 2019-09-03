using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    class RestoreIpAddress
    {
        public IList<string> RestoreIpAddresses(string s) {
            IList<string> restored = new List<string>();
            HashSet<string> set =  new HashSet<string>(); //used to check for duplicates
            StringBuilder sb = new StringBuilder();
            for(int i = 1; i < 4; i++)
            for(int j = 1; j < 4; j++)
            for(int k = 1; k < 4; k++) {
                int l = s.Length - i - j - k;
                if (l <=0 || l > 3) continue;
                int oct1 = int.Parse(s.Substring(0,i));
                if (oct1 > 255) break;
                int oct2 = int.Parse(s.Substring(i, j));
                if (oct2 > 255) break;
                int oct3 = int.Parse(s.Substring(i + j, k));
                if (oct3 > 255) break;
                int oct4 = int.Parse(s.Substring(i + j + k, l));
                if (oct4 > 255) continue;

                sb.Clear();
                sb.Append(oct1.ToString() + "." + oct2.ToString() + "."  + oct3.ToString() +  "." + oct4.ToString());
                if (sb.Length != s.Length + 3) continue;    // this is a corner case. for example a string "00" when converted to int is 0

                string str = sb.ToString();
                if (set.Contains(str)) continue;
                set.Add(str);
                restored.Add(str);
            }

            return restored;
        }
    }
}