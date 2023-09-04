using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class PaintOver
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.solution(4, 2, new int[] { 3, 4 }));
        }

        public class Solution
        {
            public static int solution(int n, int m, int[] section)
            {
                int answer = 0;

                int start = section[0];
                answer++;
                for (int i = 1; i < section.Length; i++)
                {
                    if (section[i] >= start + m)
                    {
                        start = section[i];
                        answer++;
                    }
                }

                return answer;
            }
        }
    }
}
