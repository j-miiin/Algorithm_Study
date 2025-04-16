using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmStudy.Baekjoon.Silver4
{
    class Coin0
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ");
            int N = int.Parse(str[0]);  
            int K = int.Parse(str[1]);

            int[] coins = new int[N];

            for (int i = 0; i < N; i++)
            {
                coins[i] = int.Parse(Console.ReadLine());
            }

            int count = 0;
            int cur = K;
            int idx = N - 1;

            while (cur > 0)
            {
                if (cur < coins[idx])
                {
                    idx--;
                    continue;
                }

                int c = cur / coins[idx];
                count += c;
                cur -= coins[idx] * c;
            }

            Console.WriteLine(count);
        }
    }
}
