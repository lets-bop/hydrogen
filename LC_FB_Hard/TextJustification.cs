using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    /*
        Given an array of words and a width maxWidth, format the text such that each line has exactly maxWidth characters and is fully 
        (left and right) justified. You should pack your words in a greedy approach; that is, pack as many words as you can in each line. 
        Pad extra spaces ' ' when necessary so that each line has exactly maxWidth characters.

        Extra spaces between words should be distributed as evenly as possible. If the number of spaces on a line do not divide evenly between words, 
        the empty slots on the left will be assigned more spaces than the slots on the right.
        For the last line of text, it should be left justified and no extra space is inserted between words.

        Note:

        A word is defined as a character sequence consisting of non-space characters only.
        Each word's length is guaranteed to be greater than 0 and not exceed maxWidth.
        The input array words contains at least one word.
        Example 1:

        Input:
        words = ["This", "is", "an", "example", "of", "text", "justification."]
        maxWidth = 16
        Output:
        [
        "This    is    an",
        "example  of text",
        "justification.  "
        ]
        Example 2:

        Input:
        words = ["What","must","be","acknowledgment","shall","be"]
        maxWidth = 16
        Output:
        [
        "What   must   be",
        "acknowledgment  ",
        "shall be        "
        ]
        Explanation: Note that the last line is "shall be    " instead of "shall     be",
                    because the last line must be left-justified instead of fully-justified.
                    Note that the second line is also left-justified becase it contains only one word.
        Example 3:

        Input:
        words = ["Science","is","what","we","understand","well","enough","to","explain",
                "to","a","computer.","Art","is","everything","else","we","do"]
        maxWidth = 20
        Output:
        [
        "Science  is  what we",
        "understand      well",
        "enough to explain to",
        "a  computer.  Art is",
        "everything  else  we",
        "do                  "
        ]
    */
    class TextJustification
    {
        public IList<string> FullJustify(string[] words, int maxWidth) {
            int end = 0;
            int i = 0;
            int currentLengthOfWords = 0;
            int minSpacesNeeded = 0; // If there are n words, there needs to be at least n - 1 spaces.
            StringBuilder sb = new StringBuilder();
            IList<string> result = new List<string>();

            while (i < words.Length && end <= words.Length) {
                if (end < words.Length && words[end].Length + currentLengthOfWords + minSpacesNeeded < maxWidth) {
                    // We can add this word to the line
                    currentLengthOfWords += words[end].Length;
                    if (end > i) minSpacesNeeded++;
                    end++;
                } else {
                    // reached the max of words for this iteration
                    if (end - i == 1 || end == i || end == words.Length) { 
                        // Needs to be left justified.
                        int w = i;
                        do {
                            sb.Append(words[w] + " ");
                            w++;
                        } while (w < end);

                        for (int k = sb.Length; k < maxWidth; k++) sb.Append(" ");
                        if (sb.Length > maxWidth) sb.Remove(sb.Length - 1 ,1); // corner case as we are adding a space after each word
                    } else {
                        // needs to be middle justified if needed
                        int spacesNeededInLine = maxWidth - currentLengthOfWords;

                        // see if we can split the spaces evenly between the words.
                        int minSpacesBetweenEachWord =  (spacesNeededInLine / minSpacesNeeded); // add 1 for the regular space

                        // left over spaces will definitely be less than the # of words in the line. 
                        // We need one extra iteration to add in the left over from left to right
                        int leftOverSpaces = spacesNeededInLine - (minSpacesBetweenEachWord * minSpacesNeeded);

                        for (int w = i; w < end; w++) {
                            sb.Append(words[w]);
                            if (w < end - 1)
                                for (int k = 0; k < minSpacesBetweenEachWord; k++) sb.Append(" ");
                            if (leftOverSpaces > 0) {
                                sb.Append(" ");
                                leftOverSpaces--;
                            }
                        }
                    }

                    minSpacesNeeded = 0;
                    currentLengthOfWords = 0;
                    if (i == end) end++;
                    i = end;
                    result.Add(sb.ToString());
                    sb.Clear();
                }
            }

            return result;
        }
    }
}