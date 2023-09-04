using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.Algorithm_Code_Kata.Level2
{
    internal class GymSuit
    {
        public class Solution
        {
            static void Main(string[] args)
            {
                Console.WriteLine(Solution.solution(5, new int[] { 2, 4 }, new int[] { 1, 3, 5 }));
            }

            public static int solution(int n, int[] lost, int[] reserve)
            {
                int answer = 0;
                int[] suitNum = new int[n + 1];
                Array.Fill(suitNum, 1);

                for (int i = 0; i < reserve.Length; i++) suitNum[reserve[i]]++;

                for (int i = 0; i < lost.Length; i++) suitNum[lost[i]]--;

                for (int i = 1; i < suitNum.Length; i++)
                {
                    Console.WriteLine(suitNum[i]);
                    if (suitNum[i] == 1) continue;
                    else if (suitNum[i] > 1)
                    {
                        if (i > 1 && suitNum[i - 1] == 0)
                        {
                            suitNum[i]--;
                            suitNum[i - 1]++;
                        } else if (i < suitNum.Length - 1 && suitNum[i + 1] == 0)
                        {
                            suitNum[i]--;
                            suitNum[i + 1]++;
                        }
                    }
                }

                foreach (int i in suitNum)
                {
                    if (i > 0) answer++;
                }

                return answer - 1;
            }
        }
    }
}
