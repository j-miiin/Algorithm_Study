using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Gold5
{
    internal class AlphaCentauri
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            string[] str;
            for (int i = 0; i < T; i++)
            {
                str = Console.ReadLine().Split(" ");

                int length = int.Parse(str[1]) - int.Parse(str[0]);
                int n = (int)Math.Sqrt(length);
                
                if (n * n == length)
                {
                    sb.Append(2 * n - 1).Append("\n");
                } else if (n * n < length && length <= n * n + n)
                {
                    sb.Append(2 * n).Append("\n");
                } else
                {
                    sb.Append(2 * n + 1).Append("\n");
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
