using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.DayTen
{
    public static class DayTenProgram
    {
        public static string GetPart1Answer()
        {
            long answer = 0;

            var allLines = FileReader.GetLines();

            for (int x = 0; x < allLines.Length; x++)
            {
                List<char> expectedClosingChars = new List<char>();

                for (int y = 0; y < allLines[x].Length; y++)
                {
                    var thisChar = allLines[x][y];
                    if (IsOpeningTag(thisChar))
                    {
                        //new opening char
                        var thisClosingChar = MatchingTags.First(t => t.Opening == thisChar).Closing;
                        expectedClosingChars.Add(thisClosingChar);

                    }
                    else
                    {
                        //hit closing char
                        if (expectedClosingChars.Last() == thisChar)
                        {
                            expectedClosingChars.RemoveAt(expectedClosingChars.Count - 1);
                        }
                        else
                        {
                            //corrupted!
                            answer += MatchingTags.First(t => t.Closing == thisChar).CorruptedScore;
                            break;
                        }
                    }

                }
            }

            return answer.ToString();
        }

        public static string GetPart2Answer()
        {
            List<long> lineAnswers = new List<long>();

            var allLines = FileReader.GetLines();

            for (int x = 0; x < allLines.Length; x++)
            {
                List<char> expectedClosingChars = new List<char>();

                bool corrupted = false;

                for (int y = 0; y < allLines[x].Length; y++)
                {
                    var thisChar = allLines[x][y];
                    if (IsOpeningTag(thisChar))
                    {
                        //new opening char
                        var thisClosingChar = MatchingTags.First(t => t.Opening == thisChar).Closing;
                        expectedClosingChars.Add(thisClosingChar);
                    }
                    else
                    {
                        //hit closing char
                        if (expectedClosingChars.Last() == thisChar)
                        {
                            expectedClosingChars.RemoveAt(expectedClosingChars.Count - 1);
                        }
                        else
                        {
                            //corrupted!
                            corrupted = true;

                        }
                    }
                }
               
                if (!corrupted)
                {
                    long score = 0;

                    expectedClosingChars.Reverse();

                    foreach (var closingChar in expectedClosingChars)
                    {
                        score *= 5;
                        score += MatchingTags.First(c => c.Closing == closingChar).IncompleteScore;
                    }
                    lineAnswers.Add(score);
                }
            }

            long answer = 0;

            lineAnswers.Sort();
            var split = lineAnswers.Count / 2;
            answer = lineAnswers[split];

            return answer.ToString();
        }

        private static bool IsOpeningTag(char c) => MatchingTags.Any(t => t.Opening == c);

        private static List<Tag> MatchingTags =>
            new List<Tag>() { new Tag() { Opening = '(', Closing = ')', CorruptedScore = 3, IncompleteScore = 1},
                             new Tag() { Opening = '[', Closing = ']', CorruptedScore = 57, IncompleteScore = 2 },
                             new Tag() { Opening = '{', Closing = '}', CorruptedScore = 1197, IncompleteScore = 3},
                             new Tag() { Opening = '<', Closing = '>', CorruptedScore = 25137, IncompleteScore = 4 }
            };

        private class Tag
        {
            public int CorruptedScore { get; set; }
            public int IncompleteScore { get; set; }
            public char Opening { get; set; }
            public char Closing { get; set; }
        }
    }

}
