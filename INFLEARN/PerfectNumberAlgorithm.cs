using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_CS_Algorithm_Study_2023.InflearnAlgorithms
{
    internal class PerfectNumberAlgorithm
    {
        /// <summary>
        /// 완전수: 자신을 제외한 약수의 합이 자신과 같은 수
        /// </summary>
        
        // [?] 1부터 10000까지의 완전수와 개수를 출력
        static void Main()
        {
            int sum = 0;        // 약수의 합
            int count = 0;      // 완전수의 개수
            int max = 0;        // 가장 큰 약수
            int rem = 0;        // 나머지 값 임시 보관

            for (int i = 1; i <= 10000; i++)
            {
                sum = 0;
                max = i / 2;    // 모든 짝수를 2로 나누면 가장 큰 약수를 구할 수 있음
                for (int j = 1; j <= max; j++)
                {
                    rem = i % j;
                    if (rem == 0)
                    {
                        sum += j;
                    }
                }

                if (i == sum)
                {
                    count++;
                    Console.WriteLine("완전수: {0}", i);
                }
            }

            Console.WriteLine("완전수 개수: {0}", count);
        }
    }
}
