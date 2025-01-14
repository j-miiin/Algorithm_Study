using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.InflearnAlgorithms
{
    internal class PrimeNumber
    {
        /// <summary>
        /// 소수: 자연수 중에서 1과 자기 자신만을 약수로 가지는 자연수
        /// </summary>
        
        // [?] 특정 수를 입력 받아서, 소수인지 아닌지 판별하는 프로그램
        static void Main()
        {
            // [1] Input
            var number = 0;
            Console.Write("수 입력: _\b");
            number = Convert.ToInt32(Console.ReadLine());

            // [2] Process
            var i = 1;
            do
            {
                i = i + 1;

                Console.WriteLine($"{number} % {i} = {number % i}");
            } while (number % i != 0);

            // [3] Output
            if (number == i)
            {
                Console.WriteLine("소수");
            } else
            {
                Console.WriteLine("소수 아님");
            }
        }
    }
}
