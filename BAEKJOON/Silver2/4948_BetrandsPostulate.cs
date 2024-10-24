using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparta_CS_Algorithm_Study_2023.Baekjoon.Silver2
{
    internal class BetrandsPostulate
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                int input = int.Parse(Console.ReadLine());

                if (input == 0)
                {
                    Console.WriteLine(sb.ToString());
                    break;
                }

                int count = 0;
                for (int i = input + 1; i <= input * 2; i++)
                {
                    if (IsPrime(i))
                    {
                        count++;
                    }
                }
                sb.Append(count).Append("\n");
            }
        }

        static bool IsPrime(int num)
        {
            if (num == 1)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
