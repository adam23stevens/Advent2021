using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace AdventOfCode2021.DaySix
{
    public static class DaySixProgram
    {
        public static string GetPart1Answer()
        {
            var answer = GetTotalFish(18);

            return answer.ToString();
        }

        public static string GetPart2Answer()
        {
            var answer = GetTotalFish(256);

            return answer.ToString();
        }

        public static string GetTotalFish(int days)
        {
            var fishLifeSpan = new long[9];
            var fish = FileReader.GetFishNumbers();            

            foreach (var f in fish)
            {
                fishLifeSpan[f]++;
            }
            for (var i = 0; i < days; i++)
            {
                var buffer = new long[9];
                for (var j = 0; j < fishLifeSpan.Length; j++)
                {
                    if (j == 0)
                    {
                        buffer[6] += fishLifeSpan[j];
                        buffer[8] += fishLifeSpan[j];
                    }
                    else
                    {
                        buffer[j - 1] += fishLifeSpan[j];
                    }
                }

                fishLifeSpan = buffer;
            }

            return fishLifeSpan.Sum().ToString();
            

        }      
    }
}
