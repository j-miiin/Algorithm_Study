using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level4
{
    internal class MakeBigNum
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution("1924", 2));
        }

        public class Solution
        {
            public static string solution(string number, int k)
            {
                int idx = -1;
                StringBuilder sb = new StringBuilder();
                while (sb.Length < number.Length - k)
                {
                    int max = -1;
                    int maxIdx = 0;
                    for (int i = idx + 1; i <= k + sb.Length; i++)
                    {
                        Console.WriteLine(number.Length - (k - sb.Length));
                        int curNum = int.Parse(number[i].ToString());
                        if (curNum > max)
                        {
                            max = curNum;
                            maxIdx = i;
                            if (curNum == 9) break;
                        }
                    }

                    sb.Append(max);
                    idx = maxIdx;
                    Console.WriteLine(sb.ToString() + ", " + idx);
                }

                string answer = sb.ToString();
                return answer;
            }
        }
    }
}
