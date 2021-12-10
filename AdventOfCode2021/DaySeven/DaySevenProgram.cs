using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.DaySeven
{
    public static class DaySevenProgram
    {
        public static string GetPart1Answer()
        {
            var numbers = FileReader.GetNumbers();

            int cntVal = 0;
            int lastNum = numbers.Last();
            int firstNum = numbers.First();
            for(var x = firstNum; x <= lastNum; x++)                 
            {
                cntVal = GetTotalStepDifferencesP1(numbers, x, cntVal);
            }

            return cntVal.ToString();
        }

        public static string GetPart2Answer()
        {
            var numbers = FileReader.GetNumbers();

            int cntVal = 0;
            int lastNum = numbers.Last();
            int firstNum = numbers.First();
            for (var x = firstNum; x <= lastNum; x++)
            {
                cntVal = GetTotalStepDifferencesP2(numbers, x, cntVal);
            }

            return cntVal.ToString();
        }

        private static int GetTotalStepDifferencesP2(List<int> numbers, int val, int maxVal)
        {
            int stepDiff = 0;
            bool checkMaxSize = maxVal > 0;

            foreach (var number in numbers)
            {
                stepDiff += GetTotalAddOnValue(number, val);

                if (checkMaxSize && stepDiff > maxVal)
                {
                    return maxVal;
                }
            }

            return stepDiff;
        }

        private static int GetTotalAddOnValue(int number, int val)
        {
            int ret = 0;
            int difference = Math.Abs(number - val);
            for(int x = 1; x <= difference; x++)
            {
                ret += x;
            }
            return ret;
        }

        private static int GetTotalStepDifferencesP1(List<int> numbers, int val, int maxVal)
        {
            int stepDiff = 0;
            bool checkMaxSize = maxVal > 0;

            foreach(var number in numbers)
            {
                stepDiff += Math.Abs(number - val);
                if (checkMaxSize && stepDiff > maxVal)
                {
                    return maxVal;
                }
            }

            return stepDiff;
        }
    }
}
