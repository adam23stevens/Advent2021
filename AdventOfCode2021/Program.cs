using System;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent 2021");
            AnswerPrinter.PrintAnswer(1, 1, DayOne.DayOneProgram.GetPart1Answer());
            AnswerPrinter.PrintAnswer(1, 2, DayOne.DayOneProgram.GetPart2Answer());
        }
    }
}
