using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.InflearnAlgorithms
{
    internal class PrimeNumberCount
    {
        // [?] 정수 하나를 입력 받아서, 2부터 해당 수까지 존재하는 모든 소수를 찾아서 출력
        static void Main()
        {
            // [1] Input
            var count = 0;
            var sw = true;  // 소수인지 확인하는 스위치 변수(flag)
            var number = 0;
            Console.Write("수 입력: _\b");
            number = Convert.ToInt32(Console.ReadLine());

            // [2] Process
            for (int i = 2; i <= number; i++)
            {
                sw = true;

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        sw = false;
                        break;
                    }
                }

                if (sw)
                {
                    count++;
                    Console.Write($"{i}\t");

                    if (count % 5 == 0)
                    {
                        Console.WriteLine();
                    }
                }
            }

            // [3] Output
            Console.WriteLine($"2부터 {number}까지의 소수의 개수: {count}");
        }
    }
}
