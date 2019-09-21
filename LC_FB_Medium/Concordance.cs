using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Medium
{
    /*
    Given an arbitrary text document, generate an alphabetical order of all word occurrences,
    labeled with word counts and sentence numbers in which each occurrence appeared.
    */
    class Concordance
    {
        public static void GenerateAndPrintConcordance(List<string> inputLines) 
        {
            // We'll use a dictionary to look up if the word has occurred so far.
            // If not, we'll add it to the dictionary, key being the word and the value
            // being a data structure we'll use to track the concordance requirement.
            // We'll take care of sorting requirement at the end, after all words have been procesed.
            Dictionary<string, Node> wordMap = new Dictionary<string, Node>();
            int sentenceCount = 1;
            bool incrementSentence = false;

            foreach (string input in inputLines) {
                string[] words = input.Split(' ');
                
                for (int i = 0; i < words.Length; i++) {
                    string word = words[i].Trim().ToLowerInvariant();
                    if (!string.IsNullOrEmpty(word)) {
                        // count sentences and drop special chars like ',' or '.' or ';'
                        incrementSentence = false;
                        if (!IsShortForm(word) && word[word.Length - 1] == '.') incrementSentence = true;
                        if (!IsShortForm(word) &&  IsSpecialChar(word[word.Length - 1])) {
                            word = word.Substring(0, word.Length - 1);
                        }

                        if (wordMap.ContainsKey(word)) {
                            Node node = wordMap[word];
                            node.Count++;
                            node.Sentences.Add(sentenceCount);
                        } else {
                            wordMap[word] = new Node(word, 1, sentenceCount);
                        }

                        if (incrementSentence) sentenceCount++;
                    }
                }
            }

            // We processed all words. Now we need to sort them
            List<Node> nodes = new List<Node>();
            foreach (var kv in wordMap) nodes.Add(kv.Value);
            nodes.Sort(CompareNodes);

            // output the result
            OutputNodes(nodes);
        }

        internal class Node {
            internal string Word; // the word occurrence
            internal int Count; // the total number of times the word occurred
            internal List<int> Sentences; // the sentences in which the word occurred.
            internal Node(string word, int count, int sentence) {
                this.Word = word;
                this.Count = count;
                this.Sentences = new List<int>() {sentence};
            }
        }

        private static bool IsShortForm(string word) {
            return word.CompareTo("i.e.") == 0;
        }

        private static bool IsSpecialChar(char c) {
            // add more special chars based on requirement.
            if (c == ';' || c == '.'|| c == ','|| c == ':' || c == '?') return true;
            return false;
        }

        private static int CompareNodes(Node n1, Node n2) {
            return n1.Word.CompareTo(n2.Word);
        }

        private static void OutputNodes(List<Node> nodes) {
            if (nodes == null) return;
            StringBuilder sb = new StringBuilder();
            foreach (Node n in nodes) {
                sb.Append(n.Word);
                sb.Append(": {");
                sb.Append(n.Count);
                sb.Append(":");
                for (int i = 0; i < n.Sentences.Count; i++) {
                    if (i > 0) sb.Append(",");
                    sb.Append(n.Sentences[i]);
                }
                sb.Append("}");
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
        }
    }
}