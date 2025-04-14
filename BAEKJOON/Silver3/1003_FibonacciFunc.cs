using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver3
{
    class FibonacciFunc
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            List<int> testCases = new List<int>();
            int max = 0;

            for (int i = 0; i < T; i++)
            {
                int num = int.Parse(Console.ReadLine());

                testCases.Add(num);

                if (num > max)
                    max = num;
            }

            int[,] result = new int[max + 1, 2];

            result[0, 0] = 1;
            result[0, 1] = 0;

            if (max > 0)
            {
                result[1, 0] = 0;
                result[1, 1] = 1;
            }

            for (int i = 2; i <= max; i++)
            {
                result[i, 0] = result[i - 1, 0] + result[i - 2, 0];
                result[i, 1] = result[i - 1, 1] + result[i - 2, 1];
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < testCases.Count; i++)
            {
                int zero = result[testCases[i], 0];
                int one = result[testCases[i], 1];

                sb.Append(zero).Append(" ").Append(one).Append("\n");
            }

            Console.WriteLine(sb.ToString());   
        }
    }
}
