using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.DayThree
{
    public static class DayThreeProgram
    {
        public static string GetPart1Answer()
        {
            var numbers = FileReader.GetNumbers();
            string gammaRate = string.Empty;
            string epsilonRate = string.Empty;
            int cntCeiling = numbers.Count / 2 + 1;
            int figureCnt = numbers[0].ToString().Length;
            
            for (int x = 0; x < figureCnt; x++)
            {
                bool increaseGamma = false;
                int truCnt = 0;

                foreach (var number in numbers)
                {
                    if (number[x] == '1')
                    {
                        truCnt++;
                        if (truCnt >= cntCeiling)
                        {
                            increaseGamma = true;
                            break;
                        }
                    }
                }
                gammaRate += increaseGamma ? "1" : "0";
                epsilonRate += increaseGamma ? "0" : "1";
            }

            var gammaRateInt = Convert.ToInt32(gammaRate, 2);
            var epsilonRateInt = Convert.ToInt32(epsilonRate, 2);

            var answer = gammaRateInt * epsilonRateInt;

            return answer.ToString();
        }

        public static string GetPart2Answer()
        {
            string oxygenRate = GetRate(GasType.Oxygen);
            string c02Rate = GetRate(GasType.C02);

            var oxyDec = Convert.ToInt32(oxygenRate, 2);
            var c02Dec = Convert.ToInt32(c02Rate, 2);

            var answer = oxyDec * c02Dec;
            return answer.ToString();
        }

        private static string GetRate(GasType gasType)
        {
            var numbers = FileReader.GetNumbers();
            var retNumbers = string.Empty;
            
            int figureCnt = numbers[0].ToString().Length;

            for (int x = 0; x < figureCnt; x++)
            {
                bool filterOnes = false;
                int truCnt = 0;
                int cntCeiling = numbers.Count / 2 + (numbers.Count % 2 > 0 ? 1 : 0);

                foreach (var number in numbers)
                {
                    if (number[x] == '1')
                    {
                        truCnt++;
                        if (truCnt >= cntCeiling)
                        {
                            filterOnes = true;
                            break;
                        }
                    }
                }
                if (gasType == GasType.Oxygen)
                {
                    numbers = numbers.Where(num => num[x] == (filterOnes ? '1' : '0')).ToList();
                }
                if (gasType == GasType.C02)
                {
                    numbers = numbers.Where(num => num[x] == (filterOnes ? '0' : '1')).ToList();
                }
                
                if (numbers.Count == 1)
                {
                    retNumbers = numbers.First();
                    break;
                }
            }

            return retNumbers;
        }

        private enum GasType
        {
            Oxygen = 1, C02 = 2
        }
    }
}
