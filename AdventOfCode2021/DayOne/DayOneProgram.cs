using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.DayOne
{
    public static class DayOneProgram
    {
        public static string GetPart1Answer()
        {
            var allNumbers = FileReader.GetNumbers().ToArray();

            var part1Answer = GetIncreaseCountInArray(allNumbers);

            return part1Answer.ToString();
        }

        public static string GetPart2Answer()
        {
            var numberGroups = FileReader.GetNumberGroups().ToArray();

            var part2Answer = GetIncreaseCountInArray(numberGroups);

            return part2Answer.ToString();
        }

        private static int GetIncreaseCountInArray(int[] numberArray)
        {
            int ret = 0;

            for (int x = 0; x < numberArray.Length - 1; x++)
            {
                if (numberArray[x] < numberArray[x + 1])
                {
                    ret++;
                }
            }

            return ret;
        }
    }
}
