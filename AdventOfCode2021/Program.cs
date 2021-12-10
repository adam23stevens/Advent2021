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

            AnswerPrinter.PrintAnswer(2, 1, DayTwo.DayTwoProgram.GetPartOneAnswer());
            AnswerPrinter.PrintAnswer(2, 2, DayTwo.DayTwoProgram.GetPartTwoAnswer());

            AnswerPrinter.PrintAnswer(3, 1, DayThree.DayThreeProgram.GetPart1Answer());
            AnswerPrinter.PrintAnswer(3, 2, DayThree.DayThreeProgram.GetPart2Answer());

            AnswerPrinter.PrintAnswer(4, 1, DayFour.DayFourProgram.GetPart1Answer());
            AnswerPrinter.PrintAnswer(4, 2, DayFour.DayFourProgram.GetPart2Answer());

            //Takes AGES!
            //AnswerPrinter.PrintAnswer(5, 1, DayFive.DayFiveProgram.GetPart1Answer());
            //AnswerPrinter.PrintAnswer(5, 2, DayFive.DayFiveProgram.GetPart2Answer());

            AnswerPrinter.PrintAnswer(6, 1, DaySix.DaySixProgram.GetPart1Answer());
            AnswerPrinter.PrintAnswer(6, 2, DaySix.DaySixProgram.GetPart2Answer());

            AnswerPrinter.PrintAnswer(7, 1, DaySeven.DaySevenProgram.GetPart1Answer());
            AnswerPrinter.PrintAnswer(7, 2, DaySeven.DaySevenProgram.GetPart2Answer());

            AnswerPrinter.PrintAnswer(8, 1, DayEight.DayEightProgram.GetPart1Answer());
            AnswerPrinter.PrintAnswer(8, 2, DayEight.DayEightProgram.GetPart2Answer());

            AnswerPrinter.PrintAnswer(9, 1, DayNine.DayNineProgram.GetPart1Answer());
            AnswerPrinter.PrintAnswer(9, 2, DayNine.DayNineProgram.GetPart2Answer());
        }
    }
}
