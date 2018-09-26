/*
You have a number of envelopes with widths and heights given as a pair of integers (w, h). One envelope can fit into another if and only if both the width and height of one envelope is greater than the width and height of the other envelope.

What is the maximum number of envelopes can you Russian doll? (put one inside other)

Note:
Rotation is not allowed.

Example:

Input: [[5,4],[6,4],[6,7],[2,3]]
Output: 3 
Explanation: The maximum number of envelopes you can Russian doll is 3 ([2,3] => [5,4] => [6,7]).
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class RussianDolls
    {
        internal class Envelope : IComparable
        {
            internal int Length;
            internal int Width;

            public Envelope(int length, int width){
                this.Length = length;
                this.Width = width;
            }

            public int CompareTo(object obj){
                Envelope other = (Envelope) obj;
                if (this.Length == other.Length && this.Width == other.Width) return 0;
                if (this.Length < other.Length) return -1;
                if (this.Length == other.Length && this.Width < other.Width) return -1;
                return 1;
            }
        }
        public int MaxEnvelopes(int[,] envelopes)
        {
            List<Envelope> envs =  new List<Envelope>();
            for(int i = 0; i < envelopes.GetLength(0); i++) {
                envs.Add(new Envelope(envelopes[i,0], envelopes[i,1]));
            }

            if (envs.Count == 0) return 0;

            envs.Sort();

            int[,] dp = new int[envs.Count, envs.Count];
            for(int i = 0; i < envs.Count; i++){
                for(int j = i; j < envs.Count; j++){
                    if(envs[j].Length > envs[i].Length && envs[j].Width > envs[i].Width){
                        if (i == 0){
                            dp[i,j] = 2;
                            continue;
                        }
                        else{
                            if(envs[i].Length > envs[i-1].Length && envs[i].Width > envs[i-1].Width){
                                dp[i, j] = dp[i - 1, j] + 1;
                            }
                            else{
                                dp[i, j] = Math.Max(dp[i-1, j], dp[i, j-1]);
                            }
                        }
                    }
                    else{
                        if (i != 0) dp[i, j] = Math.Max(dp[i-1, j], dp[i, j-1]);
                    }
                }
            }

            Console.WriteLine("Result is " + dp[envs.Count - 1, envs.Count - 1]);
            return dp[envs.Count - 1, envs.Count - 1];    
        }
    }
}