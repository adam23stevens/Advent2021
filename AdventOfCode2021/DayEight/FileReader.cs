using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.DayEight
{
    public static class FileReader
    {

        public static List<string> GetLines()
        {
            const string filePath = @"D:\dev\Advent\2021\AdventOfCode2021\AdventOfCode2021\DayEight\Input08_test2.txt";
            var Lines = new List<string>(System.IO.File.ReadAllLines(filePath));

            return Lines;
        }
        public static DigitResults ReadNumbers()
        {
            const string filePath = @"D:\dev\Advent\2021\AdventOfCode2021\AdventOfCode2021\DayEight\Input08.txt";
            var Lines = new List<string>(System.IO.File.ReadAllLines(filePath));
            var digitResults = new DigitResults();

            foreach (var line in Lines)
            {
                var segments = line.Split(" | ");
                var firstPartStr = segments[0].Split(" ");
                var secondPartStr = segments[1].Split(" ");

                for (int x = 0; x < firstPartStr.Length; x++)
                {
                    digitResults.FirstPart.Add(firstPartStr[x]);
                }
                for (int x = 0; x < secondPartStr.Length; x++)
                {
                    digitResults.SecondPart.Add(secondPartStr[x]);
                }
            }

            return digitResults;
        }

        public static List<LinePairings> ReadCodes()
        {
            const string filePath = @"D:\dev\Advent\2021\AdventOfCode2021\AdventOfCode2021\DayEight\Input08.txt";
            var Lines = new List<string>(System.IO.File.ReadAllLines(filePath));
            var retPairings = new List<LinePairings>();

            foreach (var line in Lines)
            {
                var segments = line.Split(" | ");
                var firstPartStr = segments[0].Split(" ");
                var secondPartStr = segments[1].Split(" ");

                retPairings.Add(new LinePairings() { Codes = firstPartStr.ToList(), Numbers = secondPartStr.ToList() });
            }
            return retPairings;
        }
        private static bool GetSegmentMatch(List<Segment> mappings, List<Segment> matches)
        {
            if (mappings.Count != matches.Count) return false;

            foreach (var map in mappings)
            {
                if (!matches.Contains(map)) return false;
            }         
            

            return true;
        }

        private static List<Segment> SegmentZeroMap => new List<Segment> { Segment.Top, Segment.LeftTop, Segment.RightTop, Segment.LeftBottom, Segment.RightBottom, Segment.Bottom };
        private static List<Segment> SegmentOneMap => new List<Segment>() { Segment.RightTop, Segment.RightBottom };
        private static List<Segment> SegmentTwoMap => new List<Segment>() { Segment.Top, Segment.RightTop, Segment.Middle, Segment.LeftBottom, Segment.Bottom };
        private static List<Segment> SegmentThreeMap => new List<Segment>() { Segment.Top, Segment.RightTop, Segment.Middle, Segment.RightBottom, Segment.Bottom };
        private static List<Segment> SegmentFourMap => new List<Segment>() { Segment.LeftTop, Segment.Middle, Segment.RightTop, Segment.RightBottom };
        private static List<Segment> SegmentFiveMap => new List<Segment>() { Segment.Top, Segment.LeftTop, Segment.Middle, Segment.RightBottom, Segment.Bottom };
        private static List<Segment> SegmentSixMap => new List<Segment>() { Segment.Top, Segment.LeftTop, Segment.Middle, Segment.LeftBottom, Segment.RightBottom, Segment.Bottom };
        private static List<Segment> SegmentSevenMap => new List<Segment>() { Segment.Top, Segment.RightTop, Segment.RightBottom };
        private static List<Segment> SegmentNineMap => new List<Segment>() { Segment.Top, Segment.LeftTop, Segment.RightTop, Segment.Middle, Segment.RightBottom, Segment.Bottom };
        private static List<Segment> AllSegments => new List<Segment>() { Segment.Top, Segment.LeftTop, Segment.RightTop, Segment.Middle, Segment.LeftBottom, Segment.RightBottom, Segment.Bottom };

        public static int ReadNumberOnMapping(string number, List<SegmentMapping> mappings)
        {
            var segmentMaps = new List<Segment>();

            foreach (var numberchar in number)
            {
                var thisMapping = mappings.First(m => m.SegmentChar == numberchar).SegmentMap;
                segmentMaps.Add(thisMapping);
            }            
            if (GetSegmentMatch(segmentMaps, SegmentZeroMap))
            {
                return 0;
            }            
            if (GetSegmentMatch(segmentMaps, SegmentOneMap))
            {
                return 1;
            }
            if (GetSegmentMatch(segmentMaps, SegmentTwoMap))
            {
                return 2;
            }
            if (GetSegmentMatch(segmentMaps, SegmentThreeMap))
            {
                return 3;
            }
            if (GetSegmentMatch(segmentMaps, SegmentFourMap))
            {
                return 4;
            }
            if (GetSegmentMatch(segmentMaps, SegmentFiveMap))
            {
                return 5;
            }
            if (GetSegmentMatch(segmentMaps, SegmentSixMap))
            {
                return 6;
            }
            if (GetSegmentMatch(segmentMaps, SegmentSevenMap))
            {
                return 7;
            }
            if (GetSegmentMatch(segmentMaps, SegmentNineMap))
            {
                return 9;
            }
            else return 8;

        }

    }

    public class LinePairings
    {
        public List<string> Codes { get; set; }
        public List<string> Numbers { get; set; }
    }

    public class DigitResults
    {
        public DigitResults()
        {
            FirstPart = new List<string>();
            SecondPart = new List<string>();
        }
        public List<string> FirstPart { get; set; }
        public List<string> SecondPart { get; set; }
    }

    public class SegmentMapping
    {
        public char SegmentChar { get; set; }
        public Segment SegmentMap { get; set; }
    }
    public enum Segment
    {
        LeftBottom, Bottom, RightTop, RightBottom, Top, Middle, LeftTop
    }

}
