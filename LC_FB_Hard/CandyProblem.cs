using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    /*
        There are N children standing in a line. Each child is assigned a rating value.
        You are giving candies to these children subjected to the following requirements:

        Each child must have at least one candy.
        Children with a higher rating get more candies than their neighbors.
        What is the minimum candies you must give?

        Example 1:
        Input: [1,0,2]
        Output: 5
        Explanation: You can allocate to the first, second and third child with 2, 1, 2 candies respectively.

        Example 2:
        Input: [1,2,2]
        Output: 4
        Explanation: You can allocate to the first, second and third child with 1, 2, 1 candies respectively.
        The third child gets 1 candy because it satisfies the above two conditions.
    */
    public class CandyProblem
        {
        public int Candy(int[] ratings)
        {
            int sum = 0;
            if (ratings == null || ratings.Length == 0) return 0;

            int[] candies = new int[ratings.Length];
            candies[0] = 1;
            sum += 1;

            // Assign candies to the ascending slopes. 
            // i.e. ranking[i+1] > ranking[i] then candy[i+1] = candy[i] + 1
            // Else default every person to receive 1 candy
            for (int i = 1; i < ratings.Length; i++){
                if(ratings[i] > ratings[i - 1])
                     candies[i] = candies[i - 1] + 1;
                else candies[i] = 1;

                sum += candies[i];
            }

            // assign candies to the descending slopes (reverse order of descending values, becomes ascending)
            // so follow the same ascending logic as earlier
            for (int i = ratings.Length - 1; i >= 1; i--){
                if (ratings[i - 1] > ratings[i] && candies[i - 1] <= candies[i]) {
                    int diff = (candies[i] + 1) - candies[i - 1] ;
                    candies[i - 1] += diff;
                    sum += diff;
                } 
            }


            return sum;
        }
    }
}