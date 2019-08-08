using System;
using System.Collections.Generic;

namespace LC_FB_Easy
{
    /*
        You are playing the following Bulls and Cows game with your friend: You write down a number and ask 
        your friend to guess what the number is. Each time your friend makes a guess, you provide a hint 
        that indicates how many digits in said guess match your secret number exactly in both digit and 
        position (called "bulls") and how many digits match the secret number but locate in the wrong 
        position (called "cows"). Your friend will use successive guesses and hints to eventually derive the secret number.

        Write a function to return a hint according to the secret number and friend's guess, use A to 
        indicate the bulls and B to indicate the cows. Please note that both secret number and friend's guess may contain duplicate digits.

        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: 1 bull and 3 cows. The bull is 8, the cows are 0, 1 and 7.

        Example 2:
        Input: secret = "1123", guess = "0111"
        Output: "1A1B"
        Explanation: The 1st 1 in friend's guess is a bull, the 2nd or 3rd 1 is a cow.

        You may assume that the secret number and your friend's guess only contain digits, and their lengths are always equal.
     */
    class BullsAndCows
    {
        public string GetHint(string secret, string guess)
        {
            int cowsCount = 0;
            int bullsCount = 0;

            // Process the secret into a dictionary where the key corresponds to the alphanumeric char
            // and the value is a hashset of the indices where the alphnumeric char was present.
            // We also need to maintain the count of the chars.
            Dictionary<char, int> secretCharCountMap = new Dictionary<char, int>();
            Dictionary<char, int> guessCharCountMap = new Dictionary<char, int>();

            // Lets first calculate the bull characters. While doing so, we will
            // build a char count map. 
            // We are assuming that the length of secret and guess are the same.
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i]) bullsCount++;
                else {
                    int count = secretCharCountMap.GetValueOrDefault(secret[i], 0);
                    secretCharCountMap[secret[i]] = count + 1;

                    count = guessCharCountMap.GetValueOrDefault(guess[i], 0);
                    guessCharCountMap[guess[i]] = count + 1;
                }
            }

            foreach (char c in guessCharCountMap.Keys) {
                int secretCount = secretCharCountMap.GetValueOrDefault(c, 0);
                cowsCount += Math.Min(secretCount, guessCharCountMap[c]);
            }          

            return string.Format("{0}A{1}B", bullsCount, cowsCount);
        }        
    }
}