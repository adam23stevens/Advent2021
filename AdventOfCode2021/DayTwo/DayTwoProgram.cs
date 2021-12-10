using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.DayTwo
{
    public static class DayTwoProgram
    {
        public static string GetPartOneAnswer()
        {
            int horizontal = 0;
            int depth = 0;

            foreach(var line in FileReader.ReadLines())
            {
                int num = 0;

                switch(line[0])
                {
                    case 'f':
                        num = getNum("forward", line);
                        horizontal += num;
                        break;
                    case 'u':
                        num = getNum("up", line);
                        depth -= num;                        
                        break;
                    case 'd':
                        num = getNum("down", line);
                        depth += num;
                        break;
                }    
            }

            var part1Answer = horizontal * depth;

            return part1Answer.ToString();
        }

        public static string GetPartTwoAnswer()
        {
            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            foreach(var line in FileReader.ReadLines())
            {
                int num = 0;

                switch(line[0])
                {
                    case 'f':
                        num = getNum("forward", line);
                        horizontal += num;
                        depth += num * aim;
                        break;
                    case 'u':
                        num = getNum("up", line);
                        aim -= num;
                        break;
                    case 'd':
                        num = getNum("down", line);
                        aim += num;
                        break;
                }
            }

            var part2Answer = horizontal * depth;

            return part2Answer.ToString();
        }

        private static int getNum(string direction, string line)
        {
            var num = line.Remove(0, direction.Length + 1);

            return int.Parse(num);
        }
    }
}
