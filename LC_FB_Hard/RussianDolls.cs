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
            internal int Width;
            internal int Height;

            public Envelope(int width, int height){
                this.Width = width;
                this.Height = height;
            }

            public int CompareTo(object obj){
                Envelope other = (Envelope) obj;
                if (other.Width != this.Width) 
                    return this.Width - other.Width; // ascending order of Width
                return other.Height - this.Height;  // descending order of Height

            }
        }
        public int MaxEnvelopes(int[][] envelopes) {

            List<Envelope> envs =  new List<Envelope>();
            for(int i = 0; i < envelopes.GetLength(0); i++) envs.Add(new Envelope(envelopes[i][0], envelopes[i][1]));

            // Idea: We sort the envelopes in ascending order of Width and descending order of Height.
            // Then look at the heights and find the longest increasing subsequence.
            // As we walk the sorted list (left to right), we will use binary search to evict envelopes that are of shorter heights.
            // The reason: We know that the width of envelope (i + 1) is atleast as much as envelope i when scanning left to right.
            // Therefore, being an envelope with shorter height could be the start of a new increasing subsequence
            envs.Sort();
            
            // Idea: We will only consider the height as the envelopes are already sorted in ascending order by width.
            // Since we have sorted the envelopes in descending order of their heights, we will evict the envelopes
            // Basically, we form a Longest increasing subsequence of heights
            List<int> lis = new List<int>(); 
            for (int i = 0; i < envs.Count; i++){
                if (lis.Count == 0 || lis[lis.Count - 1] < envs[i].Height) lis.Add(envs[i].Height);
                else{
                    // binary search to find the smallest envelope that is greater than or equal to envs[i]
                    int low = 0, high = lis.Count - 1, mid = 0;
                    while(low < high){
                        mid = low + (high - low) / 2;
                        if (lis[mid] < envs[i].Height) low = mid + 1;
                        else high = mid;
                    }

                    lis[high] = envs[i].Height;
                }
            }

            return lis.Count;
        }
    }
}