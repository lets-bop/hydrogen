/*
Given a string that contains only digits 0-9 and a target value, return all possibilities to add binary operators (not unary) +, -, or * between the digits so they evaluate to the target value.

Example 1:

Input: num = "123", target = 6
Output: ["1+2+3", "1*2*3"] 
Example 2:

Input: num = "232", target = 8
Output: ["2*3+2", "2+3*2"]
Example 3:

Input: num = "105", target = 5
Output: ["1*0+5","10-5"]
Example 4:

Input: num = "00", target = 0
Output: ["0+0", "0-0", "0*0"]
Example 5:

Input: num = "3456237490", target = 9191
Output: []
*/

using System;
using System.Collections.Generic;
using System.Text;

public class ExpressionAddOperators
{
    public IList<string> AddOperators(string num, int target) {        
    }

    public Dictionary<int, IList<string>> SplitAndProcess(
        string num, 
        int target,
        int start,
        int end)
    {
        Dictionary<int, IList<string>> result = new Dictionary<int, IList<string>>();

        for (int i = start; i < end; i++)
        {
            string partOne = num.Substring(start, i + 1);
            string partTwo = num.Substring(i + 1);
            int partOneNum = int.Parse(partOne);
            int partTwoNum = int.Parse(partTwo);

            int tempCalc = partOneNum + partTwoNum;
            if (result.ContainsKey(tempCalc))
                result[tempCalc].Add(partOne + "+" + partTwo);
        }
    }
}