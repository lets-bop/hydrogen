using System;
using System.Collections.Generic;
using System.Text;

namespace LC_FB_Hard
{
    public class CandyProblem
        {
        public int Candy(int[] ratings)
        {
            int sum = 0;
            if (ratings == null || ratings.Length == 0) return 0;

            int[] candies = new int[ratings.Length];
            candies[0] = 1;
            sum += 1;

            for (int i = 1; i < ratings.Length; i++){
                if(ratings[i] > ratings[i - 1])
                     candies[i] = candies[i - 1] + 1;
                else candies[i] = 1;

                sum += candies[i];
            }

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