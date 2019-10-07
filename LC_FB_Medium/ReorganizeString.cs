/*
Given a string S, check if the letters can be rearranged so that two characters that 
are adjacent to each other are not the same.

If possible, output any possible result.  If not possible, return the empty string.

Example 1:

Input: S = "aab"
Output: "aba"
Example 2:

Input: S = "aaab"
Output: ""

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    public class ReorganizeString
    {
        public string Reorganize(string s) {
            if (s == null || s.Length == 0) return string.Empty;
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            for(int i = 0; i < s.Length; i++) charCount[s[i]] = charCount.GetValueOrDefault(s[i], 0) + 1;
            
            if (charCount.Count == 1) {
                foreach(char key in charCount.Keys) if (charCount[key] > 1) return "";
                else return key.ToString();
            }

            MaxPQ pq = new MaxPQ(charCount.Count);
            foreach(char key in charCount.Keys) pq.Add(charCount[key], key);

            StringBuilder sb = new StringBuilder();
            while(pq.PeekMax().Item1 > 0){
                Tuple<int, char> e1 = pq.DeleteMax();
                Tuple<int, char> e2 = pq.DeleteMax();
                if (e1.Item1 > 1 && e2.Item1 < 1) return "";
                if (e1.Item1 > 0) sb.Append(e1.Item2);
                if (e2.Item1 > 0) sb.Append(e2.Item2);
                pq.Add(e1.Item1 - 1, e1.Item2);
                pq.Add(e2.Item1 - 1, e2.Item2);
            }

            return sb.ToString();
        }

        internal class MaxPQ
        {
            internal class Node{
                internal int key;
                internal char val;
                internal Node(int key, char val){
                    this.key = key;
                    this.val = val;
                }
            }

            internal Node[] pq;
            internal int size;
            internal int currentLength;

            internal MaxPQ(int size){
                this.pq = new Node[size];
                this.size = size;
                this.currentLength = 0;
            }

            internal void Add(int key, char value){
                Node node = new Node(key, value);
                this.pq[currentLength] = node;
                this.currentLength++;
                this.Swim();
                if (!this.IsMaxHeap()) 
                    throw new Exception(string.Format("MaxHeapPropertyFailed:{0}, {1}", key, value));
            }

            internal Tuple<int, char> DeleteMax(){
                Tuple<int, char> tup = new Tuple<int, char>(this.pq[0].key, this.pq[0].val);
                this.currentLength--;
                this.Swap(this.currentLength, 0);
                this.Sink();
                this.pq[this.currentLength] = null;
                if (!this.IsMaxHeap()) 
                    throw new Exception("MaxHeapPropertyFailed in deletemax");
                return tup;
            }

            internal Tuple<int, char> PeekMax(){
                Tuple<int, char> tup = new Tuple<int, char>(this.pq[0].key, this.pq[0].val);
                return tup;
            }

            internal void Swim(){
                int n = this.currentLength - 1;
                while(n > 0 && this.pq[(n-1) / 2].key < this.pq[n].key){
                    this.Swap(n, (n-1) / 2);
                    n = (n-1) / 2;
                }
            }

            internal void Sink(){
                int n = 0;
                while (2 * n + 1 < this.currentLength){
                    int largestChildIndex = n * 2 + 1;
                    if (largestChildIndex + 1 < this.currentLength){
                        if (this.pq[largestChildIndex].key < this.pq[largestChildIndex + 1].key)
                            largestChildIndex++;
                    }
                    if (this.pq[n].key < this.pq[largestChildIndex].key){
                        this.Swap(n, largestChildIndex);
                        n = largestChildIndex;
                    }
                    else break;
                }
            }

            internal void Swap(int i, int j){
                Node temp = this.pq[i];
                this.pq[i] = this.pq[j];
                this.pq[j] = temp;
            }

            internal bool IsMaxHeap(){
                int n = 0;
                while(n < this.currentLength){
                    if (2*n+1 < this.currentLength && this.pq[n].key < this.pq[2*n+1].key) return false;
                    if (2*n+2 < this.currentLength && this.pq[n].key < this.pq[2*n+2].key) return false;
                    n++;
                }

                return true;
            }
        }
    }
}