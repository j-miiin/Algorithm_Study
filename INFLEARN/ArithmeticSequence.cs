using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.InflearnAlgorithms
{
    internal class ArithmeticSequence
    {
        /// <summary>
        /// 등차수열: 연속하는 두 수의 차이가 일정한 수열
        /// </summary>

        // [?] 1부터 20까지의 정수 중 홀수의 합을 구하는 프로그램
        static void Main()
        {
            // [1] Input
            var sum = 0;

            // [2] Process
            for (int i = 1; i <= 20; i++)
            {
                if (i % 2 != 0)
                {
                    sum += i;
                    Console.Write("{0, 2} ", i);
                }
            }

            // [3] Output
            Console.WriteLine($"\n1부터 20까지의 홀수의 합: {sum}");
        }
    }
}
