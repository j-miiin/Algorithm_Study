using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class RemoteControl
    {
        static bool[] broken = new bool[10]; 

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());

            if (M != 0)
            {
                string[] str = Console.ReadLine().Split(" ");
                for (int i = 0; i < M; i++)
                {
                    int idx = int.Parse(str[i]);
                    broken[idx] = true;
                }
            }

            int result = Math.Abs(N - 100);

            for (int i = 0; i < 1000000; i++)
            {
                if (GetDirectMoveCount(i) == 0)
                {
                    continue;
                }

                result = Math.Min(result, Math.Abs(i - N) + GetDirectMoveCount(i));
            }

            Console.WriteLine(result);
        }

        static int GetDirectMoveCount(int target)
        {
            int length = 0;

            if (target == 0)
            {
                if (broken[0])
                {
                    return 0;
                } else
                {
                    return 1;
                }
            }

            while (target > 0)
            {
                if (broken[target % 10])
                {
                    return 0;
                }

                length++;
                target /= 10;
            }

            return length;
        }
    }
}
