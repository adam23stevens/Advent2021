using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.DayEight
{
    public static class DayEightProgram
    {
        public static string GetPart1Answer()
        {
            var results = FileReader.ReadNumbers();

            var retCnt = 0;
            foreach (var part in results.SecondPart)
            {
                if (part.Length == 2 || part.Length == 4 || part.Length == 3 || part.Length == 7)
                {
                    retCnt++;
                }
            }

            return retCnt.ToString();
        }

        public static string GetPart2Answer()
        {
            var results = FileReader.ReadCodes();
            int ret = 0;

            foreach (var result in results)
            {
                var thisNum = 0;

                var mappings = new List<SegmentMapping>();

                var topRightMap = GetMappingForTopRight(result.Codes);
                mappings.Add(topRightMap);

                var midMap = GetMappingForMid(result.Codes, topRightMap);
                mappings.Add(midMap);

                var leftBottomMap = GetMappingForLeftBottom(result.Codes, topRightMap, midMap);
                mappings.Add(leftBottomMap);

                var bottomRightMap = GetMappingForBottomRight(result.Codes, topRightMap);
                mappings.Add(bottomRightMap);

                var topMap = GetMappingForTop(result.Codes, topRightMap, bottomRightMap);
                mappings.Add(topMap);

                var topLeftMap = GetMappingTopLeft(result.Codes, midMap, topRightMap, bottomRightMap);
                mappings.Add(topLeftMap);

                var bottomMap = GetMappingForBottom(result.Codes, topLeftMap, topMap, topRightMap, leftBottomMap, midMap, bottomRightMap);
                mappings.Add(bottomMap);

                int thousandsCnt = 0;

                foreach (var number in result.Numbers)
                {
                    var numberCracked = FileReader.ReadNumberOnMapping(number, mappings);
                    switch(thousandsCnt)
                    {
                        case 0:
                            thisNum += numberCracked * 1000;
                            break;
                        case 1:
                            thisNum += numberCracked * 100;
                            break;
                        case 2:
                            thisNum += numberCracked * 10;
                            break;
                        case 3:
                            thisNum += numberCracked * 1;
                            break;
                    }
                    thousandsCnt++;                    
                }
                ret += thisNum;
            }

            return ret.ToString();
        }

        private static string eightMap(List<string> codes) => codes.First(x => x.Length == 7);
        private static string sevenMap(List<string> codes) => codes.First(x => x.Length == 3);
        private static string fourMap(List<string> codes) => codes.First(x => x.Length == 4);
        //private static string nineMap(List<string> codes) => codes.First(x => x.Length == 6 && sevenMap(codes).Contains(x));
        //private static string sixMap(List<string> codes) => codes.First(c => c != nineMap(codes) && c.Length == 6);
        private static string oneMap(List<string> codes) => codes.First(c => c.Length == 2);

        private static SegmentMapping GetMappingForLeftBottom(List<string> allCodes, SegmentMapping topRightMap, SegmentMapping midMap)
        {
            var zerosixornine = allCodes.Where(x => x.Length == 6);
            char charCode = ' ';

            foreach (var CCode in eightMap(allCodes))
            {
                if (CCode == topRightMap.SegmentChar || CCode == midMap.SegmentChar) continue;

                var retCode = zerosixornine.FirstOrDefault(x => !x.Contains(CCode));
                if (retCode != null)
                {
                    charCode = CCode;
                }
            }            

            var SegmentMap = new SegmentMapping
            {
                SegmentChar = charCode,
                SegmentMap = Segment.LeftBottom
            };
            return SegmentMap;
        }

        private static SegmentMapping GetMappingForBottom(List<string> allCodes, SegmentMapping leftTop, SegmentMapping top, SegmentMapping topRight, SegmentMapping bottomLeft, SegmentMapping mid, SegmentMapping bottomRight)
        {
            var charCode = eightMap(allCodes).First(x => x != leftTop.SegmentChar && x != top.SegmentChar && x != topRight.SegmentChar && x != bottomLeft.SegmentChar && x != mid.SegmentChar && x != bottomRight.SegmentChar);
            return new SegmentMapping()
            {
                SegmentChar = charCode,
                SegmentMap = Segment.Bottom
            };
        }

        private static SegmentMapping GetMappingForTopRight(List<string> allCodes)
        {
            var sevenCodes = sevenMap(allCodes);
            var zerosixornine = allCodes.Where(x => x.Length == 6);
            char c = ' ';

            foreach(var CCode in sevenCodes)
            {
                var retCode = zerosixornine.FirstOrDefault(x => !x.Contains(CCode));
                if (retCode != null)
                {
                    c = CCode;
                    break;      
                }
                
            }
            
            return new SegmentMapping()
            {
                SegmentChar = c,
                SegmentMap = Segment.RightTop
            };
        }
        private static SegmentMapping GetMappingForMid(List<string> allCodes, SegmentMapping topRight)
        {
            var fourCodes = fourMap(allCodes);
            var zerosixornine = allCodes.Where(x => x.Length == 6);
            char c = ' ';

            foreach (var CCode in fourCodes)
            {
                if (CCode == topRight.SegmentChar) continue;

                var retCode = zerosixornine.FirstOrDefault(x => !x.Contains(CCode));
                if (retCode != null)
                {
                    c = CCode;
                    break;
                }

            }

            return new SegmentMapping()
            {
                SegmentChar = c,
                SegmentMap = Segment.Middle
            };
        }

        private static SegmentMapping GetMappingForBottomRight(List<string> allCodes, SegmentMapping TopRightMapping)
        {
            var charCode = eightMap(allCodes).First(x => x != TopRightMapping.SegmentChar && oneMap(allCodes).Contains(x));

            return new SegmentMapping()
            {
                SegmentChar = charCode,
                SegmentMap = Segment.RightBottom
            };
        }

        private static SegmentMapping GetMappingForTop(List<string> allCodes, SegmentMapping TopRightMapping, SegmentMapping BottomRightMapping)
        {
            var charCode = eightMap(allCodes).First(x => x != TopRightMapping.SegmentChar && x != BottomRightMapping.SegmentChar && sevenMap(allCodes).Contains(x));

            return new SegmentMapping()
            {
                SegmentChar = charCode,
                SegmentMap = Segment.Top
            };
        }

       

        private static SegmentMapping GetMappingTopLeft(List<string> allCodes, SegmentMapping midMap, SegmentMapping topRight, SegmentMapping bottomRight)
        {
            var charCode = eightMap(allCodes).First(x => x != midMap.SegmentChar && x != topRight.SegmentChar && x != bottomRight.SegmentChar && fourMap(allCodes).Contains(x));
            return new SegmentMapping()
            {
                SegmentChar = charCode,
                SegmentMap = Segment.LeftTop
            };
        }
    }
}
