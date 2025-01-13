using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.InflearnAlgorithms
{
    internal class SumAlgorithm
    {
        static void Main()
        {
            // [1] Input : n명의 국어 점수
            int[] scores = { 100, 75, 50, 37, 90, 95 };
            int sum = 0;

            // [2] Process : 합계 알고리즘 영역
            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] >= 80)
                {
                    sum += scores[i];
                }
            }

            // [3] Output
            Console.WriteLine($"{scores.Length} 명의 점수 중 80점 이상의 총점: {sum}");
        
            // [!] 디버거(디버깅 S/W)를 사용하여 디버깅하기 : F9 -> F5 -> F11 -> F5
        }
    }
}
