using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
    /*
        Given a non-empty list of words, return the k most frequent elements.
        Your answer should be sorted by frequency from highest to lowest. 
        If two words have the same frequency, then the word with the lower alphabetical order comes first.

        Example 1:
        Input: ["i", "love", "leetcode", "i", "love", "coding"], k = 2
        Output: ["i", "love"]
        Explanation: "i" and "love" are the two most frequent words.
            Note that "i" comes before "love" due to a lower alphabetical order.

        Example 2:
        Input: ["the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is"], k = 4
        Output: ["the", "is", "sunny", "day"]
        Explanation: "the", "is", "sunny" and "day" are the four most frequent words,
            with the number of occurrence being 4, 3, 2 and 1 respectively.
        Note:
        You may assume k is always valid, 1 ≤ k ≤ number of unique elements.
        Input words contain only lowercase letters.
        Follow up:
        Try to solve it in O(n log k) time and O(n) extra space.
    */
    class TopKFrequent
    {
        public IList<string> TopK(string[] words, int k) {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            List<string> result = new List<string>();

            // To do this is O(n log k) time with O(n) space
            // store the words + their count in a dictionary
            // For each word in the dictionary, add the word to a heap of size k.
            // First k insertions are easy. But once the heap is full, we will need a 
            // find the min element in max heap to compare the new word with that element.
            // FindMin/ExtractMin - If the heap contains n elements,
            // To find min, you only need to search n/2 elements. This is a costly operation O(n/2) time.
            // Hence you will need to consider also maitaining a min heap of the elements in the max heap,
            // so that FindMin can be done in O(1) time.
            // Or use a double ended priority queue or a min-max heap.

            foreach (string w in words) {
                wordCount[w] = wordCount.GetValueOrDefault(w, 0) + 1;
            }

            return result;
        }

        class MinMaxHeap
        {
            class Item
            {
                public string value;
                public int key;

                public Item(int key, string value) {
                    this.key = key;
                    this.value = value;
                }
            }

            Item[] heap;
            int currentHeapSize;
            int maxSize;

            public MinMaxHeap(int k, Dictionary<string, int> wordCount) {
                this.heap = new Item[k];
                this.maxSize = k;
                foreach (var word in wordCount) {

                }
            }

            private void PushUp(string word, int count) {
                if (this.currentHeapSize >= heap.Length) {
                    if (heap[0].key < count || (heap[0].key == count && heap[0].value.CompareTo(word) > 0)) {
                        this.DeleteMin();
                    }
                }

                this.heap[currentHeapSize] = new Item(count, word);
                
                 
            }

            private void DeleteMin() {

            }
        }
    }
}