using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.InflearnAlgorithms
{
    internal class CountAlgorithm
    {
        /// <summary>
        /// 개수 알고리즘: 주어진 범위에 주어진 조건에 해당하는 자료들의 개수
        /// </summary>

        // [?] 1부터 1000까지의 정수 중 13의 배수의 개수
        static void Main()
        {
            // [1] Input
            var numbers = Enumerable.Range(1, 1000).ToArray();
            int count = 0;

            // [2] Process
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 13 == 0)
                {
                    count++;
                }
            }

            // [3] Output
            Console.WriteLine($"1부터 1000까지의 정수 중 13의 배수의 개수: {cou}");
        }
    }
}
